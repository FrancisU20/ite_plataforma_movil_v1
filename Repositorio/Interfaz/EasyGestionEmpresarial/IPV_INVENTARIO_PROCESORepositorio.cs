using Core;
using Entidades.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Interfaz.EasyGestionEmpresarial
{
    public interface IPV_INVENTARIO_PROCESORepositorio : IRepositorio<PV_INVENTARIO_PROCESO>
    {
        void Inicializar();
    }
}
