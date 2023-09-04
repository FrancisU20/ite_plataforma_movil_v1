using Contexto.EasyGestionEmpresarial;
using Entidades.EasyGestionEmpresarial;
using Repositorio.Interfaz.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Implementacion.EasyGestionEmpresarial
{
    public class PA_BuscarConfiguracionSegmentoArticuloRepositorio : Repositorio<PA_BuscarConfiguracionSegmentoArticulo>, IPA_BuscarConfiguracionSegmentoArticuloRepositorio
    {
        public PA_BuscarConfiguracionSegmentoArticuloRepositorio(EasyContextoFarmacia context)
            : base(context)
        {
        }

        public void Inicializar()
        {
            this.Context = new EasyContextoFarmacia();
        }

    }
}
