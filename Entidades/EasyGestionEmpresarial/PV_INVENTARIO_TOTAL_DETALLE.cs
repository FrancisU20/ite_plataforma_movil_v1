namespace Entidades.EasyGestionEmpresarial
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PV_INVENTARIO_TOTAL_DETALLE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PV_INVENTARIO_TOTAL_DETALLE()
        {
            PV_INVENTARIO_TOTAL_DETALLE_USUARIO = new HashSet<PV_INVENTARIO_TOTAL_DETALLE_USUARIO>();
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

        [Key]
        [Column(Order = 4)]
        [StringLength(15)]
        public string codigo { get; set; }

        public long existencias { get; set; }

        public long ventas { get; set; }

        public long devoluciones { get; set; }

        public long digitado { get; set; }

        public long diferencia { get; set; }

        [Required]
        [StringLength(30)]
        public string estado { get; set; }

        [Required]
        [StringLength(30)]
        public string proceso { get; set; }

        public decimal valor_diferencia { get; set; }

        [StringLength(1)]
        public string psicotropico { get; set; }

        public virtual PV_INVENTARIO_TOTAL PV_INVENTARIO_TOTAL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PV_INVENTARIO_TOTAL_DETALLE_USUARIO> PV_INVENTARIO_TOTAL_DETALLE_USUARIO { get; set; }
    }
}
