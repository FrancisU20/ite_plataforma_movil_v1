using Entidades.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Contexto.EasyGestionEmpresarial
{
    public class Tbl_tablasMap : EntityTypeConfiguration<tbl_tablas>
    {
        public Tbl_tablasMap()
        {
            // Primary Key
            this.HasKey(t => t.id_tabla);

            // Table & Column Mappings
            this.ToTable("tbl_tablas");
            this.Property(t => t.cx_argumento).HasColumnName("cx_argumento");
            this.Property(t => t.envio_pos).HasColumnName("envio_pos");
            this.Property(t => t.id_tabla).HasColumnName("id_tabla");
            this.Property(t => t.tx_descripcion).HasColumnName("tx_descripcion");
        }
    }
}
