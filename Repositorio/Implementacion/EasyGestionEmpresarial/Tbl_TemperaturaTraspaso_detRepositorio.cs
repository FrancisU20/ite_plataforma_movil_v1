using Contexto.EasyGestionEmpresarial;
using Entidades.EasyGestionEmpresarial;
using Repositorio.Interfaz.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Implementacion.EasyGestionEmpresarial
{
    public class Tbl_TemperaturaTraspaso_detRepositorio : Repositorio<tbl_TemperaturaTraspaso_det>, ITbl_TemperaturaTraspaso_detRepositorio
    {
        public Tbl_TemperaturaTraspaso_detRepositorio(EasyContextoFarmacia context)
            : base(context)
        {
        }

        public void Inicializar()
        {
            this.Context = new EasyContextoFarmacia();
        }

    }
}
