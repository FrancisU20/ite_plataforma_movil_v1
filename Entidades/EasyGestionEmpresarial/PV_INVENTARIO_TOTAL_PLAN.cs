namespace Entidades.EasyGestionEmpresarial
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PV_INVENTARIO_TOTAL_PLAN
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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long id_plan { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(10)]
        public string origen { get; set; }
    }
}
