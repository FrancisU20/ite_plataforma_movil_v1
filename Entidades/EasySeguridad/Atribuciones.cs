using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Entidades.EasySeguridad
{
    public partial class Atribuciones
    {
        [Key, Column(Order = 0)]
        public string NombreCorto { get; set; }
        [Key, Column(Order = 1)]
        public string Aplicacion { get; set; }
        [Key, Column(Order = 2)]
        public string Modulo { get; set; }
        [Key, Column(Order = 3)]
        public string Transaccion { get; set; }
        public bool Habilitado { get; set; }
        public string ENVIO_POS { get; set; }

    }
}
