using Contexto.EasyGestionEmpresarial;
using Entidades.EasyGestionEmpresarial;
using Repositorio.Interfaz.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Implementacion.EasyGestionEmpresarial
{
    public class Pa_EquipararBodegaFarmaciaRepositorio : Repositorio<Pa_EquipararBodegaFarmacia>, IPa_EquipararBodegaFarmaciaRepositorio
    {
        public Pa_EquipararBodegaFarmaciaRepositorio(EasyContextoFarmacia contexto)
            : base(contexto)
        {
        }
        public void Inicializar()
        {
            this.Context = new EasyContextoFarmacia();
        }

    }
}
