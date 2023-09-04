using Entidades.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Contexto.EasyGestionEmpresarial
{
    public class PLAN_DESCUENTODETMap : EntityTypeConfiguration<PLAN_DESCUENTODET>
    {
        public PLAN_DESCUENTODETMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ID_PLAN, t.ID_ITEM, t.SUCURSAL, t.OFICINA, t.CEDULA, t.TIPO, t.IDBODEGA });

            // Properties
            this.Property(t => t.ID_PLAN)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ID_ITEM)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.SUCURSAL)
                .IsRequired();

            this.Property(t => t.OFICINA)
                .IsRequired();

            this.Property(t => t.CEDULA)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.NOMBRES)
                .HasMaxLength(100);

            this.Property(t => t.APELLIDOS)
                .HasMaxLength(100);

            this.Property(t => t.ESTADO)
                .IsRequired()
                .HasMaxLength(2);

            this.Property(t => t.TIPO)
                .IsRequired()
                .HasMaxLength(3);

            this.Property(t => t.IDBODEGA)
                .IsRequired();

            this.Property(t => t.pld_estado_aprobacion)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("PLAN_DESCUENTODET");
            this.Property(t => t.ID_PLAN).HasColumnName("ID_PLAN");
            this.Property(t => t.ID_ITEM).HasColumnName("ID_ITEM");
            this.Property(t => t.SUCURSAL).HasColumnName("SUCURSAL");
            this.Property(t => t.OFICINA).HasColumnName("OFICINA");
            this.Property(t => t.CEDULA).HasColumnName("CEDULA");
            this.Property(t => t.NOMBRES).HasColumnName("NOMBRES");
            this.Property(t => t.APELLIDOS).HasColumnName("APELLIDOS");
            this.Property(t => t.DSC).HasColumnName("DSC");
            this.Property(t => t.ESTADO).HasColumnName("ESTADO");
            this.Property(t => t.VALDSC).HasColumnName("VALDSC");
            this.Property(t => t.TIPO).HasColumnName("TIPO");
            this.Property(t => t.IDBODEGA).HasColumnName("IDBODEGA");
            this.Property(t => t.pld_estado_aprobacion).HasColumnName("pld_estado_aprobacion");

            // Relationships
            this.HasRequired(t => t.PLAN_DESCUENTOCAB)
                .WithMany(t => t.PLAN_DESCUENTODET)
                .HasForeignKey(d => new { d.ID_PLAN, d.SUCURSAL, d.OFICINA, d.TIPO, d.IDBODEGA });

        }
    }
}
