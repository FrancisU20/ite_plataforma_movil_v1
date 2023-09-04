using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.EasyGestionEmpresarial;
using System.Data.Entity.ModelConfiguration;

namespace Contexto.EasyGestionEmpresarial
{
    public class GEN_MovTraspasosDevoluciones_CabMap: EntityTypeConfiguration<GEN_MovTraspasosDevoluciones_Cab>
    {
        public GEN_MovTraspasosDevoluciones_CabMap()
        {
            this.HasKey(t => new { t.mtc_codigo_movimiento, t.mtc_oficina, t.mtc_sucursal, t.mtc_id_bodega, t.mtc_numero_tras_dev, t.mtc_tipo_movimiento, t.mtc_oficina_origen });
            this.ToTable("GEN_MovTraspasosDevoluciones_Cab");
            this.Property(t => t.mtc_codigo_movimiento).HasColumnName("mtc_codigo_movimiento");
            this.Property(t => t.mtc_estado).HasColumnName("mtc_estado");
            this.Property(t => t.mtc_fecha_movimiento).HasColumnName("mtc_fecha_movimiento");
            this.Property(t => t.mtc_id_bodega).HasColumnName("mtc_id_bodega");
            this.Property(t => t.mtc_numero_tras_dev).HasColumnName("mtc_numero_tras_dev");
            this.Property(t => t.mtc_oficina).HasColumnName("mtc_oficina");
            this.Property(t => t.mtc_oficina_origen).HasColumnName("mtc_oficina_origen");
            this.Property(t => t.mtc_sucursal).HasColumnName("mtc_sucursal");
            this.Property(t => t.mtc_tipo_movimiento).HasColumnName("mtc_tipo_movimiento");
            this.Property(t => t.mtc_usuario_modifica).HasColumnName("mtc_usuario_modifica");
        }
    }
}
