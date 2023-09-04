namespace Entidades.EasyGestionEmpresarial
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PV_INVENTARIO_TOTAL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PV_INVENTARIO_TOTAL()
        {
            PV_INVENTARIO_TOTAL_DETALLE = new HashSet<PV_INVENTARIO_TOTAL_DETALLE>();
        }

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

        public DateTime fecha { get; set; }

        [Required]
        [StringLength(20)]
        public string usuario { get; set; }

        [Required]
        [StringLength(30)]
        public string estado { get; set; }

        [Required]
        public string descripcion { get; set; }

        public DateTime fecha_inicio { get; set; }

        public DateTime fecha_fin { get; set; }

        [Required]
        public string tipo { get; set; }

        [Required]
        [StringLength(30)]
        public string proceso { get; set; }

        [Required]
        [StringLength(1)]
        public string Total { get; set; }

        public int conteo { get; set; }

        public long? id_plan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PV_INVENTARIO_TOTAL_DETALLE> PV_INVENTARIO_TOTAL_DETALLE { get; set; }
    }
}
