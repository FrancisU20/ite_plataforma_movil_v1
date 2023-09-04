using Core;
using Entidades.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Interfaz.EasyGestionEmpresarial
{
    public interface IPA_GEN_GenerarKardexMatrizRepositorio : IRepositorio<PA_GEN_GenerarKardexMatriz>
    {
        void Inicializar();
    }
}
