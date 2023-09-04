using Contexto.EasyGestionEmpresarial;
using Entidades.EasyGestionEmpresarial;
using Repositorio.Interfaz.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Implementacion.EasyGestionEmpresarial
{
    public class VIRT_TRASPASODETOFFLINERepositorio : Repositorio<VIRT_TRASPASODETOFFLINE>, IVIRT_TRASPASODETOFFLINERepositorio
    {
        public VIRT_TRASPASODETOFFLINERepositorio(EasyContextoOffline contexto)
            : base(contexto)
        {
        }
        public void Inicializar()
        {
            this.Context = new EasyContextoOffline();
        }
    }
}
