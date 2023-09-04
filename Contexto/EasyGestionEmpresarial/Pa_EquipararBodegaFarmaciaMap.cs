using Entidades.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Contexto.EasyGestionEmpresarial
{
    public class Pa_EquipararBodegaFarmaciaMap : EntityTypeConfiguration<Pa_EquipararBodegaFarmacia>
    {
        public Pa_EquipararBodegaFarmaciaMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Name });

        }
    }
}
