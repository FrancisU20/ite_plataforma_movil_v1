namespace Entidades.EasyGestionEmpresarial
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PV_INVENTARIO_TOTAL_MARGEN
    {
        [Key]
        [StringLength(15)]
        public string tipo { get; set; }

        public int margen { get; set; }

        [StringLength(2)]
        public string envio_pos { get; set; }
    }
}
