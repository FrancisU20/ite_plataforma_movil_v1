using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using Entidades.bdgeneral;

namespace Contexto.bdgeneral
{
    public class OFICINA_IPServerMap : EntityTypeConfiguration<OFICINA_IPServer>
    {
        public OFICINA_IPServerMap()
        {
            // Primary Key
            this.HasKey(t => new { t.oficina, t.ip_red });

            // Properties
            this.Property(t => t.oficina)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.ip_red)
                .IsRequired()
                .HasMaxLength(15);

           

            // Table & Column Mappings
            this.ToTable("OFICINA_IP_SERVER");
            this.Property(t => t.oficina).HasColumnName("oficina");
            this.Property(t => t.ip_red).HasColumnName("ip_red");
    
        }
    }
}
