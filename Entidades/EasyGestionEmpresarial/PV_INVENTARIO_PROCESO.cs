namespace Entidades.EasyGestionEmpresarial
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PV_INVENTARIO_PROCESO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long id_proceso { get; set; }

        public DateTime fecha_proceso { get; set; }

        [Required]
        [StringLength(50)]
        public string estado { get; set; }

        [Required]
        [StringLength(50)]
        public string usuario { get; set; }
    }
}
