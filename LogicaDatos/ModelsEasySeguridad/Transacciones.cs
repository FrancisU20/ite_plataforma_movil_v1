using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsEasySeguridad
{
    public partial class Transacciones
    {
        public Transacciones()
        {
            AtribucionesFavoritos = new HashSet<AtribucionesFavoritos>();
        }

        public string Aplicacion { get; set; }
        public string Modulo { get; set; }
        public string Transaccion { get; set; }
        public string Descripcion { get; set; }
        public string Link { get; set; }
        public string Panel { get; set; }
        public string TipoMenu { get; set; }
        public string InfoXml { get; set; }
        public string InfoXmlDependeBco { get; set; }
        public bool Restringido { get; set; }
        public string CodigoNivelTres { get; set; }
        public string DescNivelTres { get; set; }
        public float IndiceTransaccion { get; set; }
        public string EnvioPos { get; set; }
        public int IdTransaccion { get; set; }

        public virtual Modulos Modulos { get; set; }
        public virtual ICollection<AtribucionesFavoritos> AtribucionesFavoritos { get; set; }
    }
}
