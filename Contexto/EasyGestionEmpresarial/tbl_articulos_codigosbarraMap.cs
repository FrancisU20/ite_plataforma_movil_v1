using Entidades.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Contexto.EasyGestionEmpresarial
{
    public class tbl_articulos_codigosbarraMap : EntityTypeConfiguration<tbl_articulos_codigosbarra>
    {
        public tbl_articulos_codigosbarraMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Compania, t.codigo, t.codigo_barra });

            // Properties
            this.Property(t => t.Compania)
                .IsRequired()
                .HasMaxLength(3);

            this.Property(t => t.codigo)
                .IsRequired()
                .HasMaxLength(15);

            this.Property(t => t.codigo_barra)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(t => t.estado)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.es_principal)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.es_caja)
                .IsRequired()
                .HasMaxLength(1);

            this.Property(t => t.ENVIO_POS)
                .HasMaxLength(2);

            // Table & Column Mappings
            this.ToTable("tbl_articulos_codigosbarra");
            this.Property(t => t.Compania).HasColumnName("Compania");
            this.Property(t => t.codigo).HasColumnName("codigo");
            this.Property(t => t.codigo_barra).HasColumnName("codigo_barra");
            this.Property(t => t.estado).HasColumnName("estado");
            this.Property(t => t.es_principal).HasColumnName("es_principal");
            this.Property(t => t.es_caja).HasColumnName("es_caja");
            this.Property(t => t.ENVIO_POS).HasColumnName("ENVIO_POS");           

        }
    }
}
