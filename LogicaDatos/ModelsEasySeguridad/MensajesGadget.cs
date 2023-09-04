using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsEasySeguridad
{
    public partial class MensajesGadget
    {
        public int IdMensaje { get; set; }
        public string Mensaje { get; set; }
        public bool Seleccionado { get; set; }
    }
}
