using Entidades.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Contexto.EasyGestionEmpresarial
{
    public class PA_ValidarTraspasoCFMap : EntityTypeConfiguration<PA_ValidarTraspasoCF>
    {
        public PA_ValidarTraspasoCFMap()
        {
            // Primary Key
            this.HasKey(t => new { t.resultado });

            // Properties
            this.Property(t => t.resultado);

             

            // Table & Column Mappings
            this.ToTable("PA_ValidarTraspasoCF", "rm");
            this.Property(t => t.resultado).HasColumnName("resultado");
          
        }
    }
}
