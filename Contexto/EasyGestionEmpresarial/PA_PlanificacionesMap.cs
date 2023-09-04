using Entidades.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Contexto.EasyGestionEmpresarial
{
    public class PA_PlanificacionesMap : EntityTypeConfiguration<PA_Planificaciones>
    {
        public PA_PlanificacionesMap()
        {
            // Primary Key
            this.HasKey(t => new { t.id_plan, t.origen, t.reconteo });

            // Properties
            this.Property(t => t.id_plan)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.nombre)
                .HasMaxLength(200);

            this.Property(t => t.origen)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.reconteo)
                .IsRequired()
                .HasMaxLength(1);

            this.Property(t => t.estado)
                .HasMaxLength(15);

            this.Property(t => t.fecha)
                .HasMaxLength(67);

            // Table & Column Mappings
            this.MapToStoredProcedures();
            this.Property(t => t.id_plan).HasColumnName("id_plan");
            this.Property(t => t.nombre).HasColumnName("nombre");
            this.Property(t => t.origen).HasColumnName("origen");
            this.Property(t => t.reconteo).HasColumnName("reconteo");
            this.Property(t => t.estado).HasColumnName("estado");
            this.Property(t => t.fecha).HasColumnName("fecha");
        }
    }
}
