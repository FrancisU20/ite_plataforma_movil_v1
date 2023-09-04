using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsEasySeguridad
{
    public partial class MyServiceAccounts
    {
        public string NombreCorto { get; set; }
        public string Servicio { get; set; }
        public string Cuenta { get; set; }
        public string Referencia { get; set; }
        public bool? Habilitado { get; set; }
    }
}
