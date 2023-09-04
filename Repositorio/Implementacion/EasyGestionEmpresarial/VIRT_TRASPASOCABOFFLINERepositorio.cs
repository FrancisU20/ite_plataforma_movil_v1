using Contexto.EasyGestionEmpresarial;
using Entidades.EasyGestionEmpresarial;
using Repositorio.Interfaz.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Implementacion.EasyGestionEmpresarial
{
    public class VIRT_TRASPASOCABOFFLINERepositorio : Repositorio<VIRT_TRASPASOCABOFFLINE>, IVIRT_TRASPASOCABOFFLINERepositorio
    {
        public VIRT_TRASPASOCABOFFLINERepositorio(EasyContextoOffline contexto)
            : base(contexto)
        {
        }
        public void Inicializar()
        {
            this.Context = new EasyContextoOffline();
        }
    }
}
