using Contexto.EasyGestionEmpresarial;
using Entidades.EasyGestionEmpresarial;
using Repositorio.Interfaz.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Implementacion.EasyGestionEmpresarial
{
    public class tbl_articulosRepositorio : Repositorio<tbl_articulos>, Itbl_articulosRepositorio
    {
        public tbl_articulosRepositorio(EasyContextoFarmacia contexto)
            : base(contexto)
        {
        }
        public void Inicializar()
        {
            this.Context = new EasyContextoFarmacia();
        }
        public void InicializarMatriz()
        {
            this.Context = new EasyContextoFarmacia();
        }

    }
}
