using Configuracion;
using Configuracion.Models;
using Entidades.EasyGestionEmpresarial;
using Servicio.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PlataformaMovilWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService1
    {
        #region 

        [OperationContract]
        [WebGet(UriTemplate = "/Test",
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare)]
        System.IO.Stream Test();

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        Response Ips(Request request);
        // TODO: agregue aquí sus operaciones de servicio

        [OperationContract]
        [WebGet(UriTemplate = "/AutentificarUsuarioVisor?usuario={usuario}&contrasenia={contrasena}&ipMovil={ipMovil}&ipMovil2={ipMovil2}",
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare)]
        System.IO.Stream AutentificarUsuarioVisor(string usuario, string contrasena, string ipMovil, string ipMovil2);

        [OperationContract]
        [WebGet(UriTemplate = "/AutentificarUsuario?usuario={usuario}&contrasenia={contrasena}&ipMovil={ipMovil}&ipMovil2={ipMovil2}",
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare)]
        System.IO.Stream AutentificarUsuario(string usuario, string contrasena, string ipMovil, string ipMovil2);

        [OperationContract]
        [WebGet(UriTemplate = "/AutentificarUsuariofarmascan?usuario={usuario}&contrasenia={contrasena}&ipMovil={ipMovil}&ipMovil2={ipMovil2}",
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare)]
        System.IO.Stream AutentificarUsuarioFarmascan(string usuario, string contrasena, string ipMovil, string ipMovil2);

        [OperationContract]
        [WebGet(UriTemplate = "/ListadoPlanificaciones",
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare)]
        System.IO.Stream ListadoPlanificaciones();

        [OperationContract]
        [WebGet(UriTemplate = "/ListadoArticulosPlanificacion?id_plan={id_plan}&origen={origen}",
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare)]
        System.IO.Stream ListadoArticulosPlanificacion(string id_plan, string origen);

        [OperationContract]
        [WebGet(UriTemplate = "/RestringirArticulosContar?id_plan={id_plan}&origen={origen}&usuario={usuario}&ip={ip}",
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare)]
        System.IO.Stream RestringirArticulosContar(string id_plan, string origen, string usuario, string ip);

        [OperationContract]
        [WebGet(UriTemplate = "/ActualizarPlanificacionaContar?id_plan={id_plan}&origen={origen}",
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare)]
        System.IO.Stream ActualizarPlanificacionaContar(string id_plan, string origen);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/SubirConteoInventario",
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare)]
        System.IO.Stream SubirConteoInventario(cls_Cabecera conteoInventario);

        #endregion

        #region RECEPCION

        [OperationContract]
        [WebGet(UriTemplate = "/TraspasosFarmacia?id_bodega={id_bodega}",
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare)]
        System.IO.Stream TraspasosFarmacia(string id_bodega);

        [OperationContract]
        [WebGet(UriTemplate = "/DetalleTraspaso?traspaso={traspaso}&bodegaOrg={bodegaOrg}",
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare)]
        System.IO.Stream DetalleTraspasos(string traspaso, string bodegaOrg);

        [OperationContract]
        [WebGet(UriTemplate = "/BusquedaArticulo?id_bodega={id_bodega}&codigo={codigo}",
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare)]
        System.IO.Stream BuscarArticuloTraspaso(string id_bodega, string codigo);

        [OperationContract]
        [WebGet(UriTemplate = "/VerificarTraspasoKardex?id_bodega={id_bodega}&traspaso={traspaso}",
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare)]
        System.IO.Stream VerificarTraspasoKardexFarmacia(string id_bodega, string traspaso);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/GenerarKardex",
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare)]
        System.IO.Stream GenerarKardex(Traspaso traspaso);

        [OperationContract]
        [WebGet(UriTemplate = "/ImagenArticulo?codigo={codigo}",
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare)]
        System.IO.Stream ImagenArticulo(string codigo);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/GuardarTemporal",
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare)]
        System.IO.Stream GuardarTemporal(Temporal temporal);

        [OperationContract]
        [WebGet(UriTemplate = "/RecuperarTemporal?identificador={identificador}",
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare)]
        System.IO.Stream RecuperarTemporal(string identificador);

        [OperationContract]
        [WebGet(UriTemplate = "/EliminarTemporal?identificador={identificador}",
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare)]
        System.IO.Stream EliminarTemporal(string identificador);

        #endregion


        [OperationContract]
        [WebGet(UriTemplate = "/TestConexionSAP",
        RequestFormat = WebMessageFormat.Xml,
        BodyStyle = WebMessageBodyStyle.Bare)]
        bool TestConexionSAP();

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/Cookie",
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare)]
        System.IO.Stream Cookie(Cookie cookie);

        [OperationContract]
        [WebGet(UriTemplate = "/Servidor?ip={ip}",
        RequestFormat = WebMessageFormat.Xml,
        BodyStyle = WebMessageBodyStyle.Bare)]
        System.IO.Stream Servidor(string ip);

        [OperationContract]
        [WebGet(UriTemplate = "/IPServidor",
        RequestFormat = WebMessageFormat.Xml,
        BodyStyle = WebMessageBodyStyle.Bare)]
        System.IO.Stream IPServidor();

        [OperationContract]
        [WebGet(UriTemplate = "/TipoDocumento?serie={serie}",
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare)]
        System.IO.Stream TipoDocumento(string serie);


        [OperationContract]
        [WebGet(UriTemplate = "/Verificarfactura?serie={serie}",
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare)]
        System.IO.Stream VerificarFactura(string serie);

        [OperationContract]
        [WebGet(UriTemplate = "/Digitalizacion",
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare)]
        System.IO.Stream Digitalizacion();

        [OperationContract]
        [WebGet(UriTemplate = "/VerificacionCajas?bodega={bodega}",
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare)]
        System.IO.Stream VerificacionCajas(string bodega);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/GuardarPendientesVerificacion",
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare)]
        System.IO.Stream GuardarPendientesVerificacion(List<TraspasoModel> traspasosModel);

        [OperationContract]
        [WebGet(UriTemplate = "/VerificacionPendientesVencidos",
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare)]
        bool ListaPendientesVerificacionVencidos();

        #region IMPRESION ETIQUETAS
        [OperationContract]
        [WebGet(UriTemplate = "/ConsultaArticulo?codbarra={codbarras}",
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare)]
        System.IO.Stream ConsultarArticulos(string codbarras);

        [OperationContract]
        [WebGet(UriTemplate = "/ValidarAutoservicio?oficina={codOficina}",
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare)]
        System.IO.Stream ValidarAutoservicio(string codOficina);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/GuardarImpresionEtiqueta",
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare)]
        System.IO.Stream GuardarEtiquetasPrecios(List<EtiquetasModel> etiquetasModel);
        //System.IO.Stream GuardarEtiquetasPrecios(string codigo_articulo, string codigo_barras,
        //int cantidad, string descripcion, string usuario_registro);

        #endregion


        #region INVENTARIO TOTAL

        [OperationContract]
        [WebGet(UriTemplate = "/RecuperarFarmacia?ip={ip}",
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare)]
        System.IO.Stream RecuperarFarmacia(string ip);

        [OperationContract]
        [WebGet(UriTemplate = "/CargarSiguiente?usuario={usuario}&conteo={conteo}&inventario={inventario}",
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare)]
        System.IO.Stream CargarSiguiente(string usuario, int conteo, int inventario);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/IngresoInventarioTotal",
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare)]
        System.IO.Stream Ingreso(IngresoInventarioTotal ingresoInventarioTotal);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/InventarioTotal",
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare)]
        System.IO.Stream Inventario(IngresoInventarioTotal ingresoInventarioTotal);

        [OperationContract]
        [WebGet(UriTemplate = "/ArticulosCargarInicial",
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare)]
        System.IO.Stream CargaInicialArticulos();

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/BuscarArticuloInventario",
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare)]
        System.IO.Stream BuscarArticuloInventario(BuscarArticuloInventarioTotalModel b);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/RegistroCantidadesInventarioTotal",
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare)]
        System.IO.Stream RegistroCantidades(RegistroCantidadesInventarioTotal reg);

        [OperationContract]
        [WebGet(UriTemplate = "/CerrarSesion?usuario={usuario}&ip={ip}",
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare)]
        System.IO.Stream CerrarSesion(string usuario, string ip);

        #endregion 

    }

}
