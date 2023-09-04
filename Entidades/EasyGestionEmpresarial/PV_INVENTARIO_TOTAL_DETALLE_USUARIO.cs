namespace Entidades.EasyGestionEmpresarial
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PV_INVENTARIO_TOTAL_DETALLE_USUARIO
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long cod_inventario { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(3)]
        public string sucursal { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(5)]
        public string oficina { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(5)]
        public string idbodega { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(15)]
        public string codigo { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(30)]
        public string usuario { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long digitado { get; set; }

        public long cantidad_grabada { get; set; }

        public DateTime fecha_ingreso { get; set; }

        public DateTime fecha_modificacion { get; set; }

        [StringLength(1)]
        public string contado { get; set; }

        public virtual PV_INVENTARIO_TOTAL_DETALLE PV_INVENTARIO_TOTAL_DETALLE { get; set; }
    }
}
