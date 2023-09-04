using Contexto.bdgeneral;
using Entidades.bdgeneral;
using Repositorio.Interfaz.bdgeneral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Implementacion.bdgeneral
{
    public class OFICINA_IPRepositorio : Repositorio<OFICINA_IP>, IOFICINA_IPRepositorio
    {
        public OFICINA_IPRepositorio(bdGenralContextoFarmacia contexto)
            : base(contexto)
        {
        }
        public void Inicializar()
        {
            this.Context = new bdGenralContextoFarmacia();
        }
    }
}
