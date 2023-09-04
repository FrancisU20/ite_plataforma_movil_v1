using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaDatos.EasyGestionEmpresarial;
using LogicaDatos.ITEDigitalizacion;
using LogicaDatos.ModelsEasySeguridad;
using LogicaDatos.ModelsServicioDomicilio;
using LogicaDatos.Transporte;
using LogicaNegocio;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using WebAPICentralPlataformaMovil.Filters;

namespace WebAPICentralPlataformaMovil
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ServicioDomicilioContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("ServicioDomicilioConnection"));
                options.EnableDetailedErrors(true);
            });

            services.AddDbContext<EasySeguridadContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("ServicioEasySeguridadConnection"));
                options.EnableDetailedErrors(true);
            });

            services.AddDbContext<EasyGestionEmpresarialContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("ServicioEasyGestionEmpresarialConnection"));
                options.EnableDetailedErrors(true);
            });

            services.AddDbContext<ITDigitalizacionContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("ServicioITEDigitalizacionConnection"));
                options.EnableDetailedErrors(true);
            });

            var key = Encoding.ASCII.GetBytes(Configuration.GetValue<string>("SecretKey"));

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services
             .AddMvc(options => options.Filters.Add(typeof(CustomExceptionFilterAttribute)));

            services.AddControllers().AddNewtonsoftJson();

            services.AddTransient<IResult, Result>();
            services.AddTransient<IServicio, Servicio>();

            services.AddControllers();

            // TAREAS

            //services.AddHostedService<PedidosMotorizadoTask>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceScopeFactory serviceScopeFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();


            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        private void OnShutdown()
        {
            //this code is called when the application stops
        }
    }
}
