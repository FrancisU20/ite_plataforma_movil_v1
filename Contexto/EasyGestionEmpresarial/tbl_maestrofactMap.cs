using Entidades.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Contexto.EasyGestionEmpresarial
{
    public class tbl_maestrofactMap : EntityTypeConfiguration<tbl_maestrofact>
    {
        public tbl_maestrofactMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Compania, t.Sucursal, t.Oficina, t.tipo_documento, t.numero_factura, t.Serie_Factura });

            // Properties
            this.Property(t => t.Compania)
                .IsRequired();

            this.Property(t => t.Sucursal)
                .IsRequired();

            this.Property(t => t.Oficina)
                .IsRequired();

            this.Property(t => t.tipo_documento)
                .IsRequired()
                .HasMaxLength(2);

            this.Property(t => t.numero_factura)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.tipo_idcliente)
                .HasMaxLength(1);

            this.Property(t => t.numero_idcliente)
                .HasMaxLength(20);

            this.Property(t => t.moneda)
                .HasMaxLength(3);

            this.Property(t => t.estatus)
                .HasMaxLength(1);

            this.Property(t => t.codigo_vendedor)
                .HasMaxLength(10);

            this.Property(t => t.codigo_entrega)
                .HasMaxLength(1);

            this.Property(t => t.impreso)
                .HasMaxLength(1);

            this.Property(t => t.tipo_docdevolucion)
                .HasMaxLength(2);

            this.Property(t => t.lista_precios)
                .HasMaxLength(20);

            this.Property(t => t.contabilizado)
                .HasMaxLength(1);

            this.Property(t => t.tipocomprobante)
                .HasMaxLength(1);

            this.Property(t => t.idbodega);

            this.Property(t => t.UserId)
                .HasMaxLength(10);

            this.Property(t => t.comentario)
                .HasMaxLength(255);

            this.Property(t => t.estatuspago)
                .HasMaxLength(1);

            this.Property(t => t.NombreTransporte)
                .HasMaxLength(60);

            this.Property(t => t.UnidadMedidaBultos)
                .HasMaxLength(10);

            this.Property(t => t.tipopedido)
                .HasMaxLength(2);

            this.Property(t => t.CentroCosto);

            this.Property(t => t.Serie_Factura)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(t => t.Numero_Aut_Factura)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Caducidad_Aut_Factura)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Observacion)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.generado_VTC)
                .HasMaxLength(1);

            this.Property(t => t.ENVIO_POS)
                .HasMaxLength(2);

            this.Property(t => t.direccion_matriz)
                .HasMaxLength(255);

            this.Property(t => t.telefono_matriz)
                .HasMaxLength(15);

            this.Property(t => t.contribuyente_especial)
                .HasMaxLength(20);

            this.Property(t => t.razon_social)
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("tbl_maestrofact");
            this.Property(t => t.Compania).HasColumnName("Compania");
            this.Property(t => t.Sucursal).HasColumnName("Sucursal");
            this.Property(t => t.Oficina).HasColumnName("Oficina");
            this.Property(t => t.tipo_documento).HasColumnName("tipo_documento");
            this.Property(t => t.numero_factura).HasColumnName("numero_factura");
            this.Property(t => t.tipo_idcliente).HasColumnName("tipo_idcliente");
            this.Property(t => t.numero_idcliente).HasColumnName("numero_idcliente");
            this.Property(t => t.fecha_factura).HasColumnName("fecha_factura");
            this.Property(t => t.subtotal).HasColumnName("subtotal");
            this.Property(t => t.iva).HasColumnName("iva");
            this.Property(t => t.descuento).HasColumnName("descuento");
            this.Property(t => t.totalfactura).HasColumnName("totalfactura");
            this.Property(t => t.moneda).HasColumnName("moneda");
            this.Property(t => t.formapago).HasColumnName("formapago");
            this.Property(t => t.estatus).HasColumnName("estatus");
            this.Property(t => t.direccion).HasColumnName("direccion");
            this.Property(t => t.saldofactura).HasColumnName("saldofactura");
            this.Property(t => t.codigo_vendedor).HasColumnName("codigo_vendedor");
            this.Property(t => t.comision_ventas).HasColumnName("comision_ventas");
            this.Property(t => t.codigo_entrega).HasColumnName("codigo_entrega");
            this.Property(t => t.retencion).HasColumnName("retencion");
            this.Property(t => t.tipo_cambio).HasColumnName("tipo_cambio");
            this.Property(t => t.impreso).HasColumnName("impreso");
            this.Property(t => t.numero_devolucion).HasColumnName("numero_devolucion");
            this.Property(t => t.tipo_devolucion).HasColumnName("tipo_devolucion");
            this.Property(t => t.motivo_devolucion).HasColumnName("motivo_devolucion");
            this.Property(t => t.subtotal_noiva).HasColumnName("subtotal_noiva");
            this.Property(t => t.plazo).HasColumnName("plazo");
            this.Property(t => t.numero_nota).HasColumnName("numero_nota");
            this.Property(t => t.tipo_docdevolucion).HasColumnName("tipo_docdevolucion");
            this.Property(t => t.lista_precios).HasColumnName("lista_precios");
            this.Property(t => t.subtotalventa).HasColumnName("subtotalventa");
            this.Property(t => t.contabilizado).HasColumnName("contabilizado");
            this.Property(t => t.fechacontabilizacion).HasColumnName("fechacontabilizacion");
            this.Property(t => t.tipocomprobante).HasColumnName("tipocomprobante");
            this.Property(t => t.numerocomprobante).HasColumnName("numerocomprobante");
            this.Property(t => t.idbodega).HasColumnName("idbodega");
            this.Property(t => t.numeropedido).HasColumnName("numeropedido");
            this.Property(t => t.EstacionId).HasColumnName("EstacionId");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.FechaRegistro).HasColumnName("FechaRegistro");
            this.Property(t => t.NumeroGuiaRemision).HasColumnName("NumeroGuiaRemision");
            this.Property(t => t.comentario).HasColumnName("comentario");
            this.Property(t => t.flete).HasColumnName("flete");
            this.Property(t => t.estatuspago).HasColumnName("estatuspago");
            this.Property(t => t.NombreTransporte).HasColumnName("NombreTransporte");
            this.Property(t => t.NumeroBultos).HasColumnName("NumeroBultos");
            this.Property(t => t.UnidadMedidaBultos).HasColumnName("UnidadMedidaBultos");
            this.Property(t => t.tipopedido).HasColumnName("tipopedido");
            this.Property(t => t.IdTaxGroup).HasColumnName("IdTaxGroup");
            this.Property(t => t.CentroCosto).HasColumnName("CentroCosto");
            this.Property(t => t.subtotalIce).HasColumnName("subtotalIce");
            this.Property(t => t.link).HasColumnName("link");
            this.Property(t => t.numeroOrdenInst).HasColumnName("numeroOrdenInst");
            this.Property(t => t.Serie_Factura).HasColumnName("Serie_Factura");
            this.Property(t => t.Numero_Aut_Factura).HasColumnName("Numero_Aut_Factura");
            this.Property(t => t.Caducidad_Aut_Factura).HasColumnName("Caducidad_Aut_Factura");
            this.Property(t => t.Descuento_Factura).HasColumnName("Descuento_Factura");
            this.Property(t => t.ValorIva).HasColumnName("ValorIva");
            this.Property(t => t.Observacion).HasColumnName("Observacion");
            this.Property(t => t.generado_VTC).HasColumnName("generado_VTC");
            this.Property(t => t.id_generado_VTC).HasColumnName("id_generado_VTC");
            this.Property(t => t.fechaHora_factura).HasColumnName("fechaHora_factura");
            this.Property(t => t.ENVIO_POS).HasColumnName("ENVIO_POS");
            this.Property(t => t.direccion_matriz).HasColumnName("direccion_matriz");
            this.Property(t => t.telefono_matriz).HasColumnName("telefono_matriz");
            this.Property(t => t.contribuyente_especial).HasColumnName("contribuyente_especial");
            this.Property(t => t.razon_social).HasColumnName("razon_social");
        }
    }
}
