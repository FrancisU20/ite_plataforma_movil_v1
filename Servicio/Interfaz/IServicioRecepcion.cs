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
    public interface IServicioRecepcion
    {

        void Inicializar();

        void tbl_TemperaturaTraspaso_cab_Create(List<Tbl_TemperaturaTraspaso_cab> temperaturas);
        Result PA_TraspasosFarmacia(string id_bodega);

        Result DetalleTraspasos(string traspaso, string bodegaOrg);

        Result GenerarKardex(Traspaso result);

        Result BuscarArticuloTraspaso(string id_bodega, string codigo);

        Result VerificarTraspasoKardexFarmacia(string id_bodega, string traspaso);

        Result ImagenArticulo(string codigo);

        Result GuardarTemporal(Temporal temporal);

        Result RecuperarTemporal(string identificador);

        Result EliminarTemporal(string identificador);

        Result Cookie(Cookie cookie);

        Result Servidor(string ip);

        Result IPServidor();

        Result VerificarFactura(string serieFactura);

        Result Digitalizacion();

        Result VerificacionCajas(string bodega);

        string ValidartraspasoCF(int traspaso);

        //Result GuardarPendientesVerificacion(List<TraspasoModel> traspasosModel);
        List<VIRT_TRASPASOVERIFMERCADERIA> vIRT_TRASPASOVERIFMERCADERIAs(List<string> codigosTraspasosEntrantes);

        int Max_PV_TraspasoInformeMercaderia();

        List<VIRT_TRASPASOCAB> vIRT_TRASPASOCABs(List<int> codigosEnteros);

        List<VIRT_TRASPASOCABOFFLINE> vIRT_TRASPASOCABsOffline(List<int> codigosEnteros);

        void VIRT_TRASPASOCAB_Update(List<VIRT_TRASPASOCAB> cabs);

        void VIRT_TRASPASOVERIFMERCADERIA_Create(List<VIRT_TRASPASOVERIFMERCADERIA> vir_traspasos);

        void PV_TraspasoInformeMercaderia_Create(PV_TraspasoInformeMercaderia informeCabTemp);

        void PV_TraspasoVerifMercaderiaDet_Create(List<PV_TraspasoVerifMercaderia_Det> informeDet);

        void DetalleTransferenciaBC_Update(List<string> pedidosFacturados);

        void tbl_PendientesVerificacion_create(List<tbl_PendientesVerificacion> tbl_PendientesVerificacions);

        List<tbl_PendientesVerificacion> tbl_PendientesVerificacion_Obtener(List<int> codigosTraspaso);

        List<tbl_PendientesVerificacion> ListaPendientesVerificacionVencidos();

        PV_IpServidor PV_IpServidor();

        void tbl_PendientesVerificacion_Update(List<int> traspasos);

        Oficinas RecuperarCorreoOficina(string oficina);

        List<tbl_par_UsuarioNotificacionInconsistencia> tbl_Par_UsuarioNotificacionInconsistencias(string grupoAplicacion);

        void RegistroAppMovilGenerico(List<tbl_AuditoriaAppMovil> auditoria);

        Result EjecutarConsulta(string valorFiltro);
        Result TipoDocumento(string serieFactura);

        void VIRT_TRASPASOCAB_UpdateOffline(List<VIRT_TRASPASOCABOFFLINE> cabsOffline);
    }
}
