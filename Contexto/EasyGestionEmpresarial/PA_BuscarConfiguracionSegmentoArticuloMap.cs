using Entidades.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Contexto.EasyGestionEmpresarial
{
    public class PA_BuscarConfiguracionSegmentoArticuloMap : EntityTypeConfiguration<PA_BuscarConfiguracionSegmentoArticulo>
    {
        public PA_BuscarConfiguracionSegmentoArticuloMap()
        {
            // Primary Key
            this.HasKey(t => new { t.codigo, t.desc_emp, t.valor_POS });

            // Properties
            this.Property(t => t.codigo);

            this.Property(t => t.desc_emp);

            this.Property(t => t.valor_POS);

          
            // Table & Column Mappings
            this.MapToStoredProcedures();
            this.Property(t => t.codigo).HasColumnName("codigo");
            this.Property(t => t.desc_emp).HasColumnName("desc_emp");
            this.Property(t => t.valor_POS).HasColumnName("valor_POS");

        }
    }
}
