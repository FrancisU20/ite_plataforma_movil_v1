using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsEasySeguridad
{
    public partial class SegEmpresa
    {
        public short EmpId { get; set; }
        public string EmpRuc { get; set; }
        public string EmpNombre { get; set; }
        public string EmpDireccion { get; set; }
        public string EmpDireccionWeb { get; set; }
        public string EmpDireccionAccesoUsuario { get; set; }
        public string EmpCodigoPostal { get; set; }
        public string EmpTelefono { get; set; }
        public string EmpEmail { get; set; }
        public string EmpProvincia { get; set; }
        public string EmpPais { get; set; }
        public string EmpLogo { get; set; }
        public string EmpEstado { get; set; }
        public string EmpUsuarioActualizacion { get; set; }
        public DateTime EmpFechaCreacion { get; set; }
        public DateTime EmpFechaActualizacion { get; set; }
    }
}
