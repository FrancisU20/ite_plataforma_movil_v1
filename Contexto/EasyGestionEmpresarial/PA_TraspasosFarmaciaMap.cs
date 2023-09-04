using Entidades.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Contexto.EasyGestionEmpresarial
{
    public class PA_TraspasosFarmaciaMap : EntityTypeConfiguration<PA_TraspasosFarmacia>
    {
        public PA_TraspasosFarmaciaMap()
        {
            // Primary Key
            this.HasKey(t => new { t.TR_FOL, t.TR_TIPOMOV, t.ID_BODEGA_ORG });

            // Properties
            this.Property(t => t.TR_FOL)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.TR_TIPOMOV)
                .IsRequired()
                .HasMaxLength(5);

            this.Property(t => t.TR_ESTADO)
                .HasMaxLength(2);

            this.Property(t => t.TR_ESTCONF)
                .HasMaxLength(2);

            this.Property(t => t.TR_USUA)
                .HasMaxLength(15);

            this.Property(t => t.ID_BODEGA_ORG);

            this.Property(t => t.ENVIO_POS)
                .HasMaxLength(2);

            this.Property(t => t.TRST_ESTADO)
                .HasMaxLength(2);

            this.Property(t => t.tr_es_pedido_facturado);

            
            // Table & Column Mappings
            this.ToTable("TEMPPMOV");
            this.Property(t => t.TR_FOL).HasColumnName("TR_FOL");
            this.Property(t => t.TR_TIPOMOV).HasColumnName("TR_TIPOMOV");
            this.Property(t => t.TR_FECDES).HasColumnName("TR_FECDES");
            this.Property(t => t.TR_ESTADO).HasColumnName("TR_ESTADO");
            this.Property(t => t.TR_ESTCONF).HasColumnName("TR_ESTCONF");
            this.Property(t => t.TR_USUA).HasColumnName("TR_USUA");
            this.Property(t => t.ID_BODEGA_ORG).HasColumnName("ID_BODEGA_ORG");
            this.Property(t => t.ENVIO_POS).HasColumnName("ENVIO_POS");
            this.Property(t => t.TRST_ESTADO).HasColumnName("TRST_ESTADO");
            this.Property(t => t.TRST_FECHA).HasColumnName("TRST_FECHA");
            this.Property(t => t.NumeroGuiaRemision).HasColumnName("NumeroGuiaRemision");
            this.Property(t => t.observacion).HasColumnName("observacion");

            this.Property(t => t.tbcc_num_pedido).HasColumnName("tbcc_num_pedido");
            this.Property(t => t.tbcc_sucursal).HasColumnName("tbcc_sucursal");
            this.Property(t => t.tbcc_oficina).HasColumnName("tbcc_oficina");
            this.Property(t => t.tbcc_estado).HasColumnName("tbcc_estado");
            this.Property(t => t.tbcc_retira_matriz).HasColumnName("tbcc_retira_matriz");
            this.Property(t => t.dtbc_tipo_mov).HasColumnName("dtbc_tipo_mov");
            this.Property(t => t.dtbc_tr_fol).HasColumnName("dtbc_tr_fol");
            this.Property(t => t.tr_es_pedido_facturado).HasColumnName("tr_es_pedido_facturado");
        }
    }
}
