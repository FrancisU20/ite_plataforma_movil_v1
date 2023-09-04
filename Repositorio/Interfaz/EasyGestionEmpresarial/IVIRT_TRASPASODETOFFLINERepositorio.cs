using Core;
using Entidades.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Interfaz.EasyGestionEmpresarial
{
    public interface IVIRT_TRASPASODETOFFLINERepositorio : IRepositorio<VIRT_TRASPASODETOFFLINE>
    {
        void Inicializar();
    }
}
