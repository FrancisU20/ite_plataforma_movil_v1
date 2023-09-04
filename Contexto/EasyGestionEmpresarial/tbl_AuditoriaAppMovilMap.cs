using Entidades.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Contexto.EasyGestionEmpresarial
{
    public class tbl_AuditoriaAppMovilMap: EntityTypeConfiguration<tbl_AuditoriaAppMovil>
    {
        public tbl_AuditoriaAppMovilMap()
        {
            this.HasKey(t => new { t.aum_oficina, t.aum_tipo_movimiento, t.aum_numero_movimiento, t.aum_fecha_ejecucion });
            this.Property(t => t.aum_fecha_registro);
            this.Property(t => t.aum_usuario_registro);

            this.ToTable("tbl_AuditoriaAppMovil", "pmov");
            this.Property(t => t.aum_fecha_ejecucion).HasColumnName("aum_fecha_ejecucion");
            this.Property(t => t.aum_fecha_registro).HasColumnName("aum_fecha_registro");
            this.Property(t => t.aum_numero_movimiento).HasColumnName("aum_numero_movimiento");
            this.Property(t => t.aum_oficina).HasColumnName("aum_oficina");
            this.Property(t => t.aum_tipo_movimiento).HasColumnName("aum_tipo_movimiento");
            this.Property(t => t.aum_usuario_registro).HasColumnName("aum_usuario_registro");
        }
    
    }
}
