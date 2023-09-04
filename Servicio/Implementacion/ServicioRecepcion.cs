using Configuracion;
using Configuracion.Librerias;
using Configuracion.Models;
using Contexto.Digitalizacion;
using Entidades.bdgeneral;
using Entidades.Catalogo;
using Entidades.Digitalizacion;
using Entidades.EasyGestionEmpresarial;
using Entidades.Inconsistencias;
using LogicaNegociosRecepcionProxy;
using Newtonsoft.Json;
using Repositorio.Interfaz.bdgeneral;
using Repositorio.Interfaz.Catalogo;
using Repositorio.Interfaz.Digitalizacion;
using Repositorio.Interfaz.EasyGestionEmpresarial;
using Repositorio.Interfaz.Inconsistencias;
using Servicio.dlls;
using Servicio.Interfaz;
using Servicio.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Web.Configuration;
using System.Web.Script.Serialization;

namespace Servicio.Implementacion
{
    public class ServicioRecepcion : IServicioRecepcion
    {
        IPA_TraspasosFarmaciaRepositorio iPA_TraspasosFarmaciaRepositorio;
        IVIRT_TRASPASOCABRepositorio iVIRT_TRASPASOCABRepositorio;
        Itbl_articulos_codigosbarraRepositorio itbl_Articulos_CodigosbarraRepositorio;
        IOficinasRepositorio iOficinaRepositorio;
        IPA_GEN_GenerarKardexFarmaciaRepositorio iPA_GenerarKardexFarmacia;
        IPA_GEN_GenerarKardexMatrizRepositorio iPA_GenerarKardexMatriz;
        Itbl_maestromovinventRepositorio itbl_maestromovinventRepositorioMatriz;
        Itbl_maestromovinventRepositorio itbl_maestromovinventRepositorioFarmacia;
        IVIRT_TRASPASODETRepositorio iVIRT_TRASPASODETRepositorio;
        Itbl_articulosRepositorio itbl_ArticulosRepositorio;
        Itbl_movinventRepositorio itbl_movinventRepositorio;
        IVIRT_TRASPASOCABFarmaciaRepositorio iVIRT_TRASPASOCABFarmaciaRepositorio;
        Itbl_inco_bodegaRepositorio itbl_Inco_BodegaRepositorio;
        IPA_DatosUsuarioRepositorio iPA_DatosUsuarioRepositorio;
        IPA_ObtenerFotoArticuloRepositorio ipA_ObtenerFotoArticuloRepositorio;
        Itbl_tmp_RecepcionMercaderiaRepositorio itbl_Tmp_RecepcionMercaderiaRepositorio;
        Itbl_LoginUsuarioRepositorio Itbl_LoginUsuariORepositorio;
        Itbl_RegistroAppMovilRepositorio itbl_RegistroAppMovilRepositorio;
        IPA_IpServidorRepositorio iPA_IpServidorRepositorio;
        Itbl_par_UsuarioNotificacionInconsistenciaRepositorio itbl_UsuarioNotificacionInconsistencia;
        IGEN_MovTraspasosDevoluciones_CabRepositorio iGenTraspasosDevolucionesRepositorio;
        Itbl_maestrofactRepositorio itbl_MaestrofactRepositorio;
        Itbl_ConfiguracionesRepositorio itbl_ConfiguracionesRepositorio;
        Itbl_PendientesVerificacionRepositorio itbl_PendientesVerificacionRepositorio;
        IVIRT_TRASPASOVERIFMERCADERIARepositorio iVIRT_TRASPASOVERIFMERCADERIA;
        IPV_TraspasoInformeMercaderiaRepositorio iPV_TraspasoInformeMercaderiaRepositorio;
        IPV_TraspasoVerifMercaderia_DetRepositorio iPV_TraspasoVerifMercaderia_DetRepositorio;
        Itbl_AuditoriaAppMovilRepositorio itbl_AuditoriaAppMovilRepositorio;
        IVIRT_TRASPASOCABOFFLINERepositorio iVirtTraspasoCabOffLineRepositorio;
        IVIRT_TRASPASODETOFFLINERepositorio iVirtTraspasoDetOffLineRepositorio;
        IPA_TraspasosFarmaciaOffLineRepositorio iPA_TraspasosFarmaciaOffLineRepositorio;
        IPA_ValidarTraspasoCFRepositorio iPAValidarTraspasoCFRepositorio;
        ITbl_TemperaturaTraspaso_cabRepositorio itbl_TemperaturaTraspaso_CabRepositorio;
        ITbl_TemperaturaTraspaso_detRepositorio itbl_TemperaturaTraspaso_detRepositorio;
        IPA_ArticuloCadenaFrioRepositorio iPA_ArticuloCadenaFrioRepositorio;
        Itbl_DetalleTransferenciaBCRepositorio itbl_DetalleTransferenciaBCRepositorio;

        public ServicioRecepcion(
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
        Itbl_articulosRepositorio itbl_ArticulosRepositorio,
        IPA_ObtenerFotoArticuloRepositorio ipA_ObtenerFotoArticuloRepositorio,
        Itbl_tmp_RecepcionMercaderiaRepositorio itbl_Tmp_RecepcionMercaderiaRepositorio,
        Itbl_LoginUsuarioRepositorio Itbl_LoginUsuariORepositorio,
        Itbl_RegistroAppMovilRepositorio itbl_RegistroAppMovilRepositorio,
        IPA_IpServidorRepositorio iPA_IpServidorRepositorio,
        Itbl_par_UsuarioNotificacionInconsistenciaRepositorio itbl_UsuarioNotificacionInconsistencia,
        IGEN_MovTraspasosDevoluciones_CabRepositorio iGenTraspasosDevolucionesRepositorio,
        Itbl_maestrofactRepositorio itbl_MaestrofactRepositorio,
            Itbl_ConfiguracionesRepositorio itbl_ConfiguracionesRepositorio,
            Itbl_PendientesVerificacionRepositorio itbl_PendientesVerificacionRepositorio,
            IVIRT_TRASPASOVERIFMERCADERIARepositorio iVIRT_TRASPASOVERIFMERCADERIA,
            IPV_TraspasoInformeMercaderiaRepositorio iPV_TraspasoInformeMercaderiaRepositorio,
            IPV_TraspasoVerifMercaderia_DetRepositorio iPV_TraspasoVerifMercaderia_DetRepositorio,
            Itbl_AuditoriaAppMovilRepositorio itbl_AuditoriaAppMovilRepositorio,
            IVIRT_TRASPASOCABOFFLINERepositorio iVirtTraspasoCabOffLineRepositorio,
            IVIRT_TRASPASODETOFFLINERepositorio iVirtTraspasoDetOffLineRepositorio,
            IPA_TraspasosFarmaciaOffLineRepositorio iPA_TraspasosFarmaciaOffLineRepositorio,
            IPA_ValidarTraspasoCFRepositorio iPAValidarTraspasoCFRepositorio,
            ITbl_TemperaturaTraspaso_cabRepositorio itbl_TemperaturaTraspaso_CabRepositorio,
            ITbl_TemperaturaTraspaso_detRepositorio itbl_TemperaturaTraspaso_detRepositorio,
            IPA_ArticuloCadenaFrioRepositorio iPA_ArticuloCadenaFrioRepositorio,
            Itbl_DetalleTransferenciaBCRepositorio itbl_DetalleTransferenciaBCRepositorio
        )
        {
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
            this.iPA_IpServidorRepositorio = iPA_IpServidorRepositorio;
            this.itbl_UsuarioNotificacionInconsistencia = itbl_UsuarioNotificacionInconsistencia;
            this.iGenTraspasosDevolucionesRepositorio = iGenTraspasosDevolucionesRepositorio;
            this.itbl_MaestrofactRepositorio = itbl_MaestrofactRepositorio;
            this.itbl_ConfiguracionesRepositorio = itbl_ConfiguracionesRepositorio;
            this.itbl_PendientesVerificacionRepositorio = itbl_PendientesVerificacionRepositorio;
            this.iVIRT_TRASPASOVERIFMERCADERIA = iVIRT_TRASPASOVERIFMERCADERIA;
            this.iPV_TraspasoInformeMercaderiaRepositorio = iPV_TraspasoInformeMercaderiaRepositorio;
            this.iPV_TraspasoVerifMercaderia_DetRepositorio = iPV_TraspasoVerifMercaderia_DetRepositorio;
            this.itbl_AuditoriaAppMovilRepositorio = itbl_AuditoriaAppMovilRepositorio;
            this.iVirtTraspasoDetOffLineRepositorio = iVirtTraspasoDetOffLineRepositorio;
            this.iVirtTraspasoCabOffLineRepositorio = iVirtTraspasoCabOffLineRepositorio;
            this.iPA_TraspasosFarmaciaOffLineRepositorio = iPA_TraspasosFarmaciaOffLineRepositorio;
            this.iPAValidarTraspasoCFRepositorio = iPAValidarTraspasoCFRepositorio;
            this.itbl_TemperaturaTraspaso_CabRepositorio = itbl_TemperaturaTraspaso_CabRepositorio;
            this.itbl_TemperaturaTraspaso_detRepositorio = itbl_TemperaturaTraspaso_detRepositorio;
            this.iPA_ArticuloCadenaFrioRepositorio = iPA_ArticuloCadenaFrioRepositorio;
            this.itbl_DetalleTransferenciaBCRepositorio = itbl_DetalleTransferenciaBCRepositorio;

        }

        public void Inicializar()
        {
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
            iPA_IpServidorRepositorio.Inicializar();
            itbl_UsuarioNotificacionInconsistencia.Inicializar();
            iGenTraspasosDevolucionesRepositorio.Inicializar();
            itbl_MaestrofactRepositorio.Inicializar();
            itbl_ConfiguracionesRepositorio.Inicializar();
            itbl_PendientesVerificacionRepositorio.Inicializar();
            iVIRT_TRASPASOVERIFMERCADERIA.Inicializar();
            iPV_TraspasoInformeMercaderiaRepositorio.Inicializar();
            iPV_TraspasoVerifMercaderia_DetRepositorio.Inicializar();
            itbl_AuditoriaAppMovilRepositorio.Inicializar();
            iVirtTraspasoCabOffLineRepositorio.Inicializar();
            iVirtTraspasoDetOffLineRepositorio.Inicializar();
            iPA_TraspasosFarmaciaOffLineRepositorio.Inicializar();
            iPAValidarTraspasoCFRepositorio.Inicializar();
            itbl_TemperaturaTraspaso_CabRepositorio.Inicializar();
            itbl_TemperaturaTraspaso_detRepositorio.Inicializar();
            iPA_ArticuloCadenaFrioRepositorio.Inicializar();
            itbl_DetalleTransferenciaBCRepositorio.Inicializar();
        }

        public string ValidartraspasoCF(int traspaso)
        {
            try
            {
                var objx = new Dictionary<string, string>();
                var res = iPAValidarTraspasoCFRepositorio.SqlQuery("EXECUTE [rm].[pa_ValidarTraspasoCF] " + traspaso, objx, 0).ToList();
                if (res != null && res.Count > 0)
                    return res.ElementAt(0).resultado.Equals("SI") ? "S" : "N";
                else
                    return "N";
            }
            catch (Exception ex)
            {

            }
            return "N";
        }

        public Result PA_TraspasosFarmacia(string id_bodega)
        {

            Result resultado = new Result
            {
                respuesta = "error",
                mensaje = "Error al recuperar la información de los traspasos."
            };
            try
            {
                var x = new Dictionary<string, string>();

                bool online = VerificarConexionBDD();
                List<PA_TraspasosFarmacia> result = null;
                if (!online)
                {
                    List<PA_TraspasosFarmaciaOffLine> result2 = iPA_TraspasosFarmaciaOffLineRepositorio.SqlQuery(
                        "EXECUTE [pmov].[pa_TraspasosFarmaciaOffLine] '" + id_bodega + "'", x, 0).ToList();

                    result2 = result2.Where(z => z.ENVIO_POS == null || z.ENVIO_POS.Equals("ET")).ToList();

                    result = (from a in result2
                              select new PA_TraspasosFarmacia
                              {
                                  ENVIO_POS = a.ENVIO_POS,
                                  ID_BODEGA_ORG = a.ID_BODEGA_ORG,
                                  NumeroGuiaRemision = a.NumeroGuiaRemision,
                                  observacion = a.observacion,
                                  TRST_ESTADO = a.TRST_ESTADO,
                                  TRST_FECHA = a.TRST_FECHA,
                                  tr_caja = a.tr_caja,
                                  TR_ESTADO = a.TR_ESTADO,
                                  TR_ESTCONF = a.TR_ESTCONF,
                                  TR_FECDES = a.TR_FECDES,
                                  TR_FOL = a.TR_FOL,
                                  tr_funda = a.tr_funda,
                                  tr_paca = a.tr_paca,
                                  TR_TIPOMOV = a.TR_TIPOMOV,
                                  TR_USUA = a.TR_USUA,
                                  dtbc_tipo_mov = a.dtbc_tipo_mov,
                                  tbcc_retira_matriz = a.tbcc_retira_matriz,
                                  dtbc_tr_fol = a.dtbc_tr_fol,
                                  tbcc_estado = a.tbcc_estado,
                                  tbcc_num_pedido = a.dtbc_tr_fol == null ? 0 : Convert.ToInt32(a.tbcc_num_pedido),
                                  tbcc_oficina = a.tbcc_oficina,
                                  tbcc_sucursal = a.tbcc_sucursal,
                                  tr_es_pedido_facturado = a.tr_es_pedido_facturado
                              }).ToList();


                }
                else
                {
                    result = iPA_TraspasosFarmaciaRepositorio.SqlQuery(
                     "EXECUTE [pmov].[pa_TraspasosFarmacia] '" + id_bodega + "'", x, 0).ToList();
                }

                result = result.Where(y => y.ENVIO_POS == null || !y.ENVIO_POS.Equals("R")).ToList();

                //PROCESAR LOS ESTADOS DE LAS FARMACIAS
                List<TraspasosFarmacia> traspasosFarmacias = ProcesarEstados(result);

                traspasosFarmacias = traspasosFarmacias.OrderBy(y => y.orden).ToList();

                object obj = new
                {
                    TraspasosFarmacia = traspasosFarmacias
                };

                resultado.respuesta = "ok";
                resultado.mensaje = obj;
                return resultado;
            }
            catch (Exception ex)
            {
                registrarLog("PA_TraspasosFarmacia: " + ex.Message + " -- " + ex.StackTrace);
                resultado.mensaje += "PA_TraspasosFarmacia: " + ex.Message;
                return resultado;
            }
        }

        public Result DetalleTraspasos(string traspaso, string bodegaOrg)
        {
            bool unaCaja = false;
            iVIRT_TRASPASOCABRepositorio.Inicializar();
            Result resultado = new Result
            {
                respuesta = "error",
                mensaje = "Error al recuperar el detalle del traspaso."
            };
            try
            {
                var split = traspaso.Split('-');
                string tipoMov = split.ElementAt(0);
                int id_traspaso = Convert.ToInt32(split.ElementAt(1));

                bool online = VerificarConexionBDD();

                VIRT_TRASPASOCAB cab = null;
                List<PA_ValidarTraspasoCF> res = null;
                if (online)
                {
                    cab = iVIRT_TRASPASOCABRepositorio.Find(x => x.TR_FOL == id_traspaso && x.TR_TIPOMOV.Equals(tipoMov) && x.ID_BODEGA_ORG.Equals(bodegaOrg));
                }
                else
                {
                    var cabOff = iVirtTraspasoCabOffLineRepositorio.Find(x => x.TR_FOL == id_traspaso && x.TR_TIPOMOV.Equals(tipoMov) && x.ID_BODEGA_ORG.Equals(bodegaOrg));
                    if (
                        (cabOff.TR_CAJA == 1 && cabOff.TR_PACA == 0 && cabOff.TR_FUNDA == 0) ||
                        (cabOff.TR_CAJA == 0 && cabOff.TR_PACA == 1 && cabOff.TR_FUNDA == 0) ||
                        (cabOff.TR_CAJA == 0 && cabOff.TR_PACA == 0 && cabOff.TR_FUNDA == 1)
                        )
                    {
                        unaCaja = true;
                    }
                    var objx = new Dictionary<string, string>();
                    res = iPAValidarTraspasoCFRepositorio.SqlQuery("EXECUTE [rm].[pa_ValidarTraspasoCF] " + id_traspaso, objx, 0).ToList();

                    if (cabOff == null)
                    {
                        resultado.respuesta = "error";
                        resultado.respuesta = "El traspaso no existe. [bodega origen: " + bodegaOrg + " - tipoMov: " + tipoMov + "]";
                        return resultado;
                    }

                    if (cabOff.VIRT_TRASPASODETOFFLINE == null || cabOff.VIRT_TRASPASODETOFFLINE.Count() == 0)
                    {
                        resultado.respuesta = "error";
                        resultado.respuesta = "El detalle no existe. [bodega: " + bodegaOrg + " - tipoMov: " + tipoMov + "]";
                        return resultado;
                    }

                    cab = new VIRT_TRASPASOCAB
                    {
                        ENVIO_POS = cabOff.ENVIO_POS,
                        ID_BODEGA = cabOff.ID_BODEGA,
                        ID_BODEGA_ORG = cabOff.ID_BODEGA_ORG,
                        ID_ZONA = cabOff.ID_ZONA,
                        NO_GUIA = cabOff.NO_GUIA,
                        TR_CAJA = cabOff.TR_CAJA,
                        TR_CIUDAD = cabOff.TR_CIUDAD,
                        TR_DIRBODD = cabOff.TR_DIRBODD,
                        TR_DIRBODH = cabOff.TR_DIRBODH,
                        TR_ESTADO = cabOff.TR_ESTADO,
                        TR_ESTCONF = cabOff.TR_ESTCONF,
                        TR_FECDES = cabOff.TR_FECDES,
                        TR_FECEM = cabOff.TR_FECEM,
                        TR_FOL = cabOff.TR_FOL,
                        TR_FOLRE = cabOff.TR_FOLRE,
                        TR_FUNDA = cabOff.TR_FUNDA,
                        TR_NOMBODD = cabOff.TR_NOMBODD,
                        TR_NOMBODH = cabOff.TR_NOMBODH,
                        TR_OBS = cabOff.TR_OBS,
                        TR_PACA = cabOff.TR_PACA,
                        tr_secuencial_operador = cabOff.tr_secuencial_operador,
                        TR_TIPOMOV = cabOff.TR_TIPOMOV,
                        TR_USUA = cabOff.TR_USUA,
                        TR_USUD = cabOff.TR_USUD,
                        VIRT_TRASPASODET = (from a in cabOff.VIRT_TRASPASODETOFFLINE
                                            select new VIRT_TRASPASODET
                                            {
                                                ID_BODEGA_ORG = a.ID_BODEGA_ORG,
                                                IVA = a.IVA,
                                                PR_COD = a.PR_COD,
                                                PR_CODB = a.PR_CODB,
                                                PVF = a.PVF,
                                                PVP = a.PVP,
                                                TRD_CAND = a.TRD_CAND,
                                                TRD_CANDF = a.TRD_CANDF,
                                                TRD_CANF = a.TRD_CANF,
                                                TRD_CANFF = a.TRD_CANFF,
                                                TRD_COD = a.TRD_COD,
                                                TRD_CODL = a.TRD_CODL,
                                                TRD_EST = a.TRD_EST,
                                                TRD_FECHA_CAD = a.TRD_FECHA_CAD,
                                                TRD_FECHA_ELAB = a.TRD_FECHA_ELAB,
                                                TRD_LOTE = a.TRD_LOTE,
                                                TRD_MOV = a.TRD_MOV,
                                                TRD_REG_SANITARIO = a.TRD_REG_SANITARIO,
                                                TRD_UME = a.TRD_UME,
                                                TR_FOL = a.TR_FOL,
                                                TR_TIPOMOV = a.TR_TIPOMOV,
                                                UB_ID = a.UB_ID,
                                                od_Cantidad_Facturado = a.od_Cantidad_Facturado

                                            }).ToList(),
                    };
                }

                if (cab == null)
                {
                    resultado.respuesta = "error";
                    resultado.respuesta = "El traspaso no existe.";
                    return resultado;
                }

                Traspaso _traspaso = new Traspaso();
                List<DetalleTraspaso> detalle = new List<DetalleTraspaso>();

                if (cab.VIRT_TRASPASODET.Count >= 1)
                {
                    _traspaso.traspaso = traspaso;
                    _traspaso.usuarioFarmacia = "";
                    _traspaso.bodega = cab.ID_BODEGA;
                    _traspaso.caja = Convert.ToInt32(cab.TR_CAJA);
                    _traspaso.funda = Convert.ToInt32(cab.TR_FUNDA);
                    _traspaso.paca = Convert.ToInt32(cab.TR_PACA);
                    _traspaso.fechaTraspaso = Convert.ToDateTime(cab.TR_FECDES).ToString("yyyy/MM/dd hh:mm:ss");
                    if (res != null && res.Count > 0)
                        _traspaso.cadenaFrio = res.ElementAt(0).resultado.Equals("SI") ? "S" : "N";
                    else
                        _traspaso.cadenaFrio = "N";
                }

                // DESCRIPCIÓN DE LOS ARTÍCULOS
                List<string> arts = cab.VIRT_TRASPASODET.Select(x => x.PR_COD).ToList();
                List<tbl_articulos> articulos = BuscarArticulos(arts);

                if (articulos == null)
                {
                    resultado.mensaje = "Error al recuperar los datos de los artículos.";
                    return resultado;
                }

                List<string> codigosArticulos = cab.VIRT_TRASPASODET.Select(x => x.PR_COD).ToList();
                List<tbl_articulos_codigosbarra> codigosBarras = itbl_Articulos_CodigosbarraRepositorio.Filter(x => codigosArticulos.Contains(x.codigo)).ToList();

                //CADENA DE FRIO ARTICULOS 
                var objxx = new Dictionary<string, string>();
                string whereArtCodsCF = "'''" + string.Join("'',''", codigosArticulos) + "'''";
                List<PA_ArticuloCadenaFrio> artsCF = iPA_ArticuloCadenaFrioRepositorio.SqlQuery("EXECUTE pmov.PA_ArticuloCadenaFrio " + whereArtCodsCF, objxx, 0).ToList();



                foreach (VIRT_TRASPASODET item in cab.VIRT_TRASPASODET)
                {

                    List<R_Barra> c_barras = codigosBarras.Where(x => x.codigo.Equals(item.PR_COD)).Select(x => new R_Barra { codigo = x.codigo_barra }).ToList();

                    tbl_articulos articuloTMP = articulos.FirstOrDefault(x => x.codigo.Equals(item.PR_COD));

                    if (c_barras == null || articuloTMP == null)
                        throw new Exception("El artículo [" + item.PR_COD + "], no está registrado.");

                    var esCF = artsCF.FirstOrDefault(x => x.codigo == item.PR_COD);

                    DetalleTraspaso d = new DetalleTraspaso
                    {
                        codigo = item.PR_COD,
                        descripcion = articuloTMP == null ? "" : articuloTMP.descripcion,
                        barras = c_barras,
                        entero = Convert.ToInt32(item.TRD_CANF),
                        fraccion = Convert.ToInt32(item.TRD_CANFF),
                        mas = 0,
                        menos = 0,
                        cadenaFrio = esCF != null ? "S" : "N",
                        TRD_CANF = Convert.ToInt32(item.TRD_CANF),
                        od_cantidad_facturado = Convert.ToInt32(item.od_Cantidad_Facturado),
                    };
                    d.cantidad = ((d.entero * articuloTMP.valor_POS) + d.fraccion);
                    d.pvf = (item.PVF) / articuloTMP.valor_POS;
                    detalle.Add(d);

                }

                detalle = detalle.OrderBy(x => x.descripcion).ToList();


                //EXISTEN TEMPERATURAS ALMACENADAS

                string idTraspasoTexto = id_traspaso.ToString();
                var tmpsContenedores = itbl_TemperaturaTraspaso_CabRepositorio.Filter(x => x.ttc_tr_fol == idTraspasoTexto).ToList();
                if (tmpsContenedores != null && tmpsContenedores.Count > 0)
                {
                    List<TemperaturaPostVerificacion> temperaturaPostVerificacions = new List<TemperaturaPostVerificacion>();
                    foreach (var item in tmpsContenedores)
                    {
                        TemperaturaPostVerificacion postVerificacion = new TemperaturaPostVerificacion
                        {
                            Contenedor = item.ttc_contenedor,
                            Temperatura = item.ttc_temperatura
                        };
                        temperaturaPostVerificacions.Add(postVerificacion);
                    }
                    _traspaso.temperaturaPostVerificacion = temperaturaPostVerificacions;
                }
                else
                    _traspaso.temperaturaPostVerificacion = new List<TemperaturaPostVerificacion>();

                _traspaso.articulos = detalle;


                if (unaCaja)
                {
                    string trfol = id_traspaso.ToString();
                    var temp = itbl_TemperaturaTraspaso_CabRepositorio.Find(x => x.ttc_tr_fol == trfol && x.ttc_temperatura != 0);
                    if (temp != null)
                        _traspaso.temperaturaCaja = Convert.ToDouble(temp.ttc_temperatura);
                    else
                        _traspaso.temperaturaCaja = 0;
                }

                resultado.mensaje = _traspaso;
                resultado.respuesta = "ok";

                return resultado;
            }
            catch (Exception ex)
            {
                registrarLog("DetalleTraspasos: " + ex.Message + " -- " + ex.StackTrace);
                resultado.mensaje += "DetalleTraspasos: " + ex.Message;
                return resultado;
            }

        }

        public Result ImagenArticulo(string codigo)
        {
            Stream _imageStream;
            Assembly _assembly;

            Result resultado = new Result
            {
                respuesta = "error",
                mensaje = "Error al recuperar la imagen del artículo."
            };
            try
            {
                // IMÁGENES DE LOS ARTÍCULOS
                ipA_ObtenerFotoArticuloRepositorio.Inicializar();

                Image img = null;
                Byte[] imageBytes = null;

                var obj = new Dictionary<string, string>();
                //string joinART = string.Join(";", arts);
                List<PA_ObtenerFotoArticulo> imagenes = ipA_ObtenerFotoArticuloRepositorio.SqlQuery("Exec [pmov].[pa_ObtenerFotosArticulos] '" + codigo + "'", obj, 0).ToList();
                if (imagenes == null || imagenes.Count == 0)
                {
                    resultado.respuesta = "error";
                    _assembly = Assembly.GetExecutingAssembly();
                    _imageStream = _assembly.GetManifestResourceStream("Servicio.ind.jpg");
                    img = Image.FromStream(_imageStream);
                }
                else
                {
                    resultado.respuesta = "ok";
                    imageBytes = imagenes.ElementAt(0).fot_grande_foto;
                    var ms = new MemoryStream(imageBytes);
                    img = Image.FromStream(ms);
                }

                var ms2 = new MemoryStream();
                img = Compress(new Bitmap(img));
                //img.Save(@"C:\Users\diego\Pictures\a.jpg");
                img.Save(ms2, img.RawFormat);
                string base64String = Convert.ToBase64String(ms2.ToArray());

                ImagenArticulo imagenArticulo = new ImagenArticulo
                {
                    codigo = codigo,
                    base64 = base64String
                };

                resultado.mensaje = imagenArticulo;

                return resultado;
            }
            catch (Exception ex)
            {
                registrarLog("ImagenArticulo: " + ex.Message + " -- " + ex.StackTrace);
                resultado.mensaje += "ImagenArticulo: " + ex.Message;
                return resultado;

            }
        }

        private Image Compress(Bitmap Bitmap)
        {
            using (var b = new Bitmap(Bitmap.Width, Bitmap.Height))
            {
                b.SetResolution(Bitmap.HorizontalResolution, Bitmap.VerticalResolution);

                using (var g = Graphics.FromImage(b))
                {
                    g.Clear(Color.White);
                    g.DrawImageUnscaled(Bitmap, 0, 0);
                }

                // Now save b as a JPEG like you normally would




                // Comprimir
                ImageCodecInfo codecInfo = GetEncoderInfo(ImageFormat.Jpeg);

                // Create an Encoder object based on the GUID
                // for the Quality parameter category.
                System.Drawing.Imaging.Encoder myEncoder =
                    System.Drawing.Imaging.Encoder.Quality;

                // Create an EncoderParameters object.
                // An EncoderParameters object has an array of EncoderParameter
                // objects. In this case, there is only one
                // EncoderParameter object in the array.
                EncoderParameters myEncoderParameters = new EncoderParameters(1);
                EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 50L);
                myEncoderParameters.Param[0] = myEncoderParameter;



                //picture.

                MemoryStream output = new MemoryStream();
                b.Save(output, codecInfo, myEncoderParameters);
                var ms = new MemoryStream(output.ToArray());
                Image img = Image.FromStream(ms);
                return img;
            }
        }

        public ImageCodecInfo GetEncoderInfo(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
                if (codec.FormatID == format.Guid)
                    return codec;

            return null;
        }

        private List<tbl_articulos> BuscarArticulos(List<string> arts)
        {
            List<tbl_articulos> articulos;
            try
            {
                itbl_ArticulosRepositorio.InicializarMatriz();

                articulos = itbl_ArticulosRepositorio.Filter(x => arts.Contains(x.codigo)).ToList();

                return articulos;
            }
            catch (Exception ex)
            {
                registrarLog("RecepcionTraspaso: " + ex.Message + " -- " + ex.StackTrace);
                return null;
            }
        }

        private List<TraspasosFarmacia> ProcesarEstados(List<PA_TraspasosFarmacia> result)
        {
            List<TraspasosFarmacia> traspasosFarmacia = new List<TraspasosFarmacia>();
            foreach (PA_TraspasosFarmacia item in result)
            {
                string tipoTraspaso = item.TR_TIPOMOV.ToUpper();
                string estado = "";
                string descripcion = "";
                int orden = 0;


                //ANULADO

                if (item.TR_ESTADO.Equals("A"))
                    continue;

                // EL TRASPASO ESTA EN FARMACIA: ET EP
                if (item.ENVIO_POS != null)
                {
                    if (item.ENVIO_POS.Equals("ET"))
                    {
                        estado = "ET";
                        descripcion = "POR RECIBIR";
                        orden = 1;
                    }

                    if (item.ENVIO_POS.Equals("EP"))
                    {
                        estado = "EP";
                        descripcion = "VERIFICADO PARCIAL";
                        orden = 2;
                    }
                }
                else// EL TRASPASO ESTA EN TRANSPORTE: T E   
                    if (item.ENVIO_POS == null && string.IsNullOrEmpty(item.ENVIO_POS) && item.TR_ESTCONF.Equals("D"))
                {
                    if (item.TRST_ESTADO == null)
                    {
                        estado = "ET";
                        descripcion = "POR RECIBIR";
                        orden = 1;
                    }
                    else if (item.TRST_ESTADO.Equals("T"))
                    {
                        estado = "T";
                        descripcion = "EN TRANSPORTE";
                        orden = 3;
                    }
                    else
                    {
                        estado = "D";
                        descripcion = "CERTIFICADO";
                        orden = 4;
                    }
                }

                //SOLO CUANDO ESTEN CERTIFICADOS Y EN LAS VIR 159
                if (item.TR_ESTCONF.Equals("D") && (item.ENVIO_POS == null) || item.ENVIO_POS.Equals("ET"))
                {
                    TraspasosFarmacia t = new TraspasosFarmacia
                    {
                        fecha = Convert.ToDateTime(item.TR_FECDES).ToString("yyyy/MM/dd hh:mm:ss"),
                        traspaso = tipoTraspaso + "-" + item.TR_FOL,
                        estado = string.IsNullOrEmpty(estado) ? "T" : estado,
                        descripcion = descripcion,
                        usuario = item.TR_USUA.ToUpper(),
                        bodega_org = item.ID_BODEGA_ORG,
                        guia = item.NumeroGuiaRemision == null ? "" : "001-007-00" + item.NumeroGuiaRemision.ToString(),
                        orden = orden,
                        observacion = item.observacion,
                    };


                    if (!string.IsNullOrEmpty(item.tr_es_pedido_facturado) && item.tr_es_pedido_facturado == "S")
                    {
                        t.PedidoFacturado = "S";
                    }
                    else
                        t.PedidoFacturado = "N";

                    traspasosFarmacia.Add(t);
                }

            }
            return traspasosFarmacia;
        }


        /// <summary>
        /// Permite generar kárdex en Matriz y farmacia, adicional actualizar el estado en Matriz y guardar en Matriz tablas VIRT
        /// </summary>
        /// <param name="result">Detalle del traspaso procesado</param>
        /// <returns></returns>
        public Result GenerarKardex(Traspaso result)
        {

            try
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                string json = ser.Serialize(result);
                string docPath = AppDomain.CurrentDomain.BaseDirectory;
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, DateTime.Now.ToString("yyyyMMddms") + ".txt")))
                {

                    outputFile.WriteLine(json);
                }

            }
            catch (Exception ex)
            {

            }




            Result resultado = new Result
            {
                respuesta = "error",
                mensaje = "Error al generar el kárdex de los traspasos."
            };
            try
            {

                result.articulos.ForEach(x =>
                {
                    x.pvf = Math.Round(x.pvf, 4);
                });

                //string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["EasyContextoMatriz"].ConnectionString;

                //if (connectionString.Contains("192.168.251.178"))
                //{
                //    if (result.bodega.Equals("0079"))
                //        result.bodega = "079";
                //}

                // VERIFICAR 

                // temperatura

                List<tbl_TemperaturaTraspaso_det> detsTemperatura = new List<tbl_TemperaturaTraspaso_det>();

                List<string> codigosArt = new List<string>();

                foreach (var item in result.articulos)
                {
                    codigosArt.Add(item.codigo);

                    if (item.temperaturas != null && item.temperaturas.Count > 0)
                    {
                        foreach (var artTemp in item.temperaturas)
                        {
                            if (artTemp != null)
                            {
                                decimal temperat = Convert.ToDecimal(artTemp.Temperatura);
                                string contenedor = artTemp.Contenedor.ElementAt(artTemp.Contenedor.Length - 2).ToString() + artTemp.Contenedor.ElementAt(artTemp.Contenedor.Length - 1).ToString();
                                string ntraspaso = result.traspaso.Split('-').ElementAt(1);

                                tbl_TemperaturaTraspaso_det tmpDet = new tbl_TemperaturaTraspaso_det
                                {
                                    ttd_contenedor = contenedor,
                                    ttd_fecha = DateTime.Now,
                                    ttd_observacion = "",
                                    ttd_producto = item.codigo,
                                    ttd_temperatura = Convert.ToDecimal(artTemp.Temperatura),
                                    ttd_tr_fol = ntraspaso,
                                    ttd_usuario = result.usuarioFarmacia.ToUpper(),
                                    ENVIO_POS = null,
                                };
                                detsTemperatura.Add(tmpDet);
                            }
                        }
                    }
                }

                List<tbl_articulos> articulosTraspaso = itbl_ArticulosRepositorio.Filter(x => codigosArt.Contains(x.codigo)).ToList();



                Traspaso _traspaso = result;
                iOficinaRepositorio.Inicializar();
                iVirtTraspasoCabOffLineRepositorio.Inicializar();
                itbl_maestromovinventRepositorioFarmacia.InicializarFarmacia();
                /// Obtener datos de la oficina
                Oficinas datosOficina = iOficinaRepositorio.Find(t => t.oficina == _traspaso.bodega);
                int id_traspaso = Convert.ToInt32(_traspaso.traspaso.Split('-').ElementAt(1));
                VIRT_TRASPASOCABOFFLINE virtOffLine = iVirtTraspasoCabOffLineRepositorio.Find(t => t.TR_FOL == id_traspaso);

                if (virtOffLine == null)
                {
                    resultado.respuesta = "error";
                    resultado.mensaje = "El traspaso " + id_traspaso + " no existe en VirtTraspasoCabOffLine.";
                    return resultado;
                }

                RegistroAppMovil(id_traspaso, _traspaso.usuarioFarmacia + "|IK", _traspaso.bodega);


                // Verificar si es pedido

                var parDic = new Dictionary<string, string>();

                List<PA_TraspasosFarmaciaOffLine> result2 = iPA_TraspasosFarmaciaOffLineRepositorio.SqlQuery("EXECUTE [pmov].[pa_TraspasosFarmaciaOffLine] '" + result.bodega + "'", parDic, 0).ToList();

                // 0 no es pedido
                // 1 es pedido no genera kardex
                // 2 es pedido genera kardex

                int esPedido = 0;


                var traspasoActual = result2.FirstOrDefault(x => x.TR_FOL == id_traspaso && x.tbcc_retira_matriz != null && (x.tbcc_retira_matriz == "N" || x.tbcc_retira_matriz == "X"));

                if (traspasoActual != null && traspasoActual.tbcc_retira_matriz == "X")
                {
                    resultado.respuesta = "error";
                    resultado.mensaje = "Revisar la cabecera del pedido facturado.";
                    return resultado;
                }

                if (traspasoActual != null)
                {
                    esPedido = 1;
                }


                if (datosOficina != null)
                {
                    ///Verificar si ya existe kárdex del traspaso
                    #region GenerarXML
                    string xmlKardex = "'<MovimientoKardex><MovCabecera Id = \"1\" Compania = \"002\" Sucursal = \"" + datosOficina.sucursal + "\" Oficina = \"" + datosOficina.oficina +
                    "\" Bodega = \"" + _traspaso.bodega + "\" TipoMov = \"TRASPASOS\"  TipoCausa = \"TRASPASOS\" tipo_doc_inv = \"" + virtOffLine.TR_TIPOMOV.ToString() + "\" Usuario = \"" + _traspaso.usuarioFarmacia + "\" Obs = \"ENTRADA REF. TR#" + id_traspaso + "\" NumDoc = \"" +
                    id_traspaso + "\" Monto = \"0\" num_documento=\"0\">";

                    ///Detalle de Xml para generación de kárdex
                    decimal monto = 0;
                    if (_traspaso.articulos.FindAll(t => t.cantidad == 0).ToList().Count > 0)
                    {
                        resultado.mensaje = "Error cantidad de los productos en cero(0).Por favor actualice la aplicación.";
                        return resultado;
                    }
                    foreach (var item in _traspaso.articulos)
                    {
                        var infoArt = articulosTraspaso.FirstOrDefault(z => z.codigo == item.codigo);
                        var artTraspasoDetTMP = virtOffLine.VIRT_TRASPASODETOFFLINE.FirstOrDefault(z => z.PR_COD == item.codigo);

                        if (esPedido > 0)
                        {
                            if (Convert.ToInt32(artTraspasoDetTMP.TRD_CANF) > 0 && Convert.ToInt32(artTraspasoDetTMP.TRD_CANF) - artTraspasoDetTMP.od_Cantidad_Facturado > 0)
                            {
                                xmlKardex += "<MovDetalle Id = \"1\" CodProd = \"" + item.codigo + "\" Precio = \"" + item.pvf + "\" Cant = \"" + ((Convert.ToInt32(artTraspasoDetTMP.TRD_CANF) - artTraspasoDetTMP.od_Cantidad_Facturado) * infoArt.valor_POS) + "\"/>";
                                monto += (Convert.ToInt32(artTraspasoDetTMP.TRD_CANF) - Convert.ToInt32(artTraspasoDetTMP.od_Cantidad_Facturado)) * infoArt.valor_POS * item.pvf;

                                esPedido = 2;
                            }
                        }
                        else
                        {
                            xmlKardex += "<MovDetalle Id = \"1\" CodProd = \"" + item.codigo + "\" Precio = \"" + item.pvf + "\" Cant = \"" + item.cantidad + "\"/>";
                            monto += item.cantidad * item.pvf;
                        }
                    }
                    xmlKardex += "</MovCabecera ></MovimientoKardex>'";
                    xmlKardex = xmlKardex.Replace("Monto = \"0\"", "Monto=\"" + monto + "\"");
                    #endregion
                    var x = new Dictionary<string, string>();

                    string xmlKardexMatriz = xmlKardex;

                    // GENERACIÓN KARDEX FARMACIA ****************************************************************************+     



                    try
                    {
                        string traspasoVerif = virtOffLine.TR_TIPOMOV.ToUpper() + "" + virtOffLine.TR_FOL;
                        var verif = iVIRT_TRASPASOVERIFMERCADERIA.Find(Z => Z.numTraspaso.Equals(traspasoVerif));
                        if (verif != null)
                        {
                            verif.vtvm_estado_recepcion = "RECEPCION";
                            verif.vtvm_ip_maquina = "127.0.0.0";
                            verif.vtvm_estado_traspaso = "COMPLETO";
                            verif.vtvm_usuario_recepcion = result.usuarioFarmacia.ToUpper();

                            iVIRT_TRASPASOVERIFMERCADERIA.Update(verif);

                        }

                    }
                    catch (Exception ex)
                    {

                        registrarLog(ex.Message);
                    }




                    resultado = VerificaExisteKardex(id_traspaso, datosOficina.oficina, false, _traspaso.traspaso.Split('-').ElementAt(0));
                    registrarLog("GenerarKardex: 10");

                    if (esPedido == 1)
                        resultado.respuesta = "0:0";
                    //if (esPedido == 2 && resultado.respuesta.Equals("ERROR"))
                    //    resultado.respuesta = "OK";

                    if (resultado.respuesta.Equals("OK"))///No existe generado kárdex
                    {
                        #region NoExisteKardexEnFarmacia
                        iPA_GenerarKardexFarmacia.Inicializar();
                        xmlKardex = xmlKardex.Replace("NumDoc = \"" + id_traspaso + "\"", "NumDoc=\"0\""); ///Remplazo numero de traspaso en farmacia es diferente el número de movimiento
                        xmlKardex = xmlKardex.Replace("num_documento=\"0\"", "num_documento=\"" + id_traspaso + "\"");///Número de documento para poder relacionar con el traspaso.
                        registrarLog("GenerarKardex: 9" + xmlKardex);                                                                             ///Generación de kárdex en farmacia, parámetro XML
                        xmlKardex = xmlKardex.Replace(',', '.');
                        List<PA_GEN_GenerarKardexFarmacia> resulKardexFar = iPA_GenerarKardexFarmacia.SqlQuery("Exec PA_GEN_GenerarKardex " + xmlKardex, x, 0).ToList();
                        if (resulKardexFar != null && resulKardexFar.Count > 0)
                        {
                            if (resulKardexFar[0].result.Equals("OK"))
                            {
                                #region Ejecución PA en Farmacia Correcto
                                ////Creación de las entidades VIRT para guardar en la farmacia
                                VIRT_TRASPASOCABFarmacia virtTraspasoFarmaciaExis = iVIRT_TRASPASOCABFarmaciaRepositorio.Find(t => t.TR_FOL == id_traspaso && t.ID_BODEGA == _traspaso.bodega);

                                if (virtTraspasoFarmaciaExis == null)
                                {
                                    #region NoExistenVirtFarmacia
                                    VIRT_TRASPASOCABFarmacia virtTraspasoFarmacia = new VIRT_TRASPASOCABFarmacia
                                    {
                                        ENVIO_POS = "OF",
                                        ID_BODEGA = virtOffLine.ID_BODEGA,
                                        ID_BODEGA_ORG = virtOffLine.ID_BODEGA_ORG,
                                        ID_ZONA = virtOffLine.ID_ZONA,
                                        NO_GUIA = virtOffLine.NO_GUIA,
                                        TR_CAJA = virtOffLine.TR_CAJA,
                                        TR_CIUDAD = virtOffLine.TR_CIUDAD,
                                        TR_DIRBODD = virtOffLine.TR_DIRBODD,
                                        TR_DIRBODH = virtOffLine.TR_DIRBODH,
                                        TR_ESTADO = virtOffLine.TR_ESTADO,
                                        TR_ESTCONF = virtOffLine.TR_ESTCONF,
                                        TR_FECDES = virtOffLine.TR_FECDES,
                                        TR_FECEM = virtOffLine.TR_FECEM,
                                        TR_FOL = virtOffLine.TR_FOL,
                                        TR_FOLRE = virtOffLine.TR_FOLRE,
                                        TR_FUNDA = virtOffLine.TR_FUNDA,
                                        TR_NOMBODD = virtOffLine.TR_NOMBODD,
                                        TR_NOMBODH = virtOffLine.TR_NOMBODH,
                                        TR_OBS = virtOffLine.TR_OBS,
                                        TR_PACA = virtOffLine.TR_PACA,
                                        tr_secuencial_operador = virtOffLine.tr_secuencial_operador,
                                        TR_TIPOMOV = virtOffLine.TR_TIPOMOV,
                                        TR_USUA = virtOffLine.TR_USUA,
                                        TR_USUD = result.usuarioFarmacia.ToUpper()
                                    };
                                    foreach (var item in virtOffLine.VIRT_TRASPASODETOFFLINE)
                                    {

                                        VIRT_TRASPASODETFarmacia virtd = new VIRT_TRASPASODETFarmacia
                                        {
                                            ID_BODEGA_ORG = item.ID_BODEGA_ORG,
                                            IVA = item.IVA,
                                            PR_COD = item.PR_COD,
                                            PR_CODB = item.PR_CODB,
                                            PVF = item.PVF,
                                            PVP = item.PVP,
                                            TR_FOL = item.TR_FOL,
                                            TR_TIPOMOV = item.TR_TIPOMOV,
                                            TRD_CAND = item.TRD_CAND,
                                            TRD_CANDF = item.TRD_CANDF,
                                            TRD_CANF = item.TRD_CANF,
                                            TRD_CANFF = item.TRD_CANFF,
                                            TRD_COD = item.TRD_COD,
                                            TRD_CODL = item.TRD_CODL,
                                            TRD_EST = item.TRD_EST,
                                            TRD_FECHA_CAD = item.TRD_FECHA_CAD,
                                            TRD_FECHA_ELAB = item.TRD_FECHA_ELAB,
                                            TRD_LOTE = item.TRD_LOTE,
                                            TRD_MOV = item.TRD_MOV,
                                            TRD_REG_SANITARIO = item.TRD_REG_SANITARIO,
                                            TRD_UME = item.TRD_UME,
                                            UB_ID = item.UB_ID
                                        };
                                        virtTraspasoFarmacia.VIRT_TRASPASODETFarmacia.Add(virtd);
                                    }
                                    ///Actualizar entidad
                                    virtOffLine.ENVIO_POS = "OF";

                                    bool flagKardexGenerado = false;


                                    try
                                    {
                                        if (esPedido > 0)
                                        {
                                            //virtOffLine.ENVIO_POS = "OF";
                                            var detObj = itbl_DetalleTransferenciaBCRepositorio.Find(det => det.dtbc_tr_fol == id_traspaso);
                                            detObj.dtbc_tipo_mov = "OK";
                                            itbl_DetalleTransferenciaBCRepositorio.Update(detObj);
                                        }

                                        iVirtTraspasoCabOffLineRepositorio.Update(virtOffLine);
                                        iVIRT_TRASPASOCABFarmaciaRepositorio.Create(virtTraspasoFarmacia);
                                        resultado.respuesta = "OK";


                                        if (esPedido == 2)
                                            resultado.mensaje = "La recepción de la guía se ha realizado correctamente... Nro. de Movimiento Kardex [" + resulKardexFar[0].nummov + "]";
                                        else if (esPedido == 1)
                                            resultado.mensaje = "La recepción de la guía se ha realizado correctamente.";
                                        else
                                            resultado.mensaje = "La recepción de la guía se ha realizado correctamente... Nro. de Movimiento Kardex [" + resulKardexFar[0].nummov + "]";



                                        //registrarLog(_traspaso.fechaTraspaso);
                                        RegistroAppMovil(id_traspaso, _traspaso.usuarioFarmacia + "|FK", _traspaso.bodega);
                                        resultado = GenerarInconsistencia(_traspaso, resultado);

                                        VIRT_TRASPASOCABFarmacia virtTraspasoGenerado = iVIRT_TRASPASOCABFarmaciaRepositorio.Find(t => t.TR_FOL == id_traspaso && t.ID_BODEGA == _traspaso.bodega);
                                        if (virtTraspasoGenerado != null && virtTraspasoGenerado.TR_FOL != 0)
                                            flagKardexGenerado = true;
                                        else
                                        {
                                            resultado.respuesta = "Error";
                                            resultado.mensaje = "Error al generar kárdex en la farmacia.";
                                            return resultado;
                                        }
                                    }
                                    catch (Exception ex)
                                    {

                                        resultado.respuesta = "Error";
                                        resultado.mensaje = "Error al ingresar en tablas VIRT por favor intente nuevamente.";
                                    }


                                    ServicioIntegradorSAP.I51Datos i51Datos = null;
                                    string centro = "";

                                    if (Properties.Settings.Default.tipoEjecucion.Equals("SAP"))
                                    {
                                        if (flagKardexGenerado)
                                        {
                                            try
                                            {
                                                try
                                                {
                                                    if (virtOffLine.vtc_numero_pedido_sap != null)
                                                    {
                                                        var vtcNumeroPedido = virtOffLine.vtc_numero_pedido_sap.Split('|');
                                                        centro = vtcNumeroPedido.ElementAt(0);
                                                        string pedidoSAP = vtcNumeroPedido.ElementAt(1);

                                                        i51Datos = new ServicioIntegradorSAP.I51Datos
                                                        {
                                                            Cabecera = new ServicioIntegradorSAP.CabeceraConfirmPedido
                                                            {
                                                                NotaEntrega = pedidoSAP,
                                                                Almacen = "",
                                                                Centro = centro,
                                                                NumOrdenCompra = "",
                                                                FechaContabilizacion = DateTime.Now.ToString("yyyy-MM-dd"),
                                                                FechaDocumento = DateTime.Now.ToString("yyyy-MM-dd"),
                                                            }
                                                        };

                                                    }
                                                    else
                                                    {
                                                        virtOffLine.TR_OBS = "SP|" + centro;
                                                    }
                                                }
                                                catch (Exception ex)
                                                {
                                                    virtOffLine.TR_OBS = "SP|" + centro;
                                                    registrarLog(ex.Message);
                                                }


                                                using (ServicioIntegradorSAP.ServicioConsumoSoapClient sap = new ServicioIntegradorSAP.ServicioConsumoSoapClient())
                                                {
                                                    ServicioIntegradorSAP.I51Respuesta res = null;

                                                    if (esPedido == 0 || esPedido == 2)
                                                        res = sap.ConfirmarTraspasoPedido(i51Datos);

                                                    if (esPedido > 0 || res.Resultado)
                                                    {
                                                        if (!res.Resultado)
                                                        {
                                                            if (res.Mensajes != null && res.Mensajes.Count > 0 && res.Mensajes.ElementAt(0).ToLower().Contains("previamente"))
                                                            {
                                                                virtOffLine.TR_OBS = "OK";
                                                                virtOffLine.ENVIO_POS = "R";
                                                                virtTraspasoFarmaciaExis.ENVIO_POS = "R";
                                                            }
                                                            else
                                                            {
                                                                virtOffLine.TR_OBS = "SP|" + centro;
                                                                virtOffLine.ENVIO_POS = "OF";
                                                                virtTraspasoFarmaciaExis.ENVIO_POS = "OF";
                                                            }
                                                        }
                                                        else
                                                        {
                                                            virtOffLine.TR_OBS = "OK";
                                                            virtOffLine.ENVIO_POS = "R";
                                                            virtTraspasoFarmaciaExis.ENVIO_POS = "R";
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (res.Mensajes != null && res.Mensajes.Count > 0 && res.Mensajes.ElementAt(0).ToLower().Contains("procesado previamente"))
                                                        {
                                                            virtOffLine.TR_OBS = "OK";
                                                            virtOffLine.ENVIO_POS = "R";
                                                            virtTraspasoFarmaciaExis.ENVIO_POS = "R";
                                                        }
                                                        else
                                                        {
                                                            virtOffLine.TR_OBS = "SP|" + centro;
                                                            registrarLog(res.Xml);
                                                            registrarLog(res.XmlEnvio);
                                                        }
                                                    }

                                                    using (TransactionScope t = new TransactionScope(TransactionScopeOption.Required))
                                                    {
                                                        try
                                                        {
                                                            if (esPedido > 0)
                                                            {
                                                                //virtOffLine.ENVIO_POS = "OF";
                                                                var detObj = itbl_DetalleTransferenciaBCRepositorio.Find(det => det.dtbc_tr_fol == id_traspaso);
                                                                detObj.dtbc_tipo_mov = "OK";
                                                                itbl_DetalleTransferenciaBCRepositorio.Update(detObj);
                                                            }



                                                            if (detsTemperatura.Count > 0)
                                                                itbl_TemperaturaTraspaso_detRepositorio.CreateMasivo(detsTemperatura);

                                                            iVirtTraspasoCabOffLineRepositorio.Update(virtOffLine);
                                                            iVIRT_TRASPASOCABFarmaciaRepositorio.Update(virtTraspasoFarmacia);
                                                            t.Complete();
                                                        }
                                                        catch (Exception ex2)
                                                        {
                                                            t.Dispose();
                                                            registrarLog(ex2.Message);
                                                        }
                                                    }
                                                }

                                            }
                                            catch (Exception ex)
                                            {
                                                registrarLog(ex.Message);
                                            }
                                        }
                                    }


                                    #endregion
                                }
                                else
                                {
                                    #region ExistenVirtFarmacia
                                    ///Actualizar entidad
                                    virtOffLine.ENVIO_POS = "OF";


                                    if (esPedido > 0)
                                    {
                                        //virtOffLine.ENVIO_POS = "OF";
                                        //virtOffLine.TR_OBS = "OK";
                                        var detObj = itbl_DetalleTransferenciaBCRepositorio.Find(det => det.dtbc_tr_fol == id_traspaso);
                                        detObj.dtbc_tipo_mov = "OK";
                                        itbl_DetalleTransferenciaBCRepositorio.Update(detObj);
                                    }

                                    int update = iVirtTraspasoCabOffLineRepositorio.Update(virtOffLine);

                                    ServicioIntegradorSAP.I51Datos i51Datos = null;
                                    string centro = "";

                                    if (Properties.Settings.Default.tipoEjecucion.Equals("SAP"))
                                    {

                                        try
                                        {
                                            try
                                            {
                                                if (virtOffLine.vtc_numero_pedido_sap != null)
                                                {
                                                    var vtcNumeroPedido = virtOffLine.vtc_numero_pedido_sap.Split('|');
                                                    centro = vtcNumeroPedido.ElementAt(0);
                                                    string pedidoSAP = vtcNumeroPedido.ElementAt(1);

                                                    i51Datos = new ServicioIntegradorSAP.I51Datos
                                                    {
                                                        Cabecera = new ServicioIntegradorSAP.CabeceraConfirmPedido
                                                        {
                                                            NotaEntrega = pedidoSAP,
                                                            Almacen = "",
                                                            Centro = centro,
                                                            NumOrdenCompra = "",
                                                            FechaContabilizacion = DateTime.Now.ToString("yyyy-MM-dd"),
                                                            FechaDocumento = DateTime.Now.ToString("yyyy-MM-dd"),
                                                        }
                                                    };

                                                }
                                                else
                                                {
                                                    virtOffLine.TR_OBS = "SP|" + centro;
                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                                virtOffLine.TR_OBS = "SP|" + centro;
                                                registrarLog(ex.Message);
                                            }


                                            using (ServicioIntegradorSAP.ServicioConsumoSoapClient sap = new ServicioIntegradorSAP.ServicioConsumoSoapClient())
                                            {
                                                ServicioIntegradorSAP.I51Respuesta res = null;

                                                if (esPedido == 0 || esPedido == 2)
                                                    res = sap.ConfirmarTraspasoPedido(i51Datos);

                                                if (esPedido > 0 || res.Resultado)
                                                {

                                                    if (!res.Resultado)
                                                    {
                                                        if (res.Mensajes != null && res.Mensajes.Count > 0 && res.Mensajes.ElementAt(0).ToLower().Contains("procesado previamente"))
                                                        {
                                                            virtOffLine.TR_OBS = "OK";
                                                            virtOffLine.ENVIO_POS = "R";
                                                            virtTraspasoFarmaciaExis.ENVIO_POS = "R";
                                                        }
                                                        else
                                                        {
                                                            virtOffLine.TR_OBS = "SP|" + centro;
                                                            virtOffLine.ENVIO_POS = "OF";
                                                            virtTraspasoFarmaciaExis.ENVIO_POS = "OF";
                                                        }
                                                    }
                                                    else
                                                    {
                                                        virtOffLine.TR_OBS = "OK";
                                                        virtOffLine.ENVIO_POS = "R";
                                                        virtTraspasoFarmaciaExis.ENVIO_POS = "R";
                                                    }
                                                }

                                                else
                                                {

                                                    if (res.Mensajes != null && res.Mensajes.Count > 0 && res.Mensajes.ElementAt(0).ToLower().Contains("procesado previamente"))
                                                    {
                                                        virtOffLine.TR_OBS = "OK";
                                                        virtOffLine.ENVIO_POS = "R";
                                                        virtTraspasoFarmaciaExis.ENVIO_POS = "R";
                                                    }
                                                    else
                                                    {
                                                        virtOffLine.TR_OBS = "SP|" + centro;
                                                        registrarLog(res.Xml);
                                                        registrarLog(res.XmlEnvio);
                                                    }


                                                }

                                                using (TransactionScope t = new TransactionScope(TransactionScopeOption.Required))
                                                {
                                                    try
                                                    {
                                                        if (esPedido > 0)
                                                        {
                                                            var detObj = itbl_DetalleTransferenciaBCRepositorio.Find(det => det.dtbc_tr_fol == id_traspaso);
                                                            detObj.dtbc_tipo_mov = "OK";
                                                            itbl_DetalleTransferenciaBCRepositorio.Update(detObj);
                                                        }

                                                        if (detsTemperatura.Count > 0)
                                                            itbl_TemperaturaTraspaso_detRepositorio.CreateMasivo(detsTemperatura);
                                                        iVirtTraspasoCabOffLineRepositorio.Update(virtOffLine);
                                                        iVIRT_TRASPASOCABFarmaciaRepositorio.Update(virtTraspasoFarmaciaExis);
                                                        t.Complete();
                                                    }
                                                    catch (Exception ex2)
                                                    {
                                                        t.Dispose();
                                                        registrarLog(ex2.Message);
                                                    }
                                                }
                                            }

                                        }
                                        catch (Exception ex)
                                        {
                                            registrarLog(ex.Message);
                                        }

                                    }

                                    resultado.respuesta = "OK";


                                    if (esPedido == 2)
                                        resultado.mensaje = "La recepción de la guía se ha realizado correctamente... Nro. de Movimiento Kardex [" + resulKardexFar[0].nummov + "]";
                                    else if (esPedido == 1)
                                        resultado.mensaje = "La recepción de la guía se ha realizado correctamente.";
                                    else
                                        resultado.mensaje = "La recepción de la guía se ha realizado correctamente... Nro. de Movimiento Kardex [" + resulKardexFar[0].nummov + "]";
                                    RegistroAppMovil(id_traspaso, _traspaso.usuarioFarmacia + "|FKN", _traspaso.bodega);
                                    resultado = GenerarInconsistencia(_traspaso, resultado);

                                    #endregion
                                }
                                #endregion
                            }
                            else
                            {
                                resultado.respuesta = "Error";
                                resultado.mensaje = "Error al generar kárdex en la farmacia.";
                            }
                        }
                        else
                        {
                            resultado.respuesta = "Error";
                            resultado.mensaje = "Error al ejecutar PA_Gen_GenerarKardex en la farmacia.";
                        }

                        #endregion
                    }
                    else ///kárdex generado en farmacia
                    {
                        #region ExisteKardexEnFarmacia
                        iVIRT_TRASPASOCABFarmaciaRepositorio.Inicializar();
                        ///Creación de las entidades VIRT para guardar en la farmacia
                        VIRT_TRASPASOCABFarmacia virtTraspasoFarmaciaExis = iVIRT_TRASPASOCABFarmaciaRepositorio.Find(t => t.TR_FOL == id_traspaso && t.ID_BODEGA == _traspaso.bodega);
                        if (virtTraspasoFarmaciaExis == null)
                        {
                            #region NoExistenVirtenFarmacia
                            VIRT_TRASPASOCABFarmacia virtTraspasoFarmacia = new VIRT_TRASPASOCABFarmacia
                            {
                                ENVIO_POS = "OF",
                                ID_BODEGA = virtOffLine.ID_BODEGA,
                                ID_BODEGA_ORG = virtOffLine.ID_BODEGA_ORG,
                                ID_ZONA = virtOffLine.ID_ZONA,
                                NO_GUIA = virtOffLine.NO_GUIA,
                                TR_CAJA = virtOffLine.TR_CAJA,
                                TR_CIUDAD = virtOffLine.TR_CIUDAD,
                                TR_DIRBODD = virtOffLine.TR_DIRBODD,
                                TR_DIRBODH = virtOffLine.TR_DIRBODH,
                                TR_ESTADO = virtOffLine.TR_ESTADO,
                                TR_ESTCONF = virtOffLine.TR_ESTCONF,
                                TR_FECDES = virtOffLine.TR_FECDES,
                                TR_FECEM = virtOffLine.TR_FECEM,
                                TR_FOL = virtOffLine.TR_FOL,
                                TR_FOLRE = virtOffLine.TR_FOLRE,
                                TR_FUNDA = virtOffLine.TR_FUNDA,
                                TR_NOMBODD = virtOffLine.TR_NOMBODD,
                                TR_NOMBODH = virtOffLine.TR_NOMBODH,
                                TR_OBS = virtOffLine.TR_OBS,
                                TR_PACA = virtOffLine.TR_PACA,
                                tr_secuencial_operador = virtOffLine.tr_secuencial_operador,
                                TR_TIPOMOV = virtOffLine.TR_TIPOMOV,
                                TR_USUA = virtOffLine.TR_USUA,
                                TR_USUD = result.usuarioFarmacia.ToUpper()
                            };
                            foreach (var item in virtOffLine.VIRT_TRASPASODETOFFLINE)
                            {

                                VIRT_TRASPASODETFarmacia virtd = new VIRT_TRASPASODETFarmacia
                                {
                                    ID_BODEGA_ORG = item.ID_BODEGA_ORG,
                                    IVA = item.IVA,
                                    PR_COD = item.PR_COD,
                                    PR_CODB = item.PR_CODB,
                                    PVF = item.PVF,
                                    PVP = item.PVP,
                                    TR_FOL = item.TR_FOL,
                                    TR_TIPOMOV = item.TR_TIPOMOV,
                                    TRD_CAND = item.TRD_CAND,
                                    TRD_CANDF = item.TRD_CANDF,
                                    TRD_CANF = item.TRD_CANF,
                                    TRD_CANFF = item.TRD_CANFF,
                                    TRD_COD = item.TRD_COD,
                                    TRD_CODL = item.TRD_CODL,
                                    TRD_EST = item.TRD_EST,
                                    TRD_FECHA_CAD = item.TRD_FECHA_CAD,
                                    TRD_FECHA_ELAB = item.TRD_FECHA_ELAB,
                                    TRD_LOTE = item.TRD_LOTE,
                                    TRD_MOV = item.TRD_MOV,
                                    TRD_REG_SANITARIO = item.TRD_REG_SANITARIO,
                                    TRD_UME = item.TRD_UME,
                                    UB_ID = item.UB_ID
                                };
                                virtTraspasoFarmacia.VIRT_TRASPASODETFarmacia.Add(virtd);
                            }
                            ///Actualizar entidad
                            virtOffLine.ENVIO_POS = "OF";


                            bool flagKardexGenerado = false;


                            try
                            {
                                if (esPedido > 0)
                                {
                                    //virtOffLine.ENVIO_POS = "OF";
                                    var detObj = itbl_DetalleTransferenciaBCRepositorio.Find(det => det.dtbc_tr_fol == id_traspaso);
                                    detObj.dtbc_tipo_mov = "OK";
                                    //virtOffLine.TR_OBS = "OK";
                                    itbl_DetalleTransferenciaBCRepositorio.Update(detObj);
                                }

                                iVirtTraspasoCabOffLineRepositorio.Update(virtOffLine);
                                iVIRT_TRASPASOCABFarmaciaRepositorio.Create(virtTraspasoFarmacia);

                                resultado.respuesta = "OK";
                                string[] respuestaMov = resultado.mensaje.ToString().Split(':');
                                RegistroAppMovil(id_traspaso, _traspaso.usuarioFarmacia + "|FKEM", _traspaso.bodega);


                                if (esPedido > 0)
                                    resultado.mensaje = "La recepción de la guía se ha realizado correctamente.";
                                else
                                    resultado.mensaje = "La recepción de la guía se ha realizado correctamente con Nro. de movimiento de kárdex:[" + respuestaMov[1] + "]";
                                resultado = GenerarInconsistencia(_traspaso, resultado);

                                VIRT_TRASPASOCABFarmacia virtTraspasoGenerado = iVIRT_TRASPASOCABFarmaciaRepositorio.Find(t => t.TR_FOL == id_traspaso && t.ID_BODEGA == _traspaso.bodega);
                                if (virtTraspasoGenerado != null && virtTraspasoGenerado.TR_FOL != 0)
                                    flagKardexGenerado = true;
                                else
                                {
                                    resultado.respuesta = "Error";
                                    resultado.mensaje = "Error al generar kárdex en la farmacia.";
                                    return resultado;
                                }
                            }
                            catch (Exception ex)
                            {

                                resultado.respuesta = "Error";
                                string[] respuestaMov = resultado.mensaje.ToString().Split(':');
                                resultado.mensaje = "Ocurrió un error al guardar en las tablas VIRT, por favor intente nuevamente.";
                            }


                            ServicioIntegradorSAP.I51Datos i51Datos = null;
                            string centro = "";

                            if (Properties.Settings.Default.tipoEjecucion.Equals("SAP"))
                            {
                                if (flagKardexGenerado)
                                {
                                    try
                                    {
                                        try
                                        {
                                            if (virtOffLine.vtc_numero_pedido_sap != null)
                                            {

                                                var vtcNumeroPedido = virtOffLine.vtc_numero_pedido_sap.Split('|');
                                                centro = vtcNumeroPedido.ElementAt(0);
                                                string pedidoSAP = vtcNumeroPedido.ElementAt(1);

                                                i51Datos = new ServicioIntegradorSAP.I51Datos
                                                {
                                                    Cabecera = new ServicioIntegradorSAP.CabeceraConfirmPedido
                                                    {
                                                        NotaEntrega = pedidoSAP,
                                                        Almacen = "",
                                                        Centro = centro,
                                                        NumOrdenCompra = "",
                                                        FechaContabilizacion = DateTime.Now.ToString("yyyy-MM-dd"),
                                                        FechaDocumento = DateTime.Now.ToString("yyyy-MM-dd"),
                                                    }
                                                };

                                            }
                                            else
                                            {
                                                virtOffLine.TR_OBS = "SP|" + centro;
                                            }

                                        }
                                        catch (Exception ex)
                                        {
                                            virtOffLine.TR_OBS = "SP|" + centro;
                                            registrarLog(ex.Message);
                                        }


                                        using (ServicioIntegradorSAP.ServicioConsumoSoapClient sap = new ServicioIntegradorSAP.ServicioConsumoSoapClient())
                                        {
                                            ServicioIntegradorSAP.I51Respuesta res = null;

                                            if (esPedido == 0 || esPedido == 2)
                                                res = sap.ConfirmarTraspasoPedido(i51Datos);

                                            if (esPedido > 0 || res.Resultado)
                                            {
                                                if (!res.Resultado)
                                                {
                                                    if (res.Mensajes != null && res.Mensajes.Count > 0 && res.Mensajes.ElementAt(0).ToLower().Contains("procesado previamente"))
                                                    {
                                                        virtOffLine.TR_OBS = "OK";
                                                        virtOffLine.ENVIO_POS = "R";
                                                        virtTraspasoFarmaciaExis.ENVIO_POS = "R";
                                                    }
                                                    else
                                                    {
                                                        virtOffLine.TR_OBS = "SP|" + centro;
                                                        virtOffLine.ENVIO_POS = "OF";
                                                        virtTraspasoFarmaciaExis.ENVIO_POS = "OF";
                                                    }
                                                }
                                                else
                                                {
                                                    virtOffLine.TR_OBS = "OK";
                                                    virtOffLine.ENVIO_POS = "R";
                                                    virtTraspasoFarmaciaExis.ENVIO_POS = "R";
                                                }
                                            }
                                            else
                                            {
                                                if (res.Mensajes != null && res.Mensajes.Count > 0 && res.Mensajes.ElementAt(0).ToLower().Contains("procesado previamente"))
                                                {
                                                    virtOffLine.TR_OBS = "OK";
                                                    virtOffLine.ENVIO_POS = "R";
                                                    virtTraspasoFarmaciaExis.ENVIO_POS = "R";
                                                }
                                                else
                                                {
                                                    virtOffLine.TR_OBS = "SP|" + centro;
                                                    registrarLog(res.Xml);
                                                    registrarLog(res.XmlEnvio);
                                                }
                                            }

                                            using (TransactionScope t = new TransactionScope(TransactionScopeOption.Required))
                                            {
                                                try
                                                {

                                                    if (esPedido > 0)
                                                    {
                                                        var detObj = itbl_DetalleTransferenciaBCRepositorio.Find(det => det.dtbc_tr_fol == id_traspaso);
                                                        detObj.dtbc_tipo_mov = "OK";
                                                        itbl_DetalleTransferenciaBCRepositorio.Update(detObj);
                                                    }

                                                    if (detsTemperatura.Count > 0)
                                                        itbl_TemperaturaTraspaso_detRepositorio.CreateMasivo(detsTemperatura);

                                                    iVirtTraspasoCabOffLineRepositorio.Update(virtOffLine);
                                                    iVIRT_TRASPASOCABFarmaciaRepositorio.Update(virtTraspasoFarmacia);
                                                }
                                                catch (Exception ex2)
                                                {
                                                    registrarLog(ex2.Message);
                                                }
                                            }
                                        }

                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                }

                            }
                            #endregion
                        }
                        else
                        {
                            #region ExistenVirtenFarmacia
                            ///Actualizar entidad
                            ///


                            string centro = virtOffLine.vtc_numero_pedido_sap.Split('|').ElementAt(0);
                            if (esPedido > 0)
                            {
                                //virtOffLine.ENVIO_POS = "OF";
                                if (esPedido == 2)
                                    virtOffLine.TR_OBS = "SP|" + centro;
                                else
                                {
                                    virtOffLine.TR_OBS = "OK";
                                    virtOffLine.ENVIO_POS = "R";
                                }
                                var detObj = itbl_DetalleTransferenciaBCRepositorio.Find(det => det.dtbc_tr_fol == id_traspaso);
                                detObj.dtbc_tipo_mov = "OK";
                                itbl_DetalleTransferenciaBCRepositorio.Update(detObj);
                            }
                            else
                            {
                                virtOffLine.ENVIO_POS = "OF";
                                virtOffLine.TR_OBS = "SP|" + centro;
                            }


                            int update = iVirtTraspasoCabOffLineRepositorio.Update(virtOffLine);
                            RegistroAppMovil(id_traspaso, _traspaso.usuarioFarmacia + "|FKEF", _traspaso.bodega);
                            resultado.respuesta = "OK";
                            string[] respuestaMov = resultado.mensaje.ToString().Split(':');


                            if (esPedido > 0)
                                resultado.mensaje = "La recepción de la guía se ha realizado correctamente.";
                            else
                                resultado.mensaje = "La recepción de la guía se ha realizado correctamente con Nro. de movimiento de kárdex:[" + respuestaMov[1] + "]";


                            resultado = GenerarInconsistencia(_traspaso, resultado);

                            try
                            {
                                if (detsTemperatura.Count > 0)
                                    itbl_TemperaturaTraspaso_detRepositorio.CreateMasivo(detsTemperatura);
                            }
                            catch (Exception ex)
                            {

                            }

                            #endregion
                        }
                        #endregion
                    }




                    if (!resultado.respuesta.Equals("OK"))
                        return resultado;


                }

                return resultado;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                string rs = "";
                foreach (var eve in e.EntityValidationErrors)
                {
                    rs = string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:", eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    Console.WriteLine(rs);

                    foreach (var ve in eve.ValidationErrors)
                    {
                        rs += "<br />" + string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw new Exception(rs);
            }
        }

        private Result VerificaExisteKardex(int num_mov, string oficina, bool esMatriz, string tipomov)
        {
            Result resultado = new Result
            {
                respuesta = "error",
                mensaje = "Error al generar el kárdex de los traspasos."
            };
            try
            {
                if (esMatriz)
                {
                    if (MetodoVerificarConeccionMatriz())
                    {
                        itbl_maestromovinventRepositorioMatriz.Inicializar();
                        tbl_maestromovinvent movMatriz = null;
                        if (tipomov.Equals("TA"))
                            movMatriz = itbl_maestromovinventRepositorioMatriz.Find(t => t.num_mov == num_mov && t.tipo_mov == "TRASPASOS" && t.tipo_causa == "TRASPASOS" && t.Oficina == oficina);
                        else
                            movMatriz = itbl_maestromovinventRepositorioMatriz.Find(t => t.num_documento == num_mov && t.tipo_mov == "TRASPASOS" && t.tipo_causa == "TRASPASOS" && t.Oficina == oficina);
                        if (movMatriz != null)
                        {
                            if (movMatriz.Oficina.Equals(oficina))
                            {
                                resultado.mensaje = "Se encuentra generado kárdex en Matriz del movimiento:" + num_mov;
                                resultado.respuesta = "Error";
                            }
                        }
                        else
                        {
                            resultado.mensaje = "No se generó kárdex en Matriz del movimiento:" + num_mov + "NOOK";
                            resultado.respuesta = "OK";
                            //return resultado;
                        }
                    }
                    else
                    {
                        resultado.mensaje = "No existe enlace a la matriz.";
                        resultado.respuesta = "SinEnlace";
                    }
                }
                else
                {
                    itbl_maestromovinventRepositorioFarmacia.InicializarFarmacia();
                    tbl_maestromovinvent movFarmacia = itbl_maestromovinventRepositorioFarmacia.Find(t => t.num_documento == num_mov && t.tipo_mov == "TRASPASOS" && t.tipo_causa == "TRASPASOS" && t.Oficina == oficina);
                    if (movFarmacia != null)
                    {
                        if (movFarmacia.Oficina.Equals(oficina))
                        {
                            resultado.mensaje = "El traspaso " + num_mov + " se encuentra generado kárdex con el número de movimiento:" + movFarmacia.num_mov;
                            resultado.respuesta = "Error";
                        }
                    }
                    else
                    {
                        resultado.mensaje = "No se generó kárdex en Farmacia del movimiento:" + num_mov;
                        resultado.respuesta = "OK";
                    }
                }
                return resultado;
            }
            catch (Exception ex)
            {
                registrarLog("VerificaExisteKardex: " + ex.Message + " -- " + ex.StackTrace);
                resultado.mensaje += "VerificaExisteKardex: " + ex.Message;
                return resultado;
            }
        }

        public Result BuscarArticuloTraspaso(string id_bodega, string codigo)
        {
            Result resultado = new Result
            {
                respuesta = "error",
                mensaje = "Error al Buscar el artículo."
            };

            try
            {
                int _codigo = 0;

                int.TryParse(codigo, out _codigo);

                bool online = VerificarConexionBDD();

                List<PA_TraspasosFarmacia> traspasosResult = null;
                var objx = new Dictionary<string, string>();

                if (!online)
                {
                    List<PA_TraspasosFarmaciaOffLine> result2 = iPA_TraspasosFarmaciaOffLineRepositorio.SqlQuery(
                        "EXECUTE [pmov].[pa_TraspasosFarmaciaOffLine] '" + id_bodega + "'", objx, 0).ToList();



                    traspasosResult = (from a in result2
                                       select new PA_TraspasosFarmacia
                                       {
                                           ENVIO_POS = a.ENVIO_POS,
                                           ID_BODEGA_ORG = a.ID_BODEGA_ORG,
                                           NumeroGuiaRemision = a.NumeroGuiaRemision,
                                           observacion = a.observacion,
                                           TRST_ESTADO = a.TRST_ESTADO,
                                           TRST_FECHA = a.TRST_FECHA,
                                           tr_caja = a.tr_caja,
                                           TR_ESTADO = a.TR_ESTADO,
                                           TR_ESTCONF = a.TR_ESTCONF,
                                           TR_FECDES = a.TR_FECDES,
                                           TR_FOL = a.TR_FOL,
                                           tr_funda = a.tr_funda,
                                           tr_paca = a.tr_paca,
                                           TR_TIPOMOV = a.TR_TIPOMOV,
                                           TR_USUA = a.TR_USUA,
                                           dtbc_tipo_mov = a.dtbc_tipo_mov,
                                           tbcc_retira_matriz = a.tbcc_retira_matriz,
                                           dtbc_tr_fol = a.dtbc_tr_fol,
                                           tbcc_estado = a.tbcc_estado,
                                           tbcc_num_pedido = a.dtbc_tr_fol == null ? 0 : Convert.ToInt32(a.tbcc_num_pedido),
                                           tbcc_oficina = a.tbcc_oficina,
                                           tbcc_sucursal = a.tbcc_sucursal
                                       }).ToList();

                }
                else
                {
                    traspasosResult = iPA_TraspasosFarmaciaRepositorio.SqlQuery(
                      "EXECUTE [pmov].[pa_TraspasosFarmacia] '" + id_bodega + "'", objx, 0).ToList();
                }


                List<int> result = traspasosResult.Select(x => x.TR_FOL).ToList();
                //PROCESAR ESTADO TRASPASO 
                List<TraspasosFarmacia> tf = ProcesarEstados(traspasosResult);

                List<VIRT_TRASPASODET> dets = null;
                if (!online)
                {
                    var detsOffline = iVirtTraspasoDetOffLineRepositorio.Filter(x => result.Contains(x.TR_FOL)).ToList();
                    dets = (from a in detsOffline
                            select new VIRT_TRASPASODET
                            {
                                ID_BODEGA_ORG = a.ID_BODEGA_ORG,
                                IVA = a.IVA,
                                PR_COD = a.PR_COD,
                                PR_CODB = a.PR_CODB,
                                PVF = a.PVF,
                                PVP = a.PVP,
                                TRD_CAND = a.TRD_CAND,
                                TRD_CANDF = a.TRD_CANDF,
                                TRD_CANF = a.TRD_CANF,
                                TRD_CANFF = a.TRD_CANFF,
                                TRD_COD = a.TRD_COD,
                                TRD_CODL = a.TRD_CODL,
                                TRD_EST = a.TRD_EST,
                                TRD_FECHA_CAD = a.TRD_FECHA_CAD,
                                TRD_FECHA_ELAB = a.TRD_FECHA_ELAB,
                                TRD_LOTE = a.TRD_LOTE,
                                TRD_MOV = a.TRD_MOV,
                                TRD_REG_SANITARIO = a.TRD_REG_SANITARIO,
                                TRD_UME = a.TRD_UME,
                                TR_FOL = a.TR_FOL,
                                TR_TIPOMOV = a.TR_TIPOMOV,
                                UB_ID = a.UB_ID
                            }
                            ).ToList();
                }
                else
                    dets = iVIRT_TRASPASODETRepositorio.Filter(x => result.Contains(x.TR_FOL)).ToList();


                //if (!online)
                //    itbl_Articulos_CodigosbarraRepositorio.InicializarFarmacia();

                List<string> codigosArticulos = dets.Select(x => x.PR_COD).ToList();
                List<tbl_articulos_codigosbarra> codigosBarras = itbl_Articulos_CodigosbarraRepositorio.Filter(x => codigosArticulos.Contains(x.codigo)).ToList();
                List<tbl_articulos> articulos = itbl_ArticulosRepositorio.Filter(x => codigosArticulos.Contains(x.codigo)).ToList();
                List<BusquedaArticuloTraspasos> bTraspasos = new List<BusquedaArticuloTraspasos>();

                tbl_articulos art = null;
                tbl_articulos_codigosbarra resulTemp = null;
                List<string> codigosContains = new List<string>();

                List<tbl_articulos> _Articulos = null;
                if (_codigo != 0)
                {
                    // si busca por codigo barra, recupera el codigo del codigo de barras
                    resulTemp = codigosBarras.FirstOrDefault(x => x.codigo_barra.Equals(codigo));
                    string codigoDeCodigoB = resulTemp != null ? resulTemp.codigo : null;
                    if (codigoDeCodigoB == null)
                        art = itbl_ArticulosRepositorio.Find(x => x.codigo.Equals(codigo));
                    else
                        art = itbl_ArticulosRepositorio.Find(x => x.codigo.Equals(codigoDeCodigoB));
                }
                else
                {
                    _Articulos = articulos;
                    codigo = codigo.Replace('_', '%');
                    var busqueda = codigo.Split('%');
                    for (int i = 0; i < busqueda.Length; i++)
                    {
                        if (!busqueda[i].Equals(""))
                            _Articulos = _Articulos.Where(x => x.descripcion.ToUpper().Contains(busqueda[i].ToUpper())).ToList();
                    }
                }

                if (_Articulos == null)
                    _Articulos = new List<tbl_articulos>();
                foreach (var item in dets)
                {
                    if (item.PR_COD.Equals(codigo) || (codigosBarras.Find(x => x.codigo.Equals(item.PR_COD) && x.codigo_barra.Equals(codigo)) != null) || _Articulos.FirstOrDefault(x => x.codigo.Equals(item.PR_COD)) != null)
                    {
                        tbl_articulos_codigosbarra codigoBarra = codigosBarras.Find(x => x.codigo.Equals(item.PR_COD) & x.es_principal.Equals("S"));
                        PA_TraspasosFarmacia traspasoCabResult = traspasosResult.Find(x => x.TR_FOL.Equals(item.TR_FOL));
                        TraspasosFarmacia tempTraspasoF = tf.FirstOrDefault(x => x.traspaso.Equals(item.TR_TIPOMOV + "-" + item.TR_FOL));
                        tbl_articulos tbl_articulo = articulos.FirstOrDefault(x => x.codigo.Equals(item.PR_COD));
                        BusquedaArticuloTraspasos bTemp = new BusquedaArticuloTraspasos
                        {
                            traspaso = item.TR_TIPOMOV + "-" + item.TR_FOL,
                            enteros = Convert.ToInt32(item.TRD_CANF),
                            fraccion = Convert.ToInt32(item.TRD_CANFF),
                            estado = tempTraspasoF.estado,
                            descripcion = tempTraspasoF.descripcion,
                            fecha = Convert.ToDateTime(traspasoCabResult.TRST_FECHA).ToString("yyyy/MM/dd hh:mm:ss"),
                            codigo = item.PR_COD,
                            barra = codigoBarra != null ? codigoBarra.codigo_barra : "Sin código de barra.",
                            detalle_articulo = tbl_articulo == null ? "" : tbl_articulo.descripcion
                        };
                        bTraspasos.Add(bTemp);
                    }
                }

                if (bTraspasos.Count == 0)
                {
                    resultado.mensaje = "No se encontraron resultados.";
                    return resultado;
                }
                else
                {
                    resultado.respuesta = "ok";
                    resultado.mensaje = bTraspasos;
                    return resultado;
                }
            }
            catch (Exception ex)
            {
                registrarLog("BuscarArticuloTraspaso: " + ex.Message + " -- " + ex.StackTrace);
                resultado.mensaje += "BuscarArticuloTraspaso: " + ex.Message;
                return resultado;
            }
        }

        public Result VerificarTraspasoKardexFarmacia(string id_bodega, string traspaso)
        {
            itbl_maestromovinventRepositorioFarmacia.InicializarFarmacia();
            Result resultado = new Result
            {
                respuesta = "error",
                mensaje = "Error al verificar el traspaso en el kardex de la farmacia."
            };

            try
            {
                int num_mov = 0;
                var split = traspaso.Split('-');
                if (split.Count() == 2)
                    num_mov = Convert.ToInt32(split.ElementAt(1));
                else
                {
                    int.TryParse(traspaso, out num_mov);
                }

                bool unido = false;

                if (num_mov == 0)
                    unido = true;

                tbl_maestromovinvent movFarmacia = null;
                int traspasoTmp = Convert.ToInt32(traspaso.Remove(0, 2));
                if (unido)
                    movFarmacia = itbl_maestromovinventRepositorioFarmacia.Find(t => t.num_documento == traspasoTmp && t.tipo_mov == "TRASPASOS" && t.tipo_causa == "TRASPASOS" && t.Oficina == id_bodega);
                else
                    movFarmacia = itbl_maestromovinventRepositorioFarmacia.Find(t => t.num_documento == num_mov && t.tipo_mov == "TRASPASOS" && t.tipo_causa == "TRASPASOS" && t.Oficina == id_bodega);

                if (movFarmacia != null)
                {
                    if (movFarmacia.Oficina.Equals(id_bodega))
                    {
                        resultado.mensaje = "El traspaso " + num_mov + " se encuentra generado kárdex con el número de movimiento:" + movFarmacia.num_mov;
                        resultado.respuesta = "ok";
                    }
                }
                else
                    resultado.mensaje = "El traspaso no está registrado.";

                return resultado;
            }
            catch (Exception ex)
            {
                registrarLog("VerificarTraspasoKardexFarmacia: " + ex.Message + " -- " + ex.StackTrace);
                resultado.mensaje += "VerificarTraspasoKardexFarmacia: " + ex.InnerException.Message;
                return resultado;
            }
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
        /// Permite registrar las diferencias de productos en la recepción del traspaso
        /// </summary>
        /// <param name="traspaso">Detalle del traspaso</param>
        /// <param name="result">Resultado del proceso de generación de kárdex</param>
        /// <returns></returns>
        private Result GenerarInconsistencia(Traspaso traspaso, Result result)
        {
            Result resultado = new Result();
            resultado = result;
            RegistroTraspaso registro = new RegistroTraspaso
            {
                respuesta = "error",
                mensaje = "Error al generar la novedad de los traspasos."
            };
            try
            {
                itbl_Inco_BodegaRepositorio.Inicializar();
                int idtraspaso = Convert.ToInt32(traspaso.traspaso.Split('-').ElementAt(1));
                ///Verificamos si existe una inconsistencia registrado para el traspaso
                tbl_inco_bodega objInconstenciaNueva = itbl_Inco_BodegaRepositorio.Find(t => t.num_traspaso == idtraspaso && t.id_farmacia.Equals(traspaso.bodega));
                if (objInconstenciaNueva == null)
                {
                    var inco = traspaso.articulos.FindAll(t => t.mas > 0 || t.menos > 0).ToList();
                    itbl_Inco_BodegaRepositorio.Inicializar();
                    tbl_inco_bodega inconsistencia = new tbl_inco_bodega();
                    if (inco != null && inco.ToList().Count > 0)
                    {
                        iPA_DatosUsuarioRepositorio.Inicializar();
                        var x = new Dictionary<string, string>();

                        List<PA_DatosUsuario> usuarios = null;
                        try
                        {
                            usuarios = iPA_DatosUsuarioRepositorio.SqlQuery("exec pmov.pa_DatosUsuario '" + traspaso.usuarioFarmacia + "'", x, 0).ToList();
                        }
                        catch (Exception ex2)
                        {
                            registrarLog(ex2.Message);
                        }

                        if (usuarios != null && usuarios.Count > 0)
                        {
                            inconsistencia.ci_empleado = usuarios[0].Cedula;
                            inconsistencia.empleado = usuarios[0].Nombre + " " + usuarios[0].Apellido;
                        }
                        else
                        {
                            inconsistencia.ci_empleado = "";
                            inconsistencia.empleado = "";
                        }
                        inconsistencia.alias = "plandeta";
                        inconsistencia.certificador = traspaso.usuarioFarmacia;
                        inconsistencia.fecha_cierre = null;
                        inconsistencia.fecha_proceso = null;
                        inconsistencia.fecha_reporte = DateTime.Now;
                        inconsistencia.fecha_traspaso = DateTime.Parse(traspaso.fechaTraspaso);
                        inconsistencia.id_farmacia = traspaso.bodega;
                        inconsistencia.id_inco_bodega = 1;
                        inconsistencia.num_traspaso = Convert.ToInt32(traspaso.traspaso.Split('-').ElementAt(1));
                        inconsistencia.estado = "R";
                        int i = 1;
                        var detalleTras = traspaso.articulos.FindAll(t => t.mas > 0 || t.menos > 0).ToList();
                        foreach (var itemTraspaso in detalleTras)
                        {
                            tbl_detalle_inco_bodega detInconsistencia = new tbl_detalle_inco_bodega();
                            detInconsistencia.id_detalle_inco_bodega = i;
                            detInconsistencia.id_inco_bodega = 1;
                            if (itemTraspaso.mas > 0)
                            {
                                detInconsistencia.id_motivo = 2;
                                detInconsistencia.cantidad = itemTraspaso.mas;
                            }
                            else if (itemTraspaso.menos > 0)
                            {
                                detInconsistencia.id_motivo = 1;
                                detInconsistencia.cantidad = itemTraspaso.menos;
                            }
                            detInconsistencia.id_producto = itemTraspaso.codigo;
                            inconsistencia.tbl_detalle_inco_bodega.Add(detInconsistencia);
                            i++;
                        }
                        int num = itbl_Inco_BodegaRepositorio.Create(inconsistencia);
                        if (num > 0)
                        {
                            itbl_Inco_BodegaRepositorio.Inicializar();
                            objInconstenciaNueva = itbl_Inco_BodegaRepositorio.Find(t => t.num_traspaso.Equals(inconsistencia.num_traspaso) && t.id_farmacia.Equals(traspaso.bodega));
                            if (objInconstenciaNueva != null)
                            {
                                registro.respuesta = resultado.mensaje + "\n" +
                                    "Se registro la novedad " + objInconstenciaNueva.id_inco_bodega.ToString(); //"OK";
                                registrarLog(Convert.ToDateTime(objInconstenciaNueva.fecha_traspaso).ToString("yyyy/MM/dd hh:mm:ss").ToString());
                                Inconsistencia modelInco = new Inconsistencia
                                {
                                    mensajeTraspaso = result.mensaje.ToString(),
                                    mensajeInconsistencia = "Se registro la novedad Nro. [" + objInconstenciaNueva.id_inco_bodega.ToString() + "]",
                                    traspaso = traspaso.traspaso.ToString(),
                                    fecha = Convert.ToDateTime(objInconstenciaNueva.fecha_traspaso).ToString("yyyy/MM/dd hh:mm:ss"),
                                    existeInconsistencia = "SI"
                                };
                                string descripcionArticulo = "";

                                List<DetalleInconsistencia> detallesInconsitencia = new List<DetalleInconsistencia>();

                                foreach (var itemInco in objInconstenciaNueva.tbl_detalle_inco_bodega)
                                {
                                    var articulo = traspaso.articulos.Find(t => t.codigo == itemInco.id_producto);
                                    if (articulo != null)
                                        descripcionArticulo = articulo.descripcion;
                                    else
                                        descripcionArticulo = "";
                                    DetalleInconsistencia detInco = new DetalleInconsistencia
                                    {

                                        codigo = itemInco.id_producto,
                                        descripcion = descripcionArticulo,
                                        entero = Convert.ToInt32(itemInco.cantidad),
                                        fraccion = 0,
                                        motivo = (itemInco.id_motivo == 1) ? "FALTANTE" : "SOBRANTE"
                                    };
                                    detallesInconsitencia.Add(detInco);
                                }
                                modelInco.detalleInco = detallesInconsitencia;
                                resultado.respuesta = "OK";
                                //registro.mensaje = modelInco;
                                resultado.mensaje = modelInco;
                                enviarCorreoNotificacion(objInconstenciaNueva.id_inco_bodega.ToString(), detallesInconsitencia, traspaso.bodega, traspaso.traspaso);
                            }
                        }
                        else
                        {
                            resultado.respuesta = "OK";
                            resultado.mensaje = "Error al registrar la novedad del traspaso: " + traspaso.traspaso.ToString();
                            Inconsistencia modelInco = new Inconsistencia
                            {
                                mensajeTraspaso = result.mensaje.ToString(),
                                mensajeInconsistencia = "Error al registrar la novedad del traspaso: " + traspaso.traspaso.ToString(),
                                traspaso = traspaso.traspaso.ToString(),
                                fecha = Convert.ToDateTime(traspaso.fechaTraspaso).ToString("yyyy/MM/dd hh:mm:ss"),
                                existeInconsistencia = ""
                            };
                            //DetalleInconsistencia detInco = new DetalleInconsistencia();
                            //modelInco.detalleInco.Add(detInco);
                            resultado.mensaje = modelInco;
                        }
                    }

                    else
                    {
                        resultado.respuesta = "OK";
                        Inconsistencia modelInco = new Inconsistencia
                        {
                            mensajeTraspaso = result.mensaje.ToString(),
                            mensajeInconsistencia = "El traspaso no generó ninguna novedad",
                            traspaso = traspaso.traspaso.ToString(),
                            fecha = Convert.ToDateTime(traspaso.fechaTraspaso).ToString("yyyy/MM/dd hh:mm:ss"),
                            existeInconsistencia = ""
                        };
                        resultado.mensaje = modelInco;// "No existe diferencias de cantidades en el traspaso.";
                    }

                }
                else
                {
                    resultado.respuesta = "OK";
                    Inconsistencia modelInco = new Inconsistencia
                    {
                        mensajeTraspaso = result.mensaje.ToString(),
                        mensajeInconsistencia = "La novedad ya fue generada anteriormente con el Nro. [" + objInconstenciaNueva.id_inco_bodega.ToString() + "], por favor verificar la misma.",
                        traspaso = traspaso.traspaso.ToString(),
                        fecha = Convert.ToDateTime(traspaso.fechaTraspaso).ToString("yyyy/MM/dd hh:mm:ss"),
                        existeInconsistencia = ""
                    };
                    //DetalleInconsistencia detInco = new DetalleInconsistencia();
                    //modelInco.detalleInco.Add(detInco);
                    resultado.mensaje = modelInco;
                }
                return resultado;
            }
            catch (Exception ex)
            {
                registrarLog("GenerarInconsistencia: " + ex.Message + " -- " + ex.StackTrace);
                resultado.mensaje += "\nGenerarInconsistencia: " + ex.Message;
                return resultado;
            }
            //catch (System.Data.Entity.Validation.DbEntityValidationException e)
            //{
            //    string rs = "";
            //    foreach (var eve in e.EntityValidationErrors)
            //    {
            //        rs = string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:", eve.Entry.Entity.GetType().Name, eve.Entry.State);
            //        Console.WriteLine(rs);

            //        foreach (var ve in eve.ValidationErrors)
            //        {
            //            rs += "<br />" + string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage);
            //        }
            //    }
            //    throw new Exception(rs);
            //}
        }
        private void enviarCorreoNotificacion(string idinconsistencia, List<DetalleInconsistencia> detalleInconsistencias, string oficina, string traspaso)
        {
            iOficinaRepositorio.Inicializar();
            itbl_UsuarioNotificacionInconsistencia.Inicializar();
            var listOficina = iOficinaRepositorio.Find(t => t.oficina == oficina);
            string nombreOficina = "", correoFarmacia = "";
            string correocopia = "";
            if (listOficina != null)
            {
                nombreOficina = listOficina.nombre;
                correoFarmacia = listOficina.correo_electronico;
            }
            string mensajeCorreo = crearMensajeCorreo(traspaso, idinconsistencia, nombreOficina, detalleInconsistencias);

            if (mensajeCorreo != "")
            {
                //ADEnvioCorreo correo = new ADEnvioCorreo();
                GeneraGuiaEasyTini.ADEnvioCorreo correo = new GeneraGuiaEasyTini.ADEnvioCorreo();
                correo.servidorcorreos = "192.168.238.87";
                var correoInco = itbl_UsuarioNotificacionInconsistencia.Filter(t => t.aplicacion == "AppMovil" && t.estado == "A").ToList();
                if (correoInco != null && correoInco.Count > 0)
                {
                    foreach (var item in correoInco)
                    {
                        if (!item.correo.Equals(""))
                            correocopia += item.correo + ";";
                    }
                }
                else
                    correocopia = "martavalenzuela@farmaenlace.com;";

                string resp = correo.EnviarCorreo("inconsistencias@farmaenlace.com", correoFarmacia,
                    correocopia, "NOVEDADES DE RECEPCION DE TRASPASOS", mensajeCorreo, "");

            }

        }
        private void enviarCorreo(string oficina, string traspaso)
        {
            iOficinaRepositorio.Inicializar();
            itbl_UsuarioNotificacionInconsistencia.Inicializar();
            var listOficina = iOficinaRepositorio.Find(t => t.oficina == oficina);
            string nombreOficina = "";
            string correocopia = "";
            if (listOficina != null)
            {
                nombreOficina = listOficina.nombre;
            }
            string mensajeCorreo = "Señor <br> " +
                            "Administrador FARMACIA " + nombreOficina + " <br>" +
                            "<br>" +
                            "Le informamos que la recepción del traspaso " + traspaso + " no se guardo en las tablas VIRT <br>" +
                            "<br>";

            if (mensajeCorreo != "")
            {
                //ADEnvioCorreo correo = new ADEnvioCorreo();
                GeneraGuiaEasyTini.ADEnvioCorreo correo = new GeneraGuiaEasyTini.ADEnvioCorreo();
                correo.servidorcorreos = "192.168.238.87";

                correocopia = "martavalenzuela@farmaenlace.com;";

                string resp = correo.EnviarCorreo("inconsistencias@farmaenlace.com", correocopia,
                    "", "REGISTRO TABLAS VIRT", mensajeCorreo, "");

            }

        }
        private string crearMensajeCorreo(string idTraspaso, string idinconsistencia, string nombreFarmacia, List<DetalleInconsistencia> detalleInconsistencias)
        {
            string mensaje = "Señor <br> " +
                            "Administrador FARMACIA " + nombreFarmacia + " <br>" +
                            "<br>" +
                            "Le informamos que la recepción del traspaso " + idTraspaso + " generó la siguiente novedad <br>" +
                            "<br>";

            mensaje += "<table  border=1>";
            mensaje += "<tr> " +

                    "<th scope='col'>CODIGO</th>" +
                    "<th scope='col'>DESCRIPCION</th>" +
                    "<th scope='col'>CANTIDAD</th>" +
                    "<th scope='col'>MOTIVO</th>" +
                    "</tr>";

            if (detalleInconsistencias != null && detalleInconsistencias.Count > 0)
            {
                foreach (var item in detalleInconsistencias)
                {
                    mensaje += "<tr> ";

                    mensaje += "<td>" + item.codigo + "</td>" +
                    "<td>" + item.descripcion + "</td>" +
                    "<td align='center'>" + Math.Abs(item.entero).ToString() + "</td>" +
                    "<td>" + item.motivo + "</td>" +
                    "</tr>";

                }
                mensaje += "</table> <br>" +
                            "Verificar la novedad y reportar por el sistema de inconsistencias de ser el caso.<br>" +
                            "<br>" +
                            "* Éste correo electrónico fué generado automáticamente. Por favor no responda al mismo.<br>";
            }
            return mensaje;
        }

        public Result Cookie(Cookie cookie)
        {
            registrarLog("Cookie: " + cookie.cookie + "-" + cookie.ipDispositivo + "-" + cookie.nombreUsu);
            Itbl_LoginUsuariORepositorio.Inicializar();
            Result resultado = new Result
            {
                respuesta = "error",
                mensaje = "Error al guardar cookie."
            };
            try
            {
                // PARAMETRIZACION TIEMPO DE VIDA
                double sessionTimeOut = 8;

                tbl_LoginUsuario login = Itbl_LoginUsuariORepositorio.Find(x => x.lg_cookie.Equals(cookie.cookie) && x.lg_nombreUsuario.ToUpper().Equals(cookie.nombreUsu.ToUpper()));                // ACTUALIZAR COOKIE
                if (cookie.estado.ToLower().Equals("a"))
                {
                    if (login != null)
                    {
                        TimeSpan resta = DateTime.Now - Convert.ToDateTime(login.lg_fecha);
                        if (resta.TotalHours > sessionTimeOut)
                        {
                            Itbl_LoginUsuariORepositorio.Delete(login);
                            login = new tbl_LoginUsuario
                            {
                                lg_cookie = cookie.cookie,
                                lg_estado = cookie.estado,
                                lg_compania = "0",
                                lg_oficina = "0",
                                lg_sucursal = "0",
                                lg_fecha = DateTime.Now,
                                lg_nombreUsuario = cookie.nombreUsu,
                                lg_ipCaja = cookie.ipDispositivo
                            };
                            resultado.respuesta = "ok";
                            resultado.mensaje = "ok";
                            Itbl_LoginUsuariORepositorio.Create(login);
                            return resultado;
                        }
                        else
                        {
                            resultado.respuesta = "ok";
                            resultado.mensaje = "Sesión actualizada.";
                            login.lg_fecha = DateTime.Now;
                        }

                        Itbl_LoginUsuariORepositorio.Update(login);
                        return resultado;
                    }
                    else
                    {
                        List<tbl_LoginUsuario> usuariosActivos = Itbl_LoginUsuariORepositorio.Filter(x => x.lg_nombreUsuario.ToLower().Equals(cookie.nombreUsu.ToLower()) && !x.lg_estado.ToLower().Equals("x")).ToList();
                        if (usuariosActivos != null && usuariosActivos.Count > 0)
                        {
                            TimeSpan resta = DateTime.Now - Convert.ToDateTime(usuariosActivos.ElementAt(0).lg_fecha);
                            if (resta.TotalHours > sessionTimeOut)
                            {
                                Itbl_LoginUsuariORepositorio.Delete(usuariosActivos.ElementAt(0));
                                login = new tbl_LoginUsuario
                                {
                                    lg_cookie = cookie.cookie,
                                    lg_estado = cookie.estado,
                                    lg_compania = "0",
                                    lg_oficina = "0",
                                    lg_sucursal = "0",
                                    lg_fecha = DateTime.Now,
                                    lg_nombreUsuario = cookie.nombreUsu,
                                    lg_ipCaja = cookie.ipDispositivo
                                };
                                resultado.respuesta = "ok";
                                resultado.mensaje = "ok";
                                Itbl_LoginUsuariORepositorio.Create(login);
                                return resultado;
                            }
                            resultado.respuesta = "error";
                            resultado.mensaje = "Sesión iniciada en otro dispositivo: " + usuariosActivos.ElementAt(0).lg_ipCaja;
                            return resultado;
                        }
                        login = new tbl_LoginUsuario
                        {
                            lg_cookie = cookie.cookie,
                            lg_estado = cookie.estado,
                            lg_compania = "0",
                            lg_oficina = "0",
                            lg_sucursal = "0",
                            lg_fecha = DateTime.Now,
                            lg_nombreUsuario = cookie.nombreUsu,
                            lg_ipCaja = cookie.ipDispositivo
                        };
                        Itbl_LoginUsuariORepositorio.Create(login);
                    }
                }
                // CERRADO DE COOKIE X
                else
                {
                    Itbl_LoginUsuariORepositorio.Delete(login);
                }

                resultado.mensaje = "ok";
                resultado.respuesta = "ok";
                return resultado;
            }
            catch (Exception ex)
            {
                registrarLog("Cookie: " + ex.Message + " -- " + ex.StackTrace + "---" + ex.InnerException);
                resultado.mensaje += "Cookie: " + ex.Message;
                return resultado;
            }
        }

        public Result GuardarTemporal(Temporal temporal)
        {
            Result resultado = new Result
            {
                respuesta = "error",
                mensaje = "Error al guardar temporalmente."
            };

            try
            {
                //registrarLog("GuardarTemporal INICIO: " + JsonConvert.SerializeObject(temporal).ToString());
                DateTime fechaB;

                DateTime.TryParse(temporal.fecha, out fechaB);

                tbl_tmp_RecepcionMercaderia tmp = new tbl_tmp_RecepcionMercaderia
                {
                    rm_identificador = temporal.identificador,
                    rm_usuario_farmacia = temporal.usuario,
                    rm_fecha_registro = DateTime.Now,
                    rm_estado = temporal.estado,
                    rm_fecha_bodega = DateTime.Now,
                    rm_data = temporal.data,
                    rm_data2 = temporal.data2,
                };

                var tempTemporal = itbl_Tmp_RecepcionMercaderiaRepositorio.Find(temporal.identificador);

                if (tempTemporal == null)
                    itbl_Tmp_RecepcionMercaderiaRepositorio.Create(tmp);
                else
                {
                    itbl_Tmp_RecepcionMercaderiaRepositorio.Delete(x => x.rm_identificador.Equals(temporal.identificador));
                    itbl_Tmp_RecepcionMercaderiaRepositorio.Create(tmp);
                }

                resultado.respuesta = "ok";
                resultado.mensaje = "Guardado correcto";

                return resultado;
            }
            catch (Exception ex)
            {
                registrarLog("GuardarTemporal: " + ex.Message + " -- " + ex.StackTrace + ex.InnerException);
                string x = " [ usuario, fecha, identificador, estado, data, data2 ] ";
                resultado.mensaje += "Verifique la estructura de guardado temporal. " + x + "GuardarTemporal: " + ex.Message;
                return resultado;
            }
        }

        public Result RecuperarTemporal(string identificador)
        {
            Result resultado = new Result
            {
                respuesta = "error",
                mensaje = "No se encontró el temporal."
            };

            try
            {
                tbl_tmp_RecepcionMercaderia tmp = itbl_Tmp_RecepcionMercaderiaRepositorio.Find(x => x.rm_identificador.Equals(identificador));
                if (tmp == null)
                    return resultado;

                resultado.respuesta = "ok";

                Temporal temporal = new Temporal
                {
                    identificador = tmp.rm_identificador,
                    fecha = Convert.ToDateTime(tmp.rm_fecha_bodega).ToString("yyyy/MM/dd hh:mm:ss"),
                    estado = tmp.rm_estado,
                    usuario = tmp.rm_usuario_farmacia,
                    data = tmp.rm_data,
                    data2 = tmp.rm_data2
                };

                resultado.mensaje = temporal;
                return resultado;
            }
            catch (Exception ex)
            {
                registrarLog("RecuperarTemporal: " + ex.Message + " -- " + ex.StackTrace);
                resultado.mensaje += "RecuperarTemporal: " + ex.Message;
                return resultado;
            }
        }

        public Result EliminarTemporal(string identificador)
        {
            Result resultado = new Result
            {
                respuesta = "error",
                mensaje = "No se encontró el temporal."
            };

            try
            {
                tbl_tmp_RecepcionMercaderia tmp = itbl_Tmp_RecepcionMercaderiaRepositorio.Find(x => x.rm_identificador.Equals(identificador));
                if (tmp == null)
                    return resultado;

                itbl_Tmp_RecepcionMercaderiaRepositorio.Delete(tmp);

                resultado.respuesta = "ok";
                resultado.mensaje = "Eliminado " + identificador;
                return resultado;
            }
            catch (Exception ex)
            {
                registrarLog("EliminarTemporal: " + ex.Message + " -- " + ex.StackTrace);
                resultado.mensaje += "EliminarTemporal: " + ex.Message;
                return resultado;
            }
        }

        public void RegistroAppMovilGenerico(List<tbl_AuditoriaAppMovil> auditoria)
        {
            try
            {
                itbl_AuditoriaAppMovilRepositorio.Create(auditoria);
            }
            catch (Exception ex)
            {
                registrarLog("GuardarPendientesVerificacion: " + ex.Message + " -- " + ex.StackTrace);
            }

        }

        private void RegistroAppMovil(int idtraspaso, string usuario, string oficina)
        {
            //Registro de uso de app
            try
            {
                string usuario1 = "";
                string[] usu = usuario.Split('|');
                if (usuario.Contains("FK"))
                    usuario1 = usu[0];
                else
                    usuario1 = usuario;
                tbl_RegistroAppMovil regAppExis = itbl_RegistroAppMovilRepositorio.Find(t => t.tipo_movimiento == "TRASPASOS" && t.numero_movimiento == idtraspaso);
                if (regAppExis == null)
                {
                    tbl_RegistroAppMovil regApp = new tbl_RegistroAppMovil
                    {
                        tipo_movimiento = "TRASPASOS",
                        numero_movimiento = idtraspaso,
                        fecha_registro = DateTime.Now,
                        usuario_registro = usuario
                    };
                    int insertApp = itbl_RegistroAppMovilRepositorio.Create(regApp);
                }
                else
                {
                    regAppExis.fecha_registro = DateTime.Now;
                    if (usuario.Contains("FK"))
                        regAppExis.usuario_registro = usuario1;
                    else
                        regAppExis.usuario_registro = usuario;
                    int updApp = itbl_RegistroAppMovilRepositorio.Update(regAppExis);
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                string rs = "";
                foreach (var eve in e.EntityValidationErrors)
                {
                    rs = string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:", eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    Console.WriteLine(rs);

                    foreach (var ve in eve.ValidationErrors)
                    {
                        rs += "<br />" + string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw new Exception(rs);
            }
        }

        public Result Servidor(string ip)
        {
            Result resultado = new Result
            {
                respuesta = "error",
                mensaje = "No se completó la operación Servidor."
            };
            try
            {
                //var configuration = WebConfigurationManager.OpenWebConfiguration("~");
                //var section = (ConnectionStringsSection)configuration.GetSection("connectionStrings");
                //section.ConnectionStrings["EasySeguridadContextoFarmacia"].ConnectionString = "Data Source=" + ip + ";Initial Catalog=EasySeguridad;User ID=sa;Password=sqlfarma";
                //section.ConnectionStrings["bdGenralContextoFarmacia"].ConnectionString = "Data Source=" + ip + ";Initial Catalog=bdgeneral;User ID=sa;Password=sqlfarma";
                //section.ConnectionStrings["EasyContextoFarmacia"].ConnectionString = "Data Source=" + ip + ";Initial Catalog=EasygestionEmpresarial;User ID=sa;Password=sqlfarma";
                //configuration.Save();

                iPA_IpServidorRepositorio.Inicializar();

                List<PV_IpServidor> ips = iPA_IpServidorRepositorio.All().ToList();

                if (ips != null && ips.Count() > 0)
                {
                    resultado.respuesta = "ok";
                    resultado.mensaje = ips.ElementAt(0).ipservidor + "  " + ips.ElementAt(0).nombreOficina + "  " + ips.ElementAt(0).oficina;
                }
                return resultado;
            }
            catch (Exception ex)
            {
                registrarLog("Servidor: " + ex.Message + " -- " + ex.StackTrace);
                resultado.mensaje += "Servidor: " + ex.Message;
                return resultado;
            }
        }

        public Result IPServidor()
        {
            Result resultado = new Result
            {
                respuesta = "error",
                mensaje = "No se completó la operación Servidor."
            };
            try
            {

                iPA_IpServidorRepositorio.Inicializar();

                List<PV_IpServidor> ips = iPA_IpServidorRepositorio.All().ToList();

                if (ips != null && ips.Count() > 0)
                {
                    resultado.respuesta = "ok";
                    resultado.mensaje = ips.ElementAt(0).ipservidor + "-" + ips.ElementAt(0).nombreOficina + "-" + ips.ElementAt(0).oficina;
                }
                return resultado;
            }
            catch (Exception ex)
            {
                registrarLog("Servidor: " + ex.Message + " -- " + ex.StackTrace);
                resultado.mensaje += "Servidor: " + ex.Message;
                return resultado;
            }
        }


        public Result EjecutarConsulta(string valorFiltro)
        {
            registrarLog("Servidor: " + valorFiltro);




            Result resultado = new Result
            {
                respuesta = "error",
                mensaje = "No se completó la operación Servidor."
            };
            try
            {


                if (string.IsNullOrEmpty(valorFiltro))
                {
                    resultado.respuesta = "error";
                    resultado.mensaje = "El parámetro de entrada valorFiltro, tiene el valor null o vacío.";
                    return resultado;
                }

                // VALIDACIÓN DE USUARIO

                string valor = valorFiltro.Split('|').ElementAt(0);
                string aquery = valorFiltro.Split('|').ElementAt(1);

                if (valor.Contains("SC"))
                {
                    String[] data = valor.Split(new char[] { 'C' }, 2);
                    Console.WriteLine(data);

                    valor = data[data.Length - 1];
                }

                if (valor.Count() <= 16)
                {
                    valor = valor.Replace("002F", "");
                }
                String verdata = valor.Count() + "";
                Console.WriteLine(verdata);
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["EasyContextoFarmacia"].ConnectionString;
                ConexionBDD conexion = new ConexionBDD(connectionString);

                var maestroFact = itbl_MaestrofactRepositorio.Find(x => x.Serie_Factura.Equals(valor.ToUpper()));

                DataTable dtDispensacion = new DataTable();

                string usuarioFactura = "";

                if (maestroFact == null)
                {
                    string queryDispensacion = " select dmc_nombre_convenio,dmc_usuario FROM [EasyGestionEmpresarial].[gob].[tbl_DispensacionMedicinaCab] with(nolock) where dmc_codigo_dispensacion = '" + valor + "'";
                    dtDispensacion = conexion.EjecutarSql(queryDispensacion);
                    if (dtDispensacion == null || dtDispensacion.Rows.Count == 0)
                    {
                        DataTable dtSalida = new DataTable();
                        string querySalidaBTL = "select ssc_descripcion,ssc_nombre_beneficiario from [MovimientosBovedaCaja].[caja].[tbl_SolicitudSalidaCaja] with (nolock) where ssc_id_solicitud= '" + valor + "'";
                        dtSalida = conexion.EjecutarSql(querySalidaBTL);
                        if (querySalidaBTL == null || dtSalida.Rows.Count == 0)
                        {
                            resultado.respuesta = "error";
                            resultado.mensaje = "La factura no se encuentra registrada";
                            return resultado;
                        }
                        else
                        {
                            Console.WriteLine(querySalidaBTL);
                            Console.WriteLine(dtSalida);
                            usuarioFactura = dtSalida.Rows[0]["ssc_nombre_beneficiario"].ToString();
                            Console.WriteLine("Hello");
                            //usuarioFactura= dtSalida.Rows[0][""]
                        }

                    }
                    else
                        usuarioFactura = dtDispensacion.Rows[0]["dmc_usuario"].ToString();
                }
                else
                {
                    usuarioFactura = maestroFact.UserId;
                }


                aquery = aquery.Replace("\\t", "");

                if (dtDispensacion != null && dtDispensacion.Rows.Count > 0)
                {

                    aquery = aquery.Replace("$", valor);
                    aquery = aquery.Substring(2);
                }
                else
                {
                    //Estado convenio
                    string queryEstado = "Select c2.estado from CONVENIO_FACTURAS c1 INNER JOIN[dbo].[CONVENIO_FAC] c2 ON c1.id_convenio = c2.ID_CONVENIO where c1.serie_factura ='" + valor + "'";
                    DataTable dtEstado = conexion.EjecutarSql(queryEstado);

                    if (dtEstado.Rows.Count > 0 && !string.IsNullOrEmpty(dtEstado.Rows[0]["estado"].ToString()) && dtEstado.Rows[0]["estado"].ToString().Equals("I"))
                    {
                        resultado.respuesta = "error";
                        resultado.mensaje = "El convenio no se encuentra activo para realizar la digitalización por el farmascan.";
                        return resultado;
                    }



                    string query = "select * from [EasySeguridad].[dbo].[Usuarios] where  nombrecorto = '" + usuarioFactura + "'";
                    DataTable usuarioEasy = conexion.EjecutarSql(query);


                    bool cambiarMatriz = false;
                    if (usuarioEasy == null || usuarioEasy.Rows.Count == 0)
                        cambiarMatriz = true;

                    aquery = aquery.Replace("$", valor);
                    aquery = aquery.Substring(2);

                    //CAMBIAR A MATRIZ 
                    if (cambiarMatriz)
                        aquery = aquery.Replace("[EasySeguridad].[dbo].[Usuarios]", "[MATRIZ].[EasySeguridad].[dbo].[Usuarios]");

                }

                DataTable m = conexion.EjecutarSql(aquery);

                if (m != null && m.Rows.Count > 0)
                {
                    string json = ConvertDataTabletoString(m);

                    resultado.respuesta = "ok";
                    resultado.mensaje = json;
                }
                else
                {
                    resultado.respuesta = "error";
                    resultado.mensaje = "Imposible recuperar datos de la factura número [" + valor + "]. Verifíque el número de la factura.";
                }
                return resultado;


            }
            catch (Exception ex)
            {
                registrarLog("Servidor: " + ex.Message + " -- " + ex.StackTrace);
                resultado.mensaje += "Servidor: " + ex.Message;
                return resultado;
            }
        }

        public Result TipoDocumento(string serieFactura)
        {
            Result resultado = new Result
            {
                respuesta = "error",
                mensaje = "No se completó la operación Servidor."
            };

            try
            {
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["EasyContextoFarmacia"].ConnectionString;
                ConexionBDD conexion = new ConexionBDD(connectionString);

                DataTable dtResultado = null;

                if (serieFactura.Count() <= 16)
                {
                    serieFactura = serieFactura.Replace("002F", "");
                }

                if (serieFactura.StartsWith("SC"))
                {
                    serieFactura = serieFactura.Substring(2);
                    string querySalidasCaja = @"exec [dbo].[pa_SalidaCajas] 'salidascaja',  '" + serieFactura + "'";

                    dtResultado = conexion.EjecutarSql(querySalidasCaja);

                    if (dtResultado.Rows.Count > 0)
                    {
                        string r = ConsultarDocumento(dtResultado.Rows[0]["Documento"].ToString());
                        if (!string.IsNullOrEmpty(r))
                        {
                            resultado.respuesta = "ok";
                            resultado.mensaje = dtResultado.Rows[0][0] + "|" + r.Trim();
                        }
                    }
                }
                else
                {
                    string queryCupon = @"SELECT fap_digitaliza FROM EasyGestionEmpresarial.[promo].[tbl_FacturaPromociones] fp WITH(NOLOCK)
                              WHERE fap_digitaliza != 'N' AND fap_aplica_promocion = 'S' AND fp.fap_serie_factura = '" + serieFactura + "'";

                    dtResultado = conexion.EjecutarSql(queryCupon);

                    if (dtResultado.Rows.Count > 0)
                    {
                        string r = ConsultarDocumento(dtResultado.Rows[0][0].ToString());
                        if (!string.IsNullOrEmpty(r))
                        {
                            resultado.respuesta = "ok";
                            resultado.mensaje = dtResultado.Rows[0][0] + "|" + r.Trim();
                        }
                    }
                    else
                    {
                        string queryConvenio = @"EXEC [pmov].[pa_DeterminarConvenio] '" + serieFactura + "'";
                        dtResultado = conexion.EjecutarSql(queryConvenio);

                        if (dtResultado.Rows.Count > 0)
                        {
                            string r = ConsultarDocumento(dtResultado.Rows[0]["Documento"].ToString());
                            if (!string.IsNullOrEmpty(r))
                            {
                                resultado.respuesta = "ok";
                                resultado.mensaje = dtResultado.Rows[0][0] + "|" + r.Trim();
                            }
                        }
                        else
                        {
                            string queryRecetaAntibiotico = @"EXEC [pmov].[pa_RecetaAntibiotico] '" + serieFactura + "'";
                            dtResultado = conexion.EjecutarSql(queryRecetaAntibiotico);

                            if (dtResultado.Rows.Count > 0)
                            {
                                string r = ConsultarDocumento(dtResultado.Rows[0]["Documento"].ToString());
                                if (!string.IsNullOrEmpty(r))
                                {
                                    resultado.respuesta = "ok";
                                    resultado.mensaje = dtResultado.Rows[0][0] + "|" + r.Trim();
                                }
                            }
                            else
                            {
                                string queryDispensacion = @"SELECT dmc_nombre_convenio FROM [EasyGestionEmpresarial].[gob].[tbl_DispensacionMedicinaCab] WITH(NOLOCK) WHERE dmc_codigo_dispensacion = '" + serieFactura + "'";
                                dtResultado = conexion.EjecutarSql(queryDispensacion);

                                if (dtResultado.Rows.Count > 0)
                                {
                                    string r = ConsultarDocumento(dtResultado.Rows[0]["dmc_nombre_convenio"].ToString());
                                    if (!string.IsNullOrEmpty(r))
                                    {
                                        resultado.respuesta = "ok";
                                        resultado.mensaje = dtResultado.Rows[0][0] + "|" + r.Trim();
                                    }
                                }
                                else
                                {
                                    resultado.mensaje = "No se encontró registrado el número de documento. Vuelva a escanear el código de barras.";
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                resultado.mensaje = "Hubo un error al ejecutar la consulta en el servidor.";
            }

            if (resultado.respuesta == "error")
            {
                resultado.mensaje = "Documento no disponible para digitalización automática. Vuelva a escanear el código de barras.";
            }

            return resultado;
        }


        public Result VerificarFactura(string serieFactura)
        {
            Result resultado = new Result
            {
                respuesta = "error",
                mensaje = "No se completó la operación Servidor."
            };

            try
            {

                if (serieFactura != null && serieFactura.Count() < 0)
                {
                    resultado.respuesta = "error";
                    resultado.mensaje = "El parámetro serie factura tiene el valor null o vacío.";
                    return resultado;
                }

                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["EasyContextoFarmacia"].ConnectionString;
                ConexionBDD conexion = new ConexionBDD(connectionString);

                // VALIDACIÓN DE USUARIO

                var maestroFact = itbl_MaestrofactRepositorio.Find(x => x.Serie_Factura.Equals(serieFactura.ToUpper()));
                string usuarioFactura = maestroFact.UserId;

                if (string.IsNullOrEmpty(usuarioFactura))
                {
                    resultado.respuesta = "error";
                    resultado.mensaje = "La factura no se encuentra registrada";
                    return resultado;
                }

                string query = "select * from [EasySeguridad].[dbo].[Usuarios] where  nombrecorto = '" + usuarioFactura + "'";
                DataTable usuarioEasy = conexion.EjecutarSql(query);

                bool cambiarMatriz = false;
                if (usuarioEasy == null || usuarioEasy.Rows.Count == 0)
                    cambiarMatriz = true;

                string valor = serieFactura.Split('|').ElementAt(0);
                string aquery = serieFactura.Split('|').ElementAt(1);
                aquery = aquery.Replace("$", valor);
                aquery = aquery.Substring(2);



                //CAMBIAR A MATRIZ 
                if (cambiarMatriz)
                    aquery = aquery.Replace("[EasySeguridad].[dbo].[Usuarios]", "[MATRIZ].[EasySeguridad].[dbo].[Usuarios]");

                DataTable m = conexion.EjecutarSql(aquery);
                if (m != null && m.Rows.Count > 0)
                {
                    string json = ConvertDataTabletoString(m);

                    resultado.respuesta = "ok";
                    resultado.mensaje = json;
                }
                else
                {
                    resultado.respuesta = "error";
                    resultado.mensaje = "La factura no se encuentra registrada";
                }
                return resultado;
            }
            catch (Exception ex)
            {
                registrarLog("Servidor: " + ex.Message + " -- " + ex.StackTrace);
                resultado.mensaje += "Servidor: " + ex.Message;
                return resultado;
            }
        }

        public string ConvertDataTabletoString(DataTable dt)
        {
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;
            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    var ssds = dr[col];
                    if (ssds == DBNull.Value)
                    {
                        dr[col] = "no aplica";
                    }

                    row.Add(col.ColumnName, dr[col]);
                }
                rows.Add(row);
                break;
            }
            return serializer.Serialize(rows);

        }

        private bool ValidarEnlaceMatriz()
        {
            try
            {
                String estado = "";
                Ping hacerPing = new Ping();
                string ipMat = "";
                if (ipMat.Equals(""))
                {
                    DataTable dtTablas = obtenerDatosTablas();
                    if (dtTablas != null && dtTablas.Rows.Count > 0)
                    {
                        ipMat = dtTablas.Rows[0]["tabladescripcion"].ToString();
                        PingReply p = hacerPing.Send(ipMat, 2500);
                        estado = p.Status.ToString();
                    }
                }
                if (estado.Equals("Success"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch { }
            return false;
        }

        public DataTable obtenerDatosTablas()
        {
            try
            {


                string sql = "SELECT * FROM [EasyFacturas_Data].[dbo].[Tablas] WITH(NOLOCK) WHERE IDTabla='IP_MATRIZ'";//"SELECT * FROM EasyFacturas_Data.dbo.Tablas WITH(NOLOCK) WHERE IDTabla='IP_MATRIZ'";
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["EasyContextoFarmacia"].ConnectionString;

                ConexionBDD conexion = new ConexionBDD(connectionString);

                DataTable m = conexion.EjecutarSql(sql);
                return m;
            }
            catch (Exception)
            {

                return null;
            }

        }

        public bool MetodoVerificarConeccionMatriz()
        {
            return false;
        }

        public bool VerificarConexionBDD2()
        {
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


        #region DIGITALIZACION

        string documentoResultado = "";

        public string ConsultarDocumento(string documento)
        {
            documento = documento.Replace(".", "");

            if (int.TryParse(documento, out _))
            {
                Sq1(documento);
                return documentoResultado;
            }
            else
            {
                Task task1 = new Task(() => Sq2(documento));
                Task task2 = new Task(() => Sq3(documento));
                Task task3 = new Task(() => Sq4(documento));

                task1.Start();
                task2.Start();
                task3.Start();

                Task.WaitAll(task1, task2, task3);

                return documentoResultado;
            }

        }


        //  COMBINACIÓN NOMBRES CONVENIO
        public void Sq1(string documento)
        {
            using (DigitalizacionContextoMatriz ctx = new DigitalizacionContextoMatriz())
            {
                string tillquery = @"select  DISTINCT concat(CAT.cat_codigo,'|', upper(cat_nombre)) as cat_nombre from tbl_CatalogoDocumentos cat(nolock) inner join tbl_PropiedadesDocumento pro(nolock) on cat.cat_codigo = pro.cat_codigo where cat.cat_estado = 'A' and CAT.cat_codigo = '" + documento + "'";

                var tillValue = ctx.Database.SqlQuery<string>(tillquery).ToList();
                if (tillValue != null && tillValue.Count > 0)
                {
                    if (documentoResultado == "")
                        documentoResultado = tillValue.ElementAt(0);
                }
            }
        }
        public void Sq2(string documento)
        {
            using (DigitalizacionContextoMatriz ctx = new DigitalizacionContextoMatriz())
            {
                string tillquery = @"select  DISTINCT concat(CAT.cat_codigo,'|', upper(cat_nombre)) as cat_nombre from tbl_CatalogoDocumentos cat(nolock)
inner join tbl_PropiedadesDocumento pro(nolock) on cat.cat_codigo = pro.cat_codigo
where cat.cat_estado = 'A'
and CHARINDEX(cat_nombre, '" + documento + "') > 0";

                var tillValue = ctx.Database.SqlQuery<string>(tillquery).ToList();
                if (tillValue != null && tillValue.Count > 0)
                {
                    if (documentoResultado == "")
                        documentoResultado = tillValue.ElementAt(0);
                }
            }
        }

        public void Sq3(string documento)
        {
            using (DigitalizacionContextoMatriz ctx = new DigitalizacionContextoMatriz())
            {
                string tillquery = @"select  DISTINCT concat(CAT.cat_codigo,'|', upper(cat_nombre)) as cat_nombre from tbl_CatalogoDocumentos cat(nolock)
inner join tbl_PropiedadesDocumento pro(nolock) on cat.cat_codigo = pro.cat_codigo
where cat.cat_estado = 'A'
and  cat_nombre like '%" + documento + "%'";
                var tillValue = ctx.Database.SqlQuery<string>(tillquery).ToList();
                if (tillValue != null && tillValue.Count > 0)
                {
                    if (documentoResultado == "")
                        documentoResultado = tillValue.ElementAt(0);
                }
            }
        }

        public void Sq4(string documento)
        {
            using (DigitalizacionContextoMatriz ctx = new DigitalizacionContextoMatriz())
            {
                string tillquery = @"select  DISTINCT concat(CAT.cat_codigo,'|', upper(cat_nombre)) as cat_nombre from tbl_CatalogoDocumentos cat(nolock)
            inner join tbl_PropiedadesDocumento pro(nolock) on cat.cat_codigo = pro.cat_codigo
            where cat.cat_estado = 'A' and cat_movil = 'S' AND cat_descripcion = '" + documento + "'";

                var tillValue = ctx.Database.SqlQuery<string>(tillquery).ToList();
                if (tillValue != null && tillValue.Count > 0)
                {
                    if (documentoResultado == "")
                        documentoResultado = tillValue.ElementAt(0);
                }
            }
        }


        public Result Digitalizacion()
        {
            Result resultado = new Result
            {
                respuesta = "error",
                mensaje = "No se completó la operación Servidor."
            };
            try
            {
                tbl_Configuraciones cfg = itbl_ConfiguracionesRepositorio.Find(x => x.cfg_codigo == 1);
                tbl_ConfiguracionesModel cfgModel = new tbl_ConfiguracionesModel
                {
                    cfg_codigo = cfg.cfg_codigo,
                    cfg_ip_server_app = cfg.cfg_ip_server_app,
                    cfg_url_api = cfg.cfg_url_api
                };
                resultado.respuesta = "ok";
                resultado.mensaje = cfgModel;
            }
            catch (Exception ex)
            {
                registrarLog("Servidor Digitalización: " + ex.Message + " -- " + ex.StackTrace);
                resultado.mensaje += "Servidor Digitalización: " + ex.Message;
            }
            return resultado;
        }

        #endregion

        #region VERIFICACIÓN DE CAJAS

        public Result VerificacionCajas(string bodega)
        {
            Result resultado = new Result
            {
                respuesta = "error",
                mensaje = "No se completó la operación Servidor."
            };

            try
            {
                bool online = VerificarConexionBDD();

                List<PA_TraspasosFarmacia> result = null;
                var objx = new Dictionary<string, string>();

                if (!online)
                {
                    List<PA_TraspasosFarmaciaOffLine> result2 = iPA_TraspasosFarmaciaOffLineRepositorio.SqlQuery(
                        "EXECUTE [pmov].[pa_TraspasosFarmaciaOffLine] '" + bodega + "'", objx, 0).ToList();

                    result = (from a in result2
                              select new PA_TraspasosFarmacia
                              {
                                  ENVIO_POS = a.ENVIO_POS,
                                  ID_BODEGA_ORG = a.ID_BODEGA_ORG,
                                  NumeroGuiaRemision = a.NumeroGuiaRemision,
                                  observacion = a.observacion,
                                  TRST_ESTADO = a.TRST_ESTADO,
                                  TRST_FECHA = a.TRST_FECHA,
                                  tr_caja = a.tr_caja,
                                  TR_ESTADO = a.TR_ESTADO,
                                  TR_ESTCONF = a.TR_ESTCONF,
                                  TR_FECDES = a.TR_FECDES,
                                  TR_FOL = a.TR_FOL,
                                  tr_funda = a.tr_funda,
                                  tr_paca = a.tr_paca,
                                  TR_TIPOMOV = a.TR_TIPOMOV,
                                  TR_USUA = a.TR_USUA,

                                  dtbc_tipo_mov = a.dtbc_tipo_mov,
                                  tbcc_retira_matriz = a.tbcc_retira_matriz,
                                  dtbc_tr_fol = a.dtbc_tr_fol,
                                  tbcc_estado = a.tbcc_estado,
                                  tbcc_num_pedido = a.dtbc_tr_fol == null ? 0 : Convert.ToInt32(a.tbcc_num_pedido),
                                  tbcc_oficina = a.tbcc_oficina,
                                  tbcc_sucursal = a.tbcc_sucursal
                              }
                              ).ToList();

                }
                else
                {
                    result = iPA_TraspasosFarmaciaRepositorio.SqlQuery(
                            "EXECUTE [pmov].[pa_TraspasosFarmacia] '" + bodega + "'", objx, 0).ToList();
                }


                List<TraspasosFarmacia> traspasosFarmacias = ProcesarEstados(result);
                // PROCESAR LOS - - POR RECIBIR - -

                List<tbl_PendientesVerificacion> tbl_PendientesVerifi = itbl_PendientesVerificacionRepositorio.Filter(x => !x.pe_estado.Equals("N") && (!x.pe_cajas.Equals("") || !x.pe_fundas.Equals("") || !x.pe_pacas.Equals(""))).ToList();

                int xx = traspasosFarmacias.Count();
                for (int i = 0; i < xx; i++)
                {
                    int numeroTraspasoTmp = Convert.ToInt32(traspasosFarmacias[i].traspaso.Split('-').ElementAt(1));
                    tbl_PendientesVerificacion temp = tbl_PendientesVerifi.Find(x => (x.pe_traspaso == numeroTraspasoTmp));
                    if (temp != null && temp.pe_cajas.Count() == 0 && temp.pe_fundas.Count() == 0 && temp.pe_pacas.Count() == 0)
                    {
                        traspasosFarmacias.Remove(traspasosFarmacias[i]);
                        i--;
                        xx--;
                    }
                    else
                    if (traspasosFarmacias[i].estado.Equals("ET") && temp == null)
                    {
                        traspasosFarmacias.Remove(traspasosFarmacias[i]);
                        i--;
                        xx--;
                    }
                    else
                    if (traspasosFarmacias[i].estado.Equals("R"))
                    {
                        traspasosFarmacias.Remove(traspasosFarmacias[i]);
                        i--;
                        xx--;
                    }
                }


                //traspasosFarmacias = traspasosFarmacias.OrderBy(y => y.orden).ToList();

                List<TraspasoModel> traspasosModel = new List<TraspasoModel>();

                foreach (var item in traspasosFarmacias)
                {
                    int traspasoTmp = Convert.ToInt32(item.traspaso.Split('-').ElementAt(1));
                    PA_TraspasosFarmacia tmp = result.FirstOrDefault(x => x.TR_FOL == traspasoTmp);

                    string facturadoMatriz = "";
                    if (!string.IsNullOrEmpty(tmp.dtbc_tr_fol))
                    {
                        facturadoMatriz = "S";
                    }
                    else
                        facturadoMatriz = "N";

                    TraspasoModel traspasoModel = new TraspasoModel
                    {
                        Bodega = bodega,
                        NumeroTraspaso = item.traspaso,
                        Estado = item.estado,
                        DescripcionEstado = item.descripcion,
                        FechaTraspaso = item.fecha,
                        UsuarioFarmacia = "",
                        Check = "",
                        Ip = "",
                        Caja = tmp.tr_caja,
                        Funda = tmp.tr_funda,
                        Paca = tmp.tr_paca,
                        CajasP = GenerarCodigo("C", Convert.ToInt32(tmp.tr_caja), tmp.TR_TIPOMOV.ToUpper(), tmp.TR_FOL.ToString()),
                        FundasP = GenerarCodigo("F", Convert.ToInt32(tmp.tr_funda), tmp.TR_TIPOMOV.ToUpper(), tmp.TR_FOL.ToString()),
                        PacasP = GenerarCodigo("P", Convert.ToInt32(tmp.tr_paca), tmp.TR_TIPOMOV.ToUpper(), tmp.TR_FOL.ToString()),
                        CajasV = new List<string>(),
                        FundasV = new List<string>(),
                        PacasV = new List<string>(),
                        Temperaturas = new List<TemperaturaModel>(),
                        PedidoFacturado = facturadoMatriz
                    };

                    if (traspasoModel.Estado.Equals("EP") || traspasoModel.Estado.Equals("ET"))
                    {
                        string nTraspaso = item.traspaso.Replace("-", "");
                        VIRT_TRASPASOVERIFMERCADERIA virt = iVIRT_TRASPASOVERIFMERCADERIA.Find(x => x.numTraspaso.Equals(nTraspaso));
                        if (virt != null)
                        {
                            foreach (var paquete in virt.procesado.Split(','))
                            {
                                traspasoModel.CajasP.Remove(paquete);
                                traspasoModel.FundasP.Remove(paquete);
                                traspasoModel.PacasP.Remove(paquete);

                                if (paquete.Contains("C"))
                                    traspasoModel.CajasV.Add(paquete);
                                else
                                if (paquete.Contains("F"))
                                    traspasoModel.FundasV.Add(paquete);
                                else
                                if (paquete.Contains("P"))
                                    traspasoModel.PacasV.Add(paquete);
                            }
                        }

                        int numeroTraspasoTmp = Convert.ToInt32(item.traspaso.Split('-').ElementAt(1));
                        tbl_PendientesVerificacion temp = tbl_PendientesVerifi.Find(x => (x.pe_traspaso == numeroTraspasoTmp));

                        if (temp != null)
                        {
                            traspasoModel.FechaPendiente = Convert.ToDateTime(temp.pe_fecha_registro).ToString("yyyy/MM/dd hh:mm:ss");
                            foreach (var icaja in temp.pe_cajas.Split(','))
                            {
                                if (icaja.Count() > 2)
                                {
                                    traspasoModel.CajasV.Remove(icaja);
                                    traspasoModel.CajasP.Remove(icaja);
                                    traspasoModel.CajasP.Add(icaja);
                                }
                            }
                            foreach (var ifunda in temp.pe_fundas.Split(','))
                            {
                                if (ifunda.Count() > 2)
                                {
                                    traspasoModel.FundasV.Remove(ifunda);
                                    traspasoModel.FundasP.Remove(ifunda);
                                    traspasoModel.FundasP.Add(ifunda);
                                }
                            }
                            foreach (var icaja in temp.pe_pacas.Split(','))
                            {
                                if (icaja.Count() > 2)
                                {
                                    traspasoModel.PacasV.Remove(icaja);
                                    traspasoModel.PacasP.Remove(icaja);
                                    traspasoModel.PacasP.Add(icaja);
                                }
                            }
                        }
                    }
                    traspasosModel.Add(traspasoModel);
                }
                object obj = new
                {
                    TraspasosModel = traspasosModel
                };

                //if (traspasosModel.Count() == 0)
                //{
                //    resultado.respuesta = "error";
                //    resultado.mensaje = "Se ha verificado todos los traspasos.";
                //    return resultado;
                //}

                resultado.respuesta = "ok";
                resultado.mensaje = obj;
                return resultado;
            }
            catch (Exception ex)
            {
                registrarLog("VerificacionCajas: " + ex.Message + " -- " + ex.StackTrace);
                resultado.mensaje += "VerificacionCajas: " + ex.Message;
            }
            return resultado;
        }

        public List<VIRT_TRASPASOVERIFMERCADERIA> vIRT_TRASPASOVERIFMERCADERIAs(List<string> codigosTraspasosEntrantes)
        {

            var online = VerificarConexionBDD();
            List<VIRT_TRASPASOVERIFMERCADERIA> listaVir = iVIRT_TRASPASOVERIFMERCADERIA.Filter(x => codigosTraspasosEntrantes.Contains(x.numTraspaso)).ToList();
            return listaVir;
        }

        public void PV_TraspasoInformeMercaderia_Create(PV_TraspasoInformeMercaderia informeCabTemp)
        {
            iPV_TraspasoInformeMercaderiaRepositorio.Create(informeCabTemp);
        }
        public void PV_TraspasoVerifMercaderiaDet_Create(List<PV_TraspasoVerifMercaderia_Det> informeDet)
        {
            foreach (var item in informeDet)
            {
                iPV_TraspasoVerifMercaderia_DetRepositorio.Delete(x => x.tvmd_numero_traspaso.Equals(item.tvmd_numero_traspaso));
            }
            iPV_TraspasoVerifMercaderia_DetRepositorio.Create(informeDet);
        }

        public void DetalleTransferenciaBC_Update(List<string> pedidosFacturados)
        {
            itbl_DetalleTransferenciaBCRepositorio.Inicializar();

            foreach (var item in pedidosFacturados)
            {
                string tipoMov = item.Split('-').ElementAt(0);
                int np = Convert.ToInt32(item.Split('-').ElementAt(1));

                var existe = itbl_DetalleTransferenciaBCRepositorio.Filter(x => x.dtbc_tr_fol == np && x.dtbc_tipo_mov == tipoMov).ToList();
                if (existe != null)
                {
                    foreach (var item2 in existe)
                    {
                        item2.dtbc_tipo_mov = "OK";
                        itbl_DetalleTransferenciaBCRepositorio.Update(item2);
                    }

                }
            }
        }

        public void tbl_PendientesVerificacion_create(List<tbl_PendientesVerificacion> tbl_PendientesVerificacions)
        {
            foreach (var item in tbl_PendientesVerificacions)
            {
                if (item.pe_estado.ToUpper().Equals("U"))
                {
                    //tbl_PendientesVerificacion tmp = itbl_PendientesVerificacionRepositorio.Find(x => x.pe_traspaso == item.pe_traspaso && x.pe_tipo_mov.Equals(item.pe_estado));
                    itbl_PendientesVerificacionRepositorio.Update(item);
                }
                else
                    itbl_PendientesVerificacionRepositorio.Create(item);
            }
        }

        public List<tbl_PendientesVerificacion> tbl_PendientesVerificacion_Obtener(List<int> codigosTraspaso)
        {
            return itbl_PendientesVerificacionRepositorio.Filter(x => codigosTraspaso.Contains(x.pe_traspaso)).ToList();
        }
        private List<string> GenerarCodigo(string tipoP, int nro, string tipoMov, string trFol)
        {
            int fin = 0;
            string codigoGenerado = "";
            if (tipoP.Equals("C"))
                fin = nro;
            else if (tipoP.Equals("P"))
                fin = nro;
            else if (tipoP.Equals("F"))
                fin = nro;

            for (int i = 0; i < fin; i++)
            {
                if (!codigoGenerado.Equals(""))
                    codigoGenerado += ",";
                if (codigoGenerado == string.Empty)
                    codigoGenerado = tipoMov + trFol + tipoP + (i + 1);
                else
                    codigoGenerado = codigoGenerado + tipoMov + trFol + tipoP + (i + 1);
            }
            if (codigoGenerado.Equals(""))
                return new List<string>();
            else
                return codigoGenerado.Split(',').ToList();
        }

        public int Max_PV_TraspasoInformeMercaderia()
        {
            return Convert.ToInt32(iPV_TraspasoInformeMercaderiaRepositorio.Max(x => x.tim_id));
        }

        public List<VIRT_TRASPASOCAB> vIRT_TRASPASOCABs(List<int> codigosEnteros)
        {
            List<VIRT_TRASPASOCAB> cabs = iVIRT_TRASPASOCABRepositorio.Filter(x => codigosEnteros.Contains(x.TR_FOL)).ToList();
            return cabs;
        }

        public List<VIRT_TRASPASOCABOFFLINE> vIRT_TRASPASOCABsOffline(List<int> codigosEnteros)
        {
            List<VIRT_TRASPASOCABOFFLINE> cabs = iVirtTraspasoCabOffLineRepositorio.Filter(x => codigosEnteros.Contains(x.TR_FOL)).ToList();
            return cabs;
        }

        public void VIRT_TRASPASOCAB_Update(List<VIRT_TRASPASOCAB> cabs)
        {
            iVIRT_TRASPASOCABRepositorio.Update(cabs);
        }

        public void VIRT_TRASPASOCAB_UpdateOffline(List<VIRT_TRASPASOCABOFFLINE> cabsOffline)
        {
            iVirtTraspasoCabOffLineRepositorio.Update(cabsOffline);
        }

        public void VIRT_TRASPASOVERIFMERCADERIA_Create(List<VIRT_TRASPASOVERIFMERCADERIA> vir_traspasos)
        {
            try
            {


                foreach (var item in vir_traspasos)
                {
                    VIRT_TRASPASOVERIFMERCADERIA tmp = iVIRT_TRASPASOVERIFMERCADERIA.Find(x => x.numTraspaso.Equals(item.numTraspaso));
                    if (tmp == null)
                        iVIRT_TRASPASOVERIFMERCADERIA.Create(vir_traspasos);
                    else
                    {
                        tmp.pendiente = item.pendiente;
                        tmp.procesado = item.procesado;
                        tmp.vtvm_estado_traspaso = item.vtvm_estado_traspaso;
                        tmp.estado = item.estado;
                        tmp.usuario = item.usuario;
                        tmp.fecha = item.fecha;
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }

        public List<tbl_PendientesVerificacion> ListaPendientesVerificacionVencidos()
        {
            List<tbl_PendientesVerificacion> p = itbl_PendientesVerificacionRepositorio.Filter(x => !x.pe_estado.Equals("N") && (!x.pe_cajas.Equals("") || !x.pe_fundas.Equals("") || !x.pe_pacas.Equals(""))).ToList();
            if (p.Count > 0)
            {
                return (from a in p
                        select new tbl_PendientesVerificacion
                        {
                            pe_cajas = a.pe_cajas,
                            pe_estado = a.pe_estado,
                            pe_fecha_registro = a.pe_fecha_registro,
                            pe_fundas = a.pe_fundas,
                            pe_numero = a.pe_numero,
                            pe_pacas = a.pe_pacas,
                            pe_tipo_mov = a.pe_tipo_mov,
                            pe_traspaso = a.pe_traspaso,
                            pe_usuario_registro = a.pe_usuario_registro
                        }).ToList();

            }
            else
                p = new List<tbl_PendientesVerificacion>();
            return p;
        }

        public PV_IpServidor PV_IpServidor()
        {
            List<PV_IpServidor> ips = iPA_IpServidorRepositorio.All().ToList();
            return ips.ElementAt(0);
        }

        public void tbl_PendientesVerificacion_Update(List<int> traspasos)
        {
            List<tbl_PendientesVerificacion> pendientes = itbl_PendientesVerificacionRepositorio.Filter(x => traspasos.Contains(x.pe_traspaso)).ToList();
            foreach (var item in pendientes)
            {
                item.pe_estado = "N";
            }
            itbl_PendientesVerificacionRepositorio.Update(pendientes);
        }

        public void tbl_TemperaturaTraspaso_cab_Create(List<Tbl_TemperaturaTraspaso_cab> temperaturas)
        {
            itbl_TemperaturaTraspaso_CabRepositorio.CreateMasivo(temperaturas);
        }

        public Oficinas RecuperarCorreoOficina(string oficina)
        {
            iOficinaRepositorio.Inicializar();

            Oficinas oficina_ = iOficinaRepositorio.Find(t => t.oficina == oficina);
            if (oficina_ != null)
                return oficina_;
            return null;
        }

        #endregion

        #region Notificaciones
        public List<tbl_par_UsuarioNotificacionInconsistencia> tbl_Par_UsuarioNotificacionInconsistencias(string grupoAplicacion)
        {

            itbl_UsuarioNotificacionInconsistencia.Inicializar();

            List<tbl_par_UsuarioNotificacionInconsistencia> notificaciones = itbl_UsuarioNotificacionInconsistencia.Filter(x => x.aplicacion.Equals(grupoAplicacion)).ToList();
            return notificaciones;
        }



        #endregion

    }
}
