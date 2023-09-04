using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsEasySeguridad
{
    public partial class ConsultaAuditoriaView
    {
        public long IdLog { get; set; }
        public string FechaLog { get; set; }
        public string Hora { get; set; }
        public string Aplicacion { get; set; }
        public string Transaccion { get; set; }
        public string UserId { get; set; }
        public string MaquinaId { get; set; }
        public string Descripcion { get; set; }
        public string NodoProceso { get; set; }
        public int IdSobre { get; set; }
        public int IdItem { get; set; }
        public int IdContrato { get; set; }
        public string Empresa { get; set; }
        public string Servicio { get; set; }
        public DateTime FechaTransaccion { get; set; }
    }
}
