using Entidades.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Contexto.EasyGestionEmpresarial
{
    public class tbl_par_UsuarioNotificacionInconsistenciaMap: EntityTypeConfiguration<tbl_par_UsuarioNotificacionInconsistencia>
    {
        public tbl_par_UsuarioNotificacionInconsistenciaMap()
        {
            this.HasKey(t => new { t.usuario,t.aplicacion });
            this.Property(t => t.correo);
            this.Property(t => t.estado);

            this.ToTable("tbl_par_UsuarioNotificacionInconsistencia", "pmov");
            this.Property(t => t.usuario).HasColumnName("uni_usuario");
            this.Property(t => t.aplicacion).HasColumnName("uni_aplicacion");
            this.Property(t => t.correo).HasColumnName("uni_correo");
            this.Property(t => t.estado).HasColumnName("uni_estado");
        }
    }
}
