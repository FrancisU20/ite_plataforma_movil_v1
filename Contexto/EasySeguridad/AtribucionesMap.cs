using Entidades.EasyGestionEmpresarial;
using Entidades.EasySeguridad;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Contexto.EasySeguridad
{
    public class AtribucionesMap : EntityTypeConfiguration<Atribuciones>
    {
        public AtribucionesMap()
        {
            // Primary Key
            this.HasKey(t => new { t.NombreCorto, t.Aplicacion, t.Modulo, t.Transaccion });

            // Properties
            this.Property(t => t.NombreCorto)
                .IsRequired()
                .HasMaxLength(65);

            this.Property(t => t.Aplicacion)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Modulo)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Transaccion)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ENVIO_POS)
                .HasMaxLength(2);

            // Table & Column Mappings
            this.ToTable("Atribuciones");
            this.Property(t => t.NombreCorto).HasColumnName("NombreCorto");
            this.Property(t => t.Aplicacion).HasColumnName("Aplicacion");
            this.Property(t => t.Modulo).HasColumnName("Modulo");
            this.Property(t => t.Transaccion).HasColumnName("Transaccion");
            this.Property(t => t.Habilitado).HasColumnName("Habilitado");
            this.Property(t => t.ENVIO_POS).HasColumnName("ENVIO_POS");
        }
    }
}
