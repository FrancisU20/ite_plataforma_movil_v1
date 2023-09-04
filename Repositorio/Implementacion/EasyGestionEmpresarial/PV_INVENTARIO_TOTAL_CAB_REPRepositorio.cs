
using Contexto.EasyGestionEmpresarial;
using Entidades.EasyGestionEmpresarial;
using Repositorio.Interfaz.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Implementacion.EasyGestionEmpresarial
{
    public class PV_INVENTARIO_TOTAL_CAB_REPRepositorio : Repositorio<PV_INVENTARIO_TOTAL_CAB_REP>, IPV_INVENTARIO_TOTAL_CAB_REPRepositorio
    {
        public PV_INVENTARIO_TOTAL_CAB_REPRepositorio(EasyContextoFarmacia contexto)
            : base(contexto)
        {
        }
        public void Inicializar()
        {
            this.Context = new EasyContextoFarmacia();
        }

    }
}
