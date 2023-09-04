﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Entidades.EasyGestionEmpresarial
{
    public partial class PA_TraspasosFarmaciaVerificacion
    {
        [Key]
        public int TR_FOL { get; set; }
        public string TR_TIPOMOV { get; set; }
        public Nullable<System.DateTime> TR_FECDES { get; set; }
        public string TR_ESTADO { get; set; }
        public int tr_caja { get; set; }
        public int tr_funda { get; set; }
        public int tr_paca { get; set; }
        public string TR_ESTCONF { get; set; }
        public string TR_USUA { get; set; }
        public string ID_BODEGA_ORG { get; set; }
        public string ENVIO_POS { get; set; }
        public string TRST_ESTADO { get; set; }
        public Nullable<System.DateTime> TRST_FECHA { get; set; }
        public Nullable<int> NumeroGuiaRemision { get; set; }
        public string observacion { get; set; }

    }
}
