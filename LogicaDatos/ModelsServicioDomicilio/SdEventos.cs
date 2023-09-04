using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsServicioDomicilio
{
    public partial class SdEventos
    {
        public int EvtId { get; set; }
        public string EvtNombre { get; set; }
        public DateTime? EvtFecha { get; set; }
        public string EvtObservacion { get; set; }
    }
}
