using Contexto.EasyGestionEmpresarial;
using Entidades.EasyGestionEmpresarial;
using Repositorio.Interfaz.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Implementacion.EasyGestionEmpresarial
{
    public class PA_ValidarTraspasoCFRepositorio : Repositorio<PA_ValidarTraspasoCF>, IPA_ValidarTraspasoCFRepositorio
    {
        public PA_ValidarTraspasoCFRepositorio(EasyContextoFarmacia context)
            : base(context)
        {
        }

        public void Inicializar()
        {
            this.Context = new EasyContextoFarmacia();
        }

    }
}
