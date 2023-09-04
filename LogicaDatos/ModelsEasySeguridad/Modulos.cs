using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsEasySeguridad
{
    public partial class Modulos
    {
        public Modulos()
        {
            Transacciones = new HashSet<Transacciones>();
        }

        public string Aplicacion { get; set; }
        public string Modulo { get; set; }
        public string Descripcion { get; set; }
        public float IndiceModulo { get; set; }
        public string EnvioPos { get; set; }

        public virtual Aplicaciones AplicacionNavigation { get; set; }
        public virtual ICollection<Transacciones> Transacciones { get; set; }
    }
}
