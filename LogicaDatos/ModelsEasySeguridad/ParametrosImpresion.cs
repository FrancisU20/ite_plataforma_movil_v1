using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsEasySeguridad
{
    public partial class ParametrosImpresion
    {
        public string TipoUso { get; set; }
        public string Parametro { get; set; }
        public string Campo { get; set; }
        public string Tabla { get; set; }
        public string Descripcion { get; set; }
        public int Longitud { get; set; }
        public string Aerolinea { get; set; }
        public string Idioma { get; set; }
    }
}
