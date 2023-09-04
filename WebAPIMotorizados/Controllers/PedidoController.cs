using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogicaDatos.Transporte;
using LogicaNegocio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPICentralPlataformaMovil.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {

        private readonly IServicio _servicio;

        public PedidoController(IServicio servicio)
        {
            _servicio = servicio;
        }

        [Authorize]
        //// GET: api/Pedido
        [HttpGet("{cedula}")]
        public Result PedidosMotorizado(string cedula)
        {
            return _servicio.PedidosMotorizado(cedula);
        }

        //// GET: api/Pedido/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Pedido
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/Pedido/5
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
