using Entidades.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Contexto.EasyGestionEmpresarial
{
    public class tbl_tmp_RecepcionMercaderiaMap : EntityTypeConfiguration<tbl_tmp_RecepcionMercaderia>
    {
        public tbl_tmp_RecepcionMercaderiaMap()
        {
            this.HasKey(t => new { t.rm_identificador });
            this.Property(t => t.rm_data);
            this.Property(t => t.rm_data2);
            this.Property(t => t.rm_estado);
            this.Property(t => t.rm_fecha_bodega);
            this.Property(t => t.rm_fecha_registro);
            this.Property(t => t.rm_usuario_farmacia);

            this.ToTable("tbl_tmp_RecepcionMercaderia", "pmov");
            this.Property(t => t.rm_identificador).HasColumnName("rm_identificador");
            this.Property(t => t.rm_data).HasColumnName("rm_data");
            this.Property(t => t.rm_data2).HasColumnName("rm_data2");
            this.Property(t => t.rm_estado).HasColumnName("rm_estado");
            this.Property(t => t.rm_fecha_bodega).HasColumnName("rm_fecha_bodega");
            this.Property(t => t.rm_fecha_registro).HasColumnName("rm_fecha_registro");
            this.Property(t => t.rm_usuario_farmacia).HasColumnName("rm_usuario_farmacia");
        }

    }
}
