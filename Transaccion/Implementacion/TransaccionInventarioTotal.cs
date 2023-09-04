using Configuracion.Models;
using Servicio.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Transaccion.Interfaz;

namespace Transaccion.Implementacion
{
    public class TransaccionInventarioTotal : ITransaccionInventarioTotal
    {
        IServicioInverntarioTotal servicioInverntarioTotal;

        public TransaccionInventarioTotal(IServicioInverntarioTotal servicioInverntarioTotal)
        {
            this.servicioInverntarioTotal = servicioInverntarioTotal;
        }

        public Result Ingreso(string ipServidor, string ipCliente, string nombreCorto)
        {
            return servicioInverntarioTotal.Ingreso(ipServidor, ipCliente, nombreCorto);
        }

        public Result Inventario(string ipServidor, string nombreCorto)
        {
            return servicioInverntarioTotal.Inventario(ipServidor, nombreCorto);
        }

        public Result CargaInicialArticulos()
        {
            return servicioInverntarioTotal.CargaInicialArticulos();
        }

        public Result BuscarArticuloInventario(string codigo, string codigoBarras, string descripcion, int conteo, int inventario, string usuario)
        {
            return servicioInverntarioTotal.BuscarArticuloInventario(codigo, codigoBarras, descripcion, conteo, inventario, usuario);
        }

        public Result CerrarSesion(string usuario, string ip)
        {
            return servicioInverntarioTotal.CerrarSesion(usuario, ip);
        }

        public Result RegistroCantidades(string usuario, string ipCliente, int entero, int fraccion, string codigoArticulo, int valorPos, int conteo, int inventario)
        {
            return servicioInverntarioTotal.RegistroCantidades(usuario, ipCliente, entero, fraccion, codigoArticulo, valorPos, conteo, inventario);
        }

        public Result CargarSiguiente(string usuario, int conteo, int inventario)
        {
            return servicioInverntarioTotal.CargarSiguiente(usuario, conteo, inventario);
        }

        public Result RecuperarFarmacia(string ip)
        {
            return servicioInverntarioTotal.RecuperarFarmacia(ip);
        }
    }
}
