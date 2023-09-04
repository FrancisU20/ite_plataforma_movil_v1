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
    public class LoginController : ControllerBase
    {

        private readonly IServicio _servicio;
        private readonly IResult _result;

        public LoginController(IServicio servicio, IResult result)
        {
            _servicio = servicio;
            _result = result;
        }

        [HttpPost()]
        public UsuarioViewModel AutentificarUsuario(Login login)
        {
            var x = _servicio.AutentificarUsuario(login.Usuario, login.Contrasenia);

            try
            {
                return (UsuarioViewModel)x.mensaje;
            }
            catch (Exception)
            {
                Result result = (Result)x;
                throw new Exception(result.mensaje.ToString());
            }
        }

        [Authorize]
        public Result TestAuth()
        {
            return _result.OK();
        }

        //// POST: api/Login
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/Login/5
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
