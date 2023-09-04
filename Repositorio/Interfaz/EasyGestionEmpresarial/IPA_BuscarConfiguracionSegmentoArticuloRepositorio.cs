using Core;
using Entidades.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Interfaz.EasyGestionEmpresarial
{
    public interface IPA_BuscarConfiguracionSegmentoArticuloRepositorio : IRepositorio<PA_BuscarConfiguracionSegmentoArticulo>
    {
        void Inicializar();
    }
}
