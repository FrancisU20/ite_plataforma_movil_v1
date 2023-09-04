using Contexto.EasyGestionEmpresarial;
using Entidades.EasyGestionEmpresarial;
using Repositorio.Interfaz.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Implementacion.EasyGestionEmpresarial
{
    public class PV_TraspasoVerifMercaderia_DetRepositorio : Repositorio<PV_TraspasoVerifMercaderia_Det>, IPV_TraspasoVerifMercaderia_DetRepositorio
    {
        public PV_TraspasoVerifMercaderia_DetRepositorio(EasyContextoFarmacia context)
            : base(context)
        {
        }

        public void Inicializar()
        {
            this.Context = new EasyContextoFarmacia();
        }
    }
}
