using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsEasySeguridad
{
    public partial class AtribucionesCuentas
    {
        public string NombreCorto { get; set; }
        public int IdEmpresa { get; set; }
        public int IdServicio { get; set; }
        public int IdCuenta { get; set; }
        public bool Habilitada { get; set; }
    }
}
