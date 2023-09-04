using Core;
using Entidades.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Interfaz.EasyGestionEmpresarial
{
    public interface ITbl_TemperaturaTraspaso_cabRepositorio : IRepositorio<Tbl_TemperaturaTraspaso_cab>
    {
        void Inicializar();
    }
}
