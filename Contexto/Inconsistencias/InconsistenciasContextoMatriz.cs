using Entidades.Inconsistencias;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Contexto.Inconsistencias
{
    public partial class InconsistenciasContextoMatriz : DbContext
    {
        public InconsistenciasContextoMatriz()
        : base("Name=InconsistenciasContextoMatriz")
        {
            //Database.SetInitializer<ITEInventariosExternosContext>(null);
            this.Configuration.ValidateOnSaveEnabled = true;
        }

        public DbSet<tbl_motivo> tbl_Motivos { get; set; }
        //public DbSet<tbl_inco_bodega> tbl_inco_bodega { get; set; }
        //public DbSet<tbl_detalle_inco_bodega> tbl_detalle_inco_bodega { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new tbl_motivoMap());
            //modelBuilder.Configurations.Add(new tbl_inco_bodegaMap());
            //modelBuilder.Configurations.Add(new tbl_detalle_inco_bodegaMap());
        }
    }
}
