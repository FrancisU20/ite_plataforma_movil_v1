using Entidades.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Contexto.EasyGestionEmpresarial
{
    public class tbl_ImpresionEtiquetasMap: EntityTypeConfiguration<tbl_ImpresionEtiquetas>
    {
        public tbl_ImpresionEtiquetasMap()
        {
            //Primary key
            this.HasKey(t => t.id_impresion_etiqueta);


            //Tablas y columnas Mapping
            this.ToTable("pmov.tbl_ImpresionEtiquetas");

            this.Property(t => t.id_impresion_etiqueta)
                .IsRequired()
                .HasColumnName("ie_id_impresion_etiqueta");

            this.Property(t => t.codigo_articulo)
                .IsRequired()
                .HasMaxLength(15)
                .HasColumnName("ie_codigo_articulo");

            this.Property(t => t.codigo_barras)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("ie_codigo_barras");

            this.Property(t => t.descripcion)
                .IsRequired()
                .HasColumnName("ie_descripcion");

            this.Property(t => t.cantidad)
                .IsRequired()
                .HasColumnName("ie_cantidad");

            this.Property(t => t.estado)
                .IsRequired()
                .HasColumnName("ie_estado");

            this.Property(t => t.fecha_registro)
                .IsRequired()
                .HasColumnName("ie_fecha_registro");

            this.Property(t => t.usuario_registro)
                .IsRequired()
                .HasMaxLength(15)
                .HasColumnName("ie_usuario_registro");
        }
    }
}
