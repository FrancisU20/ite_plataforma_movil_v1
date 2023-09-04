using Entidades.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Contexto.EasyGestionEmpresarial
{
    public class PLAN_FACTURACIONMap : EntityTypeConfiguration<PLAN_FACTURACION>
    {
        public PLAN_FACTURACIONMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ID_PLAN, t.OFICINA, t.SUCURSAL, t.IDBODEGA, t.ORIGEN });

            // Properties
            this.Property(t => t.ID_PLAN)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ESTADO)
                .HasMaxLength(20);

            this.Property(t => t.OFICINA)
                .IsRequired();

            this.Property(t => t.SUCURSAL)
                .IsRequired();

            this.Property(t => t.IDBODEGA)
                .IsRequired();

            this.Property(t => t.ORIGEN)
                .IsRequired()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("PLAN_FACTURACION");
            this.Property(t => t.ID_PLAN).HasColumnName("ID_PLAN");
            this.Property(t => t.FECHA_INICIO).HasColumnName("FECHA_INICIO");
            this.Property(t => t.FECHA_FIN).HasColumnName("FECHA_FIN");
            this.Property(t => t.ESTADO).HasColumnName("ESTADO");
            this.Property(t => t.OFICINA).HasColumnName("OFICINA");
            this.Property(t => t.SUCURSAL).HasColumnName("SUCURSAL");
            this.Property(t => t.IDBODEGA).HasColumnName("IDBODEGA");
            this.Property(t => t.ORIGEN).HasColumnName("ORIGEN");

            // Relationships
            this.HasRequired(t => t.PLAN_INVENTARIO)
                .WithOptional(t => t.PLAN_FACTURACION);

        }
    }
}
