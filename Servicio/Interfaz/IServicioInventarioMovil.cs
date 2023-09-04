using Configuracion;
using Configuracion.Models;
using Entidades.EasyGestionEmpresarial;
using Servicio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Servicio.Interfaz
{
    public interface IServicioInventarioMovil
    {

        void Inicializar();

        bool TestConexionSAP();

        #region INVENTARIO MOVIL

        Response Ips(Request request);

        Result AutentificarUsuario(string usuario, string contrasena, string ipWS, string ipMovil, string ipMovil2);

        Result AutentificarUsuarioFarmascan(string usuario, string contrasena, string ipWS, string ipMovil, string ipMovil2);

        Result ListadoPlanificaciones();

        Result ListadoArticulosPlanificacion(string id_plan, string origen);

        Result RestringirArticulosContar(string id_plan, string origen, string usuario, string ip);

        Result ActualizarPlanificacionaContar(string id_plan, string origen);

        Result SubirConteoInventario(cls_Cabecera conteoInventario);


        #endregion

        #region IMPRESION DE ETIQUETAS
        tbl_articulos ConsultarArticulos(string codbarras);
        Oficinas ValidarAutoservicio(string codOficina);
        Result GuardarEtiquetasPrecios(List<tbl_ImpresionEtiquetas> etiquetas);
        #endregion

    }
}
