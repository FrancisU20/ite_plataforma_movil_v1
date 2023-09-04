using Entidades.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Contexto.EasyGestionEmpresarial
{
    public class Tbl_TemperaturaTraspaso_cabMap : EntityTypeConfiguration<Tbl_TemperaturaTraspaso_cab>
    {
        public Tbl_TemperaturaTraspaso_cabMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ttc_tr_fol, t.ttc_contenedor });

            // Properties
            this.Property(t => t.ttc_tr_fol).IsRequired();
            this.Property(t => t.ttc_contenedor).IsRequired();

            this.Property(t => t.ttc_temperatura);

            this.Property(t => t.ttc_observacion);

            this.Property(t => t.ttc_fecha);

            this.Property(t => t.ttc_usuario);

            this.Property(t => t.ENVIO_POS);

            // Table & Column Mappings
            this.ToTable("tbl_TemperaturaTraspaso_cab", "inv");
            this.Property(t => t.ttc_tr_fol).HasColumnName("ttc_tr_fol");
            this.Property(t => t.ttc_contenedor).HasColumnName("ttc_contenedor");
            this.Property(t => t.ttc_temperatura).HasColumnName("ttc_temperatura");
            this.Property(t => t.ttc_observacion).HasColumnName("ttc_observacion");
            this.Property(t => t.ttc_fecha).HasColumnName("ttc_fecha");
            this.Property(t => t.ttc_usuario).HasColumnName("ttc_usuario");
            this.Property(t => t.ENVIO_POS).HasColumnName("ENVIO_POS");
        }
    }
}
