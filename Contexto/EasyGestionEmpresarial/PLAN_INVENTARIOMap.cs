using Entidades.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Contexto.EasyGestionEmpresarial
{
    public class PLAN_INVENTARIOMap : EntityTypeConfiguration<PLAN_INVENTARIO>
    {
        public PLAN_INVENTARIOMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ID_PLAN, t.OFICINA, t.SUCURSAL, t.IDBODEGA, t.ORIGEN });

            // Properties
            this.Property(t => t.ID_PLAN)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.NOMBRE)
                .HasMaxLength(200);

            this.Property(t => t.USUARIO)
                .HasMaxLength(50);

            this.Property(t => t.SOLICITANTE)
                .HasMaxLength(150);

            this.Property(t => t.ESTADO)
                .HasMaxLength(15);

            this.Property(t => t.USUARIO_MODIFICA)
                .HasMaxLength(50);

            this.Property(t => t.TIPO)
                .IsRequired()
                .HasMaxLength(15);

            this.Property(t => t.DESCONTABLE)
                .IsRequired()
                .HasMaxLength(2);

            this.Property(t => t.USUARIO_IMPRESO)
                .IsRequired()
                .HasMaxLength(15);

            this.Property(t => t.USUARIO_RECONTEO)
                .IsRequired()
                .HasMaxLength(15);

            this.Property(t => t.USUARIO_DESCUENTO)
                .IsRequired()
                .HasMaxLength(15);

            this.Property(t => t.USUARIO_FINALIZADO)
                .IsRequired()
                .HasMaxLength(15);

            this.Property(t => t.OFICINA)
                .IsRequired();

            this.Property(t => t.ENVIO_POS)
                .HasMaxLength(2);

            this.Property(t => t.SUCURSAL)
                .IsRequired();

            this.Property(t => t.IDBODEGA)
                .IsRequired();

            this.Property(t => t.NUMERO_DOCUMENTO)
                .HasMaxLength(20);

            this.Property(t => t.PROCESO)
                .HasMaxLength(20);

            this.Property(t => t.ORIGEN)
                .IsRequired()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("PLAN_INVENTARIO");
            this.Property(t => t.ID_PLAN).HasColumnName("ID_PLAN");
            this.Property(t => t.NOMBRE).HasColumnName("NOMBRE");
            this.Property(t => t.FECHA_INICIO).HasColumnName("FECHA_INICIO");
            this.Property(t => t.FECHA_FIN).HasColumnName("FECHA_FIN");
            this.Property(t => t.USUARIO).HasColumnName("USUARIO");
            this.Property(t => t.SOLICITANTE).HasColumnName("SOLICITANTE");
            this.Property(t => t.ESTADO).HasColumnName("ESTADO");
            this.Property(t => t.NOCONTEO).HasColumnName("NOCONTEO");
            this.Property(t => t.USUARIO_MODIFICA).HasColumnName("USUARIO_MODIFICA");
            this.Property(t => t.FECHA_CREACION).HasColumnName("FECHA_CREACION");
            this.Property(t => t.FECHA_MODIFICA).HasColumnName("FECHA_MODIFICA");
            this.Property(t => t.TIPO).HasColumnName("TIPO");
            this.Property(t => t.DESCONTABLE).HasColumnName("DESCONTABLE");
            this.Property(t => t.FECHA_IMPRESO).HasColumnName("FECHA_IMPRESO");
            this.Property(t => t.USUARIO_IMPRESO).HasColumnName("USUARIO_IMPRESO");
            this.Property(t => t.FECHA_RECONTEO).HasColumnName("FECHA_RECONTEO");
            this.Property(t => t.USUARIO_RECONTEO).HasColumnName("USUARIO_RECONTEO");
            this.Property(t => t.FECHA_DESCUENTO).HasColumnName("FECHA_DESCUENTO");
            this.Property(t => t.USUARIO_DESCUENTO).HasColumnName("USUARIO_DESCUENTO");
            this.Property(t => t.FECHA_FINALIZADO).HasColumnName("FECHA_FINALIZADO");
            this.Property(t => t.USUARIO_FINALIZADO).HasColumnName("USUARIO_FINALIZADO");
            this.Property(t => t.OFICINA).HasColumnName("OFICINA");
            this.Property(t => t.ENVIO_POS).HasColumnName("ENVIO_POS");
            this.Property(t => t.SUCURSAL).HasColumnName("SUCURSAL");
            this.Property(t => t.IDBODEGA).HasColumnName("IDBODEGA");
            this.Property(t => t.NUMERO_DOCUMENTO).HasColumnName("NUMERO_DOCUMENTO");
            this.Property(t => t.PROCESO).HasColumnName("PROCESO");
            this.Property(t => t.ORIGEN).HasColumnName("ORIGEN");
        }
    }
}
