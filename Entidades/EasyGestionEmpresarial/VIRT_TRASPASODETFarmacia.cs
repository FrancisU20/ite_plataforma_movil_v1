using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Entidades.EasyGestionEmpresarial
{
    [Table("VIRT_TRASPASODET")]
    public partial class VIRT_TRASPASODETFarmacia
    {
        [Key, Column(Order = 0)]
        public int TRD_CODL { get; set; }
        public int TRD_COD { get; set; }
        [Key, Column(Order = 1)]
        public int TR_FOL { get; set; }
        public string PR_COD { get; set; }
        public string PR_CODB { get; set; }
        public Nullable<int> UB_ID { get; set; }
        public Nullable<int> TRD_CAND { get; set; }
        public string TRD_UME { get; set; }
        public string TRD_EST { get; set; }
        public Nullable<int> TRD_CANF { get; set; }
        public string TRD_MOV { get; set; }
        [Key, Column(Order = 2)]
        public string TR_TIPOMOV { get; set; }
        public decimal PVP { get; set; }
        public decimal PVF { get; set; }
        public bool IVA { get; set; }
        [Key, Column(Order = 3)]
        public string ID_BODEGA_ORG { get; set; }
        public Nullable<int> TRD_CANDF { get; set; }
        public Nullable<int> TRD_CANFF { get; set; }
        public string TRD_LOTE { get; set; }
        public string TRD_FECHA_CAD { get; set; }
        public string TRD_REG_SANITARIO { get; set; }
        public string TRD_FECHA_ELAB { get; set; }

        public virtual VIRT_TRASPASOCABFarmacia VIRT_TRASPASOCABFarmacia { get; set; }
    }
}
