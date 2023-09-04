using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsServicioDomicilio
{
    public partial class SdTmpPromocionesPremiosConfirmados
    {
        public int? PpcIdPromociones { get; set; }
        public string PpcCodigoArticulo { get; set; }
        public string PpcTipoArticulo { get; set; }
        public string PpcTipoMov { get; set; }
        public string PpcCantidad { get; set; }
        public string PpcVTotal { get; set; }
        public string PpcRequiereCupon { get; set; }
        public string PpcTieneCupon { get; set; }
        public string PpcEsAcumulable { get; set; }
        public string PpcUMedida { get; set; }
        public string PpcLeyenda { get; set; }
        public string PpcNombrePromocion { get; set; }
        public string PpcLeyendaPremio { get; set; }
        public string PcaCodigo { get; set; }
    }
}
