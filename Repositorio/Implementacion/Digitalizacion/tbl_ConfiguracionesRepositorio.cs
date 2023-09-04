using Contexto.Digitalizacion;
using Entidades.Digitalizacion;
using Repositorio.Interfaz.Digitalizacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Implementacion.Digitalizacion
{
    public class tbl_ConfiguracionesRepositorio:Repositorio<tbl_Configuraciones>, Itbl_ConfiguracionesRepositorio
    {
        public tbl_ConfiguracionesRepositorio(DigitalizacionContextoMatriz contexto)
            : base(contexto)
        {
        }
        public void Inicializar()
        {
            Context = new DigitalizacionContextoMatriz();
        }
    }
}
