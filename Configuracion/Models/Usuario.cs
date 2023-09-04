using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Configuracion.Models
{
    public class Usuario
    {
        public string nombre { get; set; }
        public string cedula { get; set; }
        public string farmacia { get; set; }
        public string idbodega { get; set; }
        public string sucursal { get; set; }
        public string compania { get; set; }
        public string centro_costo { get; set; }
        public string NombreCorto { get; set; }
        public List<AtribucionesModel> atribuciones { get; set; }
    }
}
