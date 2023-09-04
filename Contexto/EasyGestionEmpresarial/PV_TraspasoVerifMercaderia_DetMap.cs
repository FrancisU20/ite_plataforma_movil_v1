
using Entidades.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Contexto.EasyGestionEmpresarial
{
    public class PV_TraspasoVerifMercaderia_DetMap : EntityTypeConfiguration<PV_TraspasoVerifMercaderia_Det>
    {
        public PV_TraspasoVerifMercaderia_DetMap()
        {
            // Primary Key
            this.HasKey(t => new { t.tvmd_numero_traspaso, t.tvmd_tipo_mercaderia });

            // Properties
            this.Property(t => t.tvmd_numero_traspaso)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.tvmd_tipo_mercaderia)
                .IsRequired()
                .HasMaxLength(1);

            this.Property(t => t.tvmd_usuario)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("PV_TraspasoVerifMercaderia_Det");
            this.Property(t => t.tvmd_numero_traspaso).HasColumnName("tvmd_numero_traspaso");
            this.Property(t => t.tvmd_tipo_mercaderia).HasColumnName("tvmd_tipo_mercaderia");
            this.Property(t => t.tvmd_numero_procesadas).HasColumnName("tvmd_numero_procesadas");
            this.Property(t => t.tvmd_numero_pendientes).HasColumnName("tvmd_numero_pendientes");
            this.Property(t => t.tvmd_usuario).HasColumnName("tvmd_usuario");
        }
    }
}
