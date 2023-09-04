using Configuracion;
using Configuracion.Models;
using Entidades.EasyGestionEmpresarial;
using Servicio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Transaccion.Interfaz
{
    public interface ITransaccionRecepcion
    {

        #region INVENTARIO MOVIL

        Result PA_TraspasosFarmacia(string id_bodega);

        Result DetalleTraspasos(string traspaso, string bodegaOrg);

        Result BuscarArticuloTraspaso(string id_bodega, string codigo);

        Result VerificarTraspasoKardexFarmacia(string id_bodega, string traspaso);

        Result GenerarKardex(Traspaso detalle);

        Result ImagenArticulo(string codigo);

        Result GuardarTemporal(Temporal temporal);

        Result RecuperarTemporal(string identificador);

        Result EliminarTemporal(string identificador);

        Result Cookie(Cookie cookie);

        Result Servidor(string ip);

        Result VerificarFactura(string serieFactura);

        Result Digitalizacion();

        #endregion

        #region VERIFICACION DE CAJAS

        Result GuardarPendientesVerificacion(List<TraspasoModel> traspasosModel);
        Result VerificacionCajas(string bodega);

        #endregion
        Result TipoDocumento(string serieFactura);
        Result EjecutarConsulta(string valorFiltro);
        bool ListaPendientesVerificacionVencidos();
        
        Result IPServidor();
    }
}
