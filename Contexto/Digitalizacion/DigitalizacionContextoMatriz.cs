using Entidades.Digitalizacion;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Contexto.Digitalizacion
{
    public partial class DigitalizacionContextoMatriz: DbContext
    {
        public DigitalizacionContextoMatriz()
        : base("Name=DigitalizacionContextoMatriz")
        {
            //Database.SetInitializer<EasyContextoMatriz>(null);
            //Database.SetInitializer<ITEInventariosExternosContext>(null);
            Database.SetInitializer<DigitalizacionContextoMatriz>(null);
        }

        public DbSet<tbl_Configuraciones> tbl_Configuraciones { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new tbl_ConfiguracionesMap());
        }
    }
}
