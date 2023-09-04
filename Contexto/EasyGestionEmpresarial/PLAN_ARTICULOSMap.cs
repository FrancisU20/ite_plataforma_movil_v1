using Entidades.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Contexto.EasyGestionEmpresarial
{
    public class PLAN_ARTICULOSMap : EntityTypeConfiguration<PLAN_ARTICULOS>
    {
        public PLAN_ARTICULOSMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ID_PLAN, t.COD_ARTICULO, t.CLASE, t.LINEA, t.OFICINA, t.SUCURSAL, t.IDBODEGA, t.ORIGEN });

            // Properties
            this.Property(t => t.ID_PLAN)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.COD_ARTICULO)
                .IsRequired()
                .HasMaxLength(15);

            this.Property(t => t.CLASE)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.LINEA)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.ESTADO)
                .HasMaxLength(15);

            this.Property(t => t.USUARIO_RECONTEO)
                .IsRequired()
                .HasMaxLength(15);

            this.Property(t => t.USUARIO_FINALIZADO)
                .IsRequired()
                .HasMaxLength(15);

            this.Property(t => t.OFICINA)
                .IsRequired();

            this.Property(t => t.SUCURSAL)
                .IsRequired();

            this.Property(t => t.IDBODEGA)
                .IsRequired();

            this.Property(t => t.PROCESO)
                .HasMaxLength(20);

            this.Property(t => t.ORIGEN)
                .IsRequired()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("PLAN_ARTICULOS");
            this.Property(t => t.ID_PLAN).HasColumnName("ID_PLAN");
            this.Property(t => t.COD_ARTICULO).HasColumnName("COD_ARTICULO");
            this.Property(t => t.CLASE).HasColumnName("CLASE");
            this.Property(t => t.LINEA).HasColumnName("LINEA");
            this.Property(t => t.ESTADO).HasColumnName("ESTADO");
            this.Property(t => t.CANTIDAD).HasColumnName("CANTIDAD");
            this.Property(t => t.CONTEO).HasColumnName("CONTEO");
            this.Property(t => t.DIFERENCIA).HasColumnName("DIFERENCIA");
            this.Property(t => t.ENTERO).HasColumnName("ENTERO");
            this.Property(t => t.FRACCION).HasColumnName("FRACCION");
            this.Property(t => t.FECHA_RECONTEO).HasColumnName("FECHA_RECONTEO");
            this.Property(t => t.USUARIO_RECONTEO).HasColumnName("USUARIO_RECONTEO");
            this.Property(t => t.FECHA_FINALIZADO).HasColumnName("FECHA_FINALIZADO");
            this.Property(t => t.USUARIO_FINALIZADO).HasColumnName("USUARIO_FINALIZADO");
            this.Property(t => t.VALORDIFERENCIA).HasColumnName("VALORDIFERENCIA");
            this.Property(t => t.OFICINA).HasColumnName("OFICINA");
            this.Property(t => t.SUCURSAL).HasColumnName("SUCURSAL");
            this.Property(t => t.IDBODEGA).HasColumnName("IDBODEGA");
            this.Property(t => t.PROCESO).HasColumnName("PROCESO");
            this.Property(t => t.ORIGEN).HasColumnName("ORIGEN");
            this.Property(t => t.IDPLANORIGEN).HasColumnName("IDPLANORIGEN");

            // Relationships
            this.HasRequired(t => t.PLAN_INVENTARIO)
                .WithMany(t => t.PLAN_ARTICULOS)
                .HasForeignKey(d => new { d.ID_PLAN, d.OFICINA, d.SUCURSAL, d.IDBODEGA, d.ORIGEN });

        }
    }
}
