using Contexto.bdgeneral;
using Entidades.bdgeneral;
using Repositorio.Interfaz.bdgeneral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Implementacion.bdgeneral
{
    public class OFICINARepositorio : Repositorio<OFICINA>, IOFICINARepositorio
    {
        public OFICINARepositorio(bdGenralContextoFarmacia contexto)
            : base(contexto)
        {
        }
        public void Inicializar()
        {
            this.Context = new bdGenralContextoFarmacia();
        }
    }
}
