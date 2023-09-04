using Entidades.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Contexto.EasyGestionEmpresarial
{
    public class Tbl_DetalleTransferenciaBCMap : EntityTypeConfiguration<Tbl_DetalleTransferenciaBC>
    {
        public Tbl_DetalleTransferenciaBCMap()
        {
            // Primary Key
            this.HasKey(t => new { t.dtbc_num_pedido, t.dtbc_tr_fol });

            // Table & Column Mappings
            this.ToTable("inv.tbl_DetalleTransferenciaBC");
            this.Property(t => t.dtbc_num_pedido).HasColumnName("dtbc_num_pedido");
            this.Property(t => t.dtbc_oficina).HasColumnName("dtbc_oficina");
            this.Property(t => t.dtbc_sucursal).HasColumnName("dtbc_sucursal");
            this.Property(t => t.dtbc_tipo_mov).HasColumnName("dtbc_tipo_mov");
            this.Property(t => t.dtbc_tr_fol).HasColumnName("dtbc_tr_fol");
            this.Property(t => t.envio_pos).HasColumnName("envio_pos");
        }
    }
}
