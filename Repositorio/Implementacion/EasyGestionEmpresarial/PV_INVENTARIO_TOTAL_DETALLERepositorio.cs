﻿



using Contexto.EasyGestionEmpresarial;
using Entidades.EasyGestionEmpresarial;
using Repositorio.Interfaz.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Implementacion.EasyGestionEmpresarial
{
    public class PV_INVENTARIO_TOTAL_DETALLERepositorio : Repositorio<PV_INVENTARIO_TOTAL_DETALLE>, IPV_INVENTARIO_TOTAL_DETALLERepositorio
    {
        public PV_INVENTARIO_TOTAL_DETALLERepositorio(EasyContextoFarmacia contexto)
            : base(contexto)
        {
        }
        public void Inicializar()
        {
            this.Context = new EasyContextoFarmacia();
        }

    }
}
