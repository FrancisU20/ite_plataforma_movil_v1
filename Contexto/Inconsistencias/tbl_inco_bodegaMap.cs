using Entidades.Inconsistencias;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Contexto.Inconsistencias
{
    public class tbl_inco_bodegaMap : EntityTypeConfiguration<tbl_inco_bodega>
    {
        public tbl_inco_bodegaMap()
        {
            // Primary Key
            this.HasKey(t => t.id_inco_bodega);

            // Properties
            this.Property(t => t.sec_inco_bodega)
                .HasMaxLength(13);

            this.Property(t => t.alias)
                .HasMaxLength(15);

            this.Property(t => t.id_farmacia)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.ci_empleado)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.empleado)
                .HasMaxLength(110);

            this.Property(t => t.certificador)
                .HasMaxLength(20);

            this.Property(t => t.estado)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.tras_certificado)
                .IsFixedLength()
                .HasMaxLength(1);

            // Table & Column Mappings
            this.ToTable("tbl_inco_bodega");
            this.Property(t => t.id_inco_bodega).HasColumnName("id_inco_bodega");
            this.Property(t => t.sec_inco_bodega).HasColumnName("sec_inco_bodega");
            this.Property(t => t.alias).HasColumnName("alias");
            this.Property(t => t.id_farmacia).HasColumnName("id_farmacia");
            this.Property(t => t.ci_empleado).HasColumnName("ci_empleado");
            this.Property(t => t.empleado).HasColumnName("empleado");
            this.Property(t => t.certificador).HasColumnName("certificador");
            this.Property(t => t.num_traspaso).HasColumnName("num_traspaso");
            this.Property(t => t.num_ei).HasColumnName("num_ei");
            this.Property(t => t.fecha_reporte).HasColumnName("fecha_reporte");
            this.Property(t => t.fecha_proceso).HasColumnName("fecha_proceso");
            this.Property(t => t.fecha_cierre).HasColumnName("fecha_cierre");
            this.Property(t => t.estado).HasColumnName("estado");
            this.Property(t => t.tras_certificado).HasColumnName("tras_certificado");
            this.Property(t => t.mail_fallido_farmacia).HasColumnName("mail_fallido_farmacia");
            this.Property(t => t.mail_fallido_matriz).HasColumnName("mail_fallido_matriz");
            this.Property(t => t.fecha_traspaso).HasColumnName("fecha_traspaso");

        }
    }
}
