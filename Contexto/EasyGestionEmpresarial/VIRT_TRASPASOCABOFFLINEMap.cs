using Entidades.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Contexto.EasyGestionEmpresarial
{
    public class VIRT_TRASPASOCABOFFLINEMap : EntityTypeConfiguration<VIRT_TRASPASOCABOFFLINE>
    {
        public VIRT_TRASPASOCABOFFLINEMap()
        {
            // Primary Key
            this.HasKey(t => new { t.TR_FOL, t.TR_TIPOMOV, t.ID_BODEGA_ORG });

            // Properties
            this.Property(t => t.TR_FOL)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.TR_USUD)
                .HasMaxLength(15);

            this.Property(t => t.TR_USUA)
                .HasMaxLength(15);

            this.Property(t => t.TR_NOMBODD)
                .HasMaxLength(100);

            this.Property(t => t.TR_DIRBODD)
                .HasMaxLength(100);

            this.Property(t => t.TR_NOMBODH)
                .HasMaxLength(100);

            this.Property(t => t.TR_DIRBODH)
                .HasMaxLength(100);

            this.Property(t => t.TR_ESTADO)
                .HasMaxLength(2);

            this.Property(t => t.TR_ESTCONF)
                .HasMaxLength(2);

            this.Property(t => t.TR_CIUDAD)
                .HasMaxLength(50);

            this.Property(t => t.ID_BODEGA)
                .HasMaxLength(3);

            this.Property(t => t.TR_TIPOMOV)
                .IsRequired()
                .HasMaxLength(5);

            this.Property(t => t.ID_BODEGA_ORG)
                .IsRequired()
                .HasMaxLength(3);

            this.Property(t => t.ENVIO_POS)
                .HasMaxLength(2);

            this.Property(t => t.NO_GUIA)
                .HasMaxLength(50);

            this.Property(t => t.vtc_numero_pedido_sap);

            // Table & Column Mappings
            this.ToTable("VIRT_TRASPASOCABOFFLINE");
            this.Property(t => t.TR_FOL).HasColumnName("TR_FOL");
            this.Property(t => t.TR_USUD).HasColumnName("TR_USUD");
            this.Property(t => t.TR_USUA).HasColumnName("TR_USUA");
            this.Property(t => t.TR_FECEM).HasColumnName("TR_FECEM");
            this.Property(t => t.TR_NOMBODD).HasColumnName("TR_NOMBODD");
            this.Property(t => t.TR_DIRBODD).HasColumnName("TR_DIRBODD");
            this.Property(t => t.TR_NOMBODH).HasColumnName("TR_NOMBODH");
            this.Property(t => t.TR_DIRBODH).HasColumnName("TR_DIRBODH");
            this.Property(t => t.TR_OBS).HasColumnName("TR_OBS");
            this.Property(t => t.TR_FECDES).HasColumnName("TR_FECDES");
            this.Property(t => t.ID_ZONA).HasColumnName("ID_ZONA");
            this.Property(t => t.TR_ESTADO).HasColumnName("TR_ESTADO");
            this.Property(t => t.TR_ESTCONF).HasColumnName("TR_ESTCONF");
            this.Property(t => t.TR_FOLRE).HasColumnName("TR_FOLRE");
            this.Property(t => t.TR_CIUDAD).HasColumnName("TR_CIUDAD");
            this.Property(t => t.TR_CAJA).HasColumnName("TR_CAJA");
            this.Property(t => t.TR_FUNDA).HasColumnName("TR_FUNDA");
            this.Property(t => t.TR_PACA).HasColumnName("TR_PACA");
            this.Property(t => t.ID_BODEGA).HasColumnName("ID_BODEGA");
            this.Property(t => t.TR_TIPOMOV).HasColumnName("TR_TIPOMOV");
            this.Property(t => t.ID_BODEGA_ORG).HasColumnName("ID_BODEGA_ORG");
            this.Property(t => t.ENVIO_POS).HasColumnName("ENVIO_POS");
            this.Property(t => t.NO_GUIA).HasColumnName("NO_GUIA");
            this.Property(t => t.vtc_numero_pedido_sap).HasColumnName("vtc_numero_pedido_sap");
            this.Property(t => t.tr_secuencial_operador).HasColumnName("tr_secuencial_operador");
        }
    }
}
