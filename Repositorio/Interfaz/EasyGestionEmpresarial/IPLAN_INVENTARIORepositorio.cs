using Core;
using Entidades.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Interfaz.EasyGestionEmpresarial
{
    public interface IPLAN_INVENTARIORepositorio : IRepositorio<PLAN_INVENTARIO>
    {
        void Inicializar();
    }
}
