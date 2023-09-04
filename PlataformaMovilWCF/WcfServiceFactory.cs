using Contexto.bdgeneral;
using Contexto.Digitalizacion;
using Contexto.EasyGestionEmpresarial;
using Contexto.EasySeguridad;
using Contexto.Inconsistencias;
using Microsoft.Practices.Unity;
using Repositorio.Implementacion.bdgeneral;
using Repositorio.Implementacion.Catalogo;
using Repositorio.Implementacion.Digitalizacion;
using Repositorio.Implementacion.EasyGestionEmpresarial;
using Repositorio.Implementacion.EasySeguridad;
using Repositorio.Implementacion.Inconsistencias;
using Repositorio.Interfaz.bdgeneral;
using Repositorio.Interfaz.Catalogo;
using Repositorio.Interfaz.Digitalizacion;
using Repositorio.Interfaz.EasyGestionEmpresarial;
using Repositorio.Interfaz.EasySeguridad;
using Repositorio.Interfaz.Inconsistencias;
using Servicio.Implementacion;
using Servicio.Interfaz;
using Transaccion.Implementacion;
using Transaccion.Interfaz;
using Unity.Wcf;

namespace PlataformaMovilWCF
{
    public class WcfServiceFactory : UnityServiceHostFactory
    {
        protected override void ConfigureContainer(IUnityContainer container)
        {
            // register all your components with the container here
            container

           .RegisterType<EasyContextoFarmacia>(new HierarchicalLifetimeManager())
           .RegisterType<EasyContextoMatriz>(new HierarchicalLifetimeManager())
           .RegisterType<CatalogoContextoMatriz>(new HierarchicalLifetimeManager())
           .RegisterType<EasySeguridadContextoFarmacia>(new HierarchicalLifetimeManager())
           .RegisterType<InconsistenciasContextoMatriz>(new HierarchicalLifetimeManager())
           .RegisterType<bdGenralContextoFarmacia>(new HierarchicalLifetimeManager())
           .RegisterType<DigitalizacionContextoMatriz>(new HierarchicalLifetimeManager())

           .RegisterType<IServicioInventarioMovil, ServicioInventarioMovil>()
           .RegisterType<IServicioRecepcion, ServicioRecepcion>()
           .RegisterType<IServicioInverntarioTotal, ServicioInverntarioTotal>()


           .RegisterType<ITransaccionInventarioMovil, TransaccionInventarioMovil>()
           .RegisterType<ITransaccionRecepcion, TransaccionRecepcion>()
           .RegisterType<ITransaccionInventarioTotal, TransaccionInventarioTotal>()

           .RegisterType<IService1, Service1>()

           .RegisterType<IOFICINA_IPRepositorio, OFICINA_IPRepositorio>()
           .RegisterType<IPA_ObtenerFotoArticuloRepositorio, PA_ObtenerFotoArticuloRepositorio>()
           .RegisterType<IOficinasRepositorio, OficinasRepositorio>()
           .RegisterType<IPA_ArticulosPlanificacionRepositorio, PA_ArticulosPlanificacionRepositorio>()
           .RegisterType<IPA_DatosUsuarioRepositorio, PA_DatosUsuarioRepositorio>()
           .RegisterType<IPA_GEN_GenerarKardexFarmaciaRepositorio, PA_GEN_GenerarKardexFarmaciaRepositorio>()
           .RegisterType<IPA_GEN_GenerarKardexMatrizRepositorio, PA_GEN_GenerarKardexMatrizRepositorio>()
           .RegisterType<IPA_IpServidorRepositorio, PA_IpServidorRepositorio>()
           .RegisterType<IPA_PlanificacionesRepositorio, PA_PlanificacionesRepositorio>()
           .RegisterType<IPA_TraspasosFarmaciaRepositorio, PA_TraspasosFarmaciaRepositorio>()
           .RegisterType<IPA_VerificacionIpFarmaciaRepositorio, PA_VerificacionIpFarmaciaRepositorio>()
           .RegisterType<IPLAN_ARTICULOSRepositorio, PLAN_ARTICULOSRepositorio>()
           .RegisterType<IPLAN_DESCUENTOCABRepositorio, PLAN_DESCUENTOCABRepositorio>()
           .RegisterType<IPLAN_DESCUENTODETRepositorio, PLAN_DESCUENTODETRepositorio>()
           .RegisterType<IPLAN_FACTURACIONRepositorio, PLAN_FACTURACIONRepositorio>()
           .RegisterType<IPLAN_INVENTARIORepositorio, PLAN_INVENTARIORepositorio>()
           .RegisterType<IPLAN_OFICINASRepositorio, PLAN_OFICINASRepositorio>()
           .RegisterType<IPLAN_USUARIORepositorio, PLAN_USUARIORepositorio>()
           .RegisterType<Itbl_articulos_codigosbarraRepositorio, tbl_articulos_codigosbarraRepositorio>()
           .RegisterType<Itbl_articulosRepositorio, tbl_articulosRepositorio>()
           .RegisterType<Itbl_LoginUsuarioRepositorio, tbl_LoginUsuarioRepositorio>()
           .RegisterType<Itbl_maestromovinventRepositorio, tbl_maestromovinventRepositorio>()
           .RegisterType<Itbl_movinventRepositorio, tbl_movinventRepositorio>()
           .RegisterType<Itbl_par_UsuarioNotificacionInconsistenciaRepositorio, tbl_par_UsuarioNotificacionInconsistenciaRepositorio>()
           .RegisterType<Itbl_RegistroAppMovilRepositorio, tbl_RegistroAppMovilRepositorio>()
           .RegisterType<Itbl_tmp_RecepcionMercaderiaRepositorio, tbl_tmp_RecepcionMercaderiaRepositorio>()
           .RegisterType<IVIRT_TRASPASOCABFarmaciaRepositorio, VIRT_TRASPASOCABFarmaciaRepositorio>()
           .RegisterType<IVIRT_TRASPASOCABRepositorio, VIRT_TRASPASOCABRepositorio>()
           .RegisterType<IVIRT_TRASPASODETFarmaciaRepositorio, VIRT_TRASPASODETFarmaciaRepositorio>()
           .RegisterType<IVIRT_TRASPASODETRepositorio, VIRT_TRASPASODETRepositorio>()
           .RegisterType<IAtribucionesRepositorio, AtribucionesRepositorio>()
           .RegisterType<Itbl_detalle_inco_bodegaRepositorio, tbl_detalle_inco_bodegaRepositorio>()
           .RegisterType<Itbl_inco_bodegaRepositorio, tbl_inco_bodegaRepositorio>()
           .RegisterType<Itbl_motivoRepositorio, tbl_motivoRepositorio>()
           .RegisterType<IGEN_MovTraspasosDevoluciones_CabRepositorio, GEN_MovTraspasosDevoluciones_CabRepositorio>()
           .RegisterType<ITbl_tablasRepositorio, Tbl_tablasRepositorio>()
           .RegisterType<IPA_ArticulosPlanificacionResumenRepositorio, PA_ArticulosPlanificacionResumenRepositorio>()
           .RegisterType<Itbl_maestrofactRepositorio, tbl_maestrofactRepositorio>()
           .RegisterType<Itbl_detallefactRepositorio, tbl_detallefactRepositorio>()
           .RegisterType<Itbl_ConfiguracionesRepositorio, tbl_ConfiguracionesRepositorio>()
           .RegisterType<IPV_TraspasoInformeMercaderiaRepositorio, PV_TraspasoInformeMercaderiaRepositorio>()
           .RegisterType<IPV_TraspasoVerifMercaderia_DetRepositorio, PV_TraspasoVerifMercaderia_DetRepositorio>()
           .RegisterType<IVIRT_TRASPASOVERIFMERCADERIARepositorio, VIRT_TRASPASOVERIFMERCADERIARepositorio>()
           .RegisterType<Itbl_PendientesVerificacionRepositorio, tbl_PendientesVerificacionRepositorio>()
           .RegisterType<Itbl_AuditoriaAppMovilRepositorio, tbl_AuditoriaAppMovilRepositorio>()
           .RegisterType<IPa_EquipararBodegaFarmaciaRepositorio, Pa_EquipararBodegaFarmaciaRepositorio>()
           .RegisterType<IVIRT_TRASPASOCABOFFLINERepositorio, VIRT_TRASPASOCABOFFLINERepositorio>()
           .RegisterType<IVIRT_TRASPASODETOFFLINERepositorio, VIRT_TRASPASODETOFFLINERepositorio>()
           .RegisterType<IPA_TraspasosFarmaciaOffLineRepositorio, PA_TraspasosFarmaciaOffLineRepositorio>()
           .RegisterType<Itbl_ControlPlanificacionesRepositorio, tbl_ControlPlanificacionesRepositorio>()
           .RegisterType<Itbl_ImpresionEtiquetasRepositorio, tbl_ImpresionEtiquetasRepositorio>()
            .RegisterType<IPA_BuscarConfiguracionSegmentoArticuloRepositorio, PA_BuscarConfiguracionSegmentoArticuloRepositorio>()

            .RegisterType<IPV_INVENTARIO_PROCESORepositorio, PV_INVENTARIO_PROCESORepositorio>()
            .RegisterType<IPV_INVENTARIO_TOTAL_AJUSTESRepositorio, PV_INVENTARIO_TOTAL_AJUSTESRepositorio>()
            .RegisterType<IPV_INVENTARIO_TOTAL_ARCHIVOSRepositorio, PV_INVENTARIO_TOTAL_ARCHIVOSRepositorio>()
            .RegisterType<IPV_INVENTARIO_TOTAL_BARRASRepositorio, PV_INVENTARIO_TOTAL_BARRASRepositorio>()
            .RegisterType<IPV_INVENTARIO_TOTAL_CAB_REPRepositorio, PV_INVENTARIO_TOTAL_CAB_REPRepositorio>()
            .RegisterType<IPV_INVENTARIO_TOTAL_DETALLE_USUARIORepositorio, PV_INVENTARIO_TOTAL_DETALLE_USUARIORepositorio>()
            .RegisterType<IPV_INVENTARIO_TOTAL_DETALLERepositorio, PV_INVENTARIO_TOTAL_DETALLERepositorio>()
            .RegisterType<IPV_INVENTARIO_TOTAL_LOGINRepositorio, PV_INVENTARIO_TOTAL_LOGINRepositorio>()
            .RegisterType<IPV_INVENTARIO_TOTAL_MARGENRepositorio, PV_INVENTARIO_TOTAL_MARGENRepositorio>()
            .RegisterType<IPV_INVENTARIO_TOTAL_OBSERVACIONESRepositorio, PV_INVENTARIO_TOTAL_OBSERVACIONESRepositorio>()
            .RegisterType<IPV_INVENTARIO_TOTAL_PLANRepositorio, PV_INVENTARIO_TOTAL_PLANRepositorio>()
            .RegisterType<IPV_INVENTARIO_TOTAL_SIN_FACTURARRepositorio, PV_INVENTARIO_TOTAL_SIN_FACTURARRepositorio>()
            .RegisterType<IPV_INVENTARIO_TRASPASOSRepositorio, PV_INVENTARIO_TRASPASOSRepositorio>()
            .RegisterType<IPA_ConsultarArtituloInventarioTotal, PA_ConsultarArtituloInventarioTotalRepositorio>()
            .RegisterType<IOFICINARepositorio, OFICINARepositorio>()
            .RegisterType<IOFICINA_IPServerRepositorio, OFICINA_IPServerRepositorio>()

            .RegisterType<IPA_ValidarTraspasoCFRepositorio, PA_ValidarTraspasoCFRepositorio>()
            .RegisterType<ITbl_TemperaturaTraspaso_cabRepositorio, Tbl_TemperaturaTraspaso_cabRepositorio>()
            .RegisterType<ITbl_TemperaturaTraspaso_detRepositorio, Tbl_TemperaturaTraspaso_detRepositorio>()
            .RegisterType<IPA_ArticuloCadenaFrioRepositorio, PA_ArticuloCadenaFrioRepositorio>()

            .RegisterType<IPV_INVENTARIO_TOTALRepositorio, PV_INVENTARIO_TOTALRepositorio>()

            .RegisterType<Itbl_DetalleTransferenciaBCRepositorio, Tbl_DetalleTransferenciaBCRepositorio>();

            
        }
    }
}