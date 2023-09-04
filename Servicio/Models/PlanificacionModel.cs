using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Servicio.Models
{
    public class PlanificacionModel
    {
        public string ip { get; set; }
        public string usuario { get; set; }
        public string id_plan { get; set; }
        public string nombre { get; set; }
        public string origen { get; set; }
        public List<ArticuloModel> articulos { get; set; }
    }
}
