using Contexto.EasyGestionEmpresarial;
using Entidades.EasyGestionEmpresarial;
using Repositorio.Interfaz.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Implementacion.EasyGestionEmpresarial
{
    public class tbl_tmp_RecepcionMercaderiaRepositorio : Repositorio<tbl_tmp_RecepcionMercaderia>, Itbl_tmp_RecepcionMercaderiaRepositorio
    {
        public tbl_tmp_RecepcionMercaderiaRepositorio(EasyContextoFarmacia context)
            : base(context)
        {
        }

        public void Inicializar()
        {
            this.Context = new EasyContextoFarmacia();
        }
    }
}
