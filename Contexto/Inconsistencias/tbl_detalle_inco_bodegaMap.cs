using Entidades.Inconsistencias;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Contexto.Inconsistencias
{
    public class tbl_detalle_inco_bodegaMap : EntityTypeConfiguration<tbl_detalle_inco_bodega>
    {
        public tbl_detalle_inco_bodegaMap()
        {
            // Primary Key
            this.HasKey(t => t.id_detalle_inco_bodega);

            // Properties
            this.Property(t => t.id_producto)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(t => t.solucion)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.num_ing_egr)
                .HasMaxLength(100);

            this.Property(t => t.aceptacion)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.conformidad)
                .IsFixedLength()
                .HasMaxLength(2);

            // Table & Column Mappings
            this.ToTable("tbl_detalle_inco_bodega");
            this.Property(t => t.id_detalle_inco_bodega).HasColumnName("id_detalle_inco_bodega");
            this.Property(t => t.id_inco_bodega).HasColumnName("id_inco_bodega");
            this.Property(t => t.id_motivo).HasColumnName("id_motivo");
            this.Property(t => t.id_producto).HasColumnName("id_producto");
            this.Property(t => t.otro).HasColumnName("otro");
            this.Property(t => t.cantidad).HasColumnName("cantidad");
            this.Property(t => t.solucion).HasColumnName("solucion");
            this.Property(t => t.nota).HasColumnName("nota");
            this.Property(t => t.num_ing_egr).HasColumnName("num_ing_egr");
            this.Property(t => t.aceptacion).HasColumnName("aceptacion");
            this.Property(t => t.conformidad).HasColumnName("conformidad");
            this.Property(t => t.obs_inconformidad).HasColumnName("obs_inconformidad");

            // Relationships
            this.HasRequired(t => t.tbl_inco_bodega)
                .WithMany(t => t.tbl_detalle_inco_bodega)
                .HasForeignKey(d => d.id_inco_bodega);

        }
    }
}
