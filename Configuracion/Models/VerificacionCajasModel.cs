using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Configuracion.Models
{
    public class TraspasoModel
    {
        /// <summary>
        /// Número de traspaso
        /// </summary>
        public string NumeroTraspaso { get; set; }
        /// <summary>
        /// Indicador de almacenamiento
        /// </summary>
        public string Check { get; set; }
        /// <summary>
        /// Ip del dispositivo de registro
        /// </summary>
        public string Ip { get; set; }
        /// <summary>
        /// Estado del traspaso
        /// </summary>
        public string Estado { get; set; }
        /// <summary>
        /// Descripción del estado del traspaso
        /// </summary>
        public string DescripcionEstado { get; set; }
        /// <summary>
        /// Usuario de la farmacia
        /// </summary>
        public string UsuarioFarmacia { get; set; }
        /// <summary>
        /// Númeor de bodega 
        /// </summary>
        public string Bodega { get; set; }
        /// <summary>
        /// Fecha de generación del traspaso
        /// </summary>
        public string FechaTraspaso { get; set; }
        public string FechaPendiente { get; set; }
        /// <summary>
        /// Cantidad de cajas en el traspaso
        /// </summary>
        public int Caja { get; set; }
        /// <summary>
        /// Número de fundas en el traspaso
        /// </summary>
        public int Funda { get; set; }
        /// <summary>
        /// Número de pacas en el traspaso
        /// </summary>
        public int Paca { get; set; }
        /// <summary>
        /// Lista de códigos Pendientes
        /// </summary>
        public List<string> CajasP { get; set; }
        public List<string> FundasP { get; set; }
        public List<string> PacasP { get; set; }
        /// <summary>
        /// Lista de códigos verificados
        /// </summary>
        public List<string> CajasV { get; set; }
        public List<string> FundasV { get; set; }
        public List<string> PacasV { get; set; }
        public List<TemperaturaModel> Temperaturas { get; set; }
        public string PedidoFacturado { get; set; }

    }
}
