using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaDatos.Transporte
{
    public interface IResult
    {
        Result OK();
        Result Error(string mensajeError);
        Result OK(Object objeto);
    }
}
