using Entidades.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Contexto.EasyGestionEmpresarial
{
    public class tbl_ControlPlanificacionesMap : EntityTypeConfiguration<tbl_ControlPlanificaciones>
    {
        public tbl_ControlPlanificacionesMap()
        {
            // Primary Key
            this.HasKey(t => new { t.cp_id_plan, t.cp_oficina, t.cp_sucursal, t.cp_id_bodega, t.cp_origen });

            // Properties
            this.Property(t => t.cp_id_plan)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.cp_oficina)
                .HasMaxLength(5);

            this.Property(t => t.cp_sucursal)
                .HasMaxLength(3);

            this.Property(t => t.cp_id_bodega)
                .HasMaxLength(5);

            this.Property(t => t.cp_origen)
                .HasMaxLength(10);

            this.Property(t => t.cp_usuario_registro)
                .HasMaxLength(25);

            this.Property(t => t.cp_ip_registro)
                .HasMaxLength(25);

            this.Property(t => t.cp_estado)
                .HasMaxLength(10);

            this.Property(t => t.cp_dispositivo);

            // Table & Column Mappings
            this.ToTable("tbl_ControlPlanificaciones", "pmov");
            this.Property(t => t.cp_id_plan).HasColumnName("cp_id_plan");
            this.Property(t => t.cp_oficina).HasColumnName("cp_oficina");
            this.Property(t => t.cp_sucursal).HasColumnName("cp_sucursal");
            this.Property(t => t.cp_id_bodega).HasColumnName("cp_id_bodega");
            this.Property(t => t.cp_origen).HasColumnName("cp_origen");
            this.Property(t => t.cp_usuario_registro).HasColumnName("cp_usuario_registro");
            this.Property(t => t.cp_fecha_registro).HasColumnName("cp_fecha_registro");
            this.Property(t => t.cp_ip_registro).HasColumnName("cp_ip_registro");
            this.Property(t => t.cp_estado).HasColumnName("cp_estado");
            this.Property(t => t.cp_dispositivo).HasColumnName("cp_dispositivo");
        }
    }
}
