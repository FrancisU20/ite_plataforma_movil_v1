using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsEasySeguridad
{
    public partial class TblArchivosComunicaciones
    {
        public string Compania { get; set; }
        public string Sucursal { get; set; }
        public string Oficina { get; set; }
        public string BaseDatos { get; set; }
        public string Tabla { get; set; }
        public string Tipo { get; set; }
        public string NombreArchivo { get; set; }
        public long Version { get; set; }
        public DateTime FechaComunicacion { get; set; }
    }
}
