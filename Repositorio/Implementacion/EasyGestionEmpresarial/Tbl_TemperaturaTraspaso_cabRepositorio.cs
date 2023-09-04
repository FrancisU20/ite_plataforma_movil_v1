using Contexto.EasyGestionEmpresarial;
using Entidades.EasyGestionEmpresarial;
using Repositorio.Interfaz.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Implementacion.EasyGestionEmpresarial
{
    public class Tbl_TemperaturaTraspaso_cabRepositorio : Repositorio<Tbl_TemperaturaTraspaso_cab>, ITbl_TemperaturaTraspaso_cabRepositorio
    {
        public Tbl_TemperaturaTraspaso_cabRepositorio(EasyContextoFarmacia context)
            : base(context)
        {
        }

        public void Inicializar()
        {
            this.Context = new EasyContextoFarmacia();
        }

    }
}
