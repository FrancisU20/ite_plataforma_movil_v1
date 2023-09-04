using Entidades.bdgeneral;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Contexto.bdgeneral
{
    public class OFICINAMap : EntityTypeConfiguration<OFICINA>
    {
        public OFICINAMap()
        {
            // Primary Key
            this.HasKey(t => t.CODIGO_OFICINA);

            // Properties
            this.Property(t => t.CODIGO_OFICINA)
                .IsRequired()
                .HasMaxLength(5);

            this.Property(t => t.NOMBRE)
                .HasMaxLength(60);

            this.Property(t => t.CODIGO_SUCURSAL)
                .HasMaxLength(3);

            this.Property(t => t.CORREO_ELECTRONICO)
                .HasMaxLength(250);

            this.Property(t => t.ENVIO_POS)
                .HasMaxLength(2);

            // Table & Column Mappings
            this.ToTable("OFICINAS");
            this.Property(t => t.CODIGO_OFICINA).HasColumnName("CODIGO_OFICINA");
            this.Property(t => t.NOMBRE).HasColumnName("NOMBRE");
            this.Property(t => t.CODIGO_SUCURSAL).HasColumnName("CODIGO_SUCURSAL");
            this.Property(t => t.CORREO_ELECTRONICO).HasColumnName("CORREO_ELECTRONICO");
            this.Property(t => t.ENVIO_POS).HasColumnName("ENVIO_POS");
        }
    }
}
