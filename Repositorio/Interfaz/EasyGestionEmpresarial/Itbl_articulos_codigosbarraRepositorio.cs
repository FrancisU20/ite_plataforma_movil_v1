using Core;
using Entidades.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Interfaz.EasyGestionEmpresarial
{
    public interface Itbl_articulos_codigosbarraRepositorio : IRepositorio<tbl_articulos_codigosbarra>
    {
        void Inicializar();
        //void InicializarFarmacia();
    }
}
