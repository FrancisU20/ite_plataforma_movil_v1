using Core;
using Entidades.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Interfaz.EasyGestionEmpresarial
{
    public interface IPLAN_DESCUENTODETRepositorio : IRepositorio<PLAN_DESCUENTODET>
    {
        void Inicializar();
    }
}
