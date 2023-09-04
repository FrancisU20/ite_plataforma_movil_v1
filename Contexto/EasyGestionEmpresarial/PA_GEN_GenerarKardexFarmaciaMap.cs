using Entidades.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Contexto.EasyGestionEmpresarial
{
    public class PA_GEN_GenerarKardexFarmaciaMap : EntityTypeConfiguration<PA_GEN_GenerarKardexFarmacia>
    {
        public PA_GEN_GenerarKardexFarmaciaMap()
        {
            // Primary Key
            this.HasKey(t => new { t.result,t.nummov });

            // Properties
            this.Property(t => t.result)
                .IsRequired();
            //.HasMaxLength(15);

           

            this.ToTable("PA_GEN_GenerarKardex", "PA_GEN_GenerarKardex");
            this.Property(t => t.result).HasColumnName("result");
            this.Property(t => t.nummov).HasColumnName("nummov");
        }
    }
}
