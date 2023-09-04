using Contexto.EasyGestionEmpresarial;
using Entidades.EasyGestionEmpresarial;
using Repositorio.Interfaz.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Implementacion.EasyGestionEmpresarial
{
    
    public class PA_GEN_GenerarKardexFarmaciaRepositorio : Repositorio<PA_GEN_GenerarKardexFarmacia>, IPA_GEN_GenerarKardexFarmaciaRepositorio
    {
        public PA_GEN_GenerarKardexFarmaciaRepositorio(EasyContextoFarmacia context)
            : base(context)
        {
        }

        public void Inicializar()
        {
            this.Context = new EasyContextoFarmacia();
        }
    }
}
