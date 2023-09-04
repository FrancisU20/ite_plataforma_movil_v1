using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogicaDatos.ModelsServicioDomicilio;
using LogicaNegocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPICentralPlataformaMovil.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MotorizadoController : ControllerBase
    {
        private readonly IServicio _servicio;

        public MotorizadoController(IServicio servicio)
        {
            _servicio = servicio;
        }

        // GET: api/Motorizado
        [HttpGet]
        public IEnumerable<SdMotorizado> Motorizados()
        {
            return _servicio.Motorizados();
        }

        //// GET: api/Motorizado
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{

        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/Motorizado/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Motorizado
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Motorizado/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
