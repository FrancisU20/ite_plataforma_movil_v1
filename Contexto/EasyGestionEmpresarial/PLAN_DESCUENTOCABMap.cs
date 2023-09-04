using Entidades.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Contexto.EasyGestionEmpresarial
{
    public class PLAN_DESCUENTOCABMap : EntityTypeConfiguration<PLAN_DESCUENTOCAB>
    {
        public PLAN_DESCUENTOCABMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ID_PLAN, t.SUCURSAL, t.OFICINA, t.TIPO, t.IDBODEGA });

            // Properties
            this.Property(t => t.ID_PLAN)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.SUCURSAL)
                .IsRequired();

            this.Property(t => t.OFICINA)
                .IsRequired();

            this.Property(t => t.HORA)
                .HasMaxLength(10);

            this.Property(t => t.USUARIO)
                .HasMaxLength(50);

            this.Property(t => t.ESTADO)
                .IsRequired()
                .HasMaxLength(2);

            this.Property(t => t.TIPO)
                .IsRequired()
                .HasMaxLength(3);

            this.Property(t => t.ENVIO_POS)
                .HasMaxLength(2);

            this.Property(t => t.IDBODEGA)
                .IsRequired();

            this.Property(t => t.APLICACION);

            // Table & Column Mappings
            this.ToTable("PLAN_DESCUENTOCAB");
            this.Property(t => t.ID_PLAN).HasColumnName("ID_PLAN");
            this.Property(t => t.SUCURSAL).HasColumnName("SUCURSAL");
            this.Property(t => t.OFICINA).HasColumnName("OFICINA");
            this.Property(t => t.FECHA).HasColumnName("FECHA");
            this.Property(t => t.HORA).HasColumnName("HORA");
            this.Property(t => t.USUARIO).HasColumnName("USUARIO");
            this.Property(t => t.FECHA_INGRESO).HasColumnName("FECHA_INGRESO");
            this.Property(t => t.ESTADO).HasColumnName("ESTADO");
            this.Property(t => t.TOTALDSC).HasColumnName("TOTALDSC");
            this.Property(t => t.TIPO).HasColumnName("TIPO");
            this.Property(t => t.ENVIO_POS).HasColumnName("ENVIO_POS");
            this.Property(t => t.IDBODEGA).HasColumnName("IDBODEGA");
            this.Property(t => t.APLICACION).HasColumnName("APLICACION");
        }
    }
}
