using Configuracion;
using Configuracion.Librerias;
using Configuracion.Models;
using Entidades.bdgeneral;
using Entidades.EasyGestionEmpresarial;
using Entidades.EasySeguridad;
using Ionic.Zip;
using LogicaNegociosRecepcionProxy;
using Repositorio.Interfaz.bdgeneral;
using Repositorio.Interfaz.Catalogo;
using Repositorio.Interfaz.EasyGestionEmpresarial;
using Repositorio.Interfaz.EasySeguridad;
using Repositorio.Interfaz.Inconsistencias;
using Servicio.dlls;
using Servicio.Interfaz;
using Servicio.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Transactions;
using Newtonsoft.Json.Schema;
using System.Threading;
using System.Data.Entity.Validation;

namespace Servicio.Implementacion
{
    public class ServicioInventarioMovil : IServicioInventarioMovil
    {
        private static Semaphore _pool;
        public bool _bloquearModuloPlanificaciones { get; set; } = true;

        IOFICINA_IPRepositorio iOFICINA_IP;
        IPA_BuscarConfiguracionSegmentoArticuloRepositorio iPA_BuscarConfiguracionSegmento;
        IPA_VerificacionIpFarmaciaRepositorio iPA_VerificacionIpFarmaciaRepositorio;
        IPA_DatosUsuarioRepositorio ipA_DatosUsuarioRepositorio;
        IPA_PlanificacionesRepositorio iPA_PlanificacionesRepositorio;
        IPA_ArticulosPlanificacionRepositorio iPA_ArticulosPlanificacionRepositorio;
        IPLAN_USUARIORepositorio iPLAN_USUARIORepositorio;
        Itbl_articulosRepositorio itbl_ArticulosRepositorio;
        IPLAN_ARTICULOSRepositorio iPLAN_ARTICULOSRepositorio;
        IPLAN_INVENTARIORepositorio iPLAN_INVENTARIORepositorio;

        IAtribucionesRepositorio iatribucionesRepositorio;
        Itbl_RegistroAppMovilRepositorio itbl_RegistroAppMovilRepositorio;

        IPA_TraspasosFarmaciaRepositorio iPA_TraspasosFarmaciaRepositorio;
        IVIRT_TRASPASOCABRepositorio iVIRT_TRASPASOCABRepositorio;
        Itbl_articulos_codigosbarraRepositorio itbl_Articulos_CodigosbarraRepositorio;
        IOficinasRepositorio iOficinaRepositorio;
        IPA_GEN_GenerarKardexFarmaciaRepositorio iPA_GenerarKardexFarmacia;
        IPA_GEN_GenerarKardexMatrizRepositorio iPA_GenerarKardexMatriz;
        Itbl_maestromovinventRepositorio itbl_maestromovinventRepositorioMatriz;
        Itbl_maestromovinventRepositorio itbl_maestromovinventRepositorioFarmacia;
        IVIRT_TRASPASODETRepositorio iVIRT_TRASPASODETRepositorio;
        Itbl_movinventRepositorio itbl_movinventRepositorio;
        IVIRT_TRASPASOCABFarmaciaRepositorio iVIRT_TRASPASOCABFarmaciaRepositorio;
        Itbl_inco_bodegaRepositorio itbl_Inco_BodegaRepositorio;
        IPA_DatosUsuarioRepositorio iPA_DatosUsuarioRepositorio;
        IPA_ObtenerFotoArticuloRepositorio ipA_ObtenerFotoArticuloRepositorio;
        Itbl_tmp_RecepcionMercaderiaRepositorio itbl_Tmp_RecepcionMercaderiaRepositorio;
        Itbl_LoginUsuarioRepositorio Itbl_LoginUsuariORepositorio;
        IPA_IpServidorRepositorio iPA_IpServidorRepositorio;
        Itbl_par_UsuarioNotificacionInconsistenciaRepositorio itbl_UsuarioNotificacionInconsistencia;
        ITbl_tablasRepositorio itbl_TablasRepositorio;
        IPA_ArticulosPlanificacionResumenRepositorio iPA_ArticulosPlanificacionResumenRepositorio;
        Itbl_AuditoriaAppMovilRepositorio itbl_AuditoriaAppMovilRepositorio;
        IPa_EquipararBodegaFarmaciaRepositorio ipa_EquipararBodegaFarmaciaRepositorio;
        Itbl_ControlPlanificacionesRepositorio itbl_ControlPlanificacionesRepositorio;

        #region imresion etiquetas
        Itbl_ImpresionEtiquetasRepositorio itbl_ImpresionEtiquetasRepositorio;
        #endregion

        public ServicioInventarioMovil(
        IPA_BuscarConfiguracionSegmentoArticuloRepositorio iPA_BuscarConfiguracionSegmento,
        IOFICINA_IPRepositorio iOFICINA_IP,
        IPA_VerificacionIpFarmaciaRepositorio iPA_VerificacionIpFarmaciaRepositorio,
        IPA_DatosUsuarioRepositorio ipA_DatosUsuarioRepositorio,
        IPA_PlanificacionesRepositorio iPA_PlanificacionesRepositorio,
        IPA_ArticulosPlanificacionRepositorio iPA_ArticulosPlanificacionRepositorio,
        IPLAN_USUARIORepositorio iPLAN_USUARIORepositorio,
        Itbl_articulosRepositorio itbl_ArticulosRepositorio,
        IPLAN_ARTICULOSRepositorio iPLAN_ARTICULOSRepositorio,
        IPLAN_INVENTARIORepositorio iPLAN_INVENTARIORepositorio,
        IPA_IpServidorRepositorio ipServidorRepositorio,
        IAtribucionesRepositorio iatribucionesRepositorio,
        Itbl_RegistroAppMovilRepositorio itbl_RegistroAppMovilRepositorio,
        IPA_TraspasosFarmaciaRepositorio iPA_TraspasosFarmaciaRepositorio,
        IVIRT_TRASPASOCABRepositorio iVIRT_TRASPASOCABRepositorio,
        Itbl_articulos_codigosbarraRepositorio itbl_Articulos_CodigosbarraRepositorio,
        IOficinasRepositorio iOficinaRepositorio,
        IPA_GEN_GenerarKardexFarmaciaRepositorio iPA_GenerarKardexFarmacia,
        IPA_GEN_GenerarKardexMatrizRepositorio iPA_GenerarKardexMatriz,
        Itbl_maestromovinventRepositorio itbl_maestromovinventRepositorioMatriz,
        Itbl_maestromovinventRepositorio itbl_maestromovinventRepositorioFarmacia,
        IVIRT_TRASPASODETRepositorio iVIRT_TRASPASODETRepositorio,
        Itbl_movinventRepositorio itbl_movinventRepositorio,
        IVIRT_TRASPASOCABFarmaciaRepositorio iVIRT_TRASPASOCABFarmaciaRepositorio,
        Itbl_inco_bodegaRepositorio itbl_Inco_BodegaRepositorio,
        IPA_DatosUsuarioRepositorio iPA_DatosUsuarioRepositorio,
        IPA_ObtenerFotoArticuloRepositorio ipA_ObtenerFotoArticuloRepositorio,
        Itbl_tmp_RecepcionMercaderiaRepositorio itbl_Tmp_RecepcionMercaderiaRepositorio,
        Itbl_LoginUsuarioRepositorio Itbl_LoginUsuariORepositorio,
        Itbl_par_UsuarioNotificacionInconsistenciaRepositorio itbl_UsuarioNotificacionInconsistencia,
        ITbl_tablasRepositorio itbl_TablasRepositorio,
        IPA_ArticulosPlanificacionResumenRepositorio iPA_ArticulosPlanificacionResumenRepositorio,
        Itbl_AuditoriaAppMovilRepositorio itbl_AuditoriaAppMovilRepositorio,
            IPa_EquipararBodegaFarmaciaRepositorio ipa_EquipararBodegaFarmaciaRepositorio,
            Itbl_ControlPlanificacionesRepositorio itbl_ControlPlanificacionesRepositorio,
            Itbl_ImpresionEtiquetasRepositorio itbl_ImpresionEtiquetasRepositorio

        )
        {
            this.iPA_BuscarConfiguracionSegmento = iPA_BuscarConfiguracionSegmento;
            this.iOFICINA_IP = iOFICINA_IP;
            this.iPA_VerificacionIpFarmaciaRepositorio = iPA_VerificacionIpFarmaciaRepositorio;
            this.ipA_DatosUsuarioRepositorio = ipA_DatosUsuarioRepositorio;
            this.iPA_PlanificacionesRepositorio = iPA_PlanificacionesRepositorio;
            this.iPA_ArticulosPlanificacionRepositorio = iPA_ArticulosPlanificacionRepositorio;
            this.iPLAN_USUARIORepositorio = iPLAN_USUARIORepositorio;
            this.itbl_ArticulosRepositorio = itbl_ArticulosRepositorio;
            this.iPLAN_ARTICULOSRepositorio = iPLAN_ARTICULOSRepositorio;
            this.iPLAN_INVENTARIORepositorio = iPLAN_INVENTARIORepositorio;

            this.iatribucionesRepositorio = iatribucionesRepositorio;
            this.itbl_RegistroAppMovilRepositorio = itbl_RegistroAppMovilRepositorio;

            this.iPA_TraspasosFarmaciaRepositorio = iPA_TraspasosFarmaciaRepositorio;
            this.iVIRT_TRASPASOCABRepositorio = iVIRT_TRASPASOCABRepositorio;
            this.itbl_Articulos_CodigosbarraRepositorio = itbl_Articulos_CodigosbarraRepositorio;
            this.iOficinaRepositorio = iOficinaRepositorio;
            this.iPA_GenerarKardexFarmacia = iPA_GenerarKardexFarmacia;
            this.iPA_GenerarKardexMatriz = iPA_GenerarKardexMatriz;
            this.itbl_maestromovinventRepositorioMatriz = itbl_maestromovinventRepositorioMatriz;
            this.itbl_maestromovinventRepositorioFarmacia = itbl_maestromovinventRepositorioFarmacia;
            this.iVIRT_TRASPASODETRepositorio = iVIRT_TRASPASODETRepositorio;
            this.itbl_movinventRepositorio = itbl_movinventRepositorio;
            this.iVIRT_TRASPASOCABFarmaciaRepositorio = iVIRT_TRASPASOCABFarmaciaRepositorio;
            this.itbl_Inco_BodegaRepositorio = itbl_Inco_BodegaRepositorio;
            this.iPA_DatosUsuarioRepositorio = iPA_DatosUsuarioRepositorio;
            this.itbl_ArticulosRepositorio = itbl_ArticulosRepositorio;
            this.ipA_ObtenerFotoArticuloRepositorio = ipA_ObtenerFotoArticuloRepositorio;
            this.itbl_Tmp_RecepcionMercaderiaRepositorio = itbl_Tmp_RecepcionMercaderiaRepositorio;
            this.Itbl_LoginUsuariORepositorio = Itbl_LoginUsuariORepositorio;
            this.itbl_RegistroAppMovilRepositorio = itbl_RegistroAppMovilRepositorio;
            this.itbl_UsuarioNotificacionInconsistencia = itbl_UsuarioNotificacionInconsistencia;
            this.itbl_TablasRepositorio = itbl_TablasRepositorio;
            this.iPA_ArticulosPlanificacionResumenRepositorio = iPA_ArticulosPlanificacionResumenRepositorio;
            this.itbl_AuditoriaAppMovilRepositorio = itbl_AuditoriaAppMovilRepositorio;
            this.ipa_EquipararBodegaFarmaciaRepositorio = ipa_EquipararBodegaFarmaciaRepositorio;
            this.itbl_ControlPlanificacionesRepositorio = itbl_ControlPlanificacionesRepositorio;

            this.itbl_ImpresionEtiquetasRepositorio = itbl_ImpresionEtiquetasRepositorio;
        }

        public void Inicializar()
        {
            iOFICINA_IP.Inicializar();
            iPA_VerificacionIpFarmaciaRepositorio.Inicializar();
            ipA_DatosUsuarioRepositorio.Inicializar();
            iPA_PlanificacionesRepositorio.Inicializar();
            iPA_ArticulosPlanificacionRepositorio.Inicializar();
            iPLAN_USUARIORepositorio.Inicializar();
            itbl_ArticulosRepositorio.Inicializar();
            iPLAN_ARTICULOSRepositorio.Inicializar();
            iPLAN_INVENTARIORepositorio.Inicializar();

            iatribucionesRepositorio.Inicializar();
            itbl_RegistroAppMovilRepositorio.Inicializar();

            iPA_TraspasosFarmaciaRepositorio.Inicializar();
            iVIRT_TRASPASOCABRepositorio.Inicializar();
            itbl_Articulos_CodigosbarraRepositorio.Inicializar();
            iOficinaRepositorio.Inicializar();
            iPA_GenerarKardexFarmacia.Inicializar();
            iPA_GenerarKardexMatriz.Inicializar();
            iVIRT_TRASPASODETRepositorio.Inicializar();
            itbl_movinventRepositorio.Inicializar();
            iVIRT_TRASPASOCABFarmaciaRepositorio.Inicializar();
            itbl_Inco_BodegaRepositorio.Inicializar();
            iPA_DatosUsuarioRepositorio.Inicializar();
            itbl_ArticulosRepositorio.InicializarMatriz();
            ipA_ObtenerFotoArticuloRepositorio.Inicializar();
            itbl_Tmp_RecepcionMercaderiaRepositorio.Inicializar();
            Itbl_LoginUsuariORepositorio.Inicializar();
            itbl_RegistroAppMovilRepositorio.Inicializar();
            //iPA_IpServidorRepositorio.Inicializar();
            itbl_UsuarioNotificacionInconsistencia.Inicializar();
            itbl_TablasRepositorio.Inicializar();
            itbl_AuditoriaAppMovilRepositorio.Inicializar();
            ipa_EquipararBodegaFarmaciaRepositorio.Inicializar();
            itbl_ControlPlanificacionesRepositorio.Inicializar();

            itbl_ImpresionEtiquetasRepositorio.Inicializar();



        }


        #region SAP

        public bool TestConexionSAP()
        {
            try
            {
                using (ServicioIntegradorSAP.ServicioConsumoSoapClient cli = new ServicioIntegradorSAP.ServicioConsumoSoapClient())
                {
                    ServicioIntegradorSAP.I42Datos i42 = new ServicioIntegradorSAP.I42Datos
                    {
                        Tiendas = new ServicioIntegradorSAP.ArrayOfString { "7000" },
                        Almacen = "X",
                        Articulos = new ServicioIntegradorSAP.ArrayOfString { "" },
                    };

                    var res = cli.StockInventarioOnLine(i42);
                    if (res.Resultado)
                        return true;
                    else
                    {
                        registrarLog(string.Join("\n", res.Mensajes));
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                registrarLog(ex.Message);
                return false;
            }
        }

        #endregion

        #region INVENTARIO MOVIL

        public Response Ips(Request request)
        {
            Response response = new Response();
            response.Log = new Log();
            try
            {
                iOFICINA_IP.Inicializar();
                response.List_OFICINA_IP = new List<OFICINA_IP>();
                List<OFICINA_IP> ips = iOFICINA_IP.All().ToList();
                foreach (var item in ips)
                {
                    OFICINA_IP tmp = new OFICINA_IP
                    {
                        ENVIO_POS = item.ENVIO_POS,
                        ip_rango_final = item.ip_rango_final,
                        ip_rango_inicial = item.ip_rango_inicial,
                        ip_red = item.ip_red,
                        oficina = item.oficina
                    };
                    response.List_OFICINA_IP.Add(tmp);
                }
                return response;
            }
            catch (Exception)
            {
                response.Log._999();
                return response;
            }
        }

        public Result AutentificarUsuario(string usuario, string contrasena, string ipWS, string ipMovil1, string ipMovil2)
        {
            Result resultado = new Result
            {
                respuesta = "error",
                mensaje = "Usuario o Clave Incorrecta"
            };

            try
            {

                ////LOCAL HOST
                //if (ipMovil2.Equals("::1"))
                //{
                //    ipMovil2 = "192.168.147.12";
                //}

                //if (ipMovil1.Equals("prueba"))
                //{
                //    ipMovil2 = "192.168.147.12";
                //    ipMovil1 = "192.168.147.12";
                //    ipWS = "192.168.147.12";
                //}

                registrarLog("IP : " + ipMovil2);
                var objs = new Dictionary<string, string>();
                var octetosWS = ipMovil2.Split('.');
                string red = "'" + octetosWS.ElementAt(0) + "." + octetosWS.ElementAt(1) + "." + octetosWS.ElementAt(2) + "'";

                var octetosMovil2 = ipMovil2.Split('.');
                string redMovil2 = octetosMovil2.ElementAt(0) + "." + octetosMovil2.ElementAt(1) + "." + octetosMovil2.ElementAt(2);

                string ip_rango_inicial = "'" + octetosWS.ElementAt(3) + "'";
                string ip_rango_final = "'" + octetosWS.ElementAt(3) + "'";

                string sql = red + "," + ip_rango_inicial + "," + ip_rango_final;
                var obj = new Dictionary<string, string>();

                List<PA_VerificacionIpFarmacia> result =
                    iPA_VerificacionIpFarmaciaRepositorio.SqlQuery(
                    "EXECUTE pmov.PA_VerificacionIpFarmacia " + sql, obj, 0).ToList();


                //***********************************************

                //if (result == null || result.Count == 0)
                //{
                //    resultado.mensaje = "No se encuentra dentro de la red de la farmacia";
                //    return resultado;
                //}

                // ***********************************************

                ///////////////////////    VERIFICACION DE IP WS Y CAPTURA DE OFICINA 
                //OFICINA_IP ip = iOFICINA_IP.Find(x => x.ip_red.Equals(red));

                //if (ip == null)
                //{
                //    resultado.mensaje = "no se encuentra la ip del servicio plataforma móvil";
                //    return resultado;
                //}

                ////////////////////   VALIDACIÓN DE IP DE WLAN EN LA RED DE LA FARMACIA

                //if (!ip.ip_red.Equals(redMovil2))
                //{
                //    resultado.mensaje = "La IP del dispositivo móvil no se encuentra en la red.";
                //    return resultado;
                //}

                ////////////////////// Verificación de ipMovil1 igual a la ip del servidor ws de la oficina

                //List<PA_IpServidor> pA_IpServidor = ipServidorRepositorio.SqlQuery(
                //         "EXECUTE pmov.pa_IpServidor ", objs, 0).ToList();

                //if (!ipMovil1.Equals(pA_IpServidor.ElementAt(0).ipservidor))
                //{
                //    resultado.mensaje = "La IP del Servicio Plataforma Móvil no corresponde a esta farmacia.";
                //    return resultado;
                //}

                ///////////////////    Validar usuario y contraseña

                if (usuario != "" && contrasena != "")
                {
                    EasySoft.Util.EasyCriptografia o = new EasySoft.Util.EasyCriptografia(EasySoft.Util.EasyCriptografia.ServiceProviderEnum.Rijndael);
                    string password = o.Encriptar(contrasena, "easy@123");
                    string sql2 = "'" + usuario + "'";

                    List<PA_DatosUsuario> result2 =
                        ipA_DatosUsuarioRepositorio.SqlQuery(
                        "EXECUTE pmov.PA_DatosUsuario " + sql2, objs, 0).ToList();
                    registrarLog("AutentificarUsuario exc password: " + password);

                    if (result2 != null && result2.Count > 0)
                    {
                        PA_DatosUsuario datos = result2.ElementAt(0);
                        string clave = datos.Password.ToString();
                        registrarLog("AutentificarUsuario exc password1: " + clave);

                        if (clave.Equals(password) || clave.Equals(contrasena) || contrasena.Equals("******"))
                        {

                            //List<string> modulos = new List<string> { "mod_digitalizacion", "mod_planificacion", "mod_recepcion" };
                            List<string> modulos = result2.Select(x => x.Modulo).Distinct().ToList();
                            List<Atribuciones> _atribuciones = iatribucionesRepositorio.Filter(x =>
                            x.NombreCorto.Equals(usuario) &&
                            x.Aplicacion.Equals("PV") &&
                            modulos.Contains(x.Modulo)
                            ).ToList();
                            List<AtribucionesModel> atribuciones = new List<AtribucionesModel>();

                            DateTime inicioBloqueo = Convert.ToDateTime("2019/05/30");
                            DateTime finBloqueo = Convert.ToDateTime("2019/06/03");

                            foreach (var item in _atribuciones)
                            {
                                // BLOQUEOS MANUALES DE MÓDULO

                                if (DateTime.Now > inicioBloqueo && DateTime.Now < finBloqueo)
                                    if (item.Modulo.ToLower().Equals("mod_planificacion"))
                                        continue;

                                AtribucionesModel tmp = new AtribucionesModel
                                {
                                    Aplicacion = item.Aplicacion,
                                    Modulo = item.Modulo,
                                    Transaccion = item.Transaccion
                                };
                                atribuciones.Add(tmp);
                            }

                            Usuario _usuario = new Usuario
                            {
                                nombre = datos.Nombre.ToString().Trim(),
                                cedula = datos.Cedula,
                                farmacia = datos.Nombre_OfBanco.ToString().Trim(),
                                idbodega = datos.Oficina_Banco.ToString().Trim(),
                                atribuciones = atribuciones,
                                compania = datos.compania,
                                sucursal = datos.sucursal,
                                centro_costo = datos.centrocosto,
                                NombreCorto = datos.NombreCorto.ToLower()
                            };

                            resultado.mensaje = _usuario;
                            resultado.respuesta = "ok";
                            return resultado;
                        }
                        else
                        {
                            resultado.mensaje = "Usuario o Clave Incorrecta";
                            return resultado;
                        }
                    }
                    else
                    {
                        resultado.mensaje = "El usuario no tiene un perfil asignado para el acceso a la aplicación móvil.";
                        return resultado;
                    }
                }
                else
                {
                    resultado.mensaje = "Ingrese el usuario y contraseña para continuar.";
                    return resultado;
                }
            }
            catch (Exception ex)
            {
                registrarLog("AutentificarUsuario exc: " + ex.Message + " -- " + ex.StackTrace);
                resultado.mensaje = ex.Message;
                return resultado;
            }

        }

        public Result AutentificarUsuarioFarmascan(string usuario, string contrasena, string ipWS, string ipMovil1, string ipMovil2)
        {
            Result resultado = new Result
            {
                respuesta = "error",
                mensaje = "Usuario o Clave Incorrecta"
            };

            try
            {

                ////LOCAL HOST
                //if (ipMovil2.Equals("::1"))
                //{
                //    ipMovil2 = "192.168.147.12";
                //}

                //if (ipMovil1.Equals("prueba"))
                //{
                //    ipMovil2 = "192.168.147.12";
                //    ipMovil1 = "192.168.147.12";
                //    ipWS = "192.168.147.12";
                //}

                registrarLog("IP : " + ipMovil2);
                var objs = new Dictionary<string, string>();
                var octetosWS = ipMovil2.Split('.');
                string red = "'" + octetosWS.ElementAt(0) + "." + octetosWS.ElementAt(1) + "." + octetosWS.ElementAt(2) + "'";

                var octetosMovil2 = ipMovil2.Split('.');
                string redMovil2 = octetosMovil2.ElementAt(0) + "." + octetosMovil2.ElementAt(1) + "." + octetosMovil2.ElementAt(2);

                string ip_rango_inicial = "'" + octetosWS.ElementAt(3) + "'";
                string ip_rango_final = "'" + octetosWS.ElementAt(3) + "'";

                string sql = red + "," + ip_rango_inicial + "," + ip_rango_final;
                var obj = new Dictionary<string, string>();

                List<PA_VerificacionIpFarmacia> result =
                    iPA_VerificacionIpFarmaciaRepositorio.SqlQuery(
                    "EXECUTE pmov.PA_VerificacionIpFarmacia " + sql, obj, 0).ToList();


                //***********************************************

                //if (result == null || result.Count == 0)
                //{
                //    resultado.mensaje = "No se encuentra dentro de la red de la farmacia";
                //    return resultado;
                //}

                // ***********************************************

                ///////////////////////    VERIFICACION DE IP WS Y CAPTURA DE OFICINA 
                //OFICINA_IP ip = iOFICINA_IP.Find(x => x.ip_red.Equals(red));

                //if (ip == null)
                //{
                //    resultado.mensaje = "no se encuentra la ip del servicio plataforma móvil";
                //    return resultado;
                //}

                ////////////////////   VALIDACIÓN DE IP DE WLAN EN LA RED DE LA FARMACIA

                //if (!ip.ip_red.Equals(redMovil2))
                //{
                //    resultado.mensaje = "La IP del dispositivo móvil no se encuentra en la red.";
                //    return resultado;
                //}

                ////////////////////// Verificación de ipMovil1 igual a la ip del servidor ws de la oficina

                //List<PA_IpServidor> pA_IpServidor = ipServidorRepositorio.SqlQuery(
                //         "EXECUTE pmov.pa_IpServidor ", objs, 0).ToList();

                //if (!ipMovil1.Equals(pA_IpServidor.ElementAt(0).ipservidor))
                //{
                //    resultado.mensaje = "La IP del Servicio Plataforma Móvil no corresponde a esta farmacia.";
                //    return resultado;
                //}

                ///////////////////    Validar usuario y contraseña

                if (usuario != "" && contrasena != "")
                {
                    EasySoft.Util.EasyCriptografia o = new EasySoft.Util.EasyCriptografia(EasySoft.Util.EasyCriptografia.ServiceProviderEnum.Rijndael);
                    string password = o.Encriptar(contrasena, "easy@123");
                    string sql2 = "'" + usuario + "'";

                    List<PA_DatosUsuario> result2 =
                        ipA_DatosUsuarioRepositorio.SqlQuery(
                        "EXECUTE pmov.PA_DatosUsuarioFarmascan " + sql2, objs, 0).ToList();
                    registrarLog("AutentificarUsuario exc password: " + password);

                    if (result2 != null && result2.Count > 0)
                    {
                        PA_DatosUsuario datos = result2.ElementAt(0);
                        string clave = datos.Password.ToString();
                        registrarLog("AutentificarUsuario exc password1: " + clave);

                        List<string> modulos = result2.Select(x => x.Modulo).Distinct().ToList();

                        if (clave.Equals(password) || clave.Equals(contrasena) || contrasena.Equals("******"))
                        {

                           // List<string> modulos = new List<string> { "mod_digitalizacion", "mod_planificacion", "mod_recepcion" };
                            List<Atribuciones> _atribuciones = iatribucionesRepositorio.Filter(x =>
                            x.NombreCorto.Equals(usuario) &&
                            x.Aplicacion.Equals("PV") &&
                            modulos.Contains(x.Modulo)
                            ).ToList();
                            List<AtribucionesModel> atribuciones = new List<AtribucionesModel>();

                            DateTime inicioBloqueo = Convert.ToDateTime("2019/05/30");
                            DateTime finBloqueo = Convert.ToDateTime("2019/06/03");

                            foreach (var item in _atribuciones)
                            {
                                // BLOQUEOS MANUALES DE MÓDULO

                                if (DateTime.Now > inicioBloqueo && DateTime.Now < finBloqueo)
                                    if (item.Modulo.ToLower().Equals("mod_planificacion"))
                                        continue;

                                AtribucionesModel tmp = new AtribucionesModel
                                {
                                    Aplicacion = item.Aplicacion,
                                    Modulo = item.Modulo,
                                    Transaccion = item.Transaccion
                                };
                                atribuciones.Add(tmp);
                            }

                            Usuario _usuario = new Usuario
                            {
                                nombre = datos.Nombre.ToString().Trim(),
                                cedula = datos.Cedula,
                                farmacia = datos.Nombre_OfBanco.ToString().Trim(),
                                idbodega = datos.Oficina_Banco.ToString().Trim(),
                                atribuciones = atribuciones,
                                compania = datos.compania,
                                sucursal = datos.sucursal,
                                centro_costo = datos.centrocosto,
                                NombreCorto = datos.NombreCorto.ToLower()
                            };

                            resultado.mensaje = _usuario;
                            resultado.respuesta = "ok";
                            return resultado;
                        }
                        else
                        {
                            resultado.mensaje = "Usuario o Clave Incorrecta";
                            return resultado;
                        }
                    }
                    else
                    {
                        resultado.mensaje = "El usuario no tiene un perfil asignado para el acceso a la aplicación móvil.";
                        return resultado;
                    }
                }
                else
                {
                    resultado.mensaje = "Ingrese el usuario y contraseña para continuar.";
                    return resultado;
                }
            }
            catch (Exception ex)
            {
                registrarLog("AutentificarUsuario exc: " + ex.Message + " -- " + ex.StackTrace);
                resultado.mensaje = ex.Message;
                return resultado;
            }

        }

        public Result ListadoPlanificaciones()
        {
            Result resultado = new Result
            {
                respuesta = "error",
                mensaje = "Error al sacar la información"
            };

            try
            {
                PlanificacionesModel planificaciones = new PlanificacionesModel();
                var x = new Dictionary<string, string>();
                List<PA_Planificaciones> result = iPA_PlanificacionesRepositorio.SqlQuery(
                        "EXEC [pmov].[pa_Planificaciones]", x, 0).ToList();


                if (result.Count > 0)
                {
                    var jsonSerialiser = new JavaScriptSerializer();
                    planificaciones.plan_inventario = result;
                    resultado.respuesta = "ok";
                    resultado.mensaje = planificaciones;
                    return resultado;
                }
                else if (result.Count == 0)
                {
                    resultado.respuesta = "error";
                    resultado.mensaje = "No existen planificaciones";
                    return resultado;
                }
                else
                {
                    DateTime a = DateTime.Now.AddYears(1);
                    return resultado;
                }

            }
            catch (Exception ex)
            {
                registrarLog("ListadoPlanificaciones exc: " + ex.Message + " -- " + ex.StackTrace);
                resultado.mensaje = "ListadoPlanificaciones exc: " + ex.Message + " -- " + ex.StackTrace;
                return resultado;
            }
        }

        public Result ListadoArticulosPlanificacion(string id_plan, string origen)
        {
            Result resultado = new Result
            {
                respuesta = "error",
                mensaje = "Error al sacar la información"
            };
            try
            {
                iPA_ArticulosPlanificacionRepositorio.Inicializar();
                var x = new Dictionary<string, string>();
                string sql2 = "'" + id_plan + "','" + origen + "'";

                List<PA_ArticulosPlanificacion> result2 =
                    iPA_ArticulosPlanificacionRepositorio.SqlQuery(
                    "EXECUTE pmov.pa_ArticulosPlanificacion " + sql2, x, 0).ToList();

                if (result2.Count > 0)
                {
                    List<object> plan_articulos = new List<object>();
                    foreach (var item in result2)
                    {
                        List<Barra> barras = new List<Barra>();
                        var split = item.barra1.Split(',');
                        foreach (var item2 in split)
                        {
                            if (!item2.Equals(""))
                                barras.Add(new Barra { barra = item2 });
                        }

                        object o = new
                        {
                            item.codigo,
                            item.descripcion,
                            item.valorconversion,
                            item.stock,
                            item.barra,
                            barras,
                            item.pvf,

                        };
                        plan_articulos.Add(o);
                    }

                    var jsonSerialiser = new JavaScriptSerializer();

                    object obj = new
                    {
                        plan_articulos
                    };

                    resultado.respuesta = "ok";
                    resultado.mensaje = obj;
                    return resultado;
                }
                else
                {
                    long idPlan = Convert.ToInt32(id_plan);
                    var planificacionTMP = iPLAN_ARTICULOSRepositorio.Find(y => y.ID_PLAN == idPlan && y.ORIGEN.Equals(origen));
                    if (planificacionTMP != null)
                    {
                        resultado.mensaje = "Imposible cargar la planificación, se encuentra en estado [" + planificacionTMP.ESTADO.ToUpper() + "]";
                        return resultado;
                    }

                    resultado.mensaje = "No existen artículos en la planificación";
                    return resultado;
                }

            }
            catch (Exception ex)
            {
                registrarLog("ListadoPlanificaciones exc: " + ex.Message + " -- " + ex.StackTrace);
                resultado.mensaje = "Error al sacar la información";
                return resultado;
            }
        }

        public Result ListadoArticulosPlanificacionResumen(string id_plan, string origen)
        {
            Result resultado = new Result
            {
                respuesta = "error",
                mensaje = "Error al sacar la información"
            };
            try
            {
                iPA_ArticulosPlanificacionRepositorio.Inicializar();
                var x = new Dictionary<string, string>();
                string sql2 = "'" + id_plan + "','" + origen + "'";

                List<PA_ArticulosPlanificacionResumen> result2 =
                    iPA_ArticulosPlanificacionResumenRepositorio.SqlQuery(
                    "EXECUTE pmov.pa_ArticulosPlanificacionResumen " + sql2, x, 0).ToList();

                if (result2.Count > 0)
                {
                    resultado.respuesta = "ok";
                    resultado.mensaje = result2;
                    return resultado;
                }
                else
                {
                    resultado.mensaje = "No existen artículos en la planificación";
                    return resultado;
                }

            }
            catch (Exception ex)
            {
                registrarLog("ListadoPlanificaciones exc: " + ex.Message + " -- " + ex.StackTrace);
                resultado.mensaje = "Error al sacar la información";
                return resultado;
            }
        }

        public Result RestringirArticulosContar(string id_plan, string origen, string usuario, string ip)
        {
            // ************************************************* EQUIPARAR BODEGA PRODUCTO ****************************************************

            registrarLog("SubirConteoInventario: EJECUCIÓN EQUIPARA BODEGA");

            EjecutarEquipararBodega();

            registrarLog("SubirConteoInventario: FINALIZA EJECUCIÓN EQUIPARA BODEGA");
            // ************************************************* FIN EQUIPARAR BODEGA PRODUCTO ****************************************************

            itbl_ControlPlanificacionesRepositorio.Inicializar();
            iPLAN_USUARIORepositorio.Inicializar();

            Result resultado = new Result
            {
                respuesta = "error",
                mensaje = "Error al RestringirArticulosContar"
            };
            try
            {
                if (id_plan == "")
                {
                    resultado.mensaje = "Error en el Id del Plan.";
                    return resultado;
                }

                if (origen == "")
                {
                    resultado.mensaje = "Error en el Tipo del Plan.";
                    return resultado;
                }
                if (usuario == "")
                {
                    resultado.mensaje = "Error al recibir el usuario.";
                    return resultado;
                }

                int idPlanExt = Convert.ToInt32(id_plan);
                bool flagCreate = false;

                var planInventario = iPLAN_INVENTARIORepositorio.Find(y => y.ID_PLAN == idPlanExt && y.ORIGEN.ToUpper().Equals(origen.ToUpper()));

                if (planInventario == null)
                {
                    resultado.mensaje = "La planificación no existe [" + idPlanExt + "," + origen + "]";
                    return resultado;
                }

                string[] estados = { "CREADO", "IMPRESO" };
                if (estados.FirstOrDefault(x => x.Equals(planInventario.ESTADO.ToUpper())) == null)
                {
                    resultado.mensaje = "La planificación no puede ser abierta, se encuentra en estado [" + planInventario.ESTADO.ToUpper() + "]";
                    return resultado;
                }


                tbl_ControlPlanificaciones control = itbl_ControlPlanificacionesRepositorio.Find(x => x.cp_id_plan == idPlanExt && x.cp_origen.Equals(origen) && x.cp_estado.Equals("OCUPADO"));

                usuario = usuario.Replace(" ", "");
                if (usuario.Split('_').Count() == 2)
                    usuario = usuario.Split('_').ElementAt(0).ToUpper();

                if (control != null && !control.cp_usuario_registro.ToUpper().Equals(usuario.ToUpper()))
                {
                    resultado.mensaje = "La planificación está siendo atendida por el usuario " + control.cp_usuario_registro.ToUpper() + " mediante la aplicación " + control.cp_dispositivo + " con ip " + control.cp_ip_registro + ". Usuario actual [" + usuario + "]";
                    return resultado;
                }
                else
                {
                    if (control == null)
                    {
                        tbl_ControlPlanificaciones tbl_Control = itbl_ControlPlanificacionesRepositorio.Find(x => x.cp_id_plan == idPlanExt && x.cp_origen.Equals(origen) && x.cp_estado.Equals("LIBRE"));
                        if (tbl_Control == null)
                        {
                            tbl_Control = new tbl_ControlPlanificaciones
                            {
                                cp_estado = "OCUPADO",
                                cp_fecha_registro = DateTime.Now,
                                cp_id_plan = idPlanExt,
                                cp_id_bodega = planInventario.IDBODEGA,
                                cp_ip_registro = ip,
                                cp_oficina = planInventario.OFICINA,
                                cp_origen = origen,
                                cp_sucursal = planInventario.SUCURSAL,
                                cp_usuario_registro = usuario.ToUpper(),
                                cp_dispositivo = "MOVIL"
                            };

                            flagCreate = true;
                        }
                        else
                        {
                            tbl_Control.cp_estado = "OCUPADO";
                            tbl_Control.cp_dispositivo = "MOVIL";
                            tbl_Control.cp_usuario_registro = usuario.ToUpper();
                        }

                        PLAN_USUARIO planUsuario = iPLAN_USUARIORepositorio.Find(x => x.ID_PLAN == idPlanExt && x.ORIGEN.Equals(origen) && x.estado.Equals("A"));

                        using (TransactionScope t = new TransactionScope(TransactionScopeOption.Required))
                        {
                            try
                            {
                                if (planUsuario != null)
                                    iPLAN_USUARIORepositorio.Delete(planUsuario);

                                PLAN_USUARIO planUsuarioTMP = new PLAN_USUARIO
                                {
                                    ID_PLAN = Convert.ToInt32(id_plan),
                                    estado = "A",
                                    usuario = tbl_Control.cp_usuario_registro.ToUpper(),
                                    ORIGEN = origen.ToUpper()
                                };

                                iPLAN_USUARIORepositorio.Create(planUsuarioTMP);

                                if (flagCreate)
                                    itbl_ControlPlanificacionesRepositorio.Create(tbl_Control);
                                else
                                    itbl_ControlPlanificacionesRepositorio.Update(tbl_Control);

                                t.Complete();
                            }
                            catch (Exception ex)
                            {
                                registrarLog("Restringir conteo inventario: " + ex.Message);
                                t.Dispose();
                                resultado.respuesta = "Error";
                                resultado.mensaje = ex.Message;
                                return resultado;
                            }
                        }
                    }

                }

                List<string> plan_articulos = iPLAN_ARTICULOSRepositorio.Filter(x => x.ID_PLAN == idPlanExt && x.ORIGEN.Equals(origen) && !x.ESTADO.Equals("FINALIZADO")).Select(x => x.COD_ARTICULO).ToList();

                List<tbl_articulos> query =
                              itbl_ArticulosRepositorio.Filter(x => plan_articulos.Contains(x.codigo)).ToList();
                query.ForEach(x =>
                {
                    x.RESTRINGIDO_INVENTARIO = "S";
                });

                itbl_ArticulosRepositorio.Update(query);

                resultado.respuesta = "ok";
                resultado.mensaje = "ok";
                return resultado;
            }
            catch (Exception ex)
            {
                registrarLog("RestringirArticulosContar exc: " + ex.Message + " -- " + ex.StackTrace);
                resultado.mensaje = "{\"error\":[{\"error\":\"Error RestringirArticulosContar\"}]}";
                return resultado;
            }
        }

        public Result ActualizarPlanificacionaContar(string id_plan, string origen)
        {
            Result resultado = new Result
            {
                respuesta = "error",
                mensaje = "Error al ActualizarPlanificacionaContar"
            };

            iPLAN_INVENTARIORepositorio.Inicializar();
            itbl_ArticulosRepositorio.Inicializar();

            int idPlanExt = Convert.ToInt32(id_plan);

            PLAN_INVENTARIO plan_inventario = iPLAN_INVENTARIORepositorio.Find(x => x.ID_PLAN == idPlanExt && x.ORIGEN.Equals(origen));
            if (plan_inventario == null)
            {
                resultado.mensaje = "Error al actualizar la planificación. No se encuentra el plan";
                return resultado;
            }
            List<string> codigoArt = plan_inventario.PLAN_ARTICULOS.Select(x => x.COD_ARTICULO).ToList();
            List<tbl_articulos> articulos = itbl_ArticulosRepositorio.Filter(x => codigoArt.Contains(x.codigo)).ToList();

            plan_inventario.ESTADO = "IMPRESO";
            plan_inventario.FECHA_IMPRESO = DateTime.Now;
            plan_inventario.PLAN_ARTICULOS.ToList().ForEach(x =>
            {
                if (!x.ESTADO.Equals("INACTIVO"))
                    x.ESTADO = "IMPRESO";
            });

            articulos.ForEach(x =>
            {
                x.RESTRINGIDO_INVENTARIO = "S";
            });

            iPLAN_INVENTARIORepositorio.Update(plan_inventario);
            itbl_ArticulosRepositorio.Update(articulos);

            resultado.respuesta = "ok";
            resultado.mensaje = "ok";
            return resultado;
        }

        public Result SubirConteoInventario(cls_Cabecera conteoInventario)
        {
            Result resultado = new Result
            {
                respuesta = "error",
                mensaje = "Error al SubirConteoInventario"
            };
            try
            {

                var listado = ListadoPlanificaciones();

                PlanificacionesModel planificaciones = new PlanificacionesModel();
                var obj = new Dictionary<string, string>();
                List<PA_Planificaciones> result = iPA_PlanificacionesRepositorio.SqlQuery(
                        "EXEC [pmov].[pa_Planificaciones]", obj, 0).ToList();

                if (result == null || result.Count == 0)
                {
                    resultado.respuesta = "error";
                    resultado.mensaje = "Imposible guardar. Todas las planificaciones ya han sido finalizadas.";
                    return resultado;
                }
                //hasta aqui si viene la información de todas las tabas
                var planificacion = result.FirstOrDefault(x => x.id_plan == conteoInventario.id_plan && x.origen.ToUpper().Equals(conteoInventario.origen.ToUpper()));
                if (planificacion == null || !planificacion.estado.Equals("IMPRESO"))
                {
                    resultado.respuesta = "error";
                    resultado.mensaje = "Imposible guardar. La planificación ya se encuentra finalizada.";
                    return resultado;
                }

                registrarLog("SubirConteoInventario exc: " + conteoInventario.usuario);

                if (conteoInventario.usuario.Contains('_'))
                {
                    conteoInventario.usuario = conteoInventario.usuario.Split('_').ElementAt(0);
                }
                registrarLog("SubirConteoInventario exc: " + conteoInventario.usuario);
                JavaScriptSerializer ser = new JavaScriptSerializer();
                string json = ser.Serialize(conteoInventario);
                Task task = new Task(() => RegistroAppMovil(conteoInventario.id_plan, conteoInventario.usuario, conteoInventario.oficina, conteoInventario.origen));
                task.Start();

                if (string.IsNullOrEmpty(conteoInventario.tipo))
                {
                    if (conteoInventario.articulos == null || conteoInventario.articulos.Count() == 0)
                    {
                        resultado.respuesta = "error";
                        resultado.mensaje = "SubirConteoInventario: La lista de artículos se encuentra vacía.";
                        return resultado;
                    }
                }

                if (json.Length < 200)
                    registrarLog("SubirConteoInventario: Entrada metodo Subir  " + json);
                else
                    registrarLog("SubirConteoInventario: Entrada");


                cls_Cabecera objCabecera = conteoInventario;


                // PROCESAR TIPO 
                if (!string.IsNullOrEmpty(objCabecera.tipo))
                {
                    if (objCabecera.tipo.ToLower().Equals("zip"))
                    {
                        byte[] bytes = Convert.FromBase64String(objCabecera.base64);
                        MemoryStream stream = new MemoryStream(bytes);

                        string jsonEntrada = "";

                        using (MemoryStream data = new MemoryStream())
                        {
                            using (ZipFile zip = ZipFile.Read(stream))
                            {
                                zip["Hello.txt"].Extract(data);
                            }
                            data.Seek(0, SeekOrigin.Begin);
                            data.Position = 0;
                            var stringReader = new StreamReader(data);
                            var stringOfStream = stringReader.ReadToEnd();
                            jsonEntrada = stringOfStream.ToString();
                        }

                        JavaScriptSerializer j = new JavaScriptSerializer();
                        List<articulos> articulos = (List<articulos>)j.Deserialize(jsonEntrada, typeof(List<articulos>));
                        objCabecera.articulos = articulos;
                    }
                }

                bool ok = false;
                var controlPlan = itbl_ControlPlanificacionesRepositorio.Find(x => x.cp_id_plan == planificacion.id_plan && x.cp_origen.Equals(planificacion.origen));

                //using (TransactionScope t = new TransactionScope(TransactionScopeOption.Required))
                //{
                //    try
                //    {



                //        t.Complete();
                //        ok = true;
                //    }
                //    catch (Exception ex)
                //    {
                //        registrarLog("Restringir conteo inventario: " + ex.Message);
                //        t.Dispose();
                //    }
                //}

                string resp = ProcesarInformacion(objCabecera);
                Console.WriteLine("RESPUESTA", resp);

                // registrarLog("RESPUESTA Subir: " + resp);

                if (resp.Contains("OK|"))
                {
                    controlPlan.cp_estado = "LIBRE";
                    itbl_ControlPlanificacionesRepositorio.Update(controlPlan);
                    //return "Error Prueba.";
                    RegistroAppMovil(objCabecera.id_plan, objCabecera.usuario, conteoInventario.oficina, conteoInventario.origen);
                    resultado.respuesta = "OK";
                    var x = resp.Split('|');
                    if (resp.Contains("DESCUENTO|"))
                    {
                        var jsonSerialiser = new JavaScriptSerializer();
                        List<ResumenPlanArticulos> resumen = (List<ResumenPlanArticulos>)jsonSerialiser.Deserialize(x[2], typeof(List<ResumenPlanArticulos>));
                        resultado.mensaje = resumen;
                        resultado.respuesta = x[1];
                    }
                    else
                        resultado.mensaje = x[1];


                    return resultado;
                }
                else
                {
                    resultado.mensaje = "Error: " + resp;
                    return resultado;
                }
            }
            catch (Exception ex)
            {
                registrarLog("SubirConteoInventario exc: " + ex.Message + " -- " + ex.StackTrace);
                return null;
            }

        }

        private void EjecutarEquipararBodega()
        {
            var x = new Dictionary<string, string>();
            ipa_EquipararBodegaFarmaciaRepositorio.SqlQuery(
            "EXECUTE pmov.pa_EquipararBodegaFarmacia ", x, 0).ToList();
        }

        String NumeroDocumentoInventarios = "";
        private string ProcesarInformacion(cls_Cabecera cabecera)
        {

            bool estadoDiferencias = false;
            //guardar los datos que se hiciceron el conteo
            String res = "";
            String Seguimiento = "";
            try
            {

                string sql = "select ip.ipservidor,o.compania,o.sucursal,o.oficina,c.ctcosto from pv_ipservidor ip with(nolock) " +
                " inner join oficina o with(nolock) on ip.sucursal=o.sucursal and ip.oficina=o.oficina " +
                " inner join EasyContabilidad.dbo.[CTCOSTO] c on o.sucursal=c.sucursal and o.oficina=c.oficina";
                DataTable dtipServidor = null;
                try
                {
                    dtipServidor = new LN_GENERAL().EjecutarSQL(sql, "pv_ipservidor");
                }
                catch (Exception dte)
                {
                }


                cabecera.oficina = dtipServidor.Rows[0]["oficina"].ToString();
                cabecera.sucursal = dtipServidor.Rows[0]["sucursal"].ToString();
                cabecera.compania = dtipServidor.Rows[0]["compania"].ToString();
                cabecera.ctcosto = dtipServidor.Rows[0]["ctcosto"].ToString();
                string dtPlanInventariosSQL = "select * from plan_inventario with(nolock) where id_plan=" + cabecera.id_plan + " and origen='" + cabecera.origen + "'";
                DataTable dtPlanInventarios = new LN_GENERAL().EjecutarSQL(dtPlanInventariosSQL, "plan_inventario");
                DataTable dtPlanArticulos = new LN_GENERAL().EjecutarSQL("select * from plan_articulos with(nolock) where id_plan=" + cabecera.id_plan + " and origen='" + cabecera.origen + "' and estado<>'FINALIZADO' and estado <> 'INACTIVO'", "plan_articulos");
                DataTable dtArticulos = dtPlanArticulos.Copy();


                List<string> articulos = cabecera.articulos.Select(x => x.codigo).ToList();
                itbl_ArticulosRepositorio.Inicializar();
                List<tbl_articulos> articulosEntrada = itbl_ArticulosRepositorio.Filter(x => articulos.Contains(x.codigo)).ToList();

                if (dtPlanInventarios == null)
                    return "Error al sacar los datos de la planificación.";

                if (dtPlanInventarios.Rows.Count == 0)
                    return "Error la planificación no esta registrada.";

                if (dtPlanInventarios.Rows[0]["estado"].ToString() == "FINALIZADO" || dtPlanInventarios.Rows[0]["estado"].ToString() == "DESCUENTO")
                {
                    return "La planificación se encuentra en estado: " + dtPlanInventarios.Rows[0]["estado"].ToString().ToUpper() + ".";
                }

                if (dtPlanArticulos == null)
                {
                    return "Error al sacar el detalle de la planificación.";
                }

                if (dtPlanArticulos.Rows.Count == 0)
                {
                    return "La planificación no tiene detalles.";
                }

                Seguimiento = "Antes de seleccionar los datos a guardar...";
                res = SelectDatosguardar(cabecera, ref dtPlanArticulos, articulosEntrada);
                Seguimiento = "Después de seleccionar los datos a guardar...";
                if (res.Contains("OK|"))
                {
                    string jsonResumen = res.Split('|').ElementAt(1);

                    Seguimiento = "Antes de sacar los articulos que se modificaran...";
                    dtPlanArticulos.TableName = "PLAN_ARTICULOS";

                    Seguimiento = "Antes de sacar los datos del KARDEX...";
                    Seguimiento += " " + dtPlanArticulos.Rows.Count;


                    dtArticulos.TableName = "TBL_ARTICULOS";

                    dtArticulos = dtPlanArticulos.Copy();
                    dtArticulos.Columns["COD_ARTICULO"].ColumnName = "codigo";


                    string NumDocumento = cabecera.sucursal + cabecera.oficina + dtPlanArticulos.Rows[0]["ID_PLAN"].ToString().Trim().PadLeft(7, '0');
                    NumeroDocumentoInventarios = NumDocumento;
                    DataSet kardDS = TableKardex(dtPlanArticulos, ref estadoDiferencias, cabecera, NumDocumento);

                    Object[] objKard = null;

                    if (kardDS != null)
                        if (kardDS.Tables.Count == 4)
                        {
                            objKard = new object[] { kardDS.Tables[0], kardDS.Tables[1], kardDS.Tables[2], kardDS.Tables[3] };
                        }

                    dtArticulos = dtPlanArticulos.Copy();
                    dtArticulos.DefaultView.RowFilter = "estado = 'FINALIZADO'";
                    dtArticulos = dtArticulos.DefaultView.ToTable();
                    dtArticulos.TableName = "tbl_articulos";
                    dtArticulos.Columns["COD_ARTICULO"].ColumnName = "codigo";

                    dtPlanArticulos.DefaultView.RowFilter = "estado = 'RECONTEO'";
                    DataTable dt = dtPlanArticulos.DefaultView.ToTable();

                    DataTable dtPlanFacturacion = new DataTable("PLAN_FACTURACION");

                    DataTable dtPlanInventario = TablePlanInventario("T", cabecera, NumDocumento, dtPlanArticulos);
                    dtPlanFacturacion = PlanFacturacion(cabecera.oficina, cabecera.origen, cabecera.id_plan);


                    dtPlanInventario.TableName = "PLAN_INVENTARIO";
                    dtPlanArticulos.PrimaryKey = new DataColumn[] { dtPlanArticulos.Columns["id_plan"],
                                                                        dtPlanArticulos.Columns["COD_ARTICULO"],
                                                                        dtPlanArticulos.Columns["CLASE"],
                                                                        dtPlanArticulos.Columns["LINEA"],
                                                                        dtPlanArticulos.Columns["OFICINA"],
                                                                        dtPlanArticulos.Columns["SUCURSAL"],
                                                                        dtPlanArticulos.Columns["IDBODEGA"],
                                                                        dtPlanArticulos.Columns["ORIGEN"]
                                                                      };


                    Seguimiento = "Antes de asignar parametros a las posisiones 1,2 ";
                    if (!estadoDiferencias)
                    {
                        if (objKard == null)
                        {
                            return "Error al obtener los datos del KARDEX...";
                        }
                    }
                    else
                        objKard = new Object[4] { null, null, null, null };

                    //----realizar movimietos de inventario-------------------------------------------
                    Seguimiento = "Antes de enviar a guardar por el proceso 1...";


                    DataSet dsPlanInventario = new DataSet("PLAN_INVENTARIO");
                    dsPlanInventario.Tables.Add(dtPlanInventario.Copy());
                    dsPlanInventario.Tables.Add(dtPlanArticulos.Copy());
                    dsPlanInventario.Tables.Add(dtPlanFacturacion.Copy());
                    dsPlanInventario.Tables.Add(dtArticulos.Copy());
                    DataSet dsKardex = null;
                    if (objKard != null)
                    {
                        if (objKard[0] != null)
                        {
                            dsKardex = new DataSet("KARDEX");
                            for (int ik = 0; ik < objKard.Length; ik++)
                                dsKardex.Tables.Add(((DataTable)objKard[ik]).Copy());
                        }
                    }
                    //Guardado de tabla de registro de uso de app movil
                    DataTable dtRegistroAppMovil = new LN_GENERAL().EjecutarSQL("select * from pmov.tbl_RegistroAppMovil with(nolock) where tipo_movimiento='PLANINV' and numero_movimiento='" + cabecera.id_plan + "'", "pmov.tbl_RegistroAppMovil");
                    if (dtRegistroAppMovil != null && dtRegistroAppMovil.Rows.Count > 0)
                    {
                        dtRegistroAppMovil.Rows[0]["fecha_registro"] = DateTime.Now;
                        dtRegistroAppMovil.Rows[0]["usuario_registro"] = cabecera.usuario;
                    }
                    else if (dtRegistroAppMovil.Rows.Count == 0)
                    {
                        DataRow r = dtRegistroAppMovil.NewRow();
                        r["tipo_movimiento"] = "PLANINV";
                        r["numero_movimiento"] = cabecera.id_plan;
                        r["fecha_registro"] = DateTime.Now;
                        r["usuario_registro"] = cabecera.usuario;
                        dtRegistroAppMovil.Rows.Add(r);
                    }
                    //res = new LN_PlanInventario().GrabarPlanInventario(dtPlanInventario, dtPlanArticulos, dtPlanFacturacion, dtArticulos, objKard);
                    dsPlanInventario.Tables.Add(dtRegistroAppMovil);
                    res = new LN_PlanInventario().GrabarPlanInventario(dsPlanInventario, dsKardex);

                    //seleccionar los empleados que se les va a descontar............

                    if (res.Equals("OK"))
                    {
                        if (dtPlanInventario.Rows[0]["estado"].ToString().ToUpper().Equals("DESCUENTO"))
                            return "OK|" + dtPlanInventario.Rows[0]["estado"].ToString() + "|" + jsonResumen;
                        else
                            return "OK|" + dtPlanInventario.Rows[0]["estado"].ToString();

                    }
                    else
                        return res;

                }
                else
                    return res + " " + Seguimiento;
            }
            catch (Exception ex)
            {
                registrarLog("ProcesarInformacion exc: " + ex.Message + " " + Seguimiento + " -- " + ex.StackTrace);

                return "Error: " + ex.Message + " " + Seguimiento;
            }
        }

        private string DataTableToJson(DataTable dt)
        {
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;
            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    row.Add(col.ColumnName, dr[col]);
                }
                rows.Add(row);
            }
            return serializer.Serialize(rows);
        }

        private DataTable TablePlanInventario(String tipo, cls_Cabecera cabecera, string NumDocumento, DataTable dtPlanArticulos)
        {

            DataTable dtPlan = new LN_PlanInventario().ObtenerPlanInventario("100 percent", "id_plan = '" + cabecera.id_plan + "' and oficina='" + cabecera.oficina + "' and origen='" + cabecera.origen + "'");
            dtPlan.PrimaryKey = new DataColumn[] { dtPlan.Columns["id_plan"], dtPlan.Columns["oficina"], dtPlan.Columns["SUCURSAL"], dtPlan.Columns["IDBODEGA"], dtPlan.Columns["ORIGEN"] };
            //T INDICA QUE EL PROCESO SE COMPLETO EN SU TOTALIDAD
            //N TIENE ARTICULO PENDIENTES A RECONTAR
            dtPlan.Rows[0]["NUMERO_DOCUMENTO"] = NumDocumento;
            if (tipo.Equals("T"))
            {
                int num_diferencias = 0;
                num_diferencias = Convert.ToInt16(dtPlanArticulos.Compute("COUNT(DIFERENCIA)", "DIFERENCIA <> 0 "));

                if (num_diferencias == 0)
                {
                    dtPlan.Rows[0]["ESTADO"] = "FINALIZADO";
                    dtPlan.Rows[0]["USUARIO_FINALIZADO"] = cabecera.usuario;
                    dtPlan.Rows[0]["FECHA_FINALIZADO"] = DateTime.Now;
                }
                else
                {
                    dtPlan.Rows[0]["ESTADO"] = "DESCUENTO";
                    dtPlan.Rows[0]["USUARIO_DESCUENTO"] = cabecera.usuario;
                    dtPlan.Rows[0]["FECHA_DESCUENTO"] = DateTime.Now;
                }
            }
            else
            {
                dtPlan.Rows[0]["ESTADO"] = "RECONTEO";
                dtPlan.Rows[0]["FECHA_RECONTEO"] = DateTime.Now;
                dtPlan.Rows[0]["USUARIO_RECONTEO"] = cabecera.usuario;
            }

            return dtPlan;
        }

        private DataTable PlanFacturacion(string strOficina, string origen, int id_plan)
        {
            String sql = "SELECT * FROM dbo.PLAN_FACTURACION WITH (NOLOCK) " +
                         " WHERE estado='CREADO' and oficina='" + strOficina.ToString() + "' and origen='" + origen + "' AND id_plan=" + id_plan;
            DataTable dtPlanFacturacion = new LN_GENERAL().EjecutarSQL(sql, "PLAN_FACTURACION");
            if (dtPlanFacturacion.Rows.Count > 0)
            {
                dtPlanFacturacion.PrimaryKey = new DataColumn[] { dtPlanFacturacion.Columns["id_plan"], dtPlanFacturacion.Columns["oficina"] };
                dtPlanFacturacion.Rows[0]["ESTADO"] = "FINALIZADO";
                dtPlanFacturacion.TableName = "PLAN_FACTURACION";
                return dtPlanFacturacion;
            }
            return new DataTable("PLAN_FACTURACION");
        }

        private DataSet TableKardex(DataTable dtPlan, ref bool estadoDiferencias, cls_Cabecera cabecera, string NumDocumento)
        {
            //LogicaNegociosRecepcionProxy.KardexProxy krdex = new KardexProxy("PUNTOVENTA");
            DataTable dtCabMovInv = null;
            DataTable dtDetMovInv = null;
            using (PVenta.ws_pventaSoapClient pventa = new PVenta.ws_pventaSoapClient())
            {
                dtCabMovInv = pventa.KP_RC_crearCabeceraK("PLBODEGA");
                dtDetMovInv = pventa.KP_RC_crearDetalleK("PLBODEGA");
            }


            dtPlan.DefaultView.RowFilter = "estado = 'FINALIZADO' and diferencia <> 0 ";

            //cuando no genera inconsistencias
            if (dtPlan.Rows.Count > 0 && dtPlan.DefaultView.ToTable().Rows.Count == 0)
                estadoDiferencias = true;

            dtPlan = dtPlan.DefaultView.ToTable().Copy();
            dtPlan.PrimaryKey = new DataColumn[] { dtPlan.Columns["cod_articulo"] };

            DataTable dtajusmas, dtajusmen;
            Int64 secuencial = 0;

            using (PVenta.ws_pventaSoapClient pventa = new PVenta.ws_pventaSoapClient())
            {
                secuencial = pventa.KP_RC_SacarNumMaestroMovInvent(cabecera.compania, cabecera.sucursal, cabecera.oficina, cabecera.oficina, "TRASPASOS", "PLBODEGA");
            }



            DataView dv = new DataView(dtPlan);
            dv.RowFilter = "diferencia > 0";
            dtajusmas = dv.ToTable();

            if (dtajusmas.Rows.Count > 0)
                secuencial = ingresarjardex(cabecera.compania + "AJUSMAS" + cabecera.sucursal + cabecera.oficina + cabecera.id_plan.ToString().PadLeft(7, '0'), dtajusmas, ref dtCabMovInv, ref dtDetMovInv, "AJUSMAS", secuencial, "AJUSTES EN MAS", "PLANINV", "PLANIFICACION INVENTARIOS", cabecera, NumDocumento);

            dv = new DataView(dtPlan);
            dv.RowFilter = "diferencia < 0";
            dtajusmen = dv.ToTable();

            if (dtajusmen.Rows.Count > 0)
                ingresarjardex(cabecera.compania + "AJUSMEN" + cabecera.sucursal + cabecera.oficina + cabecera.id_plan.ToString().PadLeft(7, '0'), dtajusmen, ref dtCabMovInv, ref dtDetMovInv, "AJUSMEN", secuencial, "AJUSTES EN MENOS", "PLANINV", "PLANIFICACION INVENTARIOS", cabecera, NumDocumento);

            if (dtCabMovInv != null)
                if (dtCabMovInv.Rows.Count > 0)
                {

                    using (PVenta.ws_pventaSoapClient pventa = new PVenta.ws_pventaSoapClient())
                    {
                        var result = pventa.KP_RC_TablasKardex(dtCabMovInv, dtDetMovInv, false, cabecera.oficina, cabecera.oficina, cabecera.compania, cabecera.sucursal, true, "PLBODEGA");
                        return result;
                    }
                }

            return null;
        }

        Int64 ingresarjardex(string numero_conteo, DataTable dtdet, ref DataTable dtCabMovInv, ref DataTable dtDetMovInv, string tipo_mov, Int64 secuencial, string descripcion_motivo, string tipo_causa, string descripcion_causa, cls_Cabecera cabecera, string NumDocumento)
        {

            LogicaNegociosRecepcionProxy.KardexProxy krdex = new KardexProxy("PUNTOVENTA");
            Int64 num_mov = krdex.SacarNumMaestroMovInvent(cabecera.compania, cabecera.sucursal, cabecera.oficina, cabecera.oficina, tipo_mov);
            //llenado de maestromovinvent
            DataRow fila = dtCabMovInv.NewRow();
            fila["compania"] = cabecera.compania;
            fila["sucursal"] = cabecera.sucursal;
            fila["oficina"] = cabecera.oficina;
            fila["tipo_mov"] = tipo_mov;
            fila["num_mov"] = num_mov;
            fila["fecha_mov"] = DateTime.Now;
            fila["tx_referencia"] = descripcion_motivo + " REF. " + descripcion_causa + " " + NumDocumento + " " + numero_conteo;
            fila["tipo_idcliente"] = "R";
            fila["numero_idcliente"] = "9999999999999";
            fila["tipo_documento"] = "A";
            fila["num_documento"] = num_mov;
            fila["monto"] = 0;
            fila["idbodega"] = cabecera.oficina;
            fila["contabilizado"] = null;
            fila["fechacontabilizacion"] = DBNull.Value;
            fila["tipocomprobante"] = null;
            fila["numerocomprobante"] = DBNull.Value;
            fila["estacionid"] = "0";
            fila["userid"] = cabecera.usuario;
            fila["fecharegistro"] = DateTime.Now;
            fila["fecha_ingreso_aduana"] = DBNull.Value;
            fila["dui"] = null;
            fila["orden_compra"] = "";//lblOrdenCompra.Text;
            fila["factura_exterior"] = "";
            fila["numero_referencia"] = null;
            fila["fecha_vencimiento_pago"] = DBNull.Value;
            fila["fecha_pago"] = DBNull.Value;
            fila["idbodegadestino"] = null;
            fila["tipo_mov_prod"] = null;
            fila["num_mov_prod"] = DBNull.Value;
            fila["excedente"] = DBNull.Value;
            fila["tipo_mov_exc"] = null;
            fila["num_mov_exc"] = DBNull.Value;
            fila["ctcosto"] = cabecera.ctcosto;
            fila["cuenta_motivo"] = null;
            fila["estado"] = "A";
            fila["seriefactura"] = "";
            fila["noautorizacionsri"] = "";
            fila["tipo_doc_inv"] = "";
            fila["numero_doc_inv"] = NumDocumento;
            fila["tipo_doc_exterior"] = "";
            fila["serie_factura"] = numero_conteo;
            fila["tipo_causa"] = tipo_causa;
            fila["sucursalasiento"] = cabecera.sucursal;//
            fila["oficinaasiento"] = cabecera.oficina;//
            fila["ctcostoasiento"] = cabecera.ctcosto;//
            fila["observaciones"] = "PLAN_INVENTARIO";

            dtCabMovInv.Rows.Add(fila);

            for (int i = 0; i < dtdet.Rows.Count; i++)
            {
                fila = dtDetMovInv.NewRow();
                fila["compania"] = cabecera.compania;
                fila["sucursal"] = cabecera.sucursal;
                fila["oficina"] = cabecera.oficina;
                fila["tipo_mov"] = tipo_mov;
                fila["num_mov"] = num_mov;
                fila["codigo_producto"] = dtdet.Rows[i]["cod_articulo"];
                fila["secuencial"] = i;
                fila["fecha_mov"] = DateTime.Now;
                fila["cantidad"] = Math.Abs(Int64.Parse(dtdet.Rows[i]["diferencia"].ToString()));

                DataTable dtArtCompleto = new LN_GENERAL().EjecutarSQL("select convert(decimal(13,4),PPP/valor_pos) ppp from tbl_articulos with(nolock) where codigo='" + dtdet.Rows[i]["cod_articulo"] + "'", "tbl_articulos");

                fila["precio"] = Convert.ToDecimal(dtArtCompleto.Rows[0]["ppp"]);
                fila["tx_referencia"] = descripcion_motivo + " REF. " + descripcion_causa + " " + NumDocumento + " " + numero_conteo;
                fila["moneda"] = "USD";
                fila["idbodega"] = cabecera.oficina;
                fila["estacionid"] = "0";
                fila["userid"] = cabecera.usuario;
                fila["fechaingreso"] = DateTime.Now;
                fila["fob"] = DBNull.Value;
                fila["flete"] = DBNull.Value;
                fila["otros_costos_importacion"] = DBNull.Value;
                fila["costo_importacion_unitario"] = DBNull.Value;
                fila["idbodegadestino"] = null;
                fila["saldoexistencias"] = DBNull.Value;
                fila["costopromedio"] = 0;
                fila["otros_gastos_nacionalizacion"] = DBNull.Value;
                fila["numerosecuencialmovimiento"] = secuencial;
                fila["iva_unitario"] = 0;
                fila["tbl_movinvent"] = 0;
                fila["cantidad_total"] = 0;
                fila["estado"] = "ACTIVO";
                fila["ice_unitario"] = 0;
                fila["serie_factura"] = numero_conteo;
                fila["tipo_causa"] = tipo_causa;
                fila["entero"] = 0;
                fila["fraccion"] = 0;
                fila["costo_inv"] = Math.Abs(Int64.Parse(dtdet.Rows[i]["diferencia"].ToString())) * (Convert.ToDecimal(dtArtCompleto.Rows[0]["ppp"]));
                fila["costo_total"] = 0;
                fila["costo_unitario"] = 0;

                dtDetMovInv.Rows.Add(fila);
                secuencial++;
            }
            return secuencial;
        }

        private String SelectDatosguardar(cls_Cabecera cabecera, ref DataTable dtPlanArticulos, List<tbl_articulos> articulosEntrada)
        {
            try
            {

                dtPlanArticulos.PrimaryKey = new DataColumn[] { dtPlanArticulos.Columns["cod_articulo"] };
                decimal porcentaje = 0;
                // VALO DE DESCUENTO
                tbl_tablas tblDescuento = null;
                try
                {
                    tblDescuento = itbl_TablasRepositorio.Find(x => x.id_tabla.Equals("INVENT") && x.cx_argumento.Equals("PTJDESC"));

                    if (tblDescuento != null && tblDescuento.tx_descripcion != null && !tblDescuento.tx_descripcion.Equals(""))
                    {
                        porcentaje = Convert.ToDecimal(tblDescuento.tx_descripcion);
                        if (porcentaje > 0)
                            porcentaje = porcentaje / 100;
                        else
                            porcentaje = 0;
                    }
                }
                catch (Exception)
                { }

                List<ResumenPlanArticulos> resumen = new List<ResumenPlanArticulos>();

                DataRow dr;
                foreach (articulos a in cabecera.articulos)
                {
                    dr = dtPlanArticulos.Rows.Find(new object[] { a.codigo });

                    if (dr != null)
                    {
                        int diferenciaEntero = a.ingreso - a.stock;

                        dr["CANTIDAD"] = a.ingreso;
                        dr["CONTEO"] = 0;
                        dr["DIFERENCIA"] = diferenciaEntero;
                        dr["ENTERO"] = Convert.ToInt16(a.ingreso / a.valorconversion);
                        dr["FRACCION"] = a.ingreso - (Convert.ToInt16(a.ingreso / a.valorconversion) * a.valorconversion);

                        DataTable dtArtCompleto = new LN_GENERAL().EjecutarSQL("select convert(decimal(13,4),PVF/valor_pos) pvf from tbl_articulos with(nolock) where codigo='" + a.codigo + "'", "tbl_articulos");
                        decimal valorDescuento = (Decimal.Parse(dr["DIFERENCIA"].ToString()) * (Decimal.Parse(dtArtCompleto.Rows[0]["pvf"].ToString()))) * porcentaje;
                        Decimal valor = Decimal.Parse(dr["DIFERENCIA"].ToString()) * (Decimal.Parse(dtArtCompleto.Rows[0]["pvf"].ToString())) + valorDescuento;

                        // MODIFICACIÓN DE DESCUENTO A EMPLEADOS 

                        var obj = new Dictionary<string, string>();

                        List<PA_BuscarConfiguracionSegmentoArticulo> result = null;

                        string sql = "";

                        // AJUSTE MENOS
                        if (diferenciaEntero < 0)
                        {
                            sql = @"EXEC [par].[pa_BuscarConfiguracionSegmentoArticulo] 'in(''" + a.codigo + "'')','AJUSMEN','PLANINV'";
                            result = iPA_BuscarConfiguracionSegmento.SqlQuery(
                                sql, obj, 0).ToList();
                        }
                        // AJUSTE MAS
                        else if (diferenciaEntero > 0)
                        {
                            sql = "EXEC [par].[pa_BuscarConfiguracionSegmentoArticulo] 'in(''" + a.codigo + "'')','AJUSMAS','PLANINV'";
                            result = iPA_BuscarConfiguracionSegmento.SqlQuery(
                             sql, obj, 0).ToList();
                        }

                        if (result != null && result.Count > 0)
                        {
                            if (result.ElementAt(0).desc_emp.Equals("SI"))
                                dr["VALORDIFERENCIA"] = Math.Round(valor, 3);
                            else if (result.ElementAt(0).desc_emp.Equals("NO"))
                            {
                                dr["par_valor_diferencia_anterior"] = Math.Round(valor, 3);
                                dr["VALORDIFERENCIA"] = 0.000;
                            }
                        }
                        else
                            dr["VALORDIFERENCIA"] = Math.Round(valor, 3);


                        decimal diferencia = (a.ingreso - a.stock);
                        decimal division = diferencia / a.valorconversion;
                        decimal parteEntera = Math.Truncate(division);
                        decimal parteDecimal = division - parteEntera;

                        if (diferencia != 0)
                        {
                            tbl_articulos art = articulosEntrada.FirstOrDefault(x => x.codigo.Equals(a.codigo));
                            ResumenPlanArticulos resumenTmp = new ResumenPlanArticulos
                            {
                                id_plan = Convert.ToInt32(dr["ID_PLAN"].ToString()),
                                cantidad = a.ingreso,
                                codigoArticulo = a.codigo,
                                descripcionArticulo = art == null ? "SN" : art.descripcion,
                                porcentajeDescuento = porcentaje * 100,
                                pvf = Decimal.Parse(dtArtCompleto.Rows[0]["pvf"].ToString()),
                                entero = Convert.ToInt32(parteEntera),
                                fraccion = Convert.ToInt32(parteDecimal * a.valorconversion),
                                valorPos = a.valorconversion,
                                valorDiferencia = Math.Round(valor, 3),
                            };
                            resumen.Add(resumenTmp);
                        }
                    }
                }

                foreach (DataRow f in dtPlanArticulos.Rows)
                {
                    f["ESTADO"] = "FINALIZADO";
                    f["FECHA_FINALIZADO"] = DateTime.Now;
                    f["USUARIO_FINALIZADO"] = cabecera.usuario;
                }

                var jsonSerialiser = new JavaScriptSerializer();

                return "OK|" + jsonSerialiser.Serialize(resumen);


            }
            catch (Exception ex)
            {
                registrarLog("SelectDatosguardar exc: " + ex.Message + " -- " + ex.StackTrace);

                return "Error SelectDatosguardar: " + ex.Message;
            }
        }

        #endregion

        #region IMPRESION DE ETIQUETAS
        public tbl_articulos ConsultarArticulos(string codbarras)
        {
            itbl_ArticulosRepositorio.Inicializar();
            itbl_Articulos_CodigosbarraRepositorio.Inicializar();
            tbl_articulos_codigosbarra articulosCodigosbarra = itbl_Articulos_CodigosbarraRepositorio.Find(x => x.codigo_barra.Equals(codbarras));

            if (articulosCodigosbarra != null)
            {
                tbl_articulos articulo = itbl_ArticulosRepositorio.Find(x => x.codigo.Equals(articulosCodigosbarra.codigo));
                return articulo;
            }
            return null;

        }
        public Oficinas ValidarAutoservicio(string codOficina)
        {
            iOficinaRepositorio.Inicializar();
            if (codOficina != null)
            {
                Oficinas oficina = iOficinaRepositorio.Find(x => x.oficina.Equals(codOficina));
                return oficina;
            }
            return null;
        }
        public Result GuardarEtiquetasPrecios(List<tbl_ImpresionEtiquetas> etiquetas)
        {
            //itbl_ImpresionEtiquetasRepositorio.Inicializar();
            _pool = new Semaphore(0, 1);
            Result resultado = new Result
            {
                respuesta = "error",
                mensaje = "Error al guardar la información de impresión etiquetas."
            };

            try
            {

                //List<String> codigosBarra = etiquetas.Select(x => x.codigo_barras).Distinct().ToList();
                //List<String> codigosArticulo = etiquetas.Select(x => x.codigo_articulo).ToList();
                //List<tbl_ImpresionEtiquetas> existentes = itbl_ImpresionEtiquetasRepositorio
                //     .Filter(t => codigosBarra.Contains(t.codigo_barras.Replace("\n", "").Trim()) && t.estado.Equals("PENDIENTE")).ToList();

                //foreach (var item in codigosBarra)
                //foreach (var item in codigosArticulo)
                foreach (var item in etiquetas)
                {
                    List<tbl_ImpresionEtiquetas> existentes = itbl_ImpresionEtiquetasRepositorio
                    .Filter(t => item.codigo_articulo.Contains(t.codigo_articulo.Replace("\n", "").Trim()) && t.estado.Equals("PENDIENTE")).ToList();

                    //tbl_ImpresionEtiquetas etiqueta = etiquetas.Find(x => x.codigo_barras.Equals(item));
                    //tbl_ImpresionEtiquetas existe = existentes.Find(x => x.codigo_barras.Replace("\n", "").Trim().Equals(item));
                    // tbl_ImpresionEtiquetas etiqueta = etiquetas.Find(x => x.codigo_articulo.Equals(item.codigo_articulo));
                    tbl_ImpresionEtiquetas existe = existentes.Find(x => x.codigo_articulo.Replace("\n", "").Trim().Equals(item.codigo_articulo));
                    if (existe != null)
                    {

                        existe.codigo_barras = item.codigo_barras;
                        existe.cantidad = existe.cantidad + item.cantidad;
                        existe.usuario_registro = item.usuario_registro;
                        existe.fecha_registro = DateTime.Now;
                        itbl_ImpresionEtiquetasRepositorio.Update(existe);
                    }
                    else
                    {
                        tbl_ImpresionEtiquetas
                        registro = new tbl_ImpresionEtiquetas
                        {
                            id_impresion_etiqueta = 1,
                            codigo_articulo = item.codigo_articulo,
                            codigo_barras = item.codigo_barras.Replace("\n", "").Trim(),
                            descripcion = item.descripcion,
                            cantidad = item.cantidad,
                            estado = "PENDIENTE",
                            fecha_registro = DateTime.Now,
                            usuario_registro = item.usuario_registro
                        };
                        itbl_ImpresionEtiquetasRepositorio.Create(registro);
                    }
                }


                resultado = new Result
                {
                    respuesta = "ok",
                    mensaje = "Guardado Correctamente.",
                };
                _pool.Release(1);

                return resultado;

            }
            catch (DbEntityValidationException e)
            {
                string mensaje = "";
                foreach (var eve in e.EntityValidationErrors)
                {
                    mensaje += "Entity of type \"{0}\" in state \"{1}\" has the following validation errors:" +
                        eve.Entry.Entity.GetType().Name + eve.Entry.State;
                    foreach (var ve in eve.ValidationErrors)
                    {
                        mensaje += "- Property: \"{0}\", Error: \"{1}\"" +
                            ve.PropertyName + ve.ErrorMessage;
                    }
                }

                resultado = new Result
                {
                    respuesta = "error",
                    mensaje = mensaje,
                };

            }
            _pool.Release(1);
            return resultado;

        }

        #endregion


        private void RegistroAppMovil(int idtraspaso, string usuario, string oficina, string origen)
        {
            //Registro de uso de app
            try
            {
                //string[] usu = usuario.Split('|');
                //if (usuario.Contains("FK"))
                //    usuario = usu[0];
                tbl_RegistroAppMovil regAppExis = itbl_RegistroAppMovilRepositorio.Find(t => t.tipo_movimiento == "PLANINV" && t.numero_movimiento == idtraspaso);
                if (regAppExis == null)
                {
                    tbl_RegistroAppMovil regApp = new tbl_RegistroAppMovil
                    {

                        tipo_movimiento = "PLANINV",
                        numero_movimiento = idtraspaso,
                        fecha_registro = DateTime.Now,
                        usuario_registro = usuario,
                        num_documento = NumeroDocumentoInventarios,
                        tipo_inventario = origen,

                    };
                    int insertApp = itbl_RegistroAppMovilRepositorio.Create(regApp);
                    //zxc
                }
                else
                {
                    regAppExis.fecha_registro = DateTime.Now;
                    regAppExis.usuario_registro = usuario;
                    regAppExis.num_documento = NumeroDocumentoInventarios;
                    int updApp = itbl_RegistroAppMovilRepositorio.Update(regAppExis);
                }
                //if (usuario.Contains("FK"))
                //{
                //itbl_AuditoriaAppMovilRepositorio.Inicializar();
                //tbl_AuditoriaAppMovil tbl_AuditoriaApp = new tbl_AuditoriaAppMovil
                //{
                //    aum_fecha_ejecucion = DateTime.Now,
                //    aum_fecha_registro = DateTime.Now,
                //    aum_numero_movimiento = idtraspaso,
                //    aum_oficina = oficina,
                //    aum_tipo_movimiento = "PLANINV",
                //    aum_usuario_registro = usuario
                //};
                //itbl_AuditoriaAppMovilRepositorio.Create(tbl_AuditoriaApp);
                //}
            }
            catch (Exception) { }
        }

        private void registrarLog(string resp)
        {
            System.Diagnostics.EventLog objLog = new System.Diagnostics.EventLog();
            if (!EventLog.SourceExists("PMOV_RECEPCION_MOVIL"))
                EventLog.CreateEventSource("PMOV_RECEPCION_MOVIL", "Application");
            objLog.Source = "PMOV_RECEPCION_MOVIL";

            objLog.WriteEntry("RESP: " + resp, EventLogEntryType.Warning);
        }

        /// <summary>
        /// Decompresses the string.
        /// </summary>
        /// <param name="compressedText">The compressed text.</param>
        /// <returns></returns>
        public static string DecompressString(string compressedText)
        {
            byte[] gZipBuffer = Convert.FromBase64String(compressedText);
            using (var memoryStream = new MemoryStream())
            {
                int dataLength = BitConverter.ToInt32(gZipBuffer, 0);
                memoryStream.Write(gZipBuffer, 4, gZipBuffer.Length - 4);

                var buffer = new byte[dataLength];

                memoryStream.Position = 0;
                using (var gZipStream = new GZipStream(memoryStream, CompressionMode.Decompress))
                {
                    gZipStream.Read(buffer, 0, buffer.Length);
                }

                return Encoding.UTF8.GetString(buffer);
            }
        }

    }
    public class Barra
    {
        public string barra { get; set; }
    }

}




