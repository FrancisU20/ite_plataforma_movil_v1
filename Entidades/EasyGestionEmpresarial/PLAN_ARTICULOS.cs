using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Entidades.EasyGestionEmpresarial
{
    public partial class PLAN_ARTICULOS
    {
        [Key, Column(Order = 0)]
        public long ID_PLAN { get; set; }
        [Key, Column(Order = 1)]
        public string COD_ARTICULO { get; set; }
        [Key, Column(Order = 2)]
        public string CLASE { get; set; }
        [Key, Column(Order = 3)]
        public string LINEA { get; set; }
        public string ESTADO { get; set; }
        public Nullable<long> CANTIDAD { get; set; }
        public Nullable<int> CONTEO { get; set; }
        public Nullable<long> DIFERENCIA { get; set; }
        public long ENTERO { get; set; }
        public long FRACCION { get; set; }
        public System.DateTime FECHA_RECONTEO { get; set; }
        public string USUARIO_RECONTEO { get; set; }
        public System.DateTime FECHA_FINALIZADO { get; set; }
        public string USUARIO_FINALIZADO { get; set; }
        public decimal VALORDIFERENCIA { get; set; }
        [Key, Column(Order = 4)]
        public string OFICINA { get; set; }
        [Key, Column(Order = 5)]
        public string SUCURSAL { get; set; }
        [Key, Column(Order = 6)]
        public string IDBODEGA { get; set; }
        public string PROCESO { get; set; }
        [Key, Column(Order = 7)]
        public string ORIGEN { get; set; }
        public Nullable<long> IDPLANORIGEN { get; set; }
        public virtual PLAN_INVENTARIO PLAN_INVENTARIO { get; set; }
    }
}
