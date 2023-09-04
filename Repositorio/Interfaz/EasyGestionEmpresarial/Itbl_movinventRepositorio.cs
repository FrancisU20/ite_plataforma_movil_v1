using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;
using Entidades.EasyGestionEmpresarial;

namespace Repositorio.Interfaz.EasyGestionEmpresarial
{
    public interface Itbl_movinventRepositorio : IRepositorio<tbl_movinvent>
    {
        void Inicializar();
        void InicializarFarmacia();
    }
    
}
