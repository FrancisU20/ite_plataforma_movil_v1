using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsEasySeguridad
{
    public partial class TransaccionesExcepciones
    {
        public string Aplicacion { get; set; }
        public string Modulo { get; set; }
        public string Transaccion { get; set; }
        public string AplicacionExc { get; set; }
        public string ModuloExc { get; set; }
        public string TransaccionExc { get; set; }
        public string MensajeNegacion { get; set; }
        public string MensajeAdvertencia { get; set; }
    }
}
