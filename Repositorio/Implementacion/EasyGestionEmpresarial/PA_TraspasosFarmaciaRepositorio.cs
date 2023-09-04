using Contexto.EasyGestionEmpresarial;
using Entidades.EasyGestionEmpresarial;
using Repositorio.Interfaz.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Implementacion.EasyGestionEmpresarial
{
    public class PA_TraspasosFarmaciaRepositorio : Repositorio<PA_TraspasosFarmacia>, IPA_TraspasosFarmaciaRepositorio
    {
        public PA_TraspasosFarmaciaRepositorio(EasyContextoMatriz contexto)
            : base(contexto)
        {
        }
        public void Inicializar()
        {
            this.Context = new EasyContextoMatriz();
        }

    }
}
