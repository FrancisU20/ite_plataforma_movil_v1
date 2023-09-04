using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsServicioDomicilio
{
    public partial class SdPsicoResultado
    {
        public string PreSerieReceta { get; set; }
        public string PreNombreMedico { get; set; }
        public string PreDireccionMedico { get; set; }
        public string PreTelefonoMedico { get; set; }
        public string PreFechaReceta { get; set; }
        public string PreNumeroInh { get; set; }
        public string PreCodigoMedico { get; set; }
        public string PreEspecialidad { get; set; }
        public string PreTipoMedico { get; set; }
        public string PreEstado { get; set; }
        public long PcaCodigo { get; set; }

        public virtual SdPedidosCab PcaCodigoNavigation { get; set; }
    }
}
