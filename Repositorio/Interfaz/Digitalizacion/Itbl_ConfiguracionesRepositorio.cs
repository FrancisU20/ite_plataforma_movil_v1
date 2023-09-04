using Core;
using Entidades.Digitalizacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Interfaz.Digitalizacion
{
    public interface Itbl_ConfiguracionesRepositorio : IRepositorio<tbl_Configuraciones>
    {
        void Inicializar();
    }
}
