using Servicio.Interfaz;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace PlataformaMovilWCF
{
    public class Global : System.Web.HttpApplication
    {
        private LanzarTareas lanzarTareas { get; set; }

        protected void Application_Start(object sender, EventArgs e)
        {
            try
            {
                if (lanzarTareas == null)
                    lanzarTareas = new LanzarTareas();
            }
            catch (Exception ex)
            {
                using (EventLog eventLog = new EventLog("Application"))
                {
                    eventLog.Source = "Application";
                    eventLog.WriteEntry("PM     " + ex.Message, EventLogEntryType.Information, 101, 1);
                }
            }

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}