using Contexto.Inconsistencias;
using Entidades.bdgeneral;
using Entidades.EasyGestionEmpresarial;
using Entidades.Inconsistencias;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Contexto.EasyGestionEmpresarial
{
    public partial class EasyContextoFarmacia : DbContext
    {
        public EasyContextoFarmacia()
        : base("Name=EasyContextoFarmacia")
        {
            //Database.SetInitializer<ITEInventariosExternosContext>(null);
            this.Configuration.ValidateOnSaveEnabled = true;
        }

        public DbSet<tbl_ControlPlanificaciones> tbl_ControlPlanificaciones { get; set; }

        public DbSet<Pa_EquipararBodegaFarmacia> pa_EquipararBodegaFarmacias { get; set; }
        public DbSet<PA_ArticulosPlanificacion> pA_ArticulosPlanificacions { get; set; }
        public DbSet<PA_DatosUsuario> pA_DatosUsuarios { get; set; }
        public DbSet<PA_Planificaciones> pA_Planificaciones { get; set; }
        public DbSet<PA_VerificacionIpFarmacia> pA_VerificacionIpFarmacias { get; set; }
        public DbSet<PLAN_ARTICULOS> pLAN_ARTICULOs { get; set; }
        public DbSet<PLAN_DESCUENTOCAB> pLAN_DESCUENTOCABs { get; set; }
        public DbSet<PLAN_DESCUENTODET> pLAN_DESCUENTODETs { get; set; }
        public DbSet<PLAN_FACTURACION> pLAN_FACTURACIONs { get; set; }
        public DbSet<PLAN_INVENTARIO> pLAN_INVENTARIOs { get; set; }
        public DbSet<PLAN_OFICINAS> pLAN_OFICINAs { get; set; }
        public DbSet<tbl_articulos> tbl_Articulos { get; set; }
        public DbSet<PLAN_USUARIO> pLAN_USUARIOs { get; set; }
        public DbSet<PV_IpServidor> pA_IpServidors { get; set; }
        public DbSet<tbl_maestromovinvent> tbl_maestromovinvent { get; set; }
        public DbSet<tbl_movinvent> tbl_movinvent { get; set; }
        public DbSet<PA_GEN_GenerarKardexFarmacia> PA_GEN_GenerarKardexFarmacia { get; set; }
        public DbSet<Oficinas> Oficinas { get; set; }
        public DbSet<VIRT_TRASPASOCABFarmacia> VIRT_TRASPASOCABFarmacia { get; set; }
        public DbSet<VIRT_TRASPASODETFarmacia> VIRT_TRASPASODETFarmacia { get; set; }
        public DbSet<tbl_tmp_RecepcionMercaderia> tbl_Tmp_RecepcionMercaderias { get; set; }

        public DbSet<tbl_RegistroAppMovil> tbl_RegistroAppMovil { get; set; }
        public DbSet<tbl_LoginUsuario> tbl_LoginUsuarios { get; set; }
        public DbSet<tbl_par_UsuarioNotificacionInconsistencia> tbl_Par_UsuarioNotificacionInconsistencias { get; set; }
        public DbSet<tbl_inco_bodega> tbl_inco_bodega { get; set; }
        public DbSet<tbl_detalle_inco_bodega> tbl_detalle_inco_bodega { get; set; }
        public DbSet<tbl_tablas> tbl_Tablas { get; set; }
        public DbSet<PA_ArticulosPlanificacionResumen> pA_ArticulosPlanificacionResumen { get; set; }
        public DbSet<tbl_maestrofact> tbl_Maestrofacts { get; set; }
        public DbSet<tbl_detallefact> tbl_Detallefacts { get; set; }
        public DbSet<VIRT_TRASPASOVERIFMERCADERIA> vIRT_TRASPASOVERIFMERCADERIAs { get; set; }
        public DbSet<PV_TraspasoInformeMercaderia> pV_TraspasoInformeMercaderias { get; set; }
        public DbSet<PV_TraspasoVerifMercaderia_Det> pV_TraspasoVerifMercaderia_Dets { get; set; }
        public DbSet<tbl_ImpresionEtiquetas> tbl_ImpresionEtiquetas { get; set; }
        public DbSet<PA_BuscarConfiguracionSegmentoArticulo> pA_BuscarConfiguracionSegmentoArticulos { get; set; }
        public DbSet<PA_ValidarTraspasoCF> pA_ValidarTraspasoCFs { get; set; }
        public DbSet<Tbl_TemperaturaTraspaso_cab> tbl_TemperaturaTraspaso_Cabs { get; set; }
        public DbSet<tbl_TemperaturaTraspaso_det> tbl_TemperaturaTraspaso_Dets { get; set; }
        public DbSet<PA_ArticuloCadenaFrio> pA_ArticuloCadenaFrios { get; set; }

        public DbSet<Tbl_DetalleTransferenciaBC> tbl_DetalleTransferenciaBCs { get; set; }

        #region Inventarios Totales

        public virtual DbSet<PV_INVENTARIO_PROCESO> PV_INVENTARIO_PROCESO { get; set; }
        public virtual DbSet<PV_INVENTARIO_TOTAL> PV_INVENTARIO_TOTAL { get; set; }
        public virtual DbSet<PV_INVENTARIO_TOTAL_AJUSTES> PV_INVENTARIO_TOTAL_AJUSTES { get; set; }
        public virtual DbSet<PV_INVENTARIO_TOTAL_ARCHIVOS> PV_INVENTARIO_TOTAL_ARCHIVOS { get; set; }
        public virtual DbSet<PV_INVENTARIO_TOTAL_BARRAS> PV_INVENTARIO_TOTAL_BARRAS { get; set; }
        public virtual DbSet<PV_INVENTARIO_TOTAL_CAB_REP> PV_INVENTARIO_TOTAL_CAB_REP { get; set; }
        public virtual DbSet<PV_INVENTARIO_TOTAL_DETALLE> PV_INVENTARIO_TOTAL_DETALLE { get; set; }
        public virtual DbSet<PV_INVENTARIO_TOTAL_DETALLE_USUARIO> PV_INVENTARIO_TOTAL_DETALLE_USUARIO { get; set; }
        public virtual DbSet<PV_INVENTARIO_TOTAL_LOGIN> PV_INVENTARIO_TOTAL_LOGIN { get; set; }
        public virtual DbSet<PV_INVENTARIO_TOTAL_MARGEN> PV_INVENTARIO_TOTAL_MARGEN { get; set; }
        public virtual DbSet<PV_INVENTARIO_TOTAL_OBSERVACIONES> PV_INVENTARIO_TOTAL_OBSERVACIONES { get; set; }
        public virtual DbSet<PV_INVENTARIO_TOTAL_PLAN> PV_INVENTARIO_TOTAL_PLAN { get; set; }
        public virtual DbSet<PV_INVENTARIO_TOTAL_SIN_FACTURAR> PV_INVENTARIO_TOTAL_SIN_FACTURAR { get; set; }
        public virtual DbSet<PV_INVENTARIO_TRASPASOS> PV_INVENTARIO_TRASPASOS { get; set; }
        public virtual DbSet<PA_ConsultarArtituloInventarioTotal> PA_ConsultarArtituloInventarioTotal { get; set; }


        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<PV_INVENTARIO_TOTAL>()
                .HasMany(e => e.PV_INVENTARIO_TOTAL_DETALLE)
                .WithRequired(e => e.PV_INVENTARIO_TOTAL)
                .HasForeignKey(e => new { e.cod_inventario, e.sucursal, e.oficina, e.idbodega })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PV_INVENTARIO_TOTAL_CAB_REP>()
                .Property(e => e.itc_calificacion)
                .HasPrecision(13, 2);

            modelBuilder.Entity<PV_INVENTARIO_TOTAL_DETALLE>()
                .Property(e => e.valor_diferencia)
                .HasPrecision(13, 4);

            modelBuilder.Entity<PV_INVENTARIO_TOTAL_DETALLE>()
                .HasMany(e => e.PV_INVENTARIO_TOTAL_DETALLE_USUARIO)
                .WithRequired(e => e.PV_INVENTARIO_TOTAL_DETALLE)
                .HasForeignKey(e => new { e.cod_inventario, e.sucursal, e.oficina, e.idbodega, e.codigo })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PV_INVENTARIO_TOTAL_SIN_FACTURAR>()
                .Property(e => e.PVP)
                .HasPrecision(13, 4);

            modelBuilder.Entity<PV_INVENTARIO_TOTAL_SIN_FACTURAR>()
                .Property(e => e.valor)
                .HasPrecision(13, 4);

            modelBuilder.Entity<PV_INVENTARIO_TRASPASOS>()
                .Property(e => e.valor)
                .HasPrecision(13, 2);


            modelBuilder.Configurations.Add(new PA_ConsultarArtituloInventarioTotalMap());

            modelBuilder.Configurations.Add(new PA_ArticulosPlanificacionMap());
            modelBuilder.Configurations.Add(new PA_DatosUsuarioMap());
            modelBuilder.Configurations.Add(new PA_PlanificacionesMap());
            modelBuilder.Configurations.Add(new PA_VerificacionIpFarmaciaMap());
            modelBuilder.Configurations.Add(new PLAN_ARTICULOSMap());
            modelBuilder.Configurations.Add(new PLAN_DESCUENTOCABMap());
            modelBuilder.Configurations.Add(new PLAN_DESCUENTODETMap());
            modelBuilder.Configurations.Add(new PLAN_FACTURACIONMap());
            modelBuilder.Configurations.Add(new PLAN_INVENTARIOMap());
            modelBuilder.Configurations.Add(new PLAN_OFICINASMap());
            modelBuilder.Configurations.Add(new tbl_articulosMap());
            modelBuilder.Configurations.Add(new PLAN_USUARIOMap());
            modelBuilder.Configurations.Add(new PV_IpServidorMap());
            modelBuilder.Configurations.Add(new OficinasMap());
            modelBuilder.Configurations.Add(new VIRT_TRASPASOCABFarmaciaMap());
            modelBuilder.Configurations.Add(new VIRT_TRASPASODETFarmaciaMap());
            modelBuilder.Configurations.Add(new tbl_tmp_RecepcionMercaderiaMap());
            modelBuilder.Configurations.Add(new tbl_RegistroAppMovilMap());
            modelBuilder.Configurations.Add(new tbl_LoginUsuarioMap());
            modelBuilder.Configurations.Add(new tbl_par_UsuarioNotificacionInconsistenciaMap());
            modelBuilder.Configurations.Add(new tbl_inco_bodegaMap());
            modelBuilder.Configurations.Add(new tbl_detalle_inco_bodegaMap());
            modelBuilder.Configurations.Add(new Tbl_tablasMap());
            modelBuilder.Configurations.Add(new PA_ArticulosPlanificacionResumenMap());
            modelBuilder.Configurations.Add(new tbl_maestrofactMap());
            modelBuilder.Configurations.Add(new tbl_detallefactMap());
            modelBuilder.Configurations.Add(new VIRT_TRASPASOVERIFMERCADERIAMap());
            modelBuilder.Configurations.Add(new PV_TraspasoInformeMercaderiaMap());
            modelBuilder.Configurations.Add(new PV_TraspasoVerifMercaderia_DetMap());
            modelBuilder.Configurations.Add(new tbl_PendientesVerificacionMap());
            modelBuilder.Configurations.Add(new Pa_EquipararBodegaFarmaciaMap());
            modelBuilder.Configurations.Add(new tbl_ControlPlanificacionesMap());
            modelBuilder.Configurations.Add(new PA_BuscarConfiguracionSegmentoArticuloMap());
            modelBuilder.Configurations.Add(new tbl_ImpresionEtiquetasMap());
            modelBuilder.Configurations.Add(new PA_ValidarTraspasoCFMap());
            modelBuilder.Configurations.Add(new PA_ArticuloCadenaFrioMap());
            modelBuilder.Configurations.Add(new Tbl_TemperaturaTraspaso_cabMap());
            modelBuilder.Configurations.Add(new Tbl_TemperaturaTraspaso_detMap());

            modelBuilder.Configurations.Add(new Tbl_DetalleTransferenciaBCMap());


        }
    }
}
