using Configuracion;
using Configuracion.Models;
using Entidades.EasyGestionEmpresarial;
using Servicio.Interfaz;
using Servicio.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Transactions;
using Transaccion.Interfaz;

namespace Transaccion.Implementacion
{
    public class TransaccionInventarioMovil : ITransaccionInventarioMovil
    {
        IServicioInventarioMovil _iservicioInventarioMovil;
        IServicioRecepcion _iServicioRecepcion;

        public TransaccionInventarioMovil(IServicioInventarioMovil iservicioInventarioMovil, IServicioRecepcion iServicioRecepcion)
        {
            _iservicioInventarioMovil = iservicioInventarioMovil;
            _iServicioRecepcion = iServicioRecepcion;
        }

        public bool TestConexionSAP()
        {
            _iservicioInventarioMovil.Inicializar();
            return _iservicioInventarioMovil.TestConexionSAP();
        }

        #region INVENTARIO MOVIL

        public Response Ips(Request request)
        {
            _iservicioInventarioMovil.Inicializar();
            return _iservicioInventarioMovil.Ips(request);
        }

        public Result AutentificarUsuario(string usuario, string contrasena, string ipWS, string ipMovil, string ipMovil2)
        {
            try
            {
                _iservicioInventarioMovil.Inicializar();
                return _iservicioInventarioMovil.AutentificarUsuario(usuario, contrasena, ipWS, ipMovil, ipMovil2);
            }
            catch (Exception ex)
            {
                Result resultado = new Result
                {
                    respuesta = "error",
                    mensaje = ex.Message
                };
                return resultado;
            }
        }

        public Result AutentificarUsuarioFarmascan(string usuario, string contrasena, string ipWS, string ipMovil, string ipMovil2)
        {
            try
            {
                _iservicioInventarioMovil.Inicializar();
                return _iservicioInventarioMovil.AutentificarUsuarioFarmascan(usuario, contrasena, ipWS, ipMovil, ipMovil2);
            }
            catch (Exception ex)
            {
                Result resultado = new Result
                {
                    respuesta = "error",
                    mensaje = ex.Message
                };
                return resultado;
            }
        }

        public Result ListadoPlanificaciones()
        {
            _iservicioInventarioMovil.Inicializar();
            return _iservicioInventarioMovil.ListadoPlanificaciones();
        }

        public Result ListadoArticulosPlanificacion(string id_plan, string origen)
        {
            _iservicioInventarioMovil.Inicializar();
            return _iservicioInventarioMovil.ListadoArticulosPlanificacion(id_plan, origen);
        }

        public Result RestringirArticulosContar(string id_plan, string origen, string usuario, string ip)
        {

            //using (TransactionScope t = new TransactionScope())
            //{
                try
                {
                    _iservicioInventarioMovil.Inicializar();
                    Result result = _iservicioInventarioMovil.RestringirArticulosContar(id_plan, origen, usuario, ip);
                    //t.Complete();
                    return result;
                }
                catch (Exception ex)
                {

                    registrarLog("RestringirArticulosContar exc: " + ex.Message + " -- " + ex.StackTrace);
                    Result resultado = new Result
                    {
                        respuesta = "error",
                        mensaje = "Error al restringir. [" + ex.Message + "]"
                    };
                    //t.Dispose();
                    return resultado;

                }
            //}

        }

        public Result ActualizarPlanificacionaContar(string id_plan, string origen)
        {

            try
            {
                _iservicioInventarioMovil.Inicializar();
                Result result = _iservicioInventarioMovil.ActualizarPlanificacionaContar(id_plan, origen);

                return result;
            }
            
            catch (DbEntityValidationException e)
            {
                string cadena = "";
                foreach (var eve in e.EntityValidationErrors)
                {
                    cadena += "Entity of type \"{0}\" in state \"{1}\" has the following validation errors:\n" +
                        eve.Entry.Entity.GetType().Name + eve.Entry.State;
                    foreach (var ve in eve.ValidationErrors)
                    {
                        cadena += "- Property: \"{0}\", Error: \"{1}\"" +
                            ve.PropertyName + ve.ErrorMessage;
                    }
                }

                registrarLog("ActualizarPlanificacionaContar exc: " + cadena);
                Result resultado = new Result
                {
                    respuesta = "error",
                    mensaje = "Error al actualizar la planificación. [" + cadena + "]"
                };
                return resultado;
            }
        }

        public Result SubirConteoInventario(cls_Cabecera conteoInventario)
        {
            _iservicioInventarioMovil.Inicializar();
            try
            {
                Result result = _iservicioInventarioMovil.SubirConteoInventario(conteoInventario);
                return result;
            }
            catch (Exception ex)
            {
                registrarLog("ListadoPlanificaciones exc: " + ex.Message + " -- " + ex.StackTrace);
                Result resultado = new Result
                {
                    respuesta = "error",
                    mensaje = "Error al SubirConteoInventario. [" + ex.Message + "]"
                };
                return resultado;
            }
        }

        private void registrarLog(string resp)
        {
            System.Diagnostics.EventLog objLog = new System.Diagnostics.EventLog();
            if (!EventLog.SourceExists("PMOV_INVENTARIO_MOVIL"))
                EventLog.CreateEventSource("PMOV_INVENTARIO_MOVIL", "Application");
            objLog.Source = "PMOV_INVENTARIO_MOVIL";

            objLog.WriteEntry("RESP: " + resp, EventLogEntryType.Warning);
        }

        public Result ImagenArticulo(string codigo)
        {
            _iServicioRecepcion.Inicializar();
            return _iServicioRecepcion.ImagenArticulo(codigo);
        }


        #endregion

        #region IMPRESION DE ETIQUETAS

        public tbl_articulos ConsultarArticulos(string codbarras)
        {
           return _iservicioInventarioMovil.ConsultarArticulos(codbarras);

        }
        public Oficinas ValidarAutoservicio(string codOficina)
        {
            return _iservicioInventarioMovil.ValidarAutoservicio(codOficina);
        }
        public Result GuardarEtiquetasPrecios(List<tbl_ImpresionEtiquetas> etiquetas)
        {
            return _iservicioInventarioMovil.GuardarEtiquetasPrecios(etiquetas);
        }
        #endregion

    }
}
