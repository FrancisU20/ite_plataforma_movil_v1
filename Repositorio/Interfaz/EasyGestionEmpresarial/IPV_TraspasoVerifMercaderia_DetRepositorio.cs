using Core;
using Entidades.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Interfaz.EasyGestionEmpresarial
{
    
    public interface IPV_TraspasoVerifMercaderia_DetRepositorio : IRepositorio<PV_TraspasoVerifMercaderia_Det>
    {
        void Inicializar();
    }
}
