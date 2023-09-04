﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contexto.EasyGestionEmpresarial;
using Entidades.EasyGestionEmpresarial;
using Repositorio.Interfaz.EasyGestionEmpresarial;

namespace Repositorio.Implementacion.EasyGestionEmpresarial
{
    public class tbl_maestromovinventRepositorio : Repositorio<tbl_maestromovinvent>, Itbl_maestromovinventRepositorio
    {
        public tbl_maestromovinventRepositorio(EasyContextoMatriz contexto)
            : base(contexto)
        {
        }
        public void Inicializar()
        {
            this.Context = new EasyContextoMatriz();
        }
        public void InicializarFarmacia()
        {
            this.Context = new EasyContextoFarmacia();
            this.Context.Configuration.ValidateOnSaveEnabled = true;
        }
    }
}
