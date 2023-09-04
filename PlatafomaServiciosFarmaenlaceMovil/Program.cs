using Entidades.EasyGestionEmpresarial;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlatafomaServiciosFarmaenlaceMovil
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (ServiceReference1.Service1Client c = new ServiceReference1.Service1Client())
            //{
            try
            {
                //string result = c.RestringirArticulosContar("3923", "PIA", "tlcalderon");

                //string subir = c.SubirConteoInventario("3669", "PIA", "{ \"ip\":\"192.168.147.9\"," +
                //    "\"usuario\":\"tlcalderon\",\"id_plan\":\"3669\",\"nombre\":\"PRUEBA MV3\"," +
                //    "\"origen\":\"PIA\",\"articulos\":[{  " +
                //    "\"codigo\":\"000011042\",\"descripcion\":\"AGUA ESTERIL USP  10ML *  50 @@\"," +
                //    "\"barra\":\"12028\"," +
                //    "\"valorconversion\":50," +
                //    "\"stock\":5," +
                //    "\"ingreso\":0," +
                //    "\"coincide\":true" +
                //    "}" +
                //    "]" +
                //    "}");

                string detalle = @"{""traspaso"":""TA-4597537"",""usuarioFarmacia"":""tlcalderon"",""bodega"":""079"",""caja"":1,""funda"":0,""paca"":0}";
                ////REQUEST
                //var client = new RestClient("http://localhost:2411/Service1.svc/GenerarKardex?detalle="+detalle);
                //var request = new RestRequest("", Method.GET);
                //request.RequestFormat = DataFormat.Json;
                //IRestResponse response = client.Execute(request);

                //var deserializer = new RestSharp.Deserializers.JsonDeserializer();

                //token = deserializer.Deserialize<Token>(access_token);


                //HOLA
                //asydiuasghd
                ////POST
                var client = new RestClient("http://localhost:2411/Service1.svc/GenerarKardex");
                var requestPost = new RestRequest("", Method.POST);
                requestPost.RequestFormat = DataFormat.Json;
                var jsonResponse = JsonConvert.SerializeObject(detalle);
                requestPost.AddParameter("text/json", jsonResponse, ParameterType.RequestBody);
                var responsePost = client.Execute(requestPost);


            }
            catch (Exception ex)
                {

                    throw;
                }

            //}
        }

    }
}
