using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViewModels
{
    public class UsuarioViewModel
    {
        public string nombre { get; set; }
        public string nombreCorto { get; set; }
        public string cedula { get; set; }
        public string farmacia { get; set; }
        public string idbodega { get; set; }
        public string sucursal { get; set; }
        public string compania { get; set; }
        public string centro_costo { get; set; }
        public string tipoUsuario { get; set; }
        public int CodigoMotorizado { get; set; }
        public string Token { get; set; }
        public ITscanToken itscanToken { get; set; }
        public List<AtribucionesModel> atribuciones { get; set; }
    }
}
