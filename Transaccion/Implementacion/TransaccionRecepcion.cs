using Configuracion;
using Configuracion.Models;
using Entidades.EasyGestionEmpresarial;
using Servicio;
using Servicio.Interfaz;
using Servicio.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Transaccion.Interfaz;

namespace Transaccion.Implementacion
{
    public class TransaccionRecepcion : ITransaccionRecepcion
    {
        IServicioRecepcion _iServicioRecepcion;



        public TransaccionRecepcion(IServicioRecepcion iServicioRecepcion)
        {
            _iServicioRecepcion = iServicioRecepcion;
        }

        public Result PA_TraspasosFarmacia(string id_bodega)
        {
            _iServicioRecepcion.Inicializar();
            return _iServicioRecepcion.PA_TraspasosFarmacia(id_bodega);
        }

        public Result DetalleTraspasos(string traspaso, string bodegaOrg)
        {
            _iServicioRecepcion.Inicializar();
            return _iServicioRecepcion.DetalleTraspasos(traspaso, bodegaOrg);
        }

        void registrarLog(string resp)
        {
            System.Diagnostics.EventLog objLog = new System.Diagnostics.EventLog();
            if (!EventLog.SourceExists("PMOV_RECEPCION_MOVIL"))
                EventLog.CreateEventSource("PMOV_RECEPCION_MOVIL", "Application");
            objLog.Source = "PMOV_RECEPCION_MOVIL";

            objLog.WriteEntry("RESP: " + resp, EventLogEntryType.Warning);
        }

        public Result BuscarArticuloTraspaso(string id_bodega, string codigo)
        {
            _iServicioRecepcion.Inicializar();
            return _iServicioRecepcion.BuscarArticuloTraspaso(id_bodega, codigo);
        }

        public Result VerificarTraspasoKardexFarmacia(string id_bodega, string traspaso)
        {
            _iServicioRecepcion.Inicializar();
            return _iServicioRecepcion.VerificarTraspasoKardexFarmacia(id_bodega, traspaso);
        }

        public Result GenerarKardex(Traspaso detalle)
        {
            _iServicioRecepcion.Inicializar();
            return _iServicioRecepcion.GenerarKardex(detalle);
        }

        public Result ImagenArticulo(string codigo)
        {
            _iServicioRecepcion.Inicializar();
            return _iServicioRecepcion.ImagenArticulo(codigo);
        }

        public Result GuardarTemporal(Temporal temporal)
        {
            _iServicioRecepcion.Inicializar();
            return _iServicioRecepcion.GuardarTemporal(temporal);
        }

        public Result RecuperarTemporal(string identificador)
        {
            _iServicioRecepcion.Inicializar();
            return _iServicioRecepcion.RecuperarTemporal(identificador);
        }

        public Result EliminarTemporal(string identificador)
        {
            _iServicioRecepcion.Inicializar();
            return _iServicioRecepcion.EliminarTemporal(identificador);
        }

        public Result Cookie(Cookie cookie)
        {
            _iServicioRecepcion.Inicializar();
            return _iServicioRecepcion.Cookie(cookie);
        }

        public Result Servidor(string ip)
        {
            _iServicioRecepcion.Inicializar();
            return _iServicioRecepcion.Servidor(ip);
        }

        public Result IPServidor()
        {
            _iServicioRecepcion.Inicializar();
            return _iServicioRecepcion.IPServidor();
        }

        public Result VerificarFactura(string serieFactura)
        {
            _iServicioRecepcion.Inicializar();
            return _iServicioRecepcion.VerificarFactura(serieFactura);
        }

        public Result Digitalizacion()
        {
            _iServicioRecepcion.Inicializar();
            return _iServicioRecepcion.Digitalizacion();

        }

        public Result VerificacionCajas(string bodega)
        {
            _iServicioRecepcion.Inicializar();
            return _iServicioRecepcion.VerificacionCajas(bodega);
        }

        public Result GuardarPendientesVerificacion(List<TraspasoModel> traspasosModel)
        {
            _iServicioRecepcion.Inicializar();

            Result resultado = new Result
            {
                respuesta = "error",
                mensaje = "No se completó la operación GuardarVerificacion."
            };


            // REGISTRO DE ACTIVIDAD
            List<tbl_AuditoriaAppMovil> auditoria = new List<tbl_AuditoriaAppMovil>();


            try
            {

                if (traspasosModel.ElementAt(0) == null || traspasosModel.ElementAt(0).UsuarioFarmacia == null || traspasosModel.ElementAt(0).UsuarioFarmacia.Equals(""))
                {
                    resultado.respuesta = "error";
                    resultado.mensaje = "No existe el usuario en la estructura.";
                    return resultado;
                }

                if (traspasosModel.Where(x => x.Check.Equals("x")).Count() == 0)
                {
                    resultado.respuesta = "error";
                    resultado.mensaje = "Seleccione al menos un traspaso antes de continuar.";
                    return resultado;
                }

                bool alMenosUnaCaja = false;
                foreach (var item in traspasosModel)
                {
                    if (item.CajasV.Count > 0 || item.FundasV.Count > 0 || item.PacasV.Count > 0)
                    {
                        alMenosUnaCaja = true;
                        break;
                    }
                }
                if (!alMenosUnaCaja)
                {
                    resultado.respuesta = "error";
                    resultado.mensaje = "Verificar al menos una caja, paca o funda, antes de continuar.";
                    return resultado;
                }

                List<VIRT_TRASPASOVERIFMERCADERIA> vir_traspasos = new List<VIRT_TRASPASOVERIFMERCADERIA>();
                List<PV_TraspasoVerifMercaderia_Det> informeDet = new List<PV_TraspasoVerifMercaderia_Det>();
                List<tbl_PendientesVerificacion> tbl_PendientesVerificacions = new List<tbl_PendientesVerificacion>();

                List<string> codigosTraspasosEntrantes = traspasosModel.Select(x => x.NumeroTraspaso).ToList();
                List<string> codigosTraspasosEntrantesI = traspasosModel.Select(x => x.NumeroTraspaso).ToList();
                for (int i = 0; i < codigosTraspasosEntrantes.Count; i++)
                {
                    codigosTraspasosEntrantes[i] = codigosTraspasosEntrantes[i].Replace("-", "");
                    codigosTraspasosEntrantesI[i] = codigosTraspasosEntrantesI[i].Split('-').ElementAt(1);
                }


                List<VIRT_TRASPASOVERIFMERCADERIA> listaVir = _iServicioRecepcion.vIRT_TRASPASOVERIFMERCADERIAs(codigosTraspasosEntrantes);
                List<tbl_PendientesVerificacion> pendientes = _iServicioRecepcion.tbl_PendientesVerificacion_Obtener(codigosTraspasosEntrantesI.Select(int.Parse).ToList());
                List<Tbl_TemperaturaTraspaso_cab> temperaturas = new List<Tbl_TemperaturaTraspaso_cab>();
                List<string> pedidosFacturados = new List<string>();

                //var listaTraspasosFarmacia = (List<TraspasoModel>)PA_TraspasosFarmacia(traspaso.Bodega).mensaje;

                foreach (TraspasoModel traspaso in traspasosModel)
                {

                    string numeroTraspaso = traspaso.NumeroTraspaso.Replace("-", "").ToUpper();
                    int numeroTraspasoI = Convert.ToInt32(traspaso.NumeroTraspaso.Split('-').ElementAt(1));

                    //VERIFICACIÓN DE CHECK
                    if (traspaso.Check.ToUpper().Replace(" ", "").Equals("X"))
                    {
                        VIRT_TRASPASOVERIFMERCADERIA virTEMP = listaVir.Find(x => x.numTraspaso.Equals(numeroTraspaso));

                        if (traspaso.Estado.Equals("T") || traspaso.Estado.Equals("EP"))
                        {
                            /// Temperatura ///
                            if (traspaso.Temperaturas != null & traspaso.Temperaturas.Count > 0)
                            {
                                try
                                {
                                    int numTraspaso = Convert.ToInt32(traspaso.NumeroTraspaso.Split('-').ElementAt(1));

                                    if (traspaso.PedidoFacturado == "S")
                                        pedidosFacturados.Add(traspaso.NumeroTraspaso);

                                    string cF = _iServicioRecepcion.ValidartraspasoCF(numTraspaso);

                                    if (cF == "S")
                                    {
                                        foreach (TemperaturaModel temperatura in traspaso.Temperaturas)
                                        {


                                            //if(temperatura.Temperatura != 0) { 
                                            int taman = temperatura.Contenedor.Length;
                                            Tbl_TemperaturaTraspaso_cab tmpTemp = new Tbl_TemperaturaTraspaso_cab
                                            {
                                                ttc_contenedor = temperatura.Contenedor.ElementAt(taman - 2) + "" + temperatura.Contenedor.ElementAt(taman - 1),
                                                ttc_temperatura = Convert.ToDecimal(temperatura.Temperatura),
                                                ttc_observacion = temperatura.Observacion == null ? "" : temperatura.Observacion,
                                                ttc_fecha = DateTime.Now,
                                                ttc_usuario = traspaso.UsuarioFarmacia,
                                                ttc_tr_fol = traspaso.NumeroTraspaso.Split('-').ElementAt(1),
                                                ENVIO_POS = null,
                                            };
                                            temperaturas.Add(tmpTemp);
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {


                                }

                            }


                            //AUDITORIA /////////

                            tbl_AuditoriaAppMovil auditoriaTMP = new tbl_AuditoriaAppMovil
                            {
                                aum_fecha_ejecucion = DateTime.Now,
                                aum_fecha_registro = DateTime.Now,
                                aum_numero_movimiento = numeroTraspasoI,
                                aum_oficina = traspaso.Bodega,
                                aum_usuario_registro = traspaso.UsuarioFarmacia,
                                aum_tipo_movimiento = "VERIFMERCA"
                            };
                            auditoria.Add(auditoriaTMP);
                            /////////////////////

                            VIRT_TRASPASOVERIFMERCADERIA virTeamporal = new VIRT_TRASPASOVERIFMERCADERIA();
                            //TA4645191
                            virTeamporal.numTraspaso = numeroTraspaso;
                            virTeamporal.tr_fol = Convert.ToInt32(traspaso.NumeroTraspaso.Split('-').ElementAt(1));
                            virTeamporal.tipoMovimiento = traspaso.NumeroTraspaso.Split('-').ElementAt(0);
                            string procesado = string.Join(",", traspaso.CajasV) + "," + string.Join(",", traspaso.PacasV) + "," + string.Join(",", traspaso.FundasV) + "," + string.Join(",", traspaso.CajasP) + "," + string.Join(",", traspaso.FundasP) + "," + string.Join(",", traspaso.PacasP) + ",";
                            procesado = RemoverComainicialFinal(procesado);
                            virTeamporal.procesado = procesado.Replace(",,", ",");
                            virTeamporal.estado = "A";
                            virTeamporal.vtvm_estado_traspaso = "COMPLETO";
                            virTeamporal.usuario = traspaso.UsuarioFarmacia;
                            virTeamporal.fecha = DateTime.Now;


                            // DETALLE DE INFORME 
                            PV_TraspasoVerifMercaderia_Det detalleTempc = new PV_TraspasoVerifMercaderia_Det();
                            detalleTempc.tvmd_numero_traspaso = virTeamporal.numTraspaso;
                            detalleTempc.tvmd_tipo_mercaderia = "C";
                            detalleTempc.tvmd_numero_procesadas = traspaso.CajasV.Count() + traspaso.CajasP.Count();
                            detalleTempc.tvmd_numero_pendientes = 0;
                            detalleTempc.tvmd_usuario = traspaso.UsuarioFarmacia;
                            informeDet.Add(detalleTempc);



                            // DETALLE DE INFORME 
                            PV_TraspasoVerifMercaderia_Det detalleTempF = new PV_TraspasoVerifMercaderia_Det();
                            detalleTempF.tvmd_numero_traspaso = virTeamporal.numTraspaso;
                            detalleTempF.tvmd_tipo_mercaderia = "F";
                            detalleTempF.tvmd_numero_procesadas = traspaso.FundasV.Count() + traspaso.FundasP.Count();
                            detalleTempF.tvmd_numero_pendientes = 0;
                            detalleTempF.tvmd_usuario = traspaso.UsuarioFarmacia;
                            informeDet.Add(detalleTempF);


                            // DETALLE DE INFORME 
                            PV_TraspasoVerifMercaderia_Det detalleTempP = new PV_TraspasoVerifMercaderia_Det();
                            detalleTempP.tvmd_numero_traspaso = virTeamporal.numTraspaso;
                            detalleTempP.tvmd_tipo_mercaderia = "P";
                            detalleTempP.tvmd_numero_procesadas = traspaso.PacasV.Count() + traspaso.PacasP.Count();
                            detalleTempP.tvmd_numero_pendientes = 0;
                            detalleTempP.tvmd_usuario = traspaso.UsuarioFarmacia;
                            informeDet.Add(detalleTempP);


                            vir_traspasos.Add(virTeamporal);
                        }

                        // PENDIENTES

                        tbl_PendientesVerificacion tbl_PendientesTemp = pendientes.Find(x => x.pe_traspaso == numeroTraspasoI);
                        if (tbl_PendientesTemp == null)
                        {
                            tbl_PendientesTemp = new tbl_PendientesVerificacion();
                            tbl_PendientesTemp.pe_estado = "A";
                        }
                        else
                        {
                            tbl_PendientesTemp.pe_estado = "U";
                        }
                        tbl_PendientesTemp.pe_traspaso = Convert.ToInt32(traspaso.NumeroTraspaso.Split('-').ElementAt(1));
                        tbl_PendientesTemp.pe_cajas = string.Join(",", traspaso.CajasP);
                        tbl_PendientesTemp.pe_fundas = string.Join(",", traspaso.FundasP);
                        tbl_PendientesTemp.pe_pacas = string.Join(",", traspaso.PacasP);
                        tbl_PendientesTemp.pe_usuario_registro = traspaso.UsuarioFarmacia;
                        tbl_PendientesTemp.pe_fecha_registro = DateTime.Now;
                        tbl_PendientesTemp.pe_tipo_mov = traspaso.NumeroTraspaso.Split('-').ElementAt(0);

                        tbl_PendientesVerificacions.Add(tbl_PendientesTemp);
                    }
                }

                if (vir_traspasos.Count == 0 && tbl_PendientesVerificacions.Count == 0)
                {
                    resultado.respuesta = "ok";
                    resultado.mensaje = "No existen traspasos para procesar";
                    return resultado;
                }

                PV_TraspasoInformeMercaderia informeCabTemp = new PV_TraspasoInformeMercaderia();
                if (vir_traspasos.Count > 0)
                {
                    const string quote = "''";
                    List<string> traspasosTemp = vir_traspasos.Select(x => quote + x.tipoMovimiento.ToUpper() + x.tr_fol.ToString() + quote).ToList();
                    int id = _iServicioRecepcion.Max_PV_TraspasoInformeMercaderia();
                    id++;
                    informeCabTemp.tim_id = id;
                    informeCabTemp.tim_codigo = "VF" + traspasosModel.ElementAt(0).Bodega + id.ToString().PadLeft(10, '0');
                    informeCabTemp.tim_fecha = DateTime.Now;
                    informeCabTemp.tim_usuario = traspasosModel.ElementAt(0).UsuarioFarmacia.ToUpper();
                    informeCabTemp.tim_traspasos = string.Join(",", traspasosTemp);
                }

                //GUARDADO ***********************************************************************

                var online = VerificarConexionBDD();


                // traspaosos matriz 
                List<int> codigosEnteros = new List<int>();
                foreach (var item in vir_traspasos)
                {
                    codigosEnteros.Add(Convert.ToInt32(item.numTraspaso.Substring(2)));
                }

                if (online)
                {
                    List<VIRT_TRASPASOCAB> cabs = _iServicioRecepcion.vIRT_TRASPASOCABs(codigosEnteros);
                    for (int i = 0; i < cabs.Count; i++)
                    {
                        cabs[i].ENVIO_POS = "ET";
                    }
                    _iServicioRecepcion.VIRT_TRASPASOCAB_Update(cabs);
                }
                else
                {
                    List<VIRT_TRASPASOCABOFFLINE> cabs = _iServicioRecepcion.vIRT_TRASPASOCABsOffline(codigosEnteros);
                    for (int i = 0; i < cabs.Count; i++)
                    {
                        if (cabs[i].ENVIO_POS == null || (!cabs[i].ENVIO_POS.ToString().ToUpper().Equals("R") && !cabs[i].ENVIO_POS.ToString().ToUpper().Equals("OF")))
                            cabs[i].ENVIO_POS = "ET";
                    }
                    _iServicioRecepcion.VIRT_TRASPASOCAB_UpdateOffline(cabs);
                }


                //using (TransactionScope t = new TransactionScope(TransactionScopeOption.Required))
                //{
                try
                {
                    if (vir_traspasos.Count > 0)
                    {

                        if (temperaturas.Count > 0)
                            _iServicioRecepcion.tbl_TemperaturaTraspaso_cab_Create(temperaturas);
                        _iServicioRecepcion.VIRT_TRASPASOVERIFMERCADERIA_Create(vir_traspasos);
                        _iServicioRecepcion.PV_TraspasoInformeMercaderia_Create(informeCabTemp);
                        _iServicioRecepcion.PV_TraspasoVerifMercaderiaDet_Create(informeDet);

                        if (pedidosFacturados.Count > 0)
                        {
                            _iServicioRecepcion.DetalleTransferenciaBC_Update(pedidosFacturados);
                        }
                    }
                    _iServicioRecepcion.tbl_PendientesVerificacion_create(tbl_PendientesVerificacions);
                    //t.Complete();
                    resultado.respuesta = "ok";
                    resultado.mensaje = "Procesado Corectamente";
                }
                catch (Exception ex)
                {
                    registrarLog("GuardarPendientesVerificacion: " + ex.Message + " -- " + ex.StackTrace);
                    resultado.mensaje += "GuardarPendientesVerificacion: " + ex.Message;
                    //t.Dispose();
                    return resultado;
                }
                //}
                try
                {
                    Task task = new Task(() => RegistrarActividad(auditoria));
                    task.Start();
                }
                catch (Exception ex)
                {
                    registrarLog("GuardarPendientesVerificacion: " + ex.Message + " -- " + ex.StackTrace);
                }
            }
            catch (Exception ex)
            {
                registrarLog("GuardarPendientesVerificacion: " + ex.Message + " -- " + ex.StackTrace);
                resultado.mensaje += "GuardarPendientesVerificacion: " + ex.Message;
            }
            return resultado;
        }

        private void RegistrarActividad(List<tbl_AuditoriaAppMovil> auditoria)
        {
            try
            {
                _iServicioRecepcion.Inicializar();
                _iServicioRecepcion.RegistroAppMovilGenerico(auditoria);
            }
            catch (Exception ex)
            {
                registrarLog("GuardarPendientesVerificacion: " + ex.Message + " -- " + ex.StackTrace);
            }
        }

        private string RemoverComainicialFinal(string texto)
        {
            var x = texto.ElementAt(0);
            if (texto.ElementAt(0).ToString().Equals(","))
                texto = texto.Substring(1, texto.Length - 1);
            if (texto.ElementAt(texto.Length - 1).ToString().Equals(","))
                texto = texto.Substring(0, texto.Length - 1);
            return texto;
        }

        public bool ListaPendientesVerificacionVencidos()
        {
            try
            {
                List<tbl_PendientesVerificacion> pendientes = _iServicioRecepcion.ListaPendientesVerificacionVencidos();

                if (pendientes != null && pendientes.Count > 0)
                {

                    List<int> traspasos = new List<int>();

                    string cadenaTraspasos = "";
                    int count = 1;
                    foreach (var item in pendientes)
                    {
                        DateTime tmp = Convert.ToDateTime(item.pe_fecha_registro);
                        TimeSpan ts = DateTime.Now - tmp;
                        if (ts.TotalHours > 24)
                        {
                            cadenaTraspasos += "<p>" + count + ". <b> Traspaso " + item.pe_tipo_mov + "-" + item.pe_traspaso + "</b></p>";
                            if (!item.pe_cajas.Equals(""))
                                cadenaTraspasos += "<li type='square'> Cajas: " + item.pe_cajas + "</li>";
                            if (!item.pe_fundas.Equals(""))
                                cadenaTraspasos += "<li type='square'> Fundas: " + item.pe_fundas + "</li>";
                            if (!item.pe_pacas.Equals(""))
                                cadenaTraspasos += "<li type='square'> Pacas: " + item.pe_pacas + "</li>";
                            traspasos.Add(item.pe_traspaso);
                            count++;
                        }
                    }

                    PV_IpServidor ipServidor = _iServicioRecepcion.PV_IpServidor();
                    Oficinas oficina = _iServicioRecepcion.RecuperarCorreoOficina(ipServidor.oficina);

                    string correocopia = "";

                    List<tbl_par_UsuarioNotificacionInconsistencia> correos = _iServicioRecepcion.tbl_Par_UsuarioNotificacionInconsistencias("AppMovil-TraspasosPendientes");
                    if (correos != null && correos.Count > 0)
                    {
                        foreach (var item in correos.Where(x => !x.usuario.Equals("transportes") && x.estado.Equals("A")))
                        {
                            correocopia += item.correo + ";";
                        }
                    }
                    else
                    {
                        registrarLog("Notificación de Pedidos Pendientes: no se han paraemtrizados los correos de notificación en tbl_par_UsuarioNotificacionInconsistencia 159");
                        return false;
                    }

                    if (cadenaTraspasos.Trim().Replace(" ", "").Equals(""))
                        return false;

                    EnviarCorreo("notificaciones@farmaenlace.com", correos.Find(x => x.usuario.Equals("transportes")).correo, correocopia + oficina.correo_electronico, "Notificación de Recepción de Mercadería en Farmacias: ",
                                    "Estimado " + Properties.Resources.ResponsablePedidos + ", " +
                                    "</BR>" +
                                    "</BR>" +
                                    "Se notifica que para la farmacia " + ipServidor.nombreOficina.ToUpper() + ", existe un retraso mayor a 24 horas en la entrega de los traspasos:" +
                                    "</BR>" +
                                    cadenaTraspasos +
                                    "</BR>" +
                                    "Favor, brindar el seguimiento respectivo."
                                    + "</BR>" +
                                    "Gracias."
                                    + "</BR>"
                                    + "</BR>" +
                                    "Correo generado automáticamente por el sistema.",
                                    "mail.farmaenlace.com");

                    _iServicioRecepcion.tbl_PendientesVerificacion_Update(traspasos);
                }
                return true;
            }
            catch (Exception ex)
            {
                registrarLog("GuardarPendientesVerificacion: " + ex.Message + " -- " + ex.StackTrace);
            }
            return false;
        }



        public String EnviarCorreo(String correoDE, String correoPARA, String CC, String Saludo, String Mensaje, string servermail)
        {
            GeneraGuiaEasyTini.ADEnvioCorreo correo = new GeneraGuiaEasyTini.ADEnvioCorreo();
            correo.servidorcorreos = Properties.Resources.ServidorCorreo;
            string respuesta = correo.EnviarCorreo(correoDE, correoPARA, CC, Saludo, Mensaje, "");
            return respuesta;
        }

        public Result TipoDocumento(string serieFactura)
        {
            _iServicioRecepcion.Inicializar();
            return _iServicioRecepcion.TipoDocumento(serieFactura);
        }

        public Result EjecutarConsulta(string valorFiltro)
        {
            _iServicioRecepcion.Inicializar();
            return _iServicioRecepcion.EjecutarConsulta(valorFiltro);
        }

        public bool VerificarConexionBDD()
        {
            return false;
            try
            {
                string sql = "SELECT top(0) *  FROM [EasyGestionEmpresarial].[dbo].[PV_BaseConsumidorFinal] with (nolock)";
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["EasyContextoMatriz"].ConnectionString;

                ConexionBDD conexion = new ConexionBDD(connectionString);

                DataTable dtConsulta = conexion.EjecutarSql(sql);
                if (dtConsulta == null || dtConsulta.Columns.Count == 0)
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
