using Entidades.Inconsistencias;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Contexto.Inconsistencias
{
    public class tbl_motivoMap : EntityTypeConfiguration<tbl_motivo>
    {
        public tbl_motivoMap()
        {
            // Primary Key
            this.HasKey(t => t.id_motivo);

            // Properties
            this.Property(t => t.motivo)
                .IsRequired()
                .HasMaxLength(40);

            // Table & Column Mappings
            this.ToTable("tbl_motivo");
            this.Property(t => t.id_motivo).HasColumnName("id_motivo");
            this.Property(t => t.motivo).HasColumnName("motivo");
            this.Property(t => t.id_validacion).HasColumnName("id_validacion");

        }
    }
}
