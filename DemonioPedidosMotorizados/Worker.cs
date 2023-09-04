using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using LogicaDatos.ModelsServicioDomicilio;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RestSharp;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base;
using ViewModels;

namespace DemonioPedidosMotorizados
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConfiguration _configuration;
        TableDependency.SqlClient.SqlTableDependency<LogicaDatos.ModelsServicioDomicilio.SdMotorizadoPedidoCab> dep;
        private readonly ServicioDomicilioContext _ctxServicioDomicilio;

        // tiempo de revisión de trigger en base de datos
        private static System.Timers.Timer tgTimer;

        public Worker(ILogger<Worker> logger, IConfiguration configuration, ServicioDomicilioContext ctxServicioDomicilio)
        {
            _logger = logger;
            _configuration = configuration;
            _ctxServicioDomicilio = ctxServicioDomicilio;
        }

        public override async Task StartAsync(CancellationToken stoppingToken)
        {

            try
            {
            //    Task task = new Task(() => PrintMessage());
            //    task.Start();
            }
            catch (Exception ex)
            {

            }




            //var mapper = new ModelToTableMapper<SdMotorizadoPedidoCab>();
            //mapper.AddMapping(c => c.PcaCodigo, "pca_codigo");
            //mapper.AddMapping(c => c.MotCodigo, "mot_codigo");


            //dep = new SqlTableDependency<SdMotorizadoPedidoCab>(conString, "SD_MotorizadoPedido_Cab", mapper: mapper);
            //var estatus = dep.Status;
            //dep.OnChanged += Dep_OnChanged;
            //dep.OnStatusChanged += Dep_OnStatusChanged;
            //dep.Start();


            //await Task.Delay(5000, stoppingToken);

            //estatus = dep.Status;

            //while (!stoppingToken.IsCancellationRequested)
            //{
            //    //using (EventLog eventLog = new EventLog("Application"))
            //    //{
            //    //    eventLog.Source = "Application";
            //    //    eventLog.WriteEntry("Broker Motorizados DateTimeOffset.Now", EventLogEntryType.Information, 101, 1);
            //    //}
            //    //_logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            //    await Task.Delay(1000, stoppingToken);
            //}

            //dep.Stop();

            //estatus = dep.Status;
        }


        private void Dep_OnStatusChanged(object sender, TableDependency.SqlClient.Base.EventArgs.StatusChangedEventArgs e)
        {
            //_logger.LogInformation(e.Status.ToString());
            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = "Application";
                eventLog.WriteEntry("Broker Motorizados " + e.Status.ToString(), EventLogEntryType.Warning, 101, 1);
            }
        }

        private void Dep_OnChanged(object sender, TableDependency.SqlClient.Base.EventArgs.RecordChangedEventArgs<SdMotorizadoPedidoCab> e)
        {
            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = "Application";
                eventLog.WriteEntry("Broker Motorizados Changed", EventLogEntryType.SuccessAudit, 101, 1);
            }

            var changedEntity = e.Entity;

            switch (e.ChangeType)
            {
                case TableDependency.SqlClient.Base.Enums.ChangeType.None:
                    break;
                case TableDependency.SqlClient.Base.Enums.ChangeType.Delete:
                    break;
                case TableDependency.SqlClient.Base.Enums.ChangeType.Insert:

                    //_logger.LogInformation(changedEntity.MotCodigo.ToString());
                    // obtener token 

                    try
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
                            MotCodigo = changedEntity.MotCodigo,
                            Pedidos = new List<PedidoViewModel> { new PedidoViewModel { PcaCodigo = Convert.ToInt32(changedEntity.PcaCodigo), SerieFactura = "" } }
                        };

                        requestSession.AddJsonBody(gPSMotorizadoViewModel);
                        restResponse = clienteSesion.Execute(requestSession).Content;
                        if (!restResponse.Contains("OK"))
                            using (EventLog eventLog = new EventLog("Application"))
                            {
                                eventLog.Source = "Application";
                                eventLog.WriteEntry("Broker Motorizados NOTIFICAR" + restResponse, EventLogEntryType.Warning, 101, 1);
                            }

                    }
                    catch (Exception ex)
                    {
                        //_logger.LogError(ex.Message);
                        using (EventLog eventLog = new EventLog("Application"))
                        {
                            eventLog.Source = "Application";
                            eventLog.WriteEntry("Broker Motorizados NOTIFICAR" + ex.Message, EventLogEntryType.Warning, 101, 1);
                        }
                    }

                    break;
                case TableDependency.SqlClient.Base.Enums.ChangeType.Update:
                    break;
                default:
                    break;
            }
        }
        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            try
            {
                dep.Stop();
            }
            catch (Exception ex)
            {
                using (EventLog eventLog = new EventLog("Application"))
                {
                    eventLog.Source = "Application";
                    eventLog.WriteEntry("Broker Motorizados StopAsync " + ex.Message, EventLogEntryType.Error, 101, 1);
                }
            }
        }

        public virtual void Dispose()
        {
            try
            {
                dep.Stop();
            }
            catch (Exception ex)
            {
                using (EventLog eventLog = new EventLog("Application"))
                {
                    eventLog.Source = "Application";
                    eventLog.WriteEntry("Broker Motorizados StopAsync " + ex.Message, EventLogEntryType.Error, 101, 1);
                }
            }
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            throw new NotImplementedException();
        }

        //private static void SetTimer()
        //{
        //    // Create a timer with a two second interval.
        //    tgTimer = new System.Timers.Timer(300000);
        //    // Hook up the Elapsed event for the timer. 
        //    tgTimer.Elapsed += TgTimer_Elapsed; ;
        //    tgTimer.AutoReset = true;
        //    tgTimer.Enabled = true;
        //}

        //private static void TgTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        //{


        //    var startDate = DateTime.Now.Date;
        //    var endDate = DateTime.Now.Date.AddDays(1).AddTicks(-1);

        //    var pedidosNotificados = _ctxServicioDomicilio.SdTrackingVerificacionPedidos.
        //        Where(b => b.TkpFechaRegistro > startDate && b.TkpFechaRegistro < endDate).Select(x => x.PcaCodigo).Distinct().ToList();

        //    var pedidosPendientes = _ctxServicioDomicilio.SdMotorizadoPedidoCab.Where(x => !pedidosNotificados.Contains(x.PcaCodigo) && x.MpFecha > startDate && x.MpFecha < endDate).ToList();



        //    // revisión de trigger
        //    try
        //    {
        //        string UrlServicioCPM = _configuration.GetValue<string>("ServicioCentralPlatafomraMovilURL");
        //        string usuarioCPM = _configuration.GetValue<string>("usuario");
        //        string contraseniaCPM = _configuration.GetValue<string>("contrasenia");
        //        string dieccionServicio = UrlServicioCPM + "/Login/AutentificarUsuario";
        //        Login login = new Login
        //        {
        //            Usuario = usuarioCPM,
        //            Contrasenia = contraseniaCPM
        //        };

        //        var clienteSesion = new RestClient(dieccionServicio);
        //        var requestSession = new RestRequest("", Method.POST);
        //        requestSession.AddJsonBody(login);
        //        var restResponse = clienteSesion.Execute(requestSession).Content;

        //        TokenResponse tokenResponse = JsonSerializer.Deserialize<TokenResponse>(restResponse);


        //        // Lamado a notificar 
        //        clienteSesion = new RestClient(UrlServicioCPM + "/GPSMotorizado/Posicion");
        //        requestSession = new RestRequest("", Method.POST);
        //        requestSession.AddParameter("Authorization", string.Format("Bearer " + tokenResponse.token), ParameterType.HttpHeader);

        //        GPSMotorizadoViewModel gPSMotorizadoViewModel = new GPSMotorizadoViewModel
        //        {
        //            AccionRegistro = "NOTIFICAR",
        //            MotCodigo = changedEntity.MotCodigo,
        //            Pedidos = new List<PedidoViewModel> { new PedidoViewModel { PcaCodigo = Convert.ToInt32(changedEntity.PcaCodigo), SerieFactura = "" } }
        //        };

        //        requestSession.AddJsonBody(gPSMotorizadoViewModel);
        //        restResponse = clienteSesion.Execute(requestSession).Content;
        //        if (!restResponse.Contains("OK"))
        //            using (EventLog eventLog = new EventLog("Application"))
        //            {
        //                eventLog.Source = "Application";
        //                eventLog.WriteEntry("Broker Motorizados NOTIFICAR" + restResponse, EventLogEntryType.Warning, 101, 1);
        //            }

        //    }
        //    catch (Exception ex)
        //    {
        //        //_logger.LogError(ex.Message);
        //        using (EventLog eventLog = new EventLog("Application"))
        //        {
        //            eventLog.Source = "Application";
        //            eventLog.WriteEntry("Broker Motorizados NOTIFICAR" + ex.Message, EventLogEntryType.Warning, 101, 1);
        //        }
        //    }

        //}
    }



}


public class TokenResponse
{
    public string token { get; set; }
}
