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
    public class PV_INVENTARIO_TOTAL_PLANRepositorio : Repositorio<PV_INVENTARIO_TOTAL_PLAN>, IPV_INVENTARIO_TOTAL_PLANRepositorio
    {
        public PV_INVENTARIO_TOTAL_PLANRepositorio(EasyContextoFarmacia contexto)
            : base(contexto)
        {
        }
        public void Inicializar()
        {
            this.Context = new EasyContextoFarmacia();
        }

    }
}
