using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using Entidades.EasyGestionEmpresarial;

namespace Contexto.EasyGestionEmpresarial
{
    public class tbl_maestromovinventMap : EntityTypeConfiguration<tbl_maestromovinvent>
    {
        public tbl_maestromovinventMap()
        {
            this.HasKey(t => new { t.Compania,t.Sucursal,t.Oficina,t.tipo_mov,t.num_mov,t.serie_factura,t.tipo_causa});

            this.Property(t => t.Compania)
                .HasMaxLength(3);

            this.Property(t => t.Sucursal)
                .HasMaxLength(3);

            this.Property(t => t.Oficina)
                .HasMaxLength(3);

            this.ToTable("tbl_maestromovinvent");
            this.Property(t => t.Compania).HasColumnName("Compania");
            this.Property(t => t.idbodega).HasColumnName("idbodega");
            this.Property(t => t.monto).HasColumnName("monto");
            this.Property(t => t.num_mov).HasColumnName("num_mov");
            this.Property(t => t.Oficina).HasColumnName("Oficina");
            this.Property(t => t.serie_factura).HasColumnName("serie_factura");
            this.Property(t => t.Sucursal).HasColumnName("Sucursal");
            this.Property(t => t.tipo_causa).HasColumnName("tipo_causa");
            this.Property(t => t.tipo_mov).HasColumnName("tipo_mov");
            this.Property(t => t.num_documento).HasColumnName("num_documento");
        }
    }
}
