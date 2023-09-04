namespace Entidades.EasyGestionEmpresarial
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PV_INVENTARIO_TOTAL_CAB_REP
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

        [Required]
        [StringLength(20)]
        public string sr { get; set; }

        [Required]
        [StringLength(200)]
        public string nombres { get; set; }

        [Required]
        [StringLength(500)]
        public string tiposr { get; set; }

        [Required]
        public string Entrada1 { get; set; }

        [StringLength(50)]
        public string fecha { get; set; }

        [StringLength(1)]
        public string informe_matriz { get; set; }

        [StringLength(20)]
        public string coordinador { get; set; }

        [StringLength(100)]
        public string cod_informe { get; set; }

        public string observacion1 { get; set; }

        public string observacion2 { get; set; }

        public decimal? itc_calificacion { get; set; }
    }
}
