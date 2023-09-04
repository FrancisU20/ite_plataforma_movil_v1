using LogicaDatos.ModelsServicioDomicilio;
using LogicaDatos.Transporte;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModels;

namespace LogicaNegocio
{
    public interface IServicio
    {
        List<SdMotorizado> Motorizados();
        Result AutentificarUsuario(string usuario, string contrasenia);
        void Digitalizacion();
        Result PedidosMotorizado(string cedula);

        System.Threading.Tasks.Task<Result> GPSMotorizadoRegistroAsync(GPSMotorizadoViewModel gPSMotorizadoViewModel);

        Result RegistroCliente(OneSignalRegistroClienteViewModel oneSignalRegistroClienteViewModel);
    }
}
