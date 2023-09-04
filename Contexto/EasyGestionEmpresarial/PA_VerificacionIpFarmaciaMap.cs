using Entidades.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Contexto.EasyGestionEmpresarial
{
    public class PA_VerificacionIpFarmaciaMap : EntityTypeConfiguration<PA_VerificacionIpFarmacia>
    {
        public PA_VerificacionIpFarmaciaMap()
        {
            // Primary Key
            this.HasKey(t => t.oficina);

            // Properties
            this.Property(t => t.oficina)
                .IsRequired()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("VerificacionIpFarmacia", "PMOV");
            this.Property(t => t.oficina).HasColumnName("oficina");
        }
    }
}
