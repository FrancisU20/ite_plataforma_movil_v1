namespace Entidades.EasyGestionEmpresarial
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PV_INVENTARIO_TRASPASOS
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long id_proceso { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long secuencia { get; set; }

        public long ID_DOC { get; set; }

        public DateTime FECHA { get; set; }

        public decimal valor { get; set; }

        [Required]
        public string observacion { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(10)]
        public string TIPO { get; set; }
    }
}
