using Core;
using Entidades.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Interfaz.EasyGestionEmpresarial
{
    public interface IPLAN_USUARIORepositorio : IRepositorio<PLAN_USUARIO>
    {
        void Inicializar();
    }
}
