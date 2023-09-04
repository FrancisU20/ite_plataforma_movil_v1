







using Contexto.EasyGestionEmpresarial;
using Entidades.EasyGestionEmpresarial;
using Repositorio.Interfaz.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Implementacion.EasyGestionEmpresarial
{
    public class PV_INVENTARIO_TRASPASOSRepositorio : Repositorio<PV_INVENTARIO_TRASPASOS>, IPV_INVENTARIO_TRASPASOSRepositorio
    {
        public PV_INVENTARIO_TRASPASOSRepositorio(EasyContextoFarmacia contexto)
            : base(contexto)
        {
        }
        public void Inicializar()
        {
            this.Context = new EasyContextoFarmacia();
        }

    }
}
