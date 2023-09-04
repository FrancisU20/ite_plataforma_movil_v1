using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Servicio.Models
{
    public class cls_Cabecera
    {
        public string ip { get; set; }
        public string usuario { get; set; }
        public int id_plan { get; set; }
        public string nombre { get; set; }
        public string origen { get; set; }
        public List<articulos> articulos { get; set; }

        public string oficina { get; set; }
        public string sucursal { get; set; }
        public string compania { get; set; }
        public string ctcosto { get; set; }
        public string tipo { get; set; }
        public string base64 { get; set; }
    }

    public class articulos
    {
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public string barra { get; set; }
        public int valorconversion { get; set; }
        public int stock { get; set; }
        public int ingreso { get; set; }
        public bool coincide { get; set; }
    }
}
