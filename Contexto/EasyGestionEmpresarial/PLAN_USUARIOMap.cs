using Entidades.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Contexto.EasyGestionEmpresarial
{
    public class PLAN_USUARIOMap : EntityTypeConfiguration<PLAN_USUARIO>
    {
        public PLAN_USUARIOMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ID_PLAN, t.ORIGEN, t.usuario });

            // Properties
            this.Property(t => t.ID_PLAN);

            this.Property(t => t.ORIGEN);

            this.Property(t => t.usuario);

            this.Property(t => t.estado);           

            // Table & Column Mappings
            this.ToTable("PLAN_USUARIO", "dbo");
            this.Property(t => t.ID_PLAN).HasColumnName("ID_PLAN");
            this.Property(t => t.ORIGEN).HasColumnName("ORIGEN");
            this.Property(t => t.usuario).HasColumnName("usuario");
            this.Property(t => t.estado).HasColumnName("estado");
        }
    }
}
