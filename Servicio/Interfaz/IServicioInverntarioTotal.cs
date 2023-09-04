using Configuracion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Servicio.Interfaz
{
    public interface IServicioInverntarioTotal
    {
        void Inicializar();

        Result Ingreso(string ipServidor, string ipCliente, string nombreCorto);

        Result Inventario(string ipServidor, string nombreCorto);

        Result CargaInicialArticulos();

        Result BuscarArticuloInventario(string codigo, string codigoBarras, string descripcion, int conteo, int inventario, string usuario);

        Result CerrarSesion(string usuario, string ip);

        Result RegistroCantidades(string usuario, string ipCliente, int entero, int fraccion, string codigoArticulo, int valorPos, int conteo, int inventario);

        Result CargarSiguiente(string usuario, int conteo, int inventario);

        Result RecuperarFarmacia(string ip);
    }
}
