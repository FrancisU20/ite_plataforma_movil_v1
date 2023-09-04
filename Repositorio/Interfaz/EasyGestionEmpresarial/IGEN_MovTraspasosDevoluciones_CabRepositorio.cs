using Core;
using Entidades.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Interfaz.EasyGestionEmpresarial
{
    public interface IGEN_MovTraspasosDevoluciones_CabRepositorio : IRepositorio<GEN_MovTraspasosDevoluciones_Cab>
    {
        void Inicializar();
    }
}
