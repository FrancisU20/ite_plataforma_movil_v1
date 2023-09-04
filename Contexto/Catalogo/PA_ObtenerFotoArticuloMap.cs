using Entidades.Catalogo;
using Entidades.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Contexto.Catalogo
{
    public class PA_ObtenerFotoArticuloMap : EntityTypeConfiguration<PA_ObtenerFotoArticulo>
    {
        public PA_ObtenerFotoArticuloMap()
        {
            this.HasKey(t => new { t.fot_id_foto });

            this.Property(t => t.gru_codigo);

            // Properties
            this.Property(t => t.fot_grande_foto);

            // Table & Column Mappings
            this.ToTable("sjajs722nd");
            this.Property(t => t.fot_id_foto).HasColumnName("fot_id_foto");
            this.Property(t => t.fot_grande_foto).HasColumnName("fot_grande_foto");
            this.Property(t => t.gru_codigo).HasColumnName("gru_codigo");
        }
    }
}
