using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaDatos.Transporte
{

    public class Result : IResult
    {
        public string respuesta { get; set; }
        public Object mensaje { get; set; }

        public Result OK()
        {
            return new Result
            {
                respuesta = "OK",
                mensaje = "Operación finalizada correctamente."
            };
        }

        public Result OK(Object objeto)
        {
            return new Result
            {
                respuesta = "OK",
                mensaje = objeto
            };
        }

        public Result Error(string mensajeError)
        {
            return new Result
            {
                respuesta = "Error",
                mensaje = mensajeError
            };
        }
    }

}
