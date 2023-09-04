using LogicaDatos.ModelsServicioDomicilio;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.FileExtensions;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Runtime.CompilerServices;

namespace DemonioPedidosMotorizadosConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IConfiguration config = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json", true, true)
               .Build();


                var optionsBuilder = new DbContextOptionsBuilder<ServicioDomicilioContext>();
                optionsBuilder.UseSqlServer(config.GetConnectionString("ServicioDomicilioConnection"));

                using (var context = new ServicioDomicilioContext(optionsBuilder.Options))
                {
                    PedidoNotificacion p = new PedidoNotificacion(context, config);
                }
            }
            catch (Exception ex)
            {


            }
            finally
            {
                Environment.Exit(-1);
            }
        }
    }
}
