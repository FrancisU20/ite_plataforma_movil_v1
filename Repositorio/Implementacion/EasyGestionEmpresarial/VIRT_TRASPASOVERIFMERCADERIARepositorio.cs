using Contexto.EasyGestionEmpresarial;
using Entidades.EasyGestionEmpresarial;
using Repositorio.Interfaz.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Implementacion.EasyGestionEmpresarial
{
    public class VIRT_TRASPASOVERIFMERCADERIARepositorio : Repositorio<VIRT_TRASPASOVERIFMERCADERIA>, IVIRT_TRASPASOVERIFMERCADERIARepositorio
    {
        public VIRT_TRASPASOVERIFMERCADERIARepositorio(EasyContextoFarmacia context)
            : base(context)
        {
        }

        public void Inicializar()
        {
            this.Context = new EasyContextoFarmacia();
        }
    }
}
