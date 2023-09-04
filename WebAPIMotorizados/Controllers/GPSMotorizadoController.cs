using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogicaDatos.Transporte;
using LogicaNegocio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModels;

namespace WebAPICentralPlataformaMovil.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GPSMotorizadoController : ControllerBase
    {

        private readonly IServicio _servicio;
        private readonly IResult _result;


        public GPSMotorizadoController(IServicio servicio, IResult result)
        {
            _servicio = servicio;
            _result = result;
        }

        //// GET: api/GPSMotorizado
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/GPSMotorizado/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/GPSMotorizado
        [Authorize]
        [HttpPost]
        public Task<Result> Posicion([FromBody] GPSMotorizadoViewModel value)
        {
            return _servicio.GPSMotorizadoRegistroAsync(value);
        }

        //// PUT: api/GPSMotorizado/5
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
