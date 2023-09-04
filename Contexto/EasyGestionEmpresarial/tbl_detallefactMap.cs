using Entidades.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Contexto.EasyGestionEmpresarial
{
    public class tbl_detallefactMap : EntityTypeConfiguration<tbl_detallefact>
    {
        public tbl_detallefactMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Compania, t.Sucursal, t.Oficina, t.tipo_documento, t.numero_factura, t.codigo_producto, t.secuencial, t.Serie_Factura });

            // Properties
            this.Property(t => t.Compania)
                .IsRequired();

            this.Property(t => t.Sucursal)
                .IsRequired();

            this.Property(t => t.Oficina)
                .IsRequired();

            this.Property(t => t.tipo_documento)
                .IsRequired()
                .HasMaxLength(2);

            this.Property(t => t.numero_factura)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.codigo_producto)
                .IsRequired()
                .HasMaxLength(15);

            this.Property(t => t.secuencial)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.codigo_motivo)
                .HasMaxLength(3);

            this.Property(t => t.tipoproducto)
                .HasMaxLength(1);

            this.Property(t => t.tipolinea)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.comentario)
                .HasMaxLength(255);

            this.Property(t => t.Descripcion)
                .HasMaxLength(200);

            this.Property(t => t.tipo)
                .IsRequired()
                .HasMaxLength(1);

            this.Property(t => t.Rangos_Referencia)
                .IsRequired()
                .HasMaxLength(1);

            this.Property(t => t.Serie_Factura)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(t => t.Observacion_det)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("tbl_detallefact");
            this.Property(t => t.Compania).HasColumnName("Compania");
            this.Property(t => t.Sucursal).HasColumnName("Sucursal");
            this.Property(t => t.Oficina).HasColumnName("Oficina");
            this.Property(t => t.tipo_documento).HasColumnName("tipo_documento");
            this.Property(t => t.numero_factura).HasColumnName("numero_factura");
            this.Property(t => t.codigo_producto).HasColumnName("codigo_producto");
            this.Property(t => t.secuencial).HasColumnName("secuencial");
            this.Property(t => t.cantidad).HasColumnName("cantidad");
            this.Property(t => t.precio).HasColumnName("precio");
            this.Property(t => t.descuento).HasColumnName("descuento");
            this.Property(t => t.precio_total).HasColumnName("precio_total");
            this.Property(t => t.codigo_motivo).HasColumnName("codigo_motivo");
            this.Property(t => t.cantidad_devuelta).HasColumnName("cantidad_devuelta");
            this.Property(t => t.cantidad_entregada).HasColumnName("cantidad_entregada");
            this.Property(t => t.excento_iva).HasColumnName("excento_iva");
            this.Property(t => t.costo).HasColumnName("costo");
            this.Property(t => t.tipoproducto).HasColumnName("tipoproducto");
            this.Property(t => t.comision).HasColumnName("comision");
            this.Property(t => t.IdTaxGroup).HasColumnName("IdTaxGroup");
            this.Property(t => t.tipolinea).HasColumnName("tipolinea");
            this.Property(t => t.comentario).HasColumnName("comentario");
            this.Property(t => t.Descripcion).HasColumnName("Descripcion");
            this.Property(t => t.valor_ice).HasColumnName("valor_ice");
            this.Property(t => t.valor_iva).HasColumnName("valor_iva");
            this.Property(t => t.tipo).HasColumnName("tipo");
            this.Property(t => t.Rangos_Referencia).HasColumnName("Rangos_Referencia");
            this.Property(t => t.Serie_Factura).HasColumnName("Serie_Factura");
            this.Property(t => t.Total_Ice_Item).HasColumnName("Total_Ice_Item");
            this.Property(t => t.Total_Iva_Item).HasColumnName("Total_Iva_Item");
            this.Property(t => t.Observacion_det).HasColumnName("Observacion_det");
            this.Property(t => t.Descuento_Factura).HasColumnName("Descuento_Factura");

            // Relationships
            this.HasRequired(t => t.tbl_maestrofact)
                .WithMany(t => t.tbl_detallefact)
                .HasForeignKey(d => new { d.Compania, d.Sucursal, d.Oficina, d.tipo_documento, d.numero_factura, d.Serie_Factura });

        }
    }
}
