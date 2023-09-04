using Contexto.EasyGestionEmpresarial;
using Entidades.EasyGestionEmpresarial;
using Repositorio.Interfaz;
using Repositorio.Interfaz.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Implementacion.EasyGestionEmpresarial
{
    public class tbl_par_UsuarioNotificacionInconsistenciaRepositorio : Repositorio<tbl_par_UsuarioNotificacionInconsistencia>, Itbl_par_UsuarioNotificacionInconsistenciaRepositorio
    {
        public tbl_par_UsuarioNotificacionInconsistenciaRepositorio(EasyContextoFarmacia contexto)
            : base(contexto)
        {
        }
        public void Inicializar()
        {
            this.Context = new EasyContextoFarmacia();
        }

    }
}
