


using Core;
using Entidades.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Interfaz.EasyGestionEmpresarial
{
    public interface IPV_INVENTARIO_TOTAL_DETALLERepositorio : IRepositorio<PV_INVENTARIO_TOTAL_DETALLE>
    {
        void Inicializar();
    }
}
