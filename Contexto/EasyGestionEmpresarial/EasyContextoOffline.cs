using Entidades.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Contexto.EasyGestionEmpresarial
{
   public partial class EasyContextoOffline : DbContext
    {
        public EasyContextoOffline()
        : base("Name=EasyContextoOffline")
        {
            //Database.SetInitializer<ITEInventariosExternosContext>(null);
            this.Configuration.ValidateOnSaveEnabled = true;
        }

        public DbSet<VIRT_TRASPASODETOFFLINE> vIRT_TRASPASODETOFFLINEs { get; set; }
        public DbSet<VIRT_TRASPASOCABOFFLINE> vIRT_TRASPASOCABOFFLINEs { get; set; }
        public DbSet<PA_TraspasosFarmaciaOffLine> pA_TraspasosFarmaciaOffLines { get; set; }
        public DbSet<tbl_articulos_codigosbarra> tbl_Articulos_Codigosbarras { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PA_ArticulosPlanificacionMap());
            modelBuilder.Configurations.Add(new VIRT_TRASPASOCABMap());
            modelBuilder.Configurations.Add(new VIRT_TRASPASODETOFFLINEMap());
            modelBuilder.Configurations.Add(new PA_TraspasosFarmaciaOffLineMap());
            modelBuilder.Configurations.Add(new tbl_articulos_codigosbarraMap());
        }
    }
}

