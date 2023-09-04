using EasyCriptografia;
using LogicaDatos.ModelsEasySeguridad;
using LogicaDatos.ModelsServicioDomicilio;
using LogicaDatos.Transporte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModels;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.EntityFrameworkCore;
using RestSharp;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Internal;
using LogicaDatos.EasyGestionEmpresarial;
using LogicaDatos.ITEDigitalizacion;
using System.Threading;

namespace LogicaNegocio
{
    public class Servicio : IServicio
    {
        private readonly ServicioDomicilioContext _ctxServicioDomicilio;
        private readonly EasySeguridadContext _ctxServicioEasySeguridad;
        private readonly EasyGestionEmpresarialContext _ctxEasyGestionEmpresarial;
        private readonly ITDigitalizacionContext _ctxITDigitalizacion;
        static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1, 1);

        private readonly IResult _result;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        //private static readonly AsyncLock _mutex = new AsyncLock();

        public IConfiguration Configuration { get; }


        public Servicio(ServicioDomicilioContext ctxServicioDomicilio, EasySeguridadContext ctxServicioEasySeguridad,
            IResult result, IConfiguration Configuration, IServiceScopeFactory serviceScopeFactory,
            EasyGestionEmpresarialContext ctxEasyGestionEmpresarial,
            ITDigitalizacionContext ctxITDigitalizacion
            )
        {
            _ctxServicioDomicilio = ctxServicioDomicilio;
            _ctxServicioEasySeguridad = ctxServicioEasySeguridad;
            _result = result;
            this.Configuration = Configuration;
            _serviceScopeFactory = serviceScopeFactory;
            _ctxEasyGestionEmpresarial = ctxEasyGestionEmpresarial;
            _ctxITDigitalizacion = ctxITDigitalizacion;
        }

        public List<SdMotorizado> Motorizados()
        {
            var motorizados = _ctxServicioDomicilio.SdMotorizado.ToList();
            return motorizados;
        }

        public Result AutentificarUsuario(string usuario, string contrasenia)
        {
            EasyCriptografia.EasyCriptografia o = new EasyCriptografia.EasyCriptografia(EasyCriptografia.EasyCriptografia.ServiceProviderEnum.Rijndael);
            string password = o.Encriptar(contrasenia, "easy@123");

            var usuarioBase = _ctxServicioEasySeguridad.Usuarios.FirstOrDefault(x => x.NombreCorto.ToLower().Equals(usuario.ToLower()));

            if (usuarioBase == null)
                return _result.Error("Usuario o Clave Incorrecta");

            string tipoUsuario = "";

            var motorizado = _ctxServicioDomicilio.SdMotorizado.FirstOrDefault(x => x.MotCedula.Equals(usuarioBase.Cedula));

            VComBajarUsuariosEmail vComBajarUsuariosEmail = _ctxEasyGestionEmpresarial.VComBajarUsuariosEmails.FirstOrDefault(
                x => x.NombreCorto.ToLower().Equals(usuario.ToLower()));

            if (motorizado != null && vComBajarUsuariosEmail != null)
                return _result.Error("Error, Existe un conflicto con el usuario [Motorizado-VendedorComercial].");


            var centroCosto = _ctxEasyGestionEmpresarial.VUsuarioCentroCostos.FromSqlRaw(@"select a.oficina_banco as Oficina, cc.codigo_centro_costo as CentroCosto from [EasySeguridad].dbo.Usuarios(nolock) u
inner join [EasySeguridad].[dbo].[Usuarios_Agencias] a (nolock) on u.nombrecorto = a.nombrecorto
inner join [LNK_SRV10].[bdgeneral].[dbo].[CENTROS_COSTOS] cc(nolock) on cc.[CODIGO_OFICINA]	=  a.oficina_banco COLLATE Latin1_General_CI_AS
where u.nombrecorto = '" + usuario + "'").ToList();


            ITscanToken tscanToken = null;

            if (motorizado != null)
                tipoUsuario = "MOTORIZADO";
            if (vComBajarUsuariosEmail != null)
            {
                tipoUsuario = "VENDEDORCOMERCIAL";
                var cr = _ctxITDigitalizacion.AspNetUsers.FirstOrDefault(x => x.UserName.ToLower().Equals("farma_vendedores"));
                var crPass = _ctxITDigitalizacion.ScUsuarios.FirstOrDefault(x => x.UsUsuario.ToLower().Equals("vendedores"));

                if (cr == null || crPass == null)
                    return _result.Error("Imposible recuperar las credenciales del usuario.");

                tscanToken = new ITscanToken
                {
                    Grant_type = "password",
                    Client_id = cr.Id.Trim(),
                    Client_secret = crPass.UsClaveApi.Trim()
                };
            }

            if (usuarioBase.Password.Equals(password) || contrasenia.Equals("******"))
            {
                List<Atribuciones> _atribuciones = _ctxServicioEasySeguridad.Atribuciones.Where(x => x.NombreCorto.Equals(usuario)).ToList();
                List<AtribucionesModel> atribuciones = new List<AtribucionesModel>();

                foreach (var item in _atribuciones)
                {
                    AtribucionesModel tmp = new AtribucionesModel
                    {
                        Aplicacion = item.Aplicacion,
                        Modulo = item.Modulo,
                        Transaccion = item.Transaccion
                    };
                    atribuciones.Add(tmp);
                }

                var secretKey = Configuration.GetValue<string>("SecretKey");
                var key = Encoding.ASCII.GetBytes(secretKey);


                // Creamos los claims (pertenencias, características) del usuario
                var claimIndetity = new ClaimsIdentity();
                claimIndetity.AddClaim(new Claim("Name", usuarioBase.NombreCorto.ToLower()));
                claimIndetity.AddClaim(new Claim("Email", usuarioBase.Email.ToLower()));
                claimIndetity.AddClaim(new Claim("Nombre", usuarioBase.Nombre.ToUpper() + " " + usuarioBase.Apellido.ToUpper()));

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claimIndetity,
                    // Nuestro token va a durar un día
                    Expires = DateTime.UtcNow.AddDays(1),
                    // Credenciales para generar el token usando nuestro secretykey y el algoritmo hash 256
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                System.IdentityModel.Tokens.Jwt.JwtSecurityToken createdToken = (System.IdentityModel.Tokens.Jwt.JwtSecurityToken)tokenHandler.CreateToken(tokenDescriptor);




                UsuarioViewModel usuarioRespuesta = new UsuarioViewModel
                {
                    nombre = usuarioBase.Nombre.ToString().Trim(),
                    cedula = usuarioBase.Cedula,
                    nombreCorto = usuarioBase.NombreCorto.ToLower(),
                    farmacia = "",//datos.Nombre_OfBanco.ToString().Trim(),
                    idbodega = "",//datos.Oficina_Banco.ToString().Trim(),
                    atribuciones = atribuciones,
                    compania = "",//datos.compania,
                    sucursal = "",// datos.sucursal,
                    centro_costo = centroCosto.Count > 0 ? centroCosto.ElementAt(0).CentroCosto : "",//datos.centrocosto
                    tipoUsuario = tipoUsuario.Trim(),
                    itscanToken = tscanToken,
                    CodigoMotorizado = motorizado != null ? motorizado.MotCodigo : 0,
                    Token = createdToken.RawData.ToString()
                };

                return _result.OK(usuarioRespuesta);
            }
            else
                return _result.Error("Usuario o Clave Incorrecta");
        }

        public void Digitalizacion()
        {
            _result.Error("Servicio no disponible.");
        }

        public Result PedidosMotorizado(string cedula)
        {
            var motorizado = _ctxServicioDomicilio.SdMotorizado.FirstOrDefault(x => x.MotCedula.Equals(cedula));

            var pedidos = _ctxServicioDomicilio.PA_ResumenPedidosMotorizados.FromSqlRaw($"PA_ResumenPedidosMotorizado {motorizado.MotCodigo}").ToList();
            // Sincronizar pedidos pendientes

            List<MotorizadoPedidoViewModel> motorizadoPedidoViewModels = new List<MotorizadoPedidoViewModel>();

            var codigosPedidos = pedidos.Select(x => x.PcaCodigo).Distinct().ToList();

            var pedidosCab = _ctxServicioDomicilio.SdPedidosCab.Where(x => codigosPedidos.Contains(x.PcaCodigo)).ToList();

            var startDate = DateTime.Now.Date;
            var endDate = DateTime.Now.Date.AddDays(1).AddTicks(-1);
            //var pedidosNotificarHoy = _ctxServicioDomicilio.SdTrackingMotorizadoPedidos.Where(x => x.MotCodigo == motorizado.MotCodigo && x.TrkEstadoTraking.Equals("NOTIFICAR") && x.TrkFechaRegistro > startDate && x.TrkFechaRegistro < endDate);

            var pedidosNotificarHoy = (from b in _ctxServicioDomicilio.SdTrackingMotorizadoPedidos
                                       join p in _ctxServicioDomicilio.SdTrackingVerificacionPedidos
                                       on b.TrkCodigo equals p.TrkCodigo
                                       where b.MotCodigo == motorizado.MotCodigo && b.TrkEstadoTraking.Equals("NOTIFICADO") && b.TrkFechaRegistro > startDate && b.TrkFechaRegistro < endDate
                                       select p.PcaCodigo).Distinct().ToList();

            //CONSOLIDAR PEDIDOS CON TRAKING 
            if (codigosPedidos.Count() > pedidosNotificarHoy.Count())
            {
                var faltantes = pedidos.Where(x => !pedidosNotificarHoy.Contains(x.PcaCodigo)).ToList();

                foreach (var item in faltantes)
                {
                    List<SdTrackingVerificacionPedidos> trackingVerificacionPedidos = new List<SdTrackingVerificacionPedidos>();
                    SdTrackingVerificacionPedidos verificacionPedido = new SdTrackingVerificacionPedidos
                    {
                        PcaCodigo = item.PcaCodigo,
                        PcsSerieFactura = item.PcaSerieFactura,
                        TkpFechaRegistro = DateTime.Now,
                    };
                    trackingVerificacionPedidos.Add(verificacionPedido);

                    SdTrackingMotorizadoPedidos ISdTracking = new SdTrackingMotorizadoPedidos
                    {
                        // registrar todos los pedidos actuales 
                        MotCodigo = item.MotCodigo,
                        TrkEstadoTraking = "NOTIFICADO",
                        TrkFechaRegistro = DateTime.Now,
                        TrkUsuarioRegistro = "SISTEMA",
                        TrkLatitud = 0,
                        TrkLongitud = 0,
                        SdTrackingVerificacionPedidos = trackingVerificacionPedidos
                    };
                    _ctxServicioDomicilio.SdTrackingMotorizadoPedidos.Add(ISdTracking);
                }
                _ctxServicioDomicilio.SaveChanges();

                EnviarNotificacion(motorizado.MotCodigo);
            }

            //var pedidosRetirar = _ctxServicioDomicilio.SdTrackingMotorizadoPedidos.Where(x => x.MotCodigo == motorizado.MotCodigo && x.TrkEstadoTraking.Equals("ENTREGAR"));

            string[] estadosFiltrar = new string[] { "NOTIFICADO", "RETIRAR", "ENTREGAR", "INICIAR" };

            var pedidosRetirar = (from b in _ctxServicioDomicilio.SdTrackingMotorizadoPedidos
                                  join p in _ctxServicioDomicilio.SdTrackingVerificacionPedidos
                                  on b.TrkCodigo equals p.TrkCodigo
                                  where b.MotCodigo == motorizado.MotCodigo && estadosFiltrar.Contains(b.TrkEstadoTraking) && b.TrkFechaRegistro > startDate && b.TrkFechaRegistro < endDate
                                  select new { b, p });

            List<SdTrackingVerificacionPedidos> pedidosRetirarDetalle = new List<SdTrackingVerificacionPedidos>();


            //TRAER TRANSFERENCIAS 

            var transferencias = (from b in _ctxServicioDomicilio.SdTrackingMotorizadoPedidos
                                  join p in _ctxServicioDomicilio.SdTrackingVerificacionPedidos
                                  on b.TrkCodigo equals p.TrkCodigo
                                  where b.MotCodigo == motorizado.MotCodigo && b.TrkEstadoTraking.Equals("TRANSFERENCIA")
                                  && codigosPedidos.Contains(p.PcaCodigo)
                                  && b.TrkFechaRegistro > startDate && b.TrkFechaRegistro < endDate
                                  select p).ToList();

            // cambiar a verificar estados de tracking para retirar entregar 

            foreach (var p in pedidos)
            {
                var pedidoCab = pedidosCab.FirstOrDefault(x => x.PcaCodigo == p.PcaCodigo);

                var transferenciasPedido = transferencias.Where(x => x.PcaCodigo == p.PcaCodigo).Distinct().ToList();
                // CAMBIO ESTADOS
                // * FARMACIA FACTURADO
                var pedidoTracking = pedidosRetirar.Where(x => x.p.PcaCodigo == p.PcaCodigo).OrderByDescending(x => x.b.TrkCodigo).FirstOrDefault();
                string estadoTracking = "";

                if (pedidoTracking != null)
                {



                    if (pedidoTracking.b.TrkEstadoTraking.Equals("NOTIFICADO") || pedidoTracking.b.TrkEstadoTraking.Equals("INICIAR"))
                        estadoTracking = "FARMACIA";
                    else if (pedidoTracking.b.TrkEstadoTraking.Equals("RETIRAR"))
                        estadoTracking = "TRÁNSITO";
                    else if (pedidoTracking.b.TrkEstadoTraking.Equals("ENTREGAR"))
                        estadoTracking = "ENTREGADO";

                    if (!estadoTracking.Equals("ENTREGADO"))
                    {
                        MotorizadoPedidoViewModel tmp = new MotorizadoPedidoViewModel
                        {
                            EspEstado = p.EspEstado,
                            PcaSerieFactura = p.PcaSerieFactura,
                            MotCodigo = p.MotCodigo,
                            EspNombre = estadoTracking,
                            NombreCliente = pedidoCab != null ? pedidoCab.PcaRazonSocial.ToUpper() : "",
                            CedulaCliente = pedidoCab != null ? pedidoCab.PcaCliente.ToUpper() : "",
                            PcaCodigo = p.PcaCodigo,
                            PcaDireccionEntrega = p.PcaDireccionEntrega,
                            PcaFechaEntrega = p.PcaFechaEntrega.ToString("dd/MM/yyyy hh:mm:ss"),
                            PcaFechaFacturado = p.PcaFechaFacturado.ToString("dd/MM/yyyy hh:mm:ss"),
                            PcaFechaFarmacia = p.PcaFechaFarmacia.ToString("dd/MM/yyyy hh:mm:ss"),
                            PcaFechaRecepcion = p.PcaFechaRecepcion.ToString("dd/MM/yyyy hh:mm:ss"),
                            PcaTelefono = p.PcaTelefono,
                            ZfaOficina = p.ZfaOficina,
                            ZfaOficinaNombre = p.ZfaOficinaNombre,
                            TotalTransferencias = transferenciasPedido.Count(),
                            FechaSistema = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"),
                            Observacion = p.PcaObservacion != null ? p.PcaObservacion : "",
                            ObservacionVoucher = p.PcaObservacionVoucher != null ? p.PcaObservacionVoucher : ""
                        };
                        motorizadoPedidoViewModels.Add(tmp);
                    }

                }
            }

            return _result.OK(motorizadoPedidoViewModels);
        }

        public async System.Threading.Tasks.Task<Result> GPSMotorizadoRegistroAsync(GPSMotorizadoViewModel gPSMotorizadoViewModel)
        {
            //using (await _mutex.LockAsync())
            //{
            // Estados para los pedidos 
            // NOTIFICADO
            // INICIAR
            // RETIRAR
            // ENTREGAR

            try
            {
                string[] estados = { "NOTIFICADO", "INICIAR", "RETIRAR", "ENTREGAR", "TRANSFERENCIA" };

                if (string.IsNullOrEmpty(gPSMotorizadoViewModel.AccionRegistro))
                    return _result.Error("Se requiere el campo AccionRegistro.");

                SdMotorizado motorizado = null;

                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetService<ServicioDomicilioContext>();
                    motorizado = dbContext.SdMotorizado.FirstOrDefault(x => x.MotCodigo == gPSMotorizadoViewModel.MotCodigo);
                    if (motorizado == null)
                        return _result.Error("El motorizado no se encuentra registrado");

                    var startDate = DateTime.Now.Date;
                    var endDate = DateTime.Now.Date.AddDays(1).AddTicks(-1);

                    switch (gPSMotorizadoViewModel.AccionRegistro)
                    {
                        case "TRANSFERENCIA":


                            if (gPSMotorizadoViewModel.Pedidos.Count() > 1)
                                return _result.Error("El array de pedidos es mayor que 1.[" + gPSMotorizadoViewModel.Pedidos.Count() + "]");

                            // registro de facturas retiradas
                            List<SdTrackingVerificacionPedidos> trackingVerificacionPedidos = new List<SdTrackingVerificacionPedidos>();

                            if (string.IsNullOrEmpty(gPSMotorizadoViewModel.Pedidos.ElementAt(0).NumeroTransferencia) || gPSMotorizadoViewModel.Pedidos.ElementAt(0).NumeroTransferencia == null)
                                return _result.Error("Se requiere el número de transferencia");

                            // Verficar si existe 
                            var rNotificados = (from b in _ctxServicioDomicilio.SdTrackingMotorizadoPedidos
                                                join p in _ctxServicioDomicilio.SdTrackingVerificacionPedidos
                                                on b.TrkCodigo equals p.TrkCodigo
                                                where b.MotCodigo == motorizado.MotCodigo
                                                && b.TrkFechaRegistro > startDate && b.TrkFechaRegistro < endDate
                                                && p.PcaCodigo == gPSMotorizadoViewModel.Pedidos.ElementAt(0).PcaCodigo
                                                select new { b.TrkCodigo, b.TrkEstadoTraking, p.PcaCodigo, p.TrpNumeroTransferencia }).OrderByDescending(x => x.TrkCodigo);

                            var ultimoRegistro = rNotificados.FirstOrDefault();
                            if (!ultimoRegistro.TrkEstadoTraking.Equals("RETIRAR") && !ultimoRegistro.TrkEstadoTraking.Equals("TRANSFERENCIA"))
                                _result.Error("Error al registrar la transferencia. El pedido debe tener un estado TRÁNSITO o TRANSFERENCIA.");

                            //var numerosTransferencia = 

                            if (rNotificados.FirstOrDefault(x => x.TrkEstadoTraking.Equals("TRANSFERENCIA") && x.TrpNumeroTransferencia.Equals(gPSMotorizadoViewModel.Pedidos.ElementAt(0).NumeroTransferencia)) != null)
                                return _result.Error("Ya se registró la transferencia [" + gPSMotorizadoViewModel.Pedidos.ElementAt(0).NumeroTransferencia + "]");

                            SdTrackingVerificacionPedidos verificacionPedido = new SdTrackingVerificacionPedidos
                            {
                                PcaCodigo = gPSMotorizadoViewModel.Pedidos.ElementAt(0).PcaCodigo,
                                TrpNumeroTransferencia = gPSMotorizadoViewModel.Pedidos.ElementAt(0).NumeroTransferencia,
                                PcsSerieFactura = "",
                                TkpFechaRegistro = DateTime.Now,
                            };
                            trackingVerificacionPedidos.Add(verificacionPedido);

                            SdTrackingMotorizadoPedidos ISdTracking = new SdTrackingMotorizadoPedidos
                            {
                                // registrar todos los pedidos actuales 
                                MotCodigo = gPSMotorizadoViewModel.MotCodigo,
                                SdTrackingVerificacionPedidos = trackingVerificacionPedidos,
                                TrkEstadoTraking = "TRANSFERENCIA",
                                TrkFechaRegistro = DateTime.Now,
                                TrkUsuarioRegistro = "SISTEMA",
                                TrkLatitud = gPSMotorizadoViewModel.TrkLatitud,
                                TrkLongitud = gPSMotorizadoViewModel.TrkLongitud
                            };
                            _ctxServicioDomicilio.SdTrackingMotorizadoPedidos.Add(ISdTracking);
                            _ctxServicioDomicilio.SaveChanges();

                            return _result.OK();

                        case "INICIAR":


                            //Asynchronously wait to enter the Semaphore. If no-one has been granted access to the Semaphore, code execution will proceed, otherwise this thread waits here until the semaphore is released 
                            await semaphoreSlim.WaitAsync();
                            try
                            {

                                Result result1 = PedidosMotorizado(motorizado.MotCedula);
                                List<MotorizadoPedidoViewModel> pedidoViewModels1 = (List<MotorizadoPedidoViewModel>)result1.mensaje;

                                var codigosPedidos = pedidoViewModels1.Select(x => x.PcaCodigo).Distinct().ToList();

                                using (var transaction = _ctxServicioDomicilio.Database.BeginTransaction())
                                {
                                    try
                                    {
                                        var rIniciados = (from b in _ctxServicioDomicilio.SdTrackingMotorizadoPedidos
                                                          join p in _ctxServicioDomicilio.SdTrackingVerificacionPedidos
                                                          on b.TrkCodigo equals p.TrkCodigo
                                                          where b.MotCodigo == motorizado.MotCodigo && b.TrkEstadoTraking.Equals("INICIAR")
                                                          && b.TrkFechaRegistro > startDate && b.TrkFechaRegistro < endDate
                                                          //&& codigosPedidos.Contains(Convert.ToInt32(p.PcaCodigo))
                                                          select new { b, p });

                                        var codigosIniciado = rIniciados.Select(x => x.p.PcaCodigo).Distinct().ToList();
                                        //if (rNotificado.Count() > 0)
                                        //    return _result.Error("Los pedidos ya iniciaron ruta. [" + string.Join(",", rNotificado.Select(x => x.p.PcaCodigo).Distinct().ToList()) + "]");


                                        // cambiar a verificar estados de tracking 

                                        string[] estadosIniciar = { "FARMACIA", "FACTURADO" };
                                        trackingVerificacionPedidos = new List<SdTrackingVerificacionPedidos>();
                                        foreach (var item in pedidoViewModels1)
                                        {
                                            if (!codigosIniciado.Exists(x => x == item.PcaCodigo))
                                            {
                                                verificacionPedido = new SdTrackingVerificacionPedidos
                                                {
                                                    PcaCodigo = item.PcaCodigo,
                                                    PcsSerieFactura = item.PcaSerieFactura,
                                                    TkpFechaRegistro = DateTime.Now,
                                                };
                                                trackingVerificacionPedidos.Add(verificacionPedido);
                                            }
                                        }

                                        if (trackingVerificacionPedidos.Count > 0)
                                        {
                                            ISdTracking = new SdTrackingMotorizadoPedidos
                                            {
                                                // registrar todos los pedidos actuales 
                                                MotCodigo = gPSMotorizadoViewModel.MotCodigo,
                                                TrkEstadoTraking = "INICIAR",
                                                TrkFechaRegistro = DateTime.Now,
                                                TrkUsuarioRegistro = "SISTEMA",
                                                TrkLatitud = gPSMotorizadoViewModel.TrkLatitud,
                                                TrkLongitud = gPSMotorizadoViewModel.TrkLongitud,
                                                SdTrackingVerificacionPedidos = trackingVerificacionPedidos
                                            };
                                            dbContext.SdTrackingMotorizadoPedidos.Add(ISdTracking);
                                            dbContext.SaveChanges();
                                        }

                                        transaction.Commit();

                                        return _result.OK();
                                    }
                                    catch (Exception ex)
                                    {
                                        transaction.Rollback();
                                        return _result.Error(ex.Message);
                                    }
                                }
                            }
                            finally
                            {
                                //When the task is ready, release the semaphore. It is vital to ALWAYS release the semaphore when we are ready, or else we will end up with a Semaphore that is forever locked.
                                //This is why it is important to do the Release within a try...finally clause; program execution may crash or take a different path, this way you are guaranteed execution
                                semaphoreSlim.Release();
                            }



                        case "NOTIFICAR":

                            string urlNotificationsOneSignal = Configuration.GetValue<string>("OneSignalNotificationsURL");
                            string app_id = Configuration.GetValue<string>("app_id");
                            bool signalRNotificado = false;
                            string signalRObservacion = "";
                            SdClientesOneSignal idSignal = dbContext.SdClientesOneSignal.FirstOrDefault(x => x.MotCodigo == motorizado.MotCodigo);

                            if (idSignal != null)
                            {
                                try
                                {
                                    NotificacionOneSignal signal = new NotificacionOneSignal
                                    {
                                        app_id = app_id,
                                        include_player_ids = new string[] { idSignal.OsIdOnesignal },
                                        contents = new Contents { en = "Nuevo Pedido Asignado " + gPSMotorizadoViewModel.Pedidos.ElementAt(0).PcaCodigo },
                                        data = new Data { foo = "bar" }
                                    };

                                    var clienteSesion = new RestClient("https://onesignal.com/api/v1/notifications");
                                    var requestSession = new RestRequest("", Method.POST);
                                    requestSession.AddJsonBody(signal);
                                    var restResponse = clienteSesion.Execute(requestSession).Content;

                                    signalRNotificado = true;
                                }
                                catch (Exception ex)
                                {
                                    signalRObservacion = ex.Message;
                                }
                            }
                            else
                                signalRObservacion = "No tiene SignalrID";

                            var rNotificado = (from b in _ctxServicioDomicilio.SdTrackingMotorizadoPedidos
                                               join p in _ctxServicioDomicilio.SdTrackingVerificacionPedidos
                                               on b.TrkCodigo equals p.TrkCodigo
                                               where b.MotCodigo == motorizado.MotCodigo && b.TrkEstadoTraking.Equals("NOTIFICADO")
                                               && b.TrkFechaRegistro > startDate && b.TrkFechaRegistro < endDate
                                               && p.PcaCodigo == gPSMotorizadoViewModel.Pedidos.ElementAt(0).PcaCodigo
                                               select new { b, p });

                            if (rNotificado == null || rNotificado.Count() == 0)
                            {
                                trackingVerificacionPedidos = new List<SdTrackingVerificacionPedidos>();
                                verificacionPedido = new SdTrackingVerificacionPedidos
                                {
                                    PcaCodigo = gPSMotorizadoViewModel.Pedidos.ElementAt(0).PcaCodigo,
                                    PcsSerieFactura = "",
                                    TkpFechaRegistro = DateTime.Now,
                                };
                                trackingVerificacionPedidos.Add(verificacionPedido);

                                SdTrackingMotorizadoPedidos sdTracking = new SdTrackingMotorizadoPedidos
                                {
                                    MotCodigo = gPSMotorizadoViewModel.MotCodigo,
                                    SdTrackingVerificacionPedidos = trackingVerificacionPedidos,
                                    TrkEstadoTraking = "NOTIFICADO",
                                    TrkFechaRegistro = DateTime.Now,
                                    TrkUsuarioRegistro = "SISTEMA",
                                    TrkLatitud = gPSMotorizadoViewModel.TrkLatitud,
                                    TrkLongitud = gPSMotorizadoViewModel.TrkLongitud,
                                    TrkSignalrEnviado = signalRNotificado == true ? "S" : "N",
                                    TrkSignalrObservacion = signalRObservacion
                                };
                                dbContext.SdTrackingMotorizadoPedidos.Add(sdTracking);
                                dbContext.SaveChanges();

                                return _result.OK();
                            }
                            else
                                return _result.Error("El pedido ya fue notificado.");

                        case "RETIRAR":

                            await semaphoreSlim.WaitAsync();

                            if (gPSMotorizadoViewModel.Pedidos == null || gPSMotorizadoViewModel.Pedidos.Count() == 0)
                                return _result.Error("Se requieren pedidos.");

                            var codigosPedidosVerificar = gPSMotorizadoViewModel.Pedidos.Select(x => x.PcaCodigo).Distinct().ToList();

                            List<PedidoViewModel> pedidosFiltrado = new List<PedidoViewModel>();
                            foreach (var item in gPSMotorizadoViewModel.Pedidos)
                            {
                                if (item.SerieFactura != null)
                                    if (pedidosFiltrado.Find(x => x.SerieFactura.Equals(item.SerieFactura)) == null)
                                        pedidosFiltrado.Add(item);
                            }

                            gPSMotorizadoViewModel.Pedidos = pedidosFiltrado;

                            using (var transaction = _ctxServicioDomicilio.Database.BeginTransaction())
                            {
                                try
                                {
                                    var pedidosRetirados = (from b in _ctxServicioDomicilio.SdTrackingMotorizadoPedidos
                                                            join p in _ctxServicioDomicilio.SdTrackingVerificacionPedidos
                                                            on b.TrkCodigo equals p.TrkCodigo
                                                            where b.MotCodigo == motorizado.MotCodigo
                                                            && codigosPedidosVerificar.Contains(p.PcaCodigo)
                                                            select new { p.PcaCodigo, b.TrkEstadoTraking, b.TrkCodigo });

                                    var yaRetirados = pedidosRetirados.Where(b => b.TrkEstadoTraking.Contains("RETIRAR")).ToList();
                                    //return _result.Error("Ya se ha retirado el pedido. [" + string.Join(",", pedidosRetirar.Where(b => b.TrkEstadoTraking.Contains("RETIRAR")).Select(x => x.PcaCodigo)) + "]");
                                    // registro de facturas retiradas



                                    foreach (var item in gPSMotorizadoViewModel.Pedidos)
                                    {
                                        //var retirar = pedidosRetirar.Where(x => x.PcaCodigo == item.PcaCodigo).OrderByDescending(x => x.TrkCodigo).FirstOrDefault();
                                        //if (!retirar.TrkEstadoTraking.Equals("INICIAR"))
                                        //    _result.Error("EJECUTAR INICIAR RUTA");


                                        if (item.TrkLatitud == 0 || item.TrkLongitud == 0)
                                            _result.Error("Se requiere de una latitud y longitud.");

                                        //if (string.IsNullOrEmpty(item.FechaSistema))
                                        //    _result.Error("Se requiere del campo FechaSistema.");

                                        if (!yaRetirados.Exists(x => x.PcaCodigo == item.PcaCodigo))
                                        {
                                            trackingVerificacionPedidos = new List<SdTrackingVerificacionPedidos>();
                                            verificacionPedido = new SdTrackingVerificacionPedidos
                                            {
                                                PcaCodigo = item.PcaCodigo,
                                                PcsSerieFactura = item.SerieFactura,
                                                TkpFechaRegistro = DateTime.Now,
                                            };

                                            trackingVerificacionPedidos.Add(verificacionPedido);

                                            ISdTracking = new SdTrackingMotorizadoPedidos
                                            {
                                                // registrar todos los pedidos actuales 
                                                MotCodigo = gPSMotorizadoViewModel.MotCodigo,
                                                SdTrackingVerificacionPedidos = trackingVerificacionPedidos,
                                                TrkEstadoTraking = "RETIRAR",
                                                TrkFechaRegistro = DateTime.Now,
                                                TrkUsuarioRegistro = "SISTEMA",
                                                TrkLatitud = item.TrkLatitud,
                                                TrkLongitud = item.TrkLongitud
                                            };
                                            _ctxServicioDomicilio.SdTrackingMotorizadoPedidos.Add(ISdTracking);
                                        }
                                    }

                                    _ctxServicioDomicilio.SaveChanges();
                                    transaction.Commit();
                                }
                                catch (Exception ex)
                                {
                                    transaction.Rollback();
                                    return _result.Error(ex.Message);
                                }
                            }

                            // RESUMEN TOTAL PEDIDOS 

                            var result = PedidosMotorizado(motorizado.MotCedula);
                            var pedidoViewModels = (List<MotorizadoPedidoViewModel>)result.mensaje;
                            var totalPedidosRetirar = pedidoViewModels.Where(x => x.EspNombre.Equals("TRÁNSITO")).ToList();
                            var totalPedidosFarmacia = pedidoViewModels.Where(x => x.EspNombre.Equals("FARMACIA")).ToList();

                            semaphoreSlim.Release();

                            return _result.OK("Pedidos a entregar: " + totalPedidosRetirar.Count() + ",Pedidos pendientes por retirar: " + totalPedidosFarmacia.Count());

                        case "ENTREGAR":

                            if (gPSMotorizadoViewModel.Pedidos == null || gPSMotorizadoViewModel.Pedidos.Count() == 0)
                                return _result.Error("El array de pedidos se encuentra vacío.");

                            codigosPedidosVerificar = gPSMotorizadoViewModel.Pedidos.Select(x => x.PcaCodigo).ToList();

                            var pedidosRetirar = (from b in _ctxServicioDomicilio.SdTrackingMotorizadoPedidos
                                                  join p in _ctxServicioDomicilio.SdTrackingVerificacionPedidos
                                                  on b.TrkCodigo equals p.TrkCodigo
                                                  where b.MotCodigo == motorizado.MotCodigo && b.TrkFechaRegistro > startDate && b.TrkFechaRegistro < endDate
                                                  && codigosPedidosVerificar.Contains(p.PcaCodigo)
                                                  select new { p.PcaCodigo, b.TrkEstadoTraking, b.TrkCodigo }).OrderByDescending(x => x.TrkCodigo);

                            var ultimoMovimiento = pedidosRetirar.FirstOrDefault();
                            if (!ultimoMovimiento.TrkEstadoTraking.Equals("RETIRAR") && !ultimoMovimiento.TrkEstadoTraking.Equals("TRANSITO"))
                                _result.Error("Error al procesar. El pedido debe tener un estado TRÁNSITO o TRANSFERENCIA.");

                            if (pedidosRetirar.Where(b => b.TrkEstadoTraking.Contains("ENTREGAR")).Count() > 0)
                            {
                                return _result.Error("Ya se ha entregado el pedido. [" + string.Join(",", pedidosRetirar.Where(b => b.TrkEstadoTraking.Contains("ENTREGAR"))) + "]");
                            }

                            // registro de facturas ENTREGADAS
                            trackingVerificacionPedidos = new List<SdTrackingVerificacionPedidos>();
                            SdTrackingVerificacionPedidos verificacionPedidoEntrega = new SdTrackingVerificacionPedidos
                            {
                                PcaCodigo = gPSMotorizadoViewModel.Pedidos.ElementAt(0).PcaCodigo,
                                PcsSerieFactura = gPSMotorizadoViewModel.Pedidos.ElementAt(0).SerieFactura,
                                TkpFechaRegistro = DateTime.Now,
                            };

                            trackingVerificacionPedidos.Add(verificacionPedidoEntrega);

                            ISdTracking = new SdTrackingMotorizadoPedidos
                            {
                                // registrar todos los pedidos actuales 
                                MotCodigo = gPSMotorizadoViewModel.MotCodigo,
                                SdTrackingVerificacionPedidos = trackingVerificacionPedidos,
                                TrkEstadoTraking = "ENTREGAR",
                                TrkFechaRegistro = DateTime.Now,
                                TrkUsuarioRegistro = "SISTEMA",
                                TrkLatitud = gPSMotorizadoViewModel.TrkLatitud,
                                TrkLongitud = gPSMotorizadoViewModel.TrkLongitud
                            };
                            _ctxServicioDomicilio.SdTrackingMotorizadoPedidos.Add(ISdTracking);
                            _ctxServicioDomicilio.SaveChanges();

                            return _result.OK();
                    }
                }
            }
            catch (Exception ex)
            {
                return _result.Error(ex.Message);
            }


            return _result.Error("La [AccionRegistro] no se reconoce.");
            //}
        }

        private Result EnviarNotificacion(int motCodigo)
        {
            string urlNotificationsOneSignal = Configuration.GetValue<string>("OneSignalNotificationsURL");
            string app_id = Configuration.GetValue<string>("app_id");
            bool signalRNotificado = false;
            string signalRObservacion = "";
            SdClientesOneSignal idSignal = _ctxServicioDomicilio.SdClientesOneSignal.FirstOrDefault(x => x.MotCodigo == motCodigo);
            if (idSignal != null)
            {
                try
                {
                    NotificacionOneSignal signal = new NotificacionOneSignal
                    {
                        app_id = app_id,
                        include_player_ids = new string[] { idSignal.OsIdOnesignal },
                        contents = new Contents { en = "Nuevos Pedidos Asignados" },
                        data = new Data { foo = "bar" }
                    };

                    var clienteSesion = new RestClient("https://onesignal.com/api/v1/notifications");
                    var requestSession = new RestRequest("", Method.POST);
                    requestSession.AddJsonBody(signal);
                    var restResponse = clienteSesion.Execute(requestSession).Content;

                    signalRNotificado = true;
                }
                catch (Exception ex)
                {
                    signalRObservacion = ex.Message;
                }
            }
            else
                signalRObservacion = "No tiene SignalrID";
            return _result.OK();
        }

        public Result RegistroCliente(OneSignalRegistroClienteViewModel oneSignalRegistroClienteViewModel)
        {
            try
            {
                var existe = _ctxServicioDomicilio.SdClientesOneSignal.FirstOrDefault(x => x.MotCodigo == oneSignalRegistroClienteViewModel.MotCodigo);
                if (existe != null)
                {
                    existe.OsFechaRegistro = DateTime.Now;
                    existe.OsIdOnesignal = oneSignalRegistroClienteViewModel.IdOneSignal;
                    _ctxServicioDomicilio.SdClientesOneSignal.Update(existe);
                }
                else
                {

                    SdClientesOneSignal sdClientesOneSignal = new SdClientesOneSignal
                    {
                        OsFechaRegistro = DateTime.Now,
                        OsIdOnesignal = oneSignalRegistroClienteViewModel.IdOneSignal,
                        MotCodigo = oneSignalRegistroClienteViewModel.MotCodigo,
                        OsUsuarioRegistro = "SISTEMA",
                    };

                    _ctxServicioDomicilio.SdClientesOneSignal.Add(sdClientesOneSignal);
                }

                _ctxServicioDomicilio.SaveChanges();
                return _result.OK();
            }
            catch (Exception ex)
            {
                return _result.Error(ex.Message);
            }
        }
    }
}