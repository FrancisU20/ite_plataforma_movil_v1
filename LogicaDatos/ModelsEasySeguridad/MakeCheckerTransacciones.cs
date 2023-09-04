using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsEasySeguridad
{
    public partial class MakeCheckerTransacciones
    {
        public int IdTransaccion { get; set; }
        public string Aplicacion { get; set; }
        public string Clave { get; set; }
        public string Descripcion { get; set; }
    }
}
