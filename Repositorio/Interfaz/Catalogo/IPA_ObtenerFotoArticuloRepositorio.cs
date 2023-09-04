using Core;
using Entidades.Catalogo;
using Entidades.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Interfaz.Catalogo
{
    public interface IPA_ObtenerFotoArticuloRepositorio : IRepositorio<PA_ObtenerFotoArticulo>
    {
        void Inicializar();
    }
}
