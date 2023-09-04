using Entidades.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Contexto.EasyGestionEmpresarial
{
    public class Tbl_TemperaturaTraspaso_detMap : EntityTypeConfiguration<tbl_TemperaturaTraspaso_det>
    {
        public Tbl_TemperaturaTraspaso_detMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ttd_tr_fol, t.ttd_producto, t.ttd_contenedor});

            // Properties
            this.Property(t => t.ttd_tr_fol)
                .IsRequired();

            this.Property(t => t.ttd_producto)
                .IsRequired();

            this.Property(t => t.ttd_contenedor)
                .IsRequired();

           
            this.Property(t => t.ttd_temperatura);
            this.Property(t => t.ttd_observacion);
            this.Property(t => t.ttd_fecha);
            this.Property(t => t.ttd_usuario);
            this.Property(t => t.ENVIO_POS);

            // Table & Column Mappings
            this.ToTable("tbl_TemperaturaTraspaso_det", "inv");
            this.Property(t => t.ttd_tr_fol).HasColumnName("ttd_tr_fol");
            this.Property(t => t.ttd_producto).HasColumnName("ttd_producto");
            this.Property(t => t.ttd_contenedor).HasColumnName("ttd_contenedor");
            this.Property(t => t.ttd_temperatura).HasColumnName("ttd_temperatura");
            this.Property(t => t.ttd_observacion).HasColumnName("ttd_observacion");
            this.Property(t => t.ttd_fecha).HasColumnName("ttd_fecha");
            this.Property(t => t.ttd_usuario).HasColumnName("ttd_usuario");
            this.Property(t => t.ENVIO_POS).HasColumnName("ENVIO_POS");
        }
    }
}
