using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Configuracion.Librerias
{
    public class Log
    {
        /// <summary>
        /// Código de refencia de respuestas del servicio.
        /// </summary>
        public string codigo { get; set; }
        /// <summary>
        /// Descripción del código de refencia. [MENSAJE PERSONALIZADO]
        /// </summary>
        public string descripcion { get; set; }
        /// <summary>
        /// "La operación ha terminado correctamente."
        /// </summary>
        public void _001()
        {
            this.codigo = "001";
            this.descripcion = "La operación ha terminado correctamente.";
        }
        /// <summary>
        /// "La operación ha terminado correctamente. [" + mensaje + "]"
        /// </summary>
        /// <param name="mensaje">Mensaje</param>
        public void _001(String mensaje)
        {
            this.codigo = "001";
            this.descripcion = "La operación ha terminado correctamente. [" + mensaje + "]";
        }
        /// <summary>
        /// "La operación ha fallado."
        /// </summary>
        public void _002()
        {
            this.codigo = "002";
            this.descripcion = "La operación ha fallado.";
        }
        /// <summary>
        /// "La operación ha fallado. [" + mensaje + "]"
        /// </summary>
        /// <param name="mensaje">Mensaje de error</param>
        public void _002(String mensaje)
        {
            this.codigo = "002";
            this.descripcion = "La operación ha fallado. [" + mensaje + "]";
        }
        /// <summary>
        /// "Error interno."
        /// </summary>
        public void _999()
        {
            this.codigo = "999";
            this.descripcion = "Error interno.";
        }
        /// <summary>
        /// "Error interno. [" + mensaje + "]"
        /// </summary>
        /// <param name="mensaje">Mensaje de error</param>
        public void _999(String mensaje)
        {
            this.codigo = "999";
            this.descripcion = "Error interno. [" + mensaje + "]";
        }
    }
}
