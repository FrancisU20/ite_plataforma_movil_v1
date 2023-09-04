using Entidades.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Contexto.EasyGestionEmpresarial
{
    public class PA_DatosUsuarioMap : EntityTypeConfiguration<PA_DatosUsuario>
    {
        public PA_DatosUsuarioMap()
        {
            // Primary Key
            this.HasKey(t => new { t.NombreCorto, t.TipoUsuario, t.GrupoUsuario, t.Cambio_Clave, t.Unico_Logon, t.Perfil_Referencia, t.Manejo_Grupo, t.Fuente_Informacion_XML, t.Usuario_Supervisor, t.UserAdmin, t.TodasEmpServ, t.Actualiza_Datos, t.UserSuperAdmin, t.UserAdminBanco, t.Tipo_Ident, t.Aprobacion_General, t.Niveles_Montos_General, t.Tipos_Firmas_General, t.Restriccion_Cuentas, t.Direccion, t.Codigo_Referencia, t.Tipo_Empresa, t.Estado, t.Envio_Notificacion, t.Token, t.Password, t.Apellido, t.Aplicacion, t.Modulo, t.Transaccion, t.Habilitado });

            // Properties
            this.Property(t => t.NombreCorto)
                .IsRequired()
                .HasMaxLength(65);

            this.Property(t => t.Nombre)
                .HasMaxLength(40);

            this.Property(t => t.Cedula)
                .HasMaxLength(13);

            this.Property(t => t.Descripcion)
                .HasMaxLength(200);

            this.Property(t => t.Grupo)
                .HasMaxLength(65);

            this.Property(t => t.Oficina_Banco)
                .HasMaxLength(10);

            this.Property(t => t.Nombre_OfBanco)
                .HasMaxLength(50);

            this.Property(t => t.CodGrupoFinanciero)
                .HasMaxLength(20);

            this.Property(t => t.NomGrupoFinanciero)
                .HasMaxLength(50);

            this.Property(t => t.Codigo_Sucursal)
                .HasMaxLength(10);

            this.Property(t => t.Nombre_Sucursal)
                .HasMaxLength(50);

            this.Property(t => t.Perfil_Referencia)
                .IsRequired()
                .HasMaxLength(65);

            this.Property(t => t.Fuente_Informacion_XML)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.Perfil_Tipo)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.Tipo_Ident)
                .IsRequired()
                .HasMaxLength(1);

            this.Property(t => t.Niveles_Montos_General)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Tipos_Firmas_General)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.id_agencia)
                .HasMaxLength(10);

            this.Property(t => t.Direccion)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Codigo_Referencia)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Tipo_Empresa)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(3);

            this.Property(t => t.Estado)
                .IsRequired()
                .HasMaxLength(15);

            this.Property(t => t.Password)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Apellido)
                .IsRequired()
                .HasMaxLength(40);

            this.Property(t => t.ENVIO_POS)
                .HasMaxLength(2);

            this.Property(t => t.Alias)
                .HasMaxLength(50);

            this.Property(t => t.Email)
                .HasMaxLength(50);

            this.Property(t => t.Aplicacion)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Modulo)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Transaccion)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ENVIO_POS_a)
                .HasMaxLength(2);

            this.Property(t => t.compania);

            this.Property(t => t.sucursal);
            this.Property(t => t.centrocosto);

            // Table & Column Mappings
            this.ToTable("DatosUsuario", "PMOV");
            this.Property(t => t.NombreCorto).HasColumnName("NombreCorto");
            this.Property(t => t.Nombre).HasColumnName("Nombre");
            this.Property(t => t.Cedula).HasColumnName("Cedula");
            this.Property(t => t.Descripcion).HasColumnName("Descripcion");
            this.Property(t => t.Grupo).HasColumnName("Grupo");
            this.Property(t => t.TipoUsuario).HasColumnName("TipoUsuario");
            this.Property(t => t.Oficina_Banco).HasColumnName("Oficina_Banco");
            this.Property(t => t.Nombre_OfBanco).HasColumnName("Nombre_OfBanco");
            this.Property(t => t.GrupoUsuario).HasColumnName("GrupoUsuario");
            this.Property(t => t.CodGrupoFinanciero).HasColumnName("CodGrupoFinanciero");
            this.Property(t => t.NomGrupoFinanciero).HasColumnName("NomGrupoFinanciero");
            this.Property(t => t.Codigo_Sucursal).HasColumnName("Codigo_Sucursal");
            this.Property(t => t.Nombre_Sucursal).HasColumnName("Nombre_Sucursal");
            this.Property(t => t.Cambio_Clave).HasColumnName("Cambio_Clave");
            this.Property(t => t.Unico_Logon).HasColumnName("Unico_Logon");
            this.Property(t => t.Perfil_Referencia).HasColumnName("Perfil_Referencia");
            this.Property(t => t.Manejo_Grupo).HasColumnName("Manejo_Grupo");
            this.Property(t => t.Fuente_Informacion_XML).HasColumnName("Fuente_Informacion_XML");
            this.Property(t => t.Usuario_Supervisor).HasColumnName("Usuario_Supervisor");
            this.Property(t => t.UserAdmin).HasColumnName("UserAdmin");
            this.Property(t => t.TodasEmpServ).HasColumnName("TodasEmpServ");
            this.Property(t => t.Actualiza_Datos).HasColumnName("Actualiza_Datos");
            this.Property(t => t.UserSuperAdmin).HasColumnName("UserSuperAdmin");
            this.Property(t => t.Id_Persona).HasColumnName("Id_Persona");
            this.Property(t => t.UserAdminBanco).HasColumnName("UserAdminBanco");
            this.Property(t => t.Perfil_Tipo).HasColumnName("Perfil_Tipo");
            this.Property(t => t.Tipo_Ident).HasColumnName("Tipo_Ident");
            this.Property(t => t.Aprobacion_General).HasColumnName("Aprobacion_General");
            this.Property(t => t.Niveles_Montos_General).HasColumnName("Niveles_Montos_General");
            this.Property(t => t.Tipos_Firmas_General).HasColumnName("Tipos_Firmas_General");
            this.Property(t => t.Restriccion_Cuentas).HasColumnName("Restriccion_Cuentas");
            this.Property(t => t.id_agencia).HasColumnName("id_agencia");
            this.Property(t => t.Direccion).HasColumnName("Direccion");
            this.Property(t => t.Codigo_Referencia).HasColumnName("Codigo_Referencia");
            this.Property(t => t.Tipo_Empresa).HasColumnName("Tipo_Empresa");
            this.Property(t => t.Estado).HasColumnName("Estado");
            this.Property(t => t.Envio_Notificacion).HasColumnName("Envio_Notificacion");
            this.Property(t => t.Token).HasColumnName("Token");
            this.Property(t => t.Password).HasColumnName("Password");
            this.Property(t => t.Apellido).HasColumnName("Apellido");
            this.Property(t => t.ENVIO_POS).HasColumnName("ENVIO_POS");
            this.Property(t => t.Alias).HasColumnName("Alias");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.UsuarioAD).HasColumnName("UsuarioAD");
            this.Property(t => t.Aplicacion).HasColumnName("Aplicacion");
            this.Property(t => t.Modulo).HasColumnName("Modulo");
            this.Property(t => t.Transaccion).HasColumnName("Transaccion");
            this.Property(t => t.Habilitado).HasColumnName("Habilitado");
            this.Property(t => t.ENVIO_POS_a).HasColumnName("ENVIO_POS_a");
            this.Property(t => t.compania).HasColumnName("compania");
            this.Property(t => t.sucursal).HasColumnName("sucursal");
            this.Property(t => t.centrocosto).HasColumnName("centrocosto");
        }
    }
}
