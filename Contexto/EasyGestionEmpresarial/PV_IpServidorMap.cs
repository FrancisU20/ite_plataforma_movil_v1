using Entidades.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Contexto.EasyGestionEmpresarial
{
    public class PV_IpServidorMap : EntityTypeConfiguration<PV_IpServidor>
    {
        public PV_IpServidorMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ipservidor, t.oficina, t.nombreOficina });

            // Properties
            this.Property(t => t.ipservidor);

            this.Property(t => t.oficina);

            this.Property(t => t.nombreOficina);


            // Table & Column Mappings
            this.ToTable("PV_IpServidor");
            this.Property(t => t.ipservidor).HasColumnName("ipservidor");
            this.Property(t => t.oficina).HasColumnName("oficina");
            this.Property(t => t.nombreOficina).HasColumnName("nombreOficina");
        }
    }
}
