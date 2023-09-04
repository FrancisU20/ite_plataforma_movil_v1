using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsEasySeguridad
{
    public partial class AtribucionesProductos
    {
        public string Usuario { get; set; }
        public long IdEmpresa { get; set; }
        public long IdServicio { get; set; }
        public long IdProducto { get; set; }
        public bool Habilitado { get; set; }
        public string TipoProducto { get; set; }
    }
}
