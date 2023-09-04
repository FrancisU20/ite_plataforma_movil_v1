using Entidades.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Contexto.EasyGestionEmpresarial
{
    public class OficinasMap : EntityTypeConfiguration<Oficinas>
    {
        public OficinasMap()
        {
            // Primary Key
            this.HasKey(t => t.oficina);

            // Table & Column Mappings
            this.ToTable("Oficina");
            this.Property(t => t.oficina).HasColumnName("oficina");
            this.Property(t => t.nombre).HasColumnName("nombre");
            this.Property(t => t.correo_electronico).HasColumnName("correo_electronico");
            //this.Property(t => t.srvr_ip).HasColumnName("srvr_ip");
            this.Property(t => t.compania).HasColumnName("compania");
            this.Property(t => t.sucursal).HasColumnName("sucursal");
            this.Property(t => t.es_autoservicio).HasColumnName("es_autoservicio");
        }
    }
}
