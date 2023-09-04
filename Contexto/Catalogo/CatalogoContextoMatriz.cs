using Contexto.Catalogo;
using Entidades.bdgeneral;
using Entidades.Catalogo;
using Entidades.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Contexto.EasyGestionEmpresarial
{
    public partial class CatalogoContextoMatriz : DbContext
    {
        public CatalogoContextoMatriz()
        : base("Name=CatalogoContextoMatriz")
        {
            //Database.SetInitializer<EasyContextoMatriz>(null);
            //Database.SetInitializer<ITEInventariosExternosContext>(null);
            Database.SetInitializer<CatalogoContextoMatriz>(null);
        }

        public DbSet<PA_ObtenerFotoArticulo> pA_ObtenerFotoArticulos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PA_ObtenerFotoArticuloMap());
        }
    }
}
