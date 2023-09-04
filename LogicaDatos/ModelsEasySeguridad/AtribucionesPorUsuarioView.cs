using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsEasySeguridad
{
    public partial class AtribucionesPorUsuarioView
    {
        public string Nombrecorto { get; set; }
        public string Empresa { get; set; }
        public int IdEmpresa { get; set; }
        public string Servicio { get; set; }
        public int IdServicio { get; set; }
        public string IdAplicacion { get; set; }
        public string Aplicacion { get; set; }
        public string Modulo { get; set; }
        public string Transaccion { get; set; }
        public string IdTransaccion { get; set; }
        public bool? Estado { get; set; }
        public string CondicionPago { get; set; }
    }
}
