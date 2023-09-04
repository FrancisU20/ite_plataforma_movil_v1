using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsServicioDomicilio
{
    public partial class SdDirecciones
    {
        public string CliTipoIdCliente { get; set; }
        public string CliNumeroIdcliente { get; set; }
        public short DirIdDireccion { get; set; }
        public string DirNombreDireccion { get; set; }
        public string DirDireccion { get; set; }
        public string DirNumFono1 { get; set; }
        public string DirNumFono2 { get; set; }
        public string DirEMail { get; set; }
        public string DirEnvioPos { get; set; }
        public string DirNoEstablecimiento { get; set; }
        public string DirNombreEstablecimiento { get; set; }
    }
}
