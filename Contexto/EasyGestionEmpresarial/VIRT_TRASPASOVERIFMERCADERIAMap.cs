using Entidades.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Contexto.EasyGestionEmpresarial
{
    public class VIRT_TRASPASOVERIFMERCADERIAMap : EntityTypeConfiguration<VIRT_TRASPASOVERIFMERCADERIA>
    {
        public VIRT_TRASPASOVERIFMERCADERIAMap()
        {
            // Primary Key
            this.HasKey(t => t.numTraspaso);

            // Properties
            this.Property(t => t.numTraspaso)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.tipoMovimiento)
                .HasMaxLength(50);

            this.Property(t => t.estado)
                .HasMaxLength(50);

            this.Property(t => t.usuario)
                .HasMaxLength(50);

            this.Property(t => t.tr_fol);

            this.Property(t => t.vtvm_estado_traspaso);
            this.Property(t => t.vtvm_ip_maquina);
            this.Property(t => t.vtvm_usuario_recepcion);

            // Table & Column Mappings
            this.ToTable("VIRT_TRASPASOVERIFMERCADERIA");
            this.Property(t => t.numTraspaso).HasColumnName("numTraspaso");
            this.Property(t => t.tipoMovimiento).HasColumnName("tipoMovimiento");
            this.Property(t => t.procesado).HasColumnName("procesado");
            this.Property(t => t.pendiente).HasColumnName("pendiente");
            this.Property(t => t.estado).HasColumnName("estado");
            this.Property(t => t.usuario).HasColumnName("usuario");
            this.Property(t => t.fecha).HasColumnName("fecha");
            this.Property(t => t.tr_fol).HasColumnName("tr_fol");
            this.Property(t => t.vtvm_estado_traspaso).HasColumnName("vtvm_estado_traspaso");
            this.Property(t => t.vtvm_ip_maquina).HasColumnName("vtvm_ip_maquina");
            this.Property(t => t.vtvm_usuario_recepcion).HasColumnName("vtvm_usuario_recepcion");
            this.Property(t => t.vtvm_estado_recepcion).HasColumnName("vtvm_estado_recepcion");

        }
    }
}
