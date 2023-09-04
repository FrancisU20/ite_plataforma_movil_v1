using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsEasySeguridad
{
    public partial class SolicitudCambiosDetalle
    {
        public long IdSolicitudDetalle { get; set; }
        public long IdSolicitud { get; set; }
        public string Tabla { get; set; }
        public string CampoIdentificador { get; set; }
        public string Entrada { get; set; }
        public string Campo { get; set; }
        public string ValorOriginal { get; set; }
        public string ValorCambio { get; set; }
        public string Comando { get; set; }
    }
}
