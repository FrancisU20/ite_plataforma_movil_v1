using Entidades.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Contexto.EasyGestionEmpresarial
{
    public class PLAN_OFICINASMap : EntityTypeConfiguration<PLAN_OFICINAS>
    {
        public PLAN_OFICINASMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ID_PLAN, t.SUCURSAL, t.OFICINA, t.OFICINA_CREACION, t.IDBODEGA, t.SUCURSAL_CREACION, t.IDBODEGA_CREACION, t.ORIGEN });

            // Properties
            this.Property(t => t.ID_PLAN)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.SUCURSAL)
                .IsRequired();

            this.Property(t => t.OFICINA)
                .IsRequired();

            this.Property(t => t.OFICINA_CREACION)
                .IsRequired();

            this.Property(t => t.IDBODEGA)
                .IsRequired();

            this.Property(t => t.SUCURSAL_CREACION)
                .IsRequired();

            this.Property(t => t.IDBODEGA_CREACION)
                .IsRequired();

            this.Property(t => t.ORIGEN)
                .IsRequired()
                .HasMaxLength(10);


            // Table & Column Mappings
            this.ToTable("PLAN_OFICINAS");
            this.Property(t => t.ID_PLAN).HasColumnName("ID_PLAN");
            this.Property(t => t.SUCURSAL).HasColumnName("SUCURSAL");
            this.Property(t => t.OFICINA).HasColumnName("OFICINA");
            this.Property(t => t.OFICINA_CREACION).HasColumnName("OFICINA_CREACION");
            this.Property(t => t.IDBODEGA).HasColumnName("IDBODEGA");
            this.Property(t => t.SUCURSAL_CREACION).HasColumnName("SUCURSAL_CREACION");
            this.Property(t => t.IDBODEGA_CREACION).HasColumnName("IDBODEGA_CREACION");
            this.Property(t => t.ORIGEN).HasColumnName("ORIGEN");

            // Relationships
            this.HasRequired(t => t.PLAN_INVENTARIO)
                .WithMany(t => t.PLAN_OFICINAS)
                .HasForeignKey(d => new { d.ID_PLAN, d.OFICINA_CREACION, d.SUCURSAL_CREACION, d.IDBODEGA_CREACION, d.ORIGEN });

        }
    }
}
