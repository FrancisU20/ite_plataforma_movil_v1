using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsEasySeguridad
{
    public partial class AtribucionesExcepciones
    {
        public string NombreCorto { get; set; }
        public string Aplicacion { get; set; }
        public string Modulo { get; set; }
        public string Transaccion { get; set; }
        public int IdServicio { get; set; }
        public int IdEmpresa { get; set; }
    }
}
