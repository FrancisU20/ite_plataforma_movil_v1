using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsEasySeguridad
{
    public partial class UserEmpServ
    {
        public string Usuario { get; set; }
        public int IdEmpresa { get; set; }
        public int IdServicio { get; set; }
        public bool? Estado { get; set; }
        public bool? VisualizaDetalle { get; set; }
        public string CondicionPago { get; set; }
        public string EnvioPos { get; set; }
    }
}
