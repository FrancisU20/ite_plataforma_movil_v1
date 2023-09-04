using Entidades.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Contexto.EasyGestionEmpresarial
{
    public class tbl_articulosMap : EntityTypeConfiguration<tbl_articulos>
    {
        public tbl_articulosMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Compania, t.codigo });

            // Properties
            this.Property(t => t.Compania)
                .IsRequired()
                .HasMaxLength(3);

            this.Property(t => t.codigo)
                .IsRequired()
                .HasMaxLength(15);

            this.Property(t => t.descripcion)
                .HasMaxLength(60);

            this.Property(t => t.marca)
                .HasMaxLength(10);

            this.Property(t => t.linea)
                .HasMaxLength(10);

            this.Property(t => t.clase)
                .HasMaxLength(10);

            this.Property(t => t.RESTRINGIDO_VENTA)
                .IsRequired()
                .HasMaxLength(2);

            this.Property(t => t.RESTRINGIDO_INVENTARIO)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.RESTRINGIDO_DSCTOS)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.PVF);

            this.Property(t => t.valor_POS);

            this.Property(t => t.art_autoservicio)
                .HasMaxLength(1);

            this.Property(t => t.status)
                .IsRequired()
                .HasMaxLength(1);

            this.Property(t => t.es_psicotropico);

            // Table & Column Mappings
            this.ToTable("tbl_articulos");
            this.Property(t => t.Compania).HasColumnName("Compania");
            this.Property(t => t.codigo).HasColumnName("codigo");
            this.Property(t => t.descripcion).HasColumnName("descripcion");
            this.Property(t => t.marca).HasColumnName("marca");
            this.Property(t => t.linea).HasColumnName("linea");
            this.Property(t => t.clase).HasColumnName("clase");
            this.Property(t => t.RESTRINGIDO_VENTA).HasColumnName("RESTRINGIDO_VENTA");
            this.Property(t => t.RESTRINGIDO_INVENTARIO).HasColumnName("RESTRINGIDO_INVENTARIO");
            this.Property(t => t.RESTRINGIDO_DSCTOS).HasColumnName("RESTRINGIDO_DSCTOS");
            this.Property(t => t.RESTRINGIDO_DSCTOS).HasColumnName("RESTRINGIDO_DSCTOS");
            this.Property(t => t.PVF).HasColumnName("PVF");
            this.Property(t => t.valor_POS).HasColumnName("valor_POS");
            this.Property(t => t.art_autoservicio).HasColumnName("art_autoservicio");
            this.Property(t => t.es_psicotropico).HasColumnName("es_psicotropico");
            this.Property(t => t.status).HasColumnName("status");

        }
    }
}
