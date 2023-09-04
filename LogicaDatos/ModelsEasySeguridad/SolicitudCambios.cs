using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsEasySeguridad
{
    public partial class SolicitudCambios
    {
        public long IdSolicitud { get; set; }
        public string Aplicacion { get; set; }
        public string ObjetoCambio { get; set; }
        public string Comentario { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public string UsuarioMake { get; set; }
        public DateTime? FechaRespuesta { get; set; }
        public string UsuarioChecker { get; set; }
        public string Estado { get; set; }
        public string Referencia { get; set; }
        public string Motivo { get; set; }
    }
}
