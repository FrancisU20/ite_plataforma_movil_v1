using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsEasySeguridad
{
    public partial class ListadoUsuariosSwitchBp
    {
        public string NombreCorto { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Descripcion { get; set; }
        public string Grupo { get; set; }
        public string TipoUsuario { get; set; }
        public string OficinaBanco { get; set; }
        public string NombreOfBanco { get; set; }
        public bool GrupoUsuario { get; set; }
        public string CodGrupoFinanciero { get; set; }
        public string NomGrupoFinanciero { get; set; }
        public int CambioClave { get; set; }
        public string CodigoSucursal { get; set; }
        public string NombreSucursal { get; set; }
        public bool UnicoLogon { get; set; }
        public string PerfilReferencia { get; set; }
        public int ManejoGrupo { get; set; }
        public bool ActualizaDatos { get; set; }
        public bool UserSuperAdmin { get; set; }
        public bool UserAdminBanco { get; set; }
        public bool UsuarioSupervisor { get; set; }
        public bool TodasEmpServ { get; set; }
        public bool UserAdmin { get; set; }
        public string Email { get; set; }
        public string PerfilTipo { get; set; }
        public string IdPersona { get; set; }
        public string TipoIdent { get; set; }
        public bool AprobacionGeneral { get; set; }
        public string NivelesMontosGeneral { get; set; }
        public string TiposFirmasGeneral { get; set; }
        public bool RestriccionCuentas { get; set; }
        public string CodigoReferencia { get; set; }
        public string TipoEmpresa { get; set; }
        public string Estado { get; set; }
        public string IdAgencia { get; set; }
        public bool EnvioNotificacion { get; set; }
        public string Direccion { get; set; }
        public bool Token { get; set; }
        public string FuenteInformacionXml { get; set; }
        public string Password { get; set; }
        public int? Alias { get; set; }
        public string Apellido { get; set; }
        public bool? UsuarioAd { get; set; }
        public string UsuarioBancaPersonas { get; set; }
    }
}
