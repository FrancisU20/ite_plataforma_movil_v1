using Configuracion;
using Configuracion.Models;
using Entidades.EasyGestionEmpresarial;
using Servicio.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using Transaccion.Interfaz;

namespace PlataformaMovilWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Service1 : IService1
    {
        private readonly ITransaccionInventarioMovil _transaccionInventarioMovil;
        private readonly ITransaccionRecepcion _transaccionRecepcion;
        private readonly ITransaccionInventarioTotal _transaccionInventarioTotal;

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public Service1(ITransaccionInventarioMovil transaccionInventarioMovil, ITransaccionRecepcion transaccionRecepcion, ITransaccionInventarioTotal transaccionInventarioTotal)
        {
            _transaccionInventarioMovil = transaccionInventarioMovil;
            _transaccionRecepcion = transaccionRecepcion;
            _transaccionInventarioTotal = transaccionInventarioTotal;
        }

        public System.IO.Stream Test()
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            string json = ser.Serialize("");
            byte[] resultBytes = Encoding.UTF8.GetBytes(json);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";
            return new MemoryStream(resultBytes);
        }

        public bool TestConexionSAP()
        {
            bool result = _transaccionInventarioMovil.TestConexionSAP();
            return result;
        }

        #region INVENTARIO MOVIL

        public Response Ips(Request request)
        {
            return _transaccionInventarioMovil.Ips(request);
        }

        public string ipLLamada()
        {
            string ipAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            return ipAddress;
        }


        public System.IO.Stream AutentificarUsuarioVisor(string usuario, string contrasena, string ipMovil, string ipMovil2)
        {
            registrarLog("AutentificarUsuario exc: " + usuario);
            JavaScriptSerializer ser = new JavaScriptSerializer();

            Result resultado = new Result
            {
                respuesta = "error",
                mensaje = "Actualice la aplicación antes de continuar."
            };

            registrarLog("AutentificarUsuario exc: " + usuario);

            OperationContext oOperationContext = OperationContext.Current;
            MessageProperties oMessageProperties = oOperationContext.IncomingMessageProperties;
            RemoteEndpointMessageProperty oRemoteEndpointMessageProperty = (RemoteEndpointMessageProperty)oMessageProperties[RemoteEndpointMessageProperty.Name];

            string szAddress = oRemoteEndpointMessageProperty.Address;
            int nPort = oRemoteEndpointMessageProperty.Port;

            Result result = _transaccionInventarioMovil.AutentificarUsuarioFarmascan(usuario, contrasena, szAddress, ipMovil, ipMovil2);
            string json = ser.Serialize(result);
            byte[] resultBytes = Encoding.UTF8.GetBytes(json);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";
            return new MemoryStream(resultBytes);
        }

        public System.IO.Stream AutentificarUsuarioFarmascan(string usuario, string contrasena, string ipMovil, string ipMovil2)
        {
            registrarLog("AutentificarUsuario exc: " + usuario);
            JavaScriptSerializer ser = new JavaScriptSerializer();
            if (usuario.Contains("_") && usuario.Split('_').ElementAt(1).Equals("10"))
            {
                usuario = usuario.Split('_').ElementAt(0);
            }
            else
            {
                Result resultado = new Result
                {
                    respuesta = "error",
                    mensaje = "Actualice la aplicación antes de continuar."
                };
                string jsonx = ser.Serialize(resultado);
                byte[] resultBytesx = Encoding.UTF8.GetBytes(jsonx);
                WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";
                return new MemoryStream(resultBytesx);
            }
            registrarLog("AutentificarUsuario exc: " + usuario);

            OperationContext oOperationContext = OperationContext.Current;
            MessageProperties oMessageProperties = oOperationContext.IncomingMessageProperties;
            RemoteEndpointMessageProperty oRemoteEndpointMessageProperty = (RemoteEndpointMessageProperty)oMessageProperties[RemoteEndpointMessageProperty.Name];

            string szAddress = oRemoteEndpointMessageProperty.Address;
            int nPort = oRemoteEndpointMessageProperty.Port;

            Result result = _transaccionInventarioMovil.AutentificarUsuarioFarmascan(usuario, contrasena, szAddress, ipMovil, ipMovil2);
            string json = ser.Serialize(result);
            byte[] resultBytes = Encoding.UTF8.GetBytes(json);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";
            return new MemoryStream(resultBytes);
        }

        public System.IO.Stream AutentificarUsuario(string usuario, string contrasena, string ipMovil, string ipMovil2)
        {
            registrarLog("AutentificarUsuario exc: " + usuario);
            JavaScriptSerializer ser = new JavaScriptSerializer();
            if (usuario.Contains("_") && usuario.Split('_').ElementAt(1).Equals("34"))
            {
                usuario = usuario.Split('_').ElementAt(0);
            }
            else
            {
                Result resultado = new Result
                {
                    respuesta = "error",
                    mensaje = "Actualice la aplicación antes de continuar."
                };
                string jsonx = ser.Serialize(resultado);
                byte[] resultBytesx = Encoding.UTF8.GetBytes(jsonx);
                WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";
                return new MemoryStream(resultBytesx);
            }
            registrarLog("AutentificarUsuario exc: " + usuario);

            OperationContext oOperationContext = OperationContext.Current;
            MessageProperties oMessageProperties = oOperationContext.IncomingMessageProperties;
            RemoteEndpointMessageProperty oRemoteEndpointMessageProperty = (RemoteEndpointMessageProperty)oMessageProperties[RemoteEndpointMessageProperty.Name];

            string szAddress = oRemoteEndpointMessageProperty.Address;
            int nPort = oRemoteEndpointMessageProperty.Port;

            Result result = _transaccionInventarioMovil.AutentificarUsuario(usuario, contrasena, szAddress, ipMovil, ipMovil2);
            string json = ser.Serialize(result);
            byte[] resultBytes = Encoding.UTF8.GetBytes(json);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";
            return new MemoryStream(resultBytes);
        }

        public System.IO.Stream ListadoPlanificaciones()
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();

            Result result = _transaccionInventarioMovil.ListadoPlanificaciones();
            string json = ser.Serialize(result);
            byte[] resultBytes = Encoding.UTF8.GetBytes(json);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";
            return new MemoryStream(resultBytes);
        }

        public System.IO.Stream ListadoArticulosPlanificacion(string id_plan, string origen)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            Result result = _transaccionInventarioMovil.ListadoArticulosPlanificacion(id_plan, origen);
            string json = ser.Serialize(result);
            byte[] resultBytes = Encoding.UTF8.GetBytes(json);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";
            return new MemoryStream(resultBytes);
        }

        public System.IO.Stream RestringirArticulosContar(string id_plan, string origen, string usuario, string ip)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            Result result = _transaccionInventarioMovil.RestringirArticulosContar(id_plan, origen, usuario, ip);
            string json = ser.Serialize(result);
            byte[] resultBytes = Encoding.UTF8.GetBytes(json);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";
            return new MemoryStream(resultBytes);
        }

        public System.IO.Stream ActualizarPlanificacionaContar(string id_plan, string origen)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            Result result = _transaccionInventarioMovil.ActualizarPlanificacionaContar(id_plan, origen);
            string json = ser.Serialize(result);
            byte[] resultBytes = Encoding.UTF8.GetBytes(json);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";
            return new MemoryStream(resultBytes);
        }

        public System.IO.Stream SubirConteoInventario(cls_Cabecera conteoInventario)
        {

            if (conteoInventario.usuario.Contains('_'))
            {
                conteoInventario.usuario = conteoInventario.usuario.Split('_').ElementAt(0);
            }
            JavaScriptSerializer ser = new JavaScriptSerializer();
            //registrarLog("SelectDatosguardar exc: " + ser.Serialize(conteoInventario));
            Result result = _transaccionInventarioMovil.SubirConteoInventario(conteoInventario);
            string json = ser.Serialize(result);
            byte[] resultBytes = Encoding.UTF8.GetBytes(json);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";
            return new MemoryStream(resultBytes);
        }

        #endregion

        #region RECEPCION

        public System.IO.Stream TraspasosFarmacia(string id_bodega)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            Result result = _transaccionRecepcion.PA_TraspasosFarmacia(id_bodega);
            string json = ser.Serialize(result);
            byte[] resultBytes = Encoding.UTF8.GetBytes(json);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";
            return new MemoryStream(resultBytes);
        }

        public System.IO.Stream DetalleTraspasos(string traspaso, string bodegaOrg)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            Result result = _transaccionRecepcion.DetalleTraspasos(traspaso, bodegaOrg);
            string json = ser.Serialize(result);
            byte[] resultBytes = Encoding.UTF8.GetBytes(json);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";
            return new MemoryStream(resultBytes);
        }

        public System.IO.Stream BuscarArticuloTraspaso(string id_bodega, string codigo)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            Result result = _transaccionRecepcion.BuscarArticuloTraspaso(id_bodega, codigo);
            string json = ser.Serialize(result);
            byte[] resultBytes = Encoding.UTF8.GetBytes(json);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";
            return new MemoryStream(resultBytes);
        }

        public System.IO.Stream VerificarTraspasoKardexFarmacia(string id_bodega, string traspaso)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            Result result = _transaccionRecepcion.VerificarTraspasoKardexFarmacia(id_bodega, traspaso);
            string json = ser.Serialize(result);
            byte[] resultBytes = Encoding.UTF8.GetBytes(json);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";
            return new MemoryStream(resultBytes);
        }

        public System.IO.Stream GenerarKardex(Traspaso traspaso)
        {

            if (traspaso.usuarioFarmacia.Contains('_'))
            {
                traspaso.usuarioFarmacia = traspaso.usuarioFarmacia.Split('_').ElementAt(0);
            }

            //StreamReader reader = new StreamReader(data);
            //string detalle = reader.ReadToEnd();
            JavaScriptSerializer ser = new JavaScriptSerializer();
            Result result = _transaccionRecepcion.GenerarKardex(traspaso);
            string json = ser.Serialize(result);
            byte[] resultBytes = Encoding.UTF8.GetBytes(json);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";
            return new MemoryStream(resultBytes);
        }
        #endregion

        #region INVENTARIO TOTAL

        public System.IO.Stream RecuperarFarmacia(string ip)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            Result result = _transaccionInventarioTotal.RecuperarFarmacia(ip);
            string json = ser.Serialize(result);
            byte[] resultBytes = Encoding.UTF8.GetBytes(json);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";
            return new MemoryStream(resultBytes);
        }

        public System.IO.Stream CargarSiguiente(string usuario, int conteo, int inventario)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            Result result = _transaccionInventarioTotal.CargarSiguiente(usuario, conteo, inventario);
            string json = ser.Serialize(result);
            byte[] resultBytes = Encoding.UTF8.GetBytes(json);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";
            return new MemoryStream(resultBytes);
        }

        public System.IO.Stream CerrarSesion(string usuario, string ip)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            Result result = _transaccionInventarioTotal.CerrarSesion(usuario, ip);
            string json = ser.Serialize(result);
            byte[] resultBytes = Encoding.UTF8.GetBytes(json);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";
            return new MemoryStream(resultBytes);
        }

        public System.IO.Stream RegistroCantidades(RegistroCantidadesInventarioTotal reg)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            Result result = _transaccionInventarioTotal.RegistroCantidades(reg.Usuario, reg.IpCliente, reg.Entero, reg.Fraccion, reg.CodigoArticulo, reg.ValorPos, reg.Conteo, reg.Inventario);
            string json = ser.Serialize(result);
            byte[] resultBytes = Encoding.UTF8.GetBytes(json);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";
            return new MemoryStream(resultBytes);
        }

        public System.IO.Stream BuscarArticuloInventario(BuscarArticuloInventarioTotalModel b)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            Result result = _transaccionInventarioTotal.BuscarArticuloInventario(b.Codigo, b.CodigoBarra, b.Descripcion, b.Conteo, b.Inventario, b.Usuario);
            string json = ser.Serialize(result);
            byte[] resultBytes = Encoding.UTF8.GetBytes(json);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";
            return new MemoryStream(resultBytes);
        }


        public System.IO.Stream Ingreso(IngresoInventarioTotal ingresoInventarioTotal)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            Result result = _transaccionInventarioTotal.Ingreso(ingresoInventarioTotal.IpServidor, ingresoInventarioTotal.IpCliente, ingresoInventarioTotal.Usuario);
            string json = ser.Serialize(result);
            byte[] resultBytes = Encoding.UTF8.GetBytes(json);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";
            return new MemoryStream(resultBytes);
        }

        public System.IO.Stream Inventario(IngresoInventarioTotal ingresoInventarioTotal)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            Result result = _transaccionInventarioTotal.Inventario(ingresoInventarioTotal.IpServidor, ingresoInventarioTotal.Usuario);
            string json = ser.Serialize(result);
            byte[] resultBytes = Encoding.UTF8.GetBytes(json);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";
            return new MemoryStream(resultBytes);
        }

        public Stream CargaInicialArticulos()
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            Result result = _transaccionInventarioTotal.CargaInicialArticulos();
            ser.MaxJsonLength = 50000000;
            string json = ser.Serialize(result);
            byte[] resultBytes = Encoding.UTF8.GetBytes(json);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";
            return new MemoryStream(resultBytes);
        }

        #endregion

        public System.IO.Stream ImagenArticulo(string codigo)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            Result result = _transaccionRecepcion.ImagenArticulo(codigo);
            string json = ser.Serialize(result);
            byte[] resultBytes = Encoding.UTF8.GetBytes(json);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";
            return new MemoryStream(resultBytes);
        }

        public System.IO.Stream GuardarTemporal(Temporal temporal)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            Result result = _transaccionRecepcion.GuardarTemporal(temporal);
            string json = ser.Serialize(result);
            byte[] resultBytes = Encoding.UTF8.GetBytes(json);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";
            return new MemoryStream(resultBytes);
        }

        public System.IO.Stream RecuperarTemporal(string identificador)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            Result result = _transaccionRecepcion.RecuperarTemporal(identificador);
            string json = ser.Serialize(result);
            byte[] resultBytes = Encoding.UTF8.GetBytes(json);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";
            return new MemoryStream(resultBytes);
        }

        public System.IO.Stream Cookie(Cookie cookie)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            Result result = _transaccionRecepcion.Cookie(cookie);
            string json = ser.Serialize(result);
            byte[] resultBytes = Encoding.UTF8.GetBytes(json);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";
            return new MemoryStream(resultBytes);
        }

        void registrarLog(string resp)
        {
            System.Diagnostics.EventLog objLog = new System.Diagnostics.EventLog();
            if (!EventLog.SourceExists("PMOV_INVENTARIO_MOVIL"))
                EventLog.CreateEventSource("PMOV_INVENTARIO_MOVIL", "Application");
            objLog.Source = "PMOV_INVENTARIO_MOVIL";

            objLog.WriteEntry("RESP: " + resp, EventLogEntryType.Warning);
        }

        public System.IO.Stream EliminarTemporal(string identificador)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            Result result = _transaccionRecepcion.EliminarTemporal(identificador);
            string json = ser.Serialize(result);
            byte[] resultBytes = Encoding.UTF8.GetBytes(json);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";
            return new MemoryStream(resultBytes);
        }

        public System.IO.Stream Servidor(string ip)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            Result result = _transaccionRecepcion.Servidor(ip);
            string json = ser.Serialize(result);
            byte[] resultBytes = Encoding.UTF8.GetBytes(json);
            //WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";
            WebOperationContext.Current.OutgoingResponse.ContentType = "text/html";

            return new MemoryStream(resultBytes);
        }

        public System.IO.Stream IPServidor()
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            Result result = _transaccionRecepcion.IPServidor();
            string json = ser.Serialize(result);
            byte[] resultBytes = Encoding.UTF8.GetBytes(json);
            //WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";
            WebOperationContext.Current.OutgoingResponse.ContentType = "text/html";

            return new MemoryStream(resultBytes);
        }

        public System.IO.Stream TipoDocumento(string serie)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();

            Result result = _transaccionRecepcion.TipoDocumento(serie);

            var x = result.mensaje.ToString().Replace("[", "");
            x = x.Replace("]", "");


            result.mensaje = x;

            string json = ser.Serialize(result);
            json = json.Replace(@"\", "");
            json = json.Replace("\"{\"", "{\"");
            json = json.Replace("\"}\"", "\"}");
            json = json.Replace("}\"}", "}}");
            byte[] resultBytes = Encoding.UTF8.GetBytes(json);
            //WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";
            WebOperationContext.Current.OutgoingResponse.ContentType = "text/html";

            return new MemoryStream(resultBytes);
        }

        public System.IO.Stream VerificarFactura(string serieFactura)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();

            Result result = _transaccionRecepcion.EjecutarConsulta(serieFactura);

            var x = result.mensaje.ToString().Replace("[", "");
            x = x.Replace("]", "");


            result.mensaje = x;

            string json = ser.Serialize(result);
            json = json.Replace(@"\", "");
            json = json.Replace("\"{\"", "{\"");
            json = json.Replace("\"}\"", "\"}");
            json = json.Replace("}\"}", "}}");
            byte[] resultBytes = Encoding.UTF8.GetBytes(json);
            //WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";
            WebOperationContext.Current.OutgoingResponse.ContentType = "text/html";

            return new MemoryStream(resultBytes);
        }

        public System.IO.Stream Digitalizacion()
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            Result result = _transaccionRecepcion.Digitalizacion();
            string json = ser.Serialize(result);
            byte[] resultBytes = Encoding.UTF8.GetBytes(json);
            //WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";
            WebOperationContext.Current.OutgoingResponse.ContentType = "text/html";

            return new MemoryStream(resultBytes);
        }

        public System.IO.Stream VerificacionCajas(string bodega)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            Result result = _transaccionRecepcion.VerificacionCajas(bodega);
            string json = ser.Serialize(result);
            byte[] resultBytes = Encoding.UTF8.GetBytes(json);
            //WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";
            WebOperationContext.Current.OutgoingResponse.ContentType = "text/html";

            return new MemoryStream(resultBytes);
        }

        public System.IO.Stream GuardarPendientesVerificacion(List<TraspasoModel> traspasosModel)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            Result result = _transaccionRecepcion.GuardarPendientesVerificacion(traspasosModel);
            string json = ser.Serialize(result);
            byte[] resultBytes = Encoding.UTF8.GetBytes(json);
            //WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";
            WebOperationContext.Current.OutgoingResponse.ContentType = "text/html";

            return new MemoryStream(resultBytes);
        }

        public bool ListaPendientesVerificacionVencidos()
        {
            try
            {
                _transaccionRecepcion.ListaPendientesVerificacionVencidos();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public System.IO.Stream ConsultarArticulos(string codbarras)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            //WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";
            WebOperationContext.Current.OutgoingResponse.ContentType = "text/html";
            Result resultado;

            try
            {


                tbl_articulos articulosbarra = _transaccionInventarioMovil.ConsultarArticulos(codbarras);
                if (articulosbarra == null)
                {
                    resultado = new Result();
                    resultado.respuesta = "error";
                    resultado.mensaje = "El código de barras es incorrecto o no existe.";
                    string json = ser.Serialize(resultado);
                    byte[] resultBytes = Encoding.UTF8.GetBytes(json);
                    return new MemoryStream(resultBytes);
                }
                else
                {
                    if (articulosbarra.status.Equals("I"))
                    {
                        resultado = new Result();
                        resultado.respuesta = "error";
                        resultado.mensaje = "El producto se encuentra en estado inactivo. Por favor retire de la percha.";
                        string json = ser.Serialize(resultado);
                        byte[] resultBytes = Encoding.UTF8.GetBytes(json);
                        return new MemoryStream(resultBytes);
                    }
                    else if (articulosbarra.status.Equals("P"))
                    {
                        resultado = new Result();
                        resultado.respuesta = "error";
                        resultado.mensaje = "El producto se encuentra en cambio de precio. Por favor ingrese otro producto.";
                        string json = ser.Serialize(resultado);
                        byte[] resultBytes = Encoding.UTF8.GetBytes(json);
                        return new MemoryStream(resultBytes);
                    }

                    if (articulosbarra.art_autoservicio.Equals("S"))
                    {
                        resultado = new Result();
                        resultado.respuesta = "ok";
                        resultado.mensaje = articulosbarra;
                        string json = ser.Serialize(resultado);
                        byte[] resultBytes = Encoding.UTF8.GetBytes(json);
                        return new MemoryStream(resultBytes);

                    }
                    else
                    {
                        resultado = new Result();
                        resultado.respuesta = "error";
                        resultado.mensaje = "El artículo escaneado no es de autoservicio.";
                        string json = ser.Serialize(resultado);
                        byte[] resultBytes = Encoding.UTF8.GetBytes(json);
                        return new MemoryStream(resultBytes);
                    }

                }

            }
            catch (Exception ex)
            {
                resultado = new Result();
                resultado.respuesta = "error";
                resultado.mensaje = ex.Message;
                string json = ser.Serialize(resultado);
                byte[] resultBytes = Encoding.UTF8.GetBytes(json);
                return new MemoryStream(resultBytes);

            }
        }

        public System.IO.Stream ValidarAutoservicio(string codOficina)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            //WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";
            WebOperationContext.Current.OutgoingResponse.ContentType = "text/html";

            Result resultado;

            try
            {

                Oficinas oficina = _transaccionInventarioMovil.ValidarAutoservicio(codOficina);
                if (oficina == null)
                {
                    resultado = new Result();
                    resultado.respuesta = "error";
                    resultado.mensaje = "La farmacia no es de autoservicios.";
                    string json = ser.Serialize(resultado);
                    byte[] resultBytes = Encoding.UTF8.GetBytes(json);
                    return new MemoryStream(resultBytes);
                }
                else
                {
                    resultado = new Result();
                    resultado.respuesta = "ok";
                    resultado.mensaje = oficina;
                    string json = ser.Serialize(resultado);
                    byte[] resultBytes = Encoding.UTF8.GetBytes(json);
                    return new MemoryStream(resultBytes);
                }

            }
            catch (Exception ex)
            {
                resultado = new Result();
                resultado.respuesta = "error";
                resultado.mensaje = ex.Message;
                string json = ser.Serialize(resultado);
                byte[] resultBytes = Encoding.UTF8.GetBytes(json);
                return new MemoryStream(resultBytes);

            }
        }

        /*public System.IO.Stream GuardarEtiquetasPrecios(EtiquetasModel etiquetasModel)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            //WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";
            WebOperationContext.Current.OutgoingResponse.ContentType = "text/html";
            Result resultado;

            try
            {
                List<EtiquetasModel>
                   
                   resultado  = _transaccionInventarioMovil.GuardarEtiquetasPrecios(etiquetasModel.codigo_articulo,
                    etiquetasModel.codigo_barras, etiquetasModel.cantidad, etiquetasModel.descripcion, etiquetasModel.usuario_registro);

                string json = ser.Serialize(resultado);
                byte[] resultBytes = Encoding.UTF8.GetBytes(json);
                return new MemoryStream(resultBytes);

            }
            catch (Exception ex)
            {
                resultado = new Result();
                resultado.respuesta = "error";
                resultado.mensaje = ex.Message;
                string json = ser.Serialize(resultado);
                byte[] resultBytes = Encoding.UTF8.GetBytes(json);
                return new MemoryStream(resultBytes);
            }
        }*/

        public System.IO.Stream GuardarEtiquetasPrecios(List<EtiquetasModel> etiquetasModel)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            //WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";
            WebOperationContext.Current.OutgoingResponse.ContentType = "text/html";
            Result resultado;
            resultado = new Result();
            List<Result> listaresultados = new List<Result>();
            List<tbl_ImpresionEtiquetas> tblImpresionEtiquetas = new List<tbl_ImpresionEtiquetas>();
            try
            {
                etiquetasModel.ForEach(x =>
                {
                    tbl_ImpresionEtiquetas temporal = new tbl_ImpresionEtiquetas
                    {
                        cantidad = x.cantidad,
                        codigo_articulo = x.codigo_articulo,
                        codigo_barras = x.codigo_barras.Replace("\n", "").Trim(),
                        descripcion = x.descripcion,
                        usuario_registro = x.usuario_registro,
                    };

                    tblImpresionEtiquetas.Add(temporal);
                });
                resultado = _transaccionInventarioMovil.GuardarEtiquetasPrecios(tblImpresionEtiquetas);
                listaresultados.Add(resultado);
                string json = ser.Serialize(listaresultados);
                byte[] resultBytes = Encoding.UTF8.GetBytes(json);
                return new MemoryStream(resultBytes);

            }
            catch (Exception ex)
            {
                resultado = new Result();
                resultado.respuesta = "error";
                resultado.mensaje = ex.Message;
                string json = ser.Serialize(resultado);
                byte[] resultBytes = Encoding.UTF8.GetBytes(json);
                return new MemoryStream(resultBytes);
            }
        }
    }
}
