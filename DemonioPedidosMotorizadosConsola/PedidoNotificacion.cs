using LogicaDatos.ModelsServicioDomicilio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ViewModels;
using RestSharp;
using System.Text.Json;

namespace DemonioPedidosMotorizadosConsola
{
    public class PedidoNotificacion
    {
        private readonly ServicioDomicilioContext _ctxServicioDomicilio;
        private readonly IConfiguration _configuration;

        public PedidoNotificacion(ServicioDomicilioContext ctxServicioDomicilio, IConfiguration configuration)
        {
            _ctxServicioDomicilio = ctxServicioDomicilio;
            _configuration = configuration;

            ProcesarPendientes();
        }

        public void ProcesarPendientes()
        {
            try
            {
                var startDate = DateTime.Now.Date;
                var endDate = DateTime.Now.Date.AddDays(1).AddTicks(-1);

                var pedidosNotificados = _ctxServicioDomicilio.SdTrackingVerificacionPedidos.
                    Where(b => b.TkpFechaRegistro > startDate && b.TkpFechaRegistro < endDate).Select(x => x.PcaCodigo).Distinct().ToList();

                var idsSignal = _ctxServicioDomicilio.SdClientesOneSignal.Select(x => x.MotCodigo).Distinct().ToList();

                var pedidosPendientes = _ctxServicioDomicilio.SdMotorizadoPedidoCab.Where(x => !pedidosNotificados.Contains(x.PcaCodigo) && idsSignal.Contains(x.MotCodigo) && x.MpFecha > startDate && x.MpFecha < endDate).ToList();


                foreach (var item in pedidosPendientes)
                {

                    string UrlServicioCPM = _configuration.GetValue<string>("ServicioCentralPlatafomraMovilURL");
                    string usuarioCPM = _configuration.GetValue<string>("usuario");
                    string contraseniaCPM = _configuration.GetValue<string>("contrasenia");
                    string dieccionServicio = UrlServicioCPM + "/Login/AutentificarUsuario";
                    Login login = new Login
                    {
                        Usuario = usuarioCPM,
                        Contrasenia = contraseniaCPM
                    };

                    var clienteSesion = new RestClient(dieccionServicio);
                    var requestSession = new RestRequest("", Method.POST);
                    requestSession.AddJsonBody(login);
                    var restResponse = clienteSesion.Execute(requestSession).Content;

                    TokenResponse tokenResponse = JsonSerializer.Deserialize<TokenResponse>(restResponse);


                    // Lamado a notificar 
                    clienteSesion = new RestClient(UrlServicioCPM + "/GPSMotorizado/Posicion");
                    requestSession = new RestRequest("", Method.POST);
                    requestSession.AddParameter("Authorization", string.Format("Bearer " + tokenResponse.token), ParameterType.HttpHeader);

                    GPSMotorizadoViewModel gPSMotorizadoViewModel = new GPSMotorizadoViewModel
                    {
                        AccionRegistro = "NOTIFICAR",
                        MotCodigo = item.MotCodigo,
                        Pedidos = new List<PedidoViewModel> { new PedidoViewModel { PcaCodigo = item.PcaCodigo, SerieFactura = "" } }
                    };

                    requestSession.AddJsonBody(gPSMotorizadoViewModel);
                    restResponse = clienteSesion.Execute(requestSession).Content;

                }

            }
            catch (Exception ex)
            {
                //_logger.LogError(ex.Message);

            }


            // revisión de trigger


        }
        public class TokenResponse
        {
            public string token { get; set; }
        }
    }
}
