using Contexto.EasyGestionEmpresarial;
using Entidades.EasyGestionEmpresarial;
using Repositorio.Interfaz.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Implementacion.EasyGestionEmpresarial
{
    public class PA_TraspasosFarmaciaOffLineRepositorio : Repositorio<PA_TraspasosFarmaciaOffLine>, IPA_TraspasosFarmaciaOffLineRepositorio
    {
        public PA_TraspasosFarmaciaOffLineRepositorio(EasyContextoOffline contexto)
            : base(contexto)
        {
        }
        public void Inicializar()
        {
            this.Context = new EasyContextoOffline();
        }

    }
}
