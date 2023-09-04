using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;
using Tareas.PlataformaMovilWCF;

namespace Tareas
{
    public class PendientesRecepcion
    {
        public static string UrlBase { get; set; } = "http://localhost/ws_plataformamovil/service1.svc";
        //public static string UrlBase { get; set; } = "http://localhost:2411/Service1.svc";

        public PendientesRecepcion() { }

        public void VerificarPendientes()
        {
            try
            {
                var client = new RestClient(UrlBase + "/VerificacionPendientesVencidos");
                var request = new RestRequest("", Method.GET);
                request.RequestFormat = DataFormat.Json;
                IRestResponse response = client.Execute(request);
            }
            catch (Exception ex)
            {
                registrarLog(ex.Message);
                registrarLog(ex.InnerException.Message);
            }

        }

        private void registrarLog(string resp)
        {
            System.Diagnostics.EventLog objLog = new System.Diagnostics.EventLog();
            if (!EventLog.SourceExists("PMOV_TAREAS"))
                EventLog.CreateEventSource("PMOV_TAREAS", "Application");
            objLog.Source = "PMOV_TAREAS";

            objLog.WriteEntry("RESP: " + resp, EventLogEntryType.Warning);
        }
    }
}
