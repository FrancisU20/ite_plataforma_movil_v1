using Entidades.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Contexto.EasyGestionEmpresarial
{
    public class VIRT_TRASPASODETOFFLINEMap : EntityTypeConfiguration<VIRT_TRASPASODETOFFLINE>
    {
        public VIRT_TRASPASODETOFFLINEMap()
        {
            // Primary Key
            this.HasKey(t => new { t.TRD_CODL, t.TR_FOL, t.TR_TIPOMOV, t.ID_BODEGA_ORG });

            // Properties
            this.Property(t => t.TRD_CODL)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.TR_FOL)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.PR_COD)
                .HasMaxLength(30);

            this.Property(t => t.PR_CODB)
                .HasMaxLength(50);

            this.Property(t => t.TRD_UME)
                .HasMaxLength(5);

            this.Property(t => t.TRD_EST)
                .HasMaxLength(2);

            this.Property(t => t.TRD_MOV)
                .HasMaxLength(2);

            this.Property(t => t.TR_TIPOMOV)
                .IsRequired()
                .HasMaxLength(5);

            this.Property(t => t.ID_BODEGA_ORG)
                .IsRequired()
                .HasMaxLength(3);

            this.Property(t => t.TRD_LOTE)
                .HasMaxLength(20);

            this.Property(t => t.TRD_FECHA_CAD)
                .HasMaxLength(12);

            this.Property(t => t.TRD_REG_SANITARIO)
                .HasMaxLength(50);

            this.Property(t => t.TRD_FECHA_ELAB)
                .HasMaxLength(12);
            this.Property(t => t.od_Cantidad_Facturado);

            // Table & Column Mappings
            this.ToTable("VIRT_TRASPASODETOFFLINE");
            this.Property(t => t.TRD_CODL).HasColumnName("TRD_CODL");
            this.Property(t => t.TRD_COD).HasColumnName("TRD_COD");
            this.Property(t => t.TR_FOL).HasColumnName("TR_FOL");
            this.Property(t => t.PR_COD).HasColumnName("PR_COD");
            this.Property(t => t.PR_CODB).HasColumnName("PR_CODB");
            this.Property(t => t.UB_ID).HasColumnName("UB_ID");
            this.Property(t => t.TRD_CAND).HasColumnName("TRD_CAND");
            this.Property(t => t.TRD_UME).HasColumnName("TRD_UME");
            this.Property(t => t.TRD_EST).HasColumnName("TRD_EST");
            this.Property(t => t.TRD_CANF).HasColumnName("TRD_CANF");
            this.Property(t => t.TRD_MOV).HasColumnName("TRD_MOV");
            this.Property(t => t.TR_TIPOMOV).HasColumnName("TR_TIPOMOV");
            this.Property(t => t.PVP).HasColumnName("PVP");
            this.Property(t => t.PVF).HasColumnName("PVF");
            this.Property(t => t.IVA).HasColumnName("IVA");
            this.Property(t => t.ID_BODEGA_ORG).HasColumnName("ID_BODEGA_ORG");
            this.Property(t => t.TRD_CANDF).HasColumnName("TRD_CANDF");
            this.Property(t => t.TRD_CANFF).HasColumnName("TRD_CANFF");
            this.Property(t => t.TRD_LOTE).HasColumnName("TRD_LOTE");
            this.Property(t => t.TRD_FECHA_CAD).HasColumnName("TRD_FECHA_CAD");
            this.Property(t => t.TRD_REG_SANITARIO).HasColumnName("TRD_REG_SANITARIO");
            this.Property(t => t.TRD_FECHA_ELAB).HasColumnName("TRD_FECHA_ELAB");
            this.Property(t => t.od_Cantidad_Facturado).HasColumnName("od_Cantidad_Facturado");
            
        }
    }
}
