using Core;
using Entidades.bdgeneral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Interfaz.bdgeneral
{

    public interface IOFICINARepositorio : IRepositorio<OFICINA>
    {
        void Inicializar();
    }
}
