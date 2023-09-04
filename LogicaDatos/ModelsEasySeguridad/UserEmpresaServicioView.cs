using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsEasySeguridad
{
    public partial class UserEmpresaServicioView
    {
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public string CodigoServicio { get; set; }
        public string DescripcionServicio { get; set; }
        public string Usuario { get; set; }
        public bool? Estado { get; set; }
    }
}
