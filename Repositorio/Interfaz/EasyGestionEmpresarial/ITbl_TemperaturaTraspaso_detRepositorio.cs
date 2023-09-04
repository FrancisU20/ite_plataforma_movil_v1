using Core;
using Entidades.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Interfaz.EasyGestionEmpresarial
{
    public interface ITbl_TemperaturaTraspaso_detRepositorio : IRepositorio<tbl_TemperaturaTraspaso_det>
    {
        void Inicializar();
    }
}
