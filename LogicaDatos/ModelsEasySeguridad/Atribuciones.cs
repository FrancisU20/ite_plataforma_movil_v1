using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsEasySeguridad
{
    public partial class Atribuciones
    {
        public string NombreCorto { get; set; }
        public string Aplicacion { get; set; }
        public string Modulo { get; set; }
        public string Transaccion { get; set; }
        public bool Habilitado { get; set; }
        public string EnvioPos { get; set; }

    }
}
