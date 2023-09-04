using Core;
using Entidades.EasyGestionEmpresarial;
using Entidades.Inconsistencias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Interfaz.Inconsistencias
{
    public interface Itbl_motivoRepositorio : IRepositorio<tbl_motivo>
    {
        void Inicializar();
    }
}
