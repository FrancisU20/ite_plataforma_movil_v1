using Contexto.EasyGestionEmpresarial;
using Entidades.EasyGestionEmpresarial;
using Repositorio.Interfaz.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Implementacion.EasyGestionEmpresarial
{
    public class PA_ArticulosPlanificacionResumenRepositorio : Repositorio<PA_ArticulosPlanificacionResumen>, IPA_ArticulosPlanificacionResumenRepositorio
    {
        public PA_ArticulosPlanificacionResumenRepositorio(EasyContextoFarmacia contexto)
            : base(contexto)
        {
        }
        public void Inicializar()
        {
            this.Context = new EasyContextoFarmacia();
        }

    }
}
