using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.EasyGestionEmpresarial
{
    public partial class PA_DatosUsuario
    {
        public string NombreCorto { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Descripcion { get; set; }
        public string Grupo { get; set; }
        public bool TipoUsuario { get; set; }
        public string Oficina_Banco { get; set; }
        public string Nombre_OfBanco { get; set; }
        public bool GrupoUsuario { get; set; }
        public string CodGrupoFinanciero { get; set; }
        public string NomGrupoFinanciero { get; set; }
        public string Codigo_Sucursal { get; set; }
        public string Nombre_Sucursal { get; set; }
        public bool Cambio_Clave { get; set; }
        public bool Unico_Logon { get; set; }
        public string Perfil_Referencia { get; set; }
        public bool Manejo_Grupo { get; set; }
        public string Fuente_Informacion_XML { get; set; }
        public bool Usuario_Supervisor { get; set; }
        public bool UserAdmin { get; set; }
        public bool TodasEmpServ { get; set; }
        public bool Actualiza_Datos { get; set; }
        public bool UserSuperAdmin { get; set; }
        public Nullable<long> Id_Persona { get; set; }
        public bool UserAdminBanco { get; set; }
        public string Perfil_Tipo { get; set; }
        public string Tipo_Ident { get; set; }
        public bool Aprobacion_General { get; set; }
        public string Niveles_Montos_General { get; set; }
        public string Tipos_Firmas_General { get; set; }
        public bool Restriccion_Cuentas { get; set; }
        public string id_agencia { get; set; }
        public string Direccion { get; set; }
        public string Codigo_Referencia { get; set; }
        public string Tipo_Empresa { get; set; }
        public string Estado { get; set; }
        public bool Envio_Notificacion { get; set; }
        public bool Token { get; set; }
        public string Password { get; set; }
        public string Apellido { get; set; }
        public string ENVIO_POS { get; set; }
        public string Alias { get; set; }
        public string Email { get; set; }
        public Nullable<bool> UsuarioAD { get; set; }
        public string Aplicacion { get; set; }
        public string Modulo { get; set; }
        public string Transaccion { get; set; }
        public bool Habilitado { get; set; }
        public string ENVIO_POS_a { get; set; }
        public string compania { get; set; }
        public string sucursal { get; set; }
        public string centrocosto { get; set; }
    }
}
