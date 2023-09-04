namespace Entidades.EasyGestionEmpresarial
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PV_INVENTARIO_TOTAL_ARCHIVOS
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long cod_inventario { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(3)]
        public string pia_sucursal { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(5)]
        public string pia_oficina { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(5)]
        public string pia_idbodega { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int pia_secuencia { get; set; }

        [Required]
        public string pia_nombre_archivo { get; set; }

        [Required]
        [StringLength(50)]
        public string pia_extencion { get; set; }

        [Required]
        public string pia_ubicacion { get; set; }
    }
}
