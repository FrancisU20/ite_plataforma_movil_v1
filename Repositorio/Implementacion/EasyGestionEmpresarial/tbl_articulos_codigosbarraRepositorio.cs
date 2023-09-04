using Contexto.EasyGestionEmpresarial;
using Entidades.EasyGestionEmpresarial;
using Repositorio.Interfaz.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Implementacion.EasyGestionEmpresarial
{
    public class tbl_articulos_codigosbarraRepositorio : Repositorio<tbl_articulos_codigosbarra>, Itbl_articulos_codigosbarraRepositorio
    {
        public tbl_articulos_codigosbarraRepositorio(EasyContextoOffline contexto)
            : base(contexto)
        {
        }
        public void Inicializar()
        {
            this.Context = new EasyContextoOffline();
        }

        //public void InicializarFarmacia()
        //{
        //    this.Context = new EasyContextoOffline();
        //}

    }
}
