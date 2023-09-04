using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsEasySeguridad
{
    public partial class UsuarioPreguntasDesafio
    {
        public string NombreCorto { get; set; }
        public byte NumeroPregunta { get; set; }
        public string Pregunta { get; set; }
        public string Respuesta { get; set; }

        public virtual Usuarios NombreCortoNavigation { get; set; }
    }
}
