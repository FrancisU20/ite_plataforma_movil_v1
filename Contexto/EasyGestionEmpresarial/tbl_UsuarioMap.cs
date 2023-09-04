using Entidades.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Contexto.EasyGestionEmpresarial
{
    public class tbl_LoginUsuarioMap : EntityTypeConfiguration<tbl_LoginUsuario>
    {
        public tbl_LoginUsuarioMap()
        {// Primary Key
            this.HasKey(t => new { t.lg_cookie, t.lg_oficina });

            // Properties
            this.Property(t => t.lg_cookie)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.lg_compania);

            this.Property(t => t.lg_oficina)
                .IsRequired();

            this.Property(t => t.lg_sucursal);

            this.Property(t => t.lg_nombreUsuario)
                .HasMaxLength(65);

            this.Property(t => t.lg_estado)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.lg_ipCaja)
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("tbl_LoginUsuario", "pmov");
            this.Property(t => t.lg_cookie).HasColumnName("lg_cookie");
            this.Property(t => t.lg_compania).HasColumnName("lg_compania");
            this.Property(t => t.lg_oficina).HasColumnName("lg_oficina");
            this.Property(t => t.lg_sucursal).HasColumnName("lg_sucursal");
            this.Property(t => t.lg_nombreUsuario).HasColumnName("lg_nombreUsuario");
            this.Property(t => t.lg_estado).HasColumnName("lg_estado");
            this.Property(t => t.lg_ipCaja).HasColumnName("lg_ipCaja");
            this.Property(t => t.lg_fecha).HasColumnName("lg_fecha");
        }
    }
}
