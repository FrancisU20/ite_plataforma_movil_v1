using Contexto.bdgeneral;
using Entidades.bdgeneral;
using Repositorio.Interfaz.bdgeneral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Implementacion.bdgeneral
{
    public class OFICINA_IPServerRepositorio : Repositorio<OFICINA_IPServer>, IOFICINA_IPServerRepositorio
    {
        public OFICINA_IPServerRepositorio(bdGenralContextoFarmacia contexto)
            : base(contexto)
        {
        }
        public void Inicializar()
        {
            this.Context = new bdGenralContextoFarmacia();
        }
    }
}
