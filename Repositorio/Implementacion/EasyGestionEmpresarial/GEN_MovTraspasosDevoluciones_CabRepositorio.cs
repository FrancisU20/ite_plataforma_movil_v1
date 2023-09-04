using Contexto.EasyGestionEmpresarial;
using Entidades.EasyGestionEmpresarial;
using Repositorio.Interfaz.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Implementacion.EasyGestionEmpresarial
{
    public class GEN_MovTraspasosDevoluciones_CabRepositorio : Repositorio<GEN_MovTraspasosDevoluciones_Cab>, IGEN_MovTraspasosDevoluciones_CabRepositorio
    {
        public GEN_MovTraspasosDevoluciones_CabRepositorio(EasyContextoMatriz context)
            : base(context)
        {
        }

        public void Inicializar()
        {
            this.Context = new EasyContextoMatriz();
        }
    }
}
