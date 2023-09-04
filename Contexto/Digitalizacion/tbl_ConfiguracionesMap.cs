using Entidades.Digitalizacion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Contexto.Digitalizacion
{
    public class tbl_ConfiguracionesMap : EntityTypeConfiguration<tbl_Configuraciones>
    {
        public tbl_ConfiguracionesMap()
        {
            // Primary Key
            this.HasKey(t => t.cfg_codigo);

            // Properties

            this.Property(t => t.cfg_codigo)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.cfg_ip_server_app)
                .HasMaxLength(25);

            this.Property(t => t.cfg_us_server_app)
                .HasMaxLength(50);

            this.Property(t => t.cfg_pass_server_app)
                .HasMaxLength(50);

            this.Property(t => t.cfg_temp_app)
                .HasMaxLength(100);

            this.Property(t => t.cfg_ip_server_img)
                .HasMaxLength(50);

            this.Property(t => t.cfg_us_server_img)
                .HasMaxLength(50);

            this.Property(t => t.cfg_pass_server_img)
                .HasMaxLength(50);

            this.Property(t => t.cfg_destino_img)
                .HasMaxLength(100);

            this.Property(t => t.cfg_estado)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.cfg_usuario_registro)
                .HasMaxLength(50);

            this.Property(t => t.cfg_servicio_escaneo)
                .HasMaxLength(100);

            this.Property(t => t.cfg_bdd)
                .HasMaxLength(50);

            this.Property(t => t.cfg_bdd_pass)
                .HasMaxLength(20);

            this.Property(t => t.cfg_bdd_usuario)
                .HasMaxLength(50);

            this.Property(t => t.cfg_bdd_ip)
                .HasMaxLength(50);

            this.Property(t => t.cfg_usuarios_locales)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.cfg_centro_costo_aplica)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.cfg_empresa_master)
                .HasMaxLength(10);

            this.Property(t => t.cfg_url_api)
                .HasMaxLength(100);

            this.Property(t => t.cfg_client_id)
                .HasMaxLength(100);

            this.Property(t => t.cfg_client_secret)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("tbl_Configuraciones");
            this.Property(t => t.cfg_codigo).HasColumnName("cfg_codigo");
            this.Property(t => t.amb_codigo).HasColumnName("amb_codigo");
            this.Property(t => t.com_codigo).HasColumnName("com_codigo");
            this.Property(t => t.cfg_ip_server_app).HasColumnName("cfg_ip_server_app");
            this.Property(t => t.cfg_us_server_app).HasColumnName("cfg_us_server_app");
            this.Property(t => t.cfg_pass_server_app).HasColumnName("cfg_pass_server_app");
            this.Property(t => t.cfg_compresion).HasColumnName("cfg_compresion");
            this.Property(t => t.cfg_temp_app).HasColumnName("cfg_temp_app");
            this.Property(t => t.cfg_ip_server_img).HasColumnName("cfg_ip_server_img");
            this.Property(t => t.cfg_us_server_img).HasColumnName("cfg_us_server_img");
            this.Property(t => t.cfg_pass_server_img).HasColumnName("cfg_pass_server_img");
            this.Property(t => t.cfg_destino_img).HasColumnName("cfg_destino_img");
            this.Property(t => t.cfg_estado).HasColumnName("cfg_estado");
            this.Property(t => t.cfg_usuario_registro).HasColumnName("cfg_usuario_registro");
            this.Property(t => t.cfg_fecha_registro).HasColumnName("cfg_fecha_registro");
            this.Property(t => t.cfg_servicio_escaneo).HasColumnName("cfg_servicio_escaneo");
            this.Property(t => t.cfg_bdd).HasColumnName("cfg_bdd");
            this.Property(t => t.cfg_bdd_pass).HasColumnName("cfg_bdd_pass");
            this.Property(t => t.cfg_bdd_usuario).HasColumnName("cfg_bdd_usuario");
            this.Property(t => t.cfg_bdd_ip).HasColumnName("cfg_bdd_ip");
            this.Property(t => t.cfg_usuarios_locales).HasColumnName("cfg_usuarios_locales");
            this.Property(t => t.cfg_centro_costo_aplica).HasColumnName("cfg_centro_costo_aplica");
            this.Property(t => t.cfg_empresa_master).HasColumnName("cfg_empresa_master");
            this.Property(t => t.cfg_url_api).HasColumnName("cfg_url_api");
            this.Property(t => t.cfg_client_id).HasColumnName("cfg_client_id");
            this.Property(t => t.cfg_client_secret).HasColumnName("cfg_client_secret");

        }
    }
}
