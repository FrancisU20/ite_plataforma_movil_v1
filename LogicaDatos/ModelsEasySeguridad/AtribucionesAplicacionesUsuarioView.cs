using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsEasySeguridad
{
    public partial class AtribucionesAplicacionesUsuarioView
    {
        public string Aplicacion { get; set; }
        public string Modulo { get; set; }
        public string Transaccion { get; set; }
        public string OficinaBanco { get; set; }
        public string NombreCorto { get; set; }
        public bool Habilitado { get; set; }
        public string NombreOfBanco { get; set; }
        public string NombreSucursal { get; set; }
        public string CodigoSucursal { get; set; }
        public bool CambioClave { get; set; }
        public bool UnicoLogon { get; set; }
        public bool UsuarioSupervisor { get; set; }
        public string PerfilReferencia { get; set; }
    }
}
