using Contexto.EasyGestionEmpresarial;
using Contexto.Inconsistencias;
using Entidades.EasyGestionEmpresarial;
using Entidades.Inconsistencias;
using Repositorio.Interfaz.EasyGestionEmpresarial;
using Repositorio.Interfaz.Inconsistencias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Implementacion.Inconsistencias
{
    public class tbl_inco_bodegaRepositorio : Repositorio<tbl_inco_bodega>, Itbl_inco_bodegaRepositorio
    {
        public tbl_inco_bodegaRepositorio(EasyContextoFarmacia contexto)
            : base(contexto)
        {
        }
        public void Inicializar()
        {
            this.Context = new EasyContextoFarmacia();
        }

    }
}
