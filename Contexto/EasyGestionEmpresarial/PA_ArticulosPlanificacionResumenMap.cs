using Entidades.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Contexto.EasyGestionEmpresarial
{
    public class PA_ArticulosPlanificacionResumenMap : EntityTypeConfiguration<PA_ArticulosPlanificacionResumen>
    {
        public PA_ArticulosPlanificacionResumenMap()
        {
            // Primary Key
            this.HasKey(t => new { t.codigo });

            // Properties
            this.Property(t => t.codigo)
                .IsRequired()
                .HasMaxLength(15);

            this.Property(t => t.descripcion);

            this.Property(t => t.cantidad);

            this.Property(t => t.conteo);

            this.Property(t => t.diferencia);

            this.Property(t => t.entero);

            this.Property(t => t.estado);

            this.Property(t => t.fecha_finalizado);

            this.Property(t => t.fraccion);

            this.Property(t => t.valordiferencia);

            // Table & Column Mappings
            this.MapToStoredProcedures();
            this.Property(t => t.codigo).HasColumnName("codigo");
            this.Property(t => t.descripcion).HasColumnName("descripcion");
            this.Property(t => t.cantidad).HasColumnName("cantidad");
            this.Property(t => t.conteo).HasColumnName("conteo");
            this.Property(t => t.diferencia).HasColumnName("diferencia");
            this.Property(t => t.entero).HasColumnName("entero");
            this.Property(t => t.estado).HasColumnName("estado");
            this.Property(t => t.fecha_finalizado).HasColumnName("fecha_finalizado");
            this.Property(t => t.fraccion).HasColumnName("fraccion");
            this.Property(t => t.valordiferencia).HasColumnName("valordiferencia");
        }
    }
}
