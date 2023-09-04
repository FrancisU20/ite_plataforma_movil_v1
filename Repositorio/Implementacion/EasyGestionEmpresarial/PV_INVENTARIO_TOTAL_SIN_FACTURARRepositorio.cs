







using Contexto.EasyGestionEmpresarial;
using Entidades.EasyGestionEmpresarial;
using Repositorio.Interfaz.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Implementacion.EasyGestionEmpresarial
{
    public class PV_INVENTARIO_TOTAL_SIN_FACTURARRepositorio : Repositorio<PV_INVENTARIO_TOTAL_SIN_FACTURAR>, IPV_INVENTARIO_TOTAL_SIN_FACTURARRepositorio
    {
        public PV_INVENTARIO_TOTAL_SIN_FACTURARRepositorio(EasyContextoFarmacia contexto)
            : base(contexto)
        {
        }
        public void Inicializar()
        {
            this.Context = new EasyContextoFarmacia();
        }

    }
}
