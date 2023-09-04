using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.EasyGestionEmpresarial
{
    public partial class PLAN_DESCUENTODET
    {
        public long ID_PLAN { get; set; }
        public int ID_ITEM { get; set; }
        public string SUCURSAL { get; set; }
        public string OFICINA { get; set; }
        public string CEDULA { get; set; }
        public string NOMBRES { get; set; }
        public string APELLIDOS { get; set; }
        public decimal DSC { get; set; }
        public string ESTADO { get; set; }
        public decimal VALDSC { get; set; }
        public string TIPO { get; set; }
        public string IDBODEGA { get; set; }
        public string pld_estado_aprobacion { get; set; }
        public virtual PLAN_DESCUENTOCAB PLAN_DESCUENTOCAB { get; set; }
    }
}
