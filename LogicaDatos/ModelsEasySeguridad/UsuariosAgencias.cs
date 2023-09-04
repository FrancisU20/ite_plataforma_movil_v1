using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsEasySeguridad
{
    public partial class UsuariosAgencias
    {
        public string NombreCorto { get; set; }
        public string CodigoSucursal { get; set; }
        public string NombreSucursal { get; set; }
        public string IdAgencia { get; set; }
        public string NombreAgencia { get; set; }
        public string OficinaBanco { get; set; }
        public string NombreOfBanco { get; set; }
        public string CodAgencia { get; set; }
        public string EnvioPos { get; set; }
        public string Estado { get; set; }
        public string UagPredeterminado { get; set; }
        public short? EmpId { get; set; }
        public DateTime UagInicio { get; set; }
        public DateTime UagFin { get; set; }
    }
}
