using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsEasySeguridad
{
    public partial class Aplicaciones
    {
        public Aplicaciones()
        {
            Modulos = new HashSet<Modulos>();
        }

        public string Aplicacion { get; set; }
        public string Descripcion { get; set; }
        public string PerteneceA { get; set; }
        public string Visualiza { get; set; }
        public bool Web { get; set; }
        public string Orden { get; set; }
        public string Link { get; set; }
        public string EnvioPos { get; set; }
        public bool? AplTieneAtribuciones { get; set; }

        public virtual ICollection<Modulos> Modulos { get; set; }
    }
}
