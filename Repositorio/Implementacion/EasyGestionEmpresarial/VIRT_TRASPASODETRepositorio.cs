using Contexto.EasyGestionEmpresarial;
using Entidades.EasyGestionEmpresarial;
using Repositorio.Interfaz.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Implementacion.EasyGestionEmpresarial
{
    public class VIRT_TRASPASODETRepositorio : Repositorio<VIRT_TRASPASODET>, IVIRT_TRASPASODETRepositorio
    {
        public VIRT_TRASPASODETRepositorio(EasyContextoMatriz contexto)
            : base(contexto)
        {
        }
        public void Inicializar()
        {
            this.Context = new EasyContextoMatriz();
        }

    }
}
