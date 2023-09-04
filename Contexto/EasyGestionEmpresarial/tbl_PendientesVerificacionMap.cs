using Entidades.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Contexto.EasyGestionEmpresarial
{
    public class tbl_PendientesVerificacionMap : EntityTypeConfiguration<tbl_PendientesVerificacion>
    {
        public tbl_PendientesVerificacionMap()
        {
            // Primary Key
            this.HasKey(t => t.pe_numero);

            // Properties
            this.Property(t => t.pe_estado)
                .HasMaxLength(20);

            this.Property(t => t.pe_usuario_registro)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("tbl_PendientesVerificacion", "pmov");
            this.Property(t => t.pe_numero).HasColumnName("pe_numero");
            this.Property(t => t.pe_traspaso).HasColumnName("pe_traspaso");
            this.Property(t => t.pe_tipo_mov).HasColumnName("pe_tipo_mov");
            this.Property(t => t.pe_estado).HasColumnName("pe_estado");
            this.Property(t => t.pe_cajas).HasColumnName("pe_cajas");
            this.Property(t => t.pe_fundas).HasColumnName("pe_fundas");
            this.Property(t => t.pe_pacas).HasColumnName("pe_pacas");
            this.Property(t => t.pe_usuario_registro).HasColumnName("pe_usuario_registro");
            this.Property(t => t.pe_fecha_registro).HasColumnName("pe_fecha_registro");
        }
    }
}
