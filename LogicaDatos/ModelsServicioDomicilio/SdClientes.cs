using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsServicioDomicilio
{
    public partial class SdClientes
    {
        public string CliCompania { get; set; }
        public string CliTipoIdCliente { get; set; }
        public string CliNumeroIdCliente { get; set; }
        public string CliNombreRazon { get; set; }
        public string CliNombreComercial { get; set; }
        public short? CliTipoCliente { get; set; }
        public short? CliEstatus { get; set; }
        public string CliFechaIngresoCliente { get; set; }
        public string CliCodigoVendedor { get; set; }
        public double? CliCupoCredito { get; set; }
        public double? CliSaldoActual { get; set; }
        public short? CliPlazoCredito { get; set; }
        public string CliComentario { get; set; }
        public string CliEsCliente { get; set; }
        public string CliEsProveedor { get; set; }
        public string CliTipoIdGrupo { get; set; }
        public string CliNumeroIdGrupo { get; set; }
        public string CliEsGrupo { get; set; }
        public string CliEmail { get; set; }
        public int CliIdCliente { get; set; }
        public string CliContribuyenteEspecial { get; set; }
        public string CliControlCupo { get; set; }
        public string CliEsempleado { get; set; }
        public string CliValidaCupoCorporativo { get; set; }
        public string CliEsMedico { get; set; }
        public string CliEspecialidad { get; set; }
        public string CliActividadCliente { get; set; }
        public string CliUsuarioCreacion { get; set; }
        public DateTime? CliFechaCreacion { get; set; }
        public string CliEnvioPos { get; set; }
        public string CliEstadoCartera { get; set; }
        public string CliLogicaConvenios { get; set; }
        public DateTime? CliFechaNacimiento { get; set; }
        public string CliSexo { get; set; }
        public int? CveIdEstadoValidacion { get; set; }
        public string CliIdLugarReferencia { get; set; }
        public string Ciudad { get; set; }
        public short? CodigoCategoria { get; set; }
        public string LicenciaCompraVentaConsep { get; set; }
        public DateTime? FechaVigenciaConsep { get; set; }
        public short? ExcentoIva { get; set; }
        public short? TieneBonificacion { get; set; }
        public string Convertibildad { get; set; }
        public int? DescuentoConvertibilidad { get; set; }
        public decimal? VentaMinimaPedido { get; set; }
        public short? ExcentoRestriccion { get; set; }
    }
}
