namespace Entidades.EasyGestionEmpresarial
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PV_INVENTARIO_TOTAL_LOGIN
    {
        [Key]
        [StringLength(30)]
        public string usuario { get; set; }

        [StringLength(50)]
        public string ip { get; set; }

        [Required]
        [StringLength(1)]
        public string login { get; set; }

        [StringLength(50)]
        public string estado { get; set; }

        [StringLength(2)]
        public string envio_pos { get; set; }

        [StringLength(1)]
        public string es_coordinador { get; set; }
    }
}
