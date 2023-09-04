using Entidades.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Contexto.EasyGestionEmpresarial
{
    public class PA_ArticuloCadenaFrioMap : EntityTypeConfiguration<PA_ArticuloCadenaFrio>
    {
        public PA_ArticuloCadenaFrioMap()
        {
            // Primary Key
            this.HasKey(t => new { t.codigo });

            // Properties
            this.Property(t => t.codigo);

             

            // Table & Column Mappings
            this.ToTable("PA_ArticuloCadenaFrioMap", "pmov");
            this.Property(t => t.codigo).HasColumnName("codigo");
          
        }
    }
}
