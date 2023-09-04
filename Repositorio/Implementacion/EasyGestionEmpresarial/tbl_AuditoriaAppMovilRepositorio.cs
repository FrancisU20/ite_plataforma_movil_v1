using Contexto.EasyGestionEmpresarial;
using Entidades.EasyGestionEmpresarial;
using Repositorio.Interfaz.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Implementacion.EasyGestionEmpresarial
{
    public class tbl_AuditoriaAppMovilRepositorio : Repositorio<tbl_AuditoriaAppMovil>, Itbl_AuditoriaAppMovilRepositorio
    {
        public tbl_AuditoriaAppMovilRepositorio(EasyContextoMatriz context)
            : base(context)
        {
        }

        public void Inicializar()
        {
            this.Context = new EasyContextoMatriz();
        }
    }
}
