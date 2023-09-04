using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Entidades.EasyGestionEmpresarial
{
    [Table("VIRT_TRASPASOCAB")]
    public partial class VIRT_TRASPASOCAB
    {
        public VIRT_TRASPASOCAB()
        {
            this.VIRT_TRASPASODET = new List<VIRT_TRASPASODET>();
        }

        [Key, Column(Order = 0)]
        public int TR_FOL { get; set; }
        public string TR_USUD { get; set; }
        public string TR_USUA { get; set; }
        public Nullable<System.DateTime> TR_FECEM { get; set; }
        public string TR_NOMBODD { get; set; }
        public string TR_DIRBODD { get; set; }
        public string TR_NOMBODH { get; set; }
        public string TR_DIRBODH { get; set; }
        public string TR_OBS { get; set; }
        public Nullable<System.DateTime> TR_FECDES { get; set; }
        public Nullable<int> ID_ZONA { get; set; }
        public string TR_ESTADO { get; set; }
        public string TR_ESTCONF { get; set; }
        public Nullable<int> TR_FOLRE { get; set; }
        public string TR_CIUDAD { get; set; }
        public Nullable<int> TR_CAJA { get; set; }
        public Nullable<int> TR_FUNDA { get; set; }
        public Nullable<int> TR_PACA { get; set; }
        public string ID_BODEGA { get; set; }
        [Key, Column(Order = 1)]
        public string TR_TIPOMOV { get; set; }
        [Key, Column(Order = 2)]
        public string ID_BODEGA_ORG { get; set; }
        public string ENVIO_POS { get; set; }
        public string NO_GUIA { get; set; }
        public Nullable<long> tr_secuencial_operador { get; set; }
        public virtual ICollection<VIRT_TRASPASODET> VIRT_TRASPASODET { get; set; }
    }
}
