using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPICentralPlataformaMovil.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OneSignalController : ControllerBase
    {

        private readonly LogicaNegocio.IServicio _servicio;
        private readonly LogicaDatos.Transporte.IResult _result;

        public OneSignalController(LogicaNegocio.IServicio servicio, LogicaDatos.Transporte.IResult result)
        {
            _servicio = servicio;
            _result = result;
        }

        //// GET: api/OneSignal
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/OneSignal/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/OneSignal
        [Microsoft.AspNetCore.Authorization.Authorize]
        [HttpPost]
        public LogicaDatos.Transporte.Result RegistroCliente([FromBody] ViewModels.OneSignalRegistroClienteViewModel value)
        {
            if (string.IsNullOrEmpty(value.IdOneSignal))
                return _result.Error("Se requiere el campo IdOneSignal.");
            if (value.MotCodigo == 0)
                return _result.Error("Se requiere el campo MotCodigo.");

            return _servicio.RegistroCliente(value);
        }

        //// PUT: api/OneSignal/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
