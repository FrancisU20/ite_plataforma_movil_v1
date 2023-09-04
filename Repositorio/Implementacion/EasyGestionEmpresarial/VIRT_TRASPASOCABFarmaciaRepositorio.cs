using Contexto.EasyGestionEmpresarial;
using Entidades.EasyGestionEmpresarial;
using Repositorio.Interfaz.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Implementacion.EasyGestionEmpresarial
{
    public class VIRT_TRASPASOCABFarmaciaRepositorio : Repositorio<VIRT_TRASPASOCABFarmacia>, IVIRT_TRASPASOCABFarmaciaRepositorio
    {
        public VIRT_TRASPASOCABFarmaciaRepositorio(EasyContextoFarmacia contexto)
            : base(contexto)
        {
        }
        public void Inicializar()
        {
            this.Context = new EasyContextoFarmacia();
        }
    }
}
