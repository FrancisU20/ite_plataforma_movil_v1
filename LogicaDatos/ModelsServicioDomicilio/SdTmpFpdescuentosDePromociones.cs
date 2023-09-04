﻿using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsServicioDomicilio
{
    public partial class SdTmpFpdescuentosDePromociones
    {
        public int? PrdIdPromociones { get; set; }
        public string PrdCodigoProducto { get; set; }
        public string PrdNombrePromocion { get; set; }
        public string PrdNombre { get; set; }
        public decimal? PrdCantidad { get; set; }
        public decimal? PrdPorcentaje { get; set; }
        public long PcaCodigo { get; set; }
    }
}
