using Entidades.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Contexto.EasyGestionEmpresarial
{
    public class PA_ConsultarArtituloInventarioTotalMap : EntityTypeConfiguration<PA_ConsultarArtituloInventarioTotal>
    {
        public PA_ConsultarArtituloInventarioTotalMap()
        {
            // Primary Key
            this.HasKey(t => new { t.codigo, t.codigo_barra });

            // Properties
            this.Property(t => t.codigo);
            this.Property(t => t.codigo_barra);
            this.Property(t => t.descripcion);
            this.Property(t => t.laboratorio);
            this.Property(t => t.valor_POS);
            this.Property(t => t.existencias);

            // Table & Column Mappings
            this.MapToStoredProcedures();
            this.Property(t => t.codigo).HasColumnName("codigo");
            this.Property(t => t.codigo_barra).HasColumnName("codigo_barra");
            this.Property(t => t.descripcion).HasColumnName("descripcion");
            this.Property(t => t.valor_POS).HasColumnName("valor_POS");
            this.Property(t => t.laboratorio).HasColumnName("laboratorio");
            this.Property(t => t.existencias).HasColumnName("existencias");
           
        }
    }
}
