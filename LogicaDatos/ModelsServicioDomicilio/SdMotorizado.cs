using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsServicioDomicilio
{
    public partial class SdMotorizado
    {
        public SdMotorizado()
        {
            SdRelMotorizadoZona = new HashSet<SdRelMotorizadoZona>();
        }

        public int MotCodigo { get; set; }
        public string MotCedula { get; set; }
        public string MotNombre { get; set; }
        public string MotApellido { get; set; }
        public string MotDireccion { get; set; }
        public string MotMoto { get; set; }
        public string MotTelefono { get; set; }
        public string MotEstado { get; set; }

        public virtual ICollection<SdRelMotorizadoZona> SdRelMotorizadoZona { get; set; }
    }
}
