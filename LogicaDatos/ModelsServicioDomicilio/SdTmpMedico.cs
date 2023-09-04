using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsServicioDomicilio
{
    public partial class SdTmpMedico
    {
        public long PcaCodigo { get; set; }
        public string MedSerieReceta { get; set; }
        public string MedNombre { get; set; }
        public string MedDireccion { get; set; }
        public string MedTelefono { get; set; }
        public DateTime? MedFechaReceta { get; set; }
        public string MedNumeroInh { get; set; }
        public int? MedCodigo { get; set; }
        public string MedEspecialidad { get; set; }
        public string MedTipoMedico { get; set; }
        public string MedEstado { get; set; }
    }
}
