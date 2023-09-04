using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using PruebasUnitarias.wcf;
using RestSharp;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace PruebasUnitarias
{
    [TestClass]
    public class VerificacionCajasTest
    {
        public static string UrlBase { get; set; } = "http://localhost:2411/Service1.svc";

        [TestMethod]
        public void VerificacionCajas_Bodega_ok()
        {
            var client = new RestClient(UrlBase + "/VerificacionCajas?bodega=079");
            var request = new RestRequest("", Method.GET);
            request.RequestFormat = DataFormat.Json;

            IRestResponse response = client.Execute(request);

            Assert.IsTrue(response.Content.ToLower().Contains("ok"));
        }

        [TestMethod]
        public void GuardarPendientesVerificacion_EstadoET_ok()
        {
            List<TraspasoModel> traspasoModel = new List<TraspasoModel>();
            TraspasoModel temp = new TraspasoModel
            {
                NumeroTraspaso = "TA-4645159",
                Check = "X",
                Ip = "192.168.147.153",
                Estado = "T",
                DescripcionEstado = "EN TRANSPORTE",
                UsuarioFarmacia = "tlcalderon",
                Bodega = "079",
                FechaTraspaso = "2018/05/07 03:32:12",
                Caja = 4,
                Funda = 5,
                Paca = 3,
                CajasP = new List<string> { "TA4645159C1", "TA4645159C2", "TA4645159C3", "TA4645159C4" },
                FundasP = new List<string>(),
                PacasP = new List<string> { "TA4645159P3" },
                CajasV = new List<string>(),
                FundasV = new List<string> { "TA4645159F1", "TA4645159F2", "TA4645159F3", "TA4645159F4", "TA4645159F5" },
                PacasV = new List<string> { "TA4645159P1", "TA4645159P2" }
            };
            traspasoModel.Add(temp);
            
            var client = new RestClient(UrlBase + "/GuardarPendientesVerificacion");
            var requestPost = new RestRequest("", Method.POST);
            requestPost.RequestFormat = DataFormat.Json;
            var jsonResponse = JsonConvert.SerializeObject(traspasoModel);
            requestPost.AddParameter("text/json", jsonResponse, ParameterType.RequestBody);

            var responsePost = client.Execute(requestPost);

            Assert.IsTrue(responsePost.Content.ToLower().Contains("ok"));
        }
    }
}
