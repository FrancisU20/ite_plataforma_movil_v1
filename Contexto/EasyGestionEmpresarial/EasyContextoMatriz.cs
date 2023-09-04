using Entidades.bdgeneral;
using Entidades.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Contexto.EasyGestionEmpresarial
{
    public partial class EasyContextoMatriz : DbContext
    {
        public EasyContextoMatriz()
        : base("Name=EasyContextoMatriz")
        {
            Database.SetInitializer<EasyContextoMatriz>(null);
            //Database.SetInitializer<ITEInventariosExternosContext>(null);
            this.Configuration.ValidateOnSaveEnabled = true;
        }

        public DbSet<PA_TraspasosFarmacia> pA_TraspasosFarmacias { get; set; }
        public DbSet<VIRT_TRASPASOCAB> vIRT_TRASPASOCAB { get; set; }
        public DbSet<VIRT_TRASPASODET> vIRT_TRASPASODET { get; set; }

        public DbSet<tbl_maestromovinvent> tbl_maestromovinvent { get; set; }
        public DbSet<tbl_movinvent> tbl_movinvent { get; set; }
        public DbSet<PA_GEN_GenerarKardexMatriz> PA_GEN_GenerarKardexMatriz { get; set; }
        public DbSet<tbl_articulos> tbl_articulos { get; set; }
        public DbSet<GEN_MovTraspasosDevoluciones_Cab> GEN_MovTraspasosDevoluciones_Cab { get; set; }
        public DbSet<tbl_AuditoriaAppMovil> tbl_AuditoriaAppMovil  { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            //base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new PA_TraspasosFarmaciaMap());
            modelBuilder.Configurations.Add(new VIRT_TRASPASOCABMap());
            modelBuilder.Configurations.Add(new VIRT_TRASPASODETMap());
    
            modelBuilder.Configurations.Add(new tbl_maestromovinventMap());
            modelBuilder.Configurations.Add(new tbl_movinventMap());
            modelBuilder.Configurations.Add(new PA_GEN_GenerarKardexMatrizMap());
            modelBuilder.Configurations.Add(new tbl_articulosMap());
            modelBuilder.Configurations.Add(new GEN_MovTraspasosDevoluciones_CabMap());
            modelBuilder.Configurations.Add(new tbl_AuditoriaAppMovilMap());
        }
    }
}
