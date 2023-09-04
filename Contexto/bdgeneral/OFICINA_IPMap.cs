using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using Entidades.bdgeneral;

namespace Contexto.bdgeneral
{
    public class OFICINA_IPMap : EntityTypeConfiguration<OFICINA_IP>
    {
        public OFICINA_IPMap()
        {
            // Primary Key
            this.HasKey(t => new { t.oficina, t.ip_red });

            // Properties
            this.Property(t => t.oficina)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.ip_red)
                .IsRequired()
                .HasMaxLength(15);

            this.Property(t => t.ENVIO_POS)
                .HasMaxLength(2);

            // Table & Column Mappings
            this.ToTable("OFICINA_IP");
            this.Property(t => t.oficina).HasColumnName("oficina");
            this.Property(t => t.ip_red).HasColumnName("ip_red");
            this.Property(t => t.ip_rango_inicial).HasColumnName("ip_rango_inicial");
            this.Property(t => t.ip_rango_final).HasColumnName("ip_rango_final");
            this.Property(t => t.ENVIO_POS).HasColumnName("ENVIO_POS");
        }
    }
}
