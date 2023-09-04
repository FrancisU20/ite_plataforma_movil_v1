using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;
using Entidades.EasyGestionEmpresarial;

namespace Repositorio.Interfaz.EasyGestionEmpresarial
{
    public interface Itbl_maestromovinventRepositorio: IRepositorio<tbl_maestromovinvent>
    {
        void Inicializar();
        void InicializarFarmacia();
    }
}
