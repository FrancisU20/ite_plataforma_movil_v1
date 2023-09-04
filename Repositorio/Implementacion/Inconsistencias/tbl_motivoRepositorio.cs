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
    public class tbl_motivoRepositorio : Repositorio<tbl_motivo>, Itbl_motivoRepositorio
    {
        public tbl_motivoRepositorio(InconsistenciasContextoMatriz contexto)
            : base(contexto)
        {
        }
        public void Inicializar()
        {
            this.Context = new InconsistenciasContextoMatriz();
        }

    }
}
