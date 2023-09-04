using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsEasySeguridad
{
    public partial class OficinaParametrizacion
    {
        public string Sucursal { get; set; }
        public string Oficina { get; set; }
        public string Horaini { get; set; }
        public string Horafin { get; set; }
        public int? Saltos { get; set; }
        public bool? Estado { get; set; }
        public string EnvioPos { get; set; }
    }
}
