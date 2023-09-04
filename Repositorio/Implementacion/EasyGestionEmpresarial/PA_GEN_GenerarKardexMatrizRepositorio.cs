using Contexto.EasyGestionEmpresarial;
using Entidades.EasyGestionEmpresarial;
using Repositorio.Interfaz.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Implementacion.EasyGestionEmpresarial
{
    public class PA_GEN_GenerarKardexMatrizRepositorio : Repositorio<PA_GEN_GenerarKardexMatriz>, IPA_GEN_GenerarKardexMatrizRepositorio
    {
        public PA_GEN_GenerarKardexMatrizRepositorio(EasyContextoMatriz context)
            : base(context)
        {
        }

        public void Inicializar()
        {
            this.Context = new EasyContextoMatriz();
        }
    }
}
