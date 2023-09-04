using Entidades.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Contexto.EasyGestionEmpresarial
{
    public class PV_TraspasoInformeMercaderiaMap : EntityTypeConfiguration<PV_TraspasoInformeMercaderia>
    {
        public PV_TraspasoInformeMercaderiaMap()
        {
            // Primary Key
            this.HasKey(t => t.tim_id);

            // Properties
            this.Property(t => t.tim_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.tim_codigo)
                .HasMaxLength(50);

            this.Property(t => t.tim_usuario)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("PV_TraspasoInformeMercaderia");
            this.Property(t => t.tim_id).HasColumnName("tim_id");
            this.Property(t => t.tim_codigo).HasColumnName("tim_codigo");
            this.Property(t => t.tim_fecha).HasColumnName("tim_fecha");
            this.Property(t => t.tim_usuario).HasColumnName("tim_usuario");
            this.Property(t => t.tim_traspasos).HasColumnName("tim_traspasos");
        }
    }
}
