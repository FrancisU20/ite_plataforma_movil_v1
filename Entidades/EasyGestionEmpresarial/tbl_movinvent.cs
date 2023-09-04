using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Entidades.EasyGestionEmpresarial
{
    public class tbl_movinvent
    {
        [Key, Column(Order = 0)]
        public string Compania { get; set; }
        [Key, Column(Order = 1)]
        public string Sucursal { get; set; }
        [Key, Column(Order = 2)]
        public string Oficina { get; set; }
        [Key, Column(Order = 3)]
        public string tipo_mov { get; set; }
        [Key, Column(Order = 4)]
        public int num_mov { get; set; }
        [Key, Column(Order = 5)]
        public string codigo_producto { get; set; }
        public System.Single cantidad { get; set; }
        public double precio { get; set; }
        public string idbodega { get; set; }
        [Key, Column(Order = 6)]
        public string serie_factura { get; set; }
        [Key, Column(Order = 7)]
        public string tipo_causa { get; set; }
        //public virtual tbl_maestromovinvent tbl_maestromovinvent { get; set; }
    }
}
