using Entidades.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Contexto.EasyGestionEmpresarial
{
    public class PA_ArticulosPlanificacionMap : EntityTypeConfiguration<PA_ArticulosPlanificacion>
    {
        public PA_ArticulosPlanificacionMap()
        {
            // Primary Key
            this.HasKey(t => new { t.codigo, t.valorconversion, t.barra, t.barra1, t.barras });

            // Properties
            this.Property(t => t.codigo)
                .IsRequired()
                .HasMaxLength(15);

            this.Property(t => t.descripcion)
                .HasMaxLength(4000);

            this.Property(t => t.valorconversion)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.barra)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(t => t.barra1)
                .IsRequired();

            this.Property(t => t.barras)
                .IsRequired()
                .HasMaxLength(15);

            this.Property(t => t.pvf)
                .HasMaxLength(30);

            this.Property(t => t.stock);

            // Table & Column Mappings
            this.ToTable("ArticulosPlanificacion", "PMOV");
            this.Property(t => t.codigo).HasColumnName("codigo");
            this.Property(t => t.descripcion).HasColumnName("descripcion");
            this.Property(t => t.valorconversion).HasColumnName("valorconversion");
            this.Property(t => t.stock).HasColumnName("stock");
            this.Property(t => t.barra).HasColumnName("barra");
            this.Property(t => t.barra1).HasColumnName("barra1");
            this.Property(t => t.barras).HasColumnName("barras");
            this.Property(t => t.pvf).HasColumnName("pvf");
        }
    }
}
