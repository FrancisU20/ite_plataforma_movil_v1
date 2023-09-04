using Core;
using Entidades.EasyGestionEmpresarial;
using Entidades.EasySeguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Interfaz.EasySeguridad
{
    public interface IAtribucionesRepositorio : IRepositorio<Atribuciones>
    {
        void Inicializar();
    }
}
