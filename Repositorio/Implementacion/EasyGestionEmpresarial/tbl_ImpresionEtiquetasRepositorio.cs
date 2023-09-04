using Contexto.EasyGestionEmpresarial;
using Entidades.EasyGestionEmpresarial;
using Repositorio.Interfaz.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Implementacion.EasyGestionEmpresarial
{
    public class tbl_ImpresionEtiquetasRepositorio: Repositorio<tbl_ImpresionEtiquetas>,Itbl_ImpresionEtiquetasRepositorio
    {
        public tbl_ImpresionEtiquetasRepositorio(EasyContextoFarmacia context)
           : base(context)
        {
        }

        public void Inicializar()
        {
            this.Context = new EasyContextoFarmacia();
        }
    }
}
