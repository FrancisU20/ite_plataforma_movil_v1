using Entidades.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Contexto.EasyGestionEmpresarial
{
    public class tbl_RegistroAppMovilMap : EntityTypeConfiguration<tbl_RegistroAppMovil>
    {
        public tbl_RegistroAppMovilMap()
        {
            this.HasKey(t => new { t.tipo_movimiento,t.numero_movimiento });
            this.Property(t => t.usuario_registro);
            this.Property(t => t.fecha_registro);

            this.ToTable("tbl_RegistroAppMovil", "pmov");
            this.Property(t => t.tipo_movimiento).HasColumnName("tipo_movimiento");
            this.Property(t => t.numero_movimiento).HasColumnName("numero_movimiento");
            this.Property(t => t.usuario_registro).HasColumnName("usuario_registro");
            this.Property(t => t.fecha_registro).HasColumnName("fecha_registro");
            this.Property(t => t.tipo_inventario).HasColumnName("tipo_inventario");
            this.Property(t => t.num_documento).HasColumnName("num_documento");
        }
    }
}
