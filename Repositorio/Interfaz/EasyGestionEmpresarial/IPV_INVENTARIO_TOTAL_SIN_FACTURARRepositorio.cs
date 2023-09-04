

using Core;
using Entidades.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Interfaz.EasyGestionEmpresarial
{
    public interface IPV_INVENTARIO_TOTAL_SIN_FACTURARRepositorio : IRepositorio<PV_INVENTARIO_TOTAL_SIN_FACTURAR>
    {
        void Inicializar();
    }
}
