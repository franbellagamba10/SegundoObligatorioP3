using Dominio.Interfaces;
using Datos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fachada;

namespace ProyectoWeb
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
            services.AddControllersWithViews();

            string tipoRepo = Configuration.GetSection("TipoRepo").Value;
           
            services.AddScoped<IManejadorUsuarios, ManejadorUsuarios>();            
            services.AddScoped<IRepositorioUsuarios, RepositorioUsuariosADO>();
            services.AddSession();      
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
                      
        }

        public static string ObtenerConexion()
        {
            string cadenaConexion = string.Empty;
            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            cadenaConexion = config.GetConnectionString("conexion");
            return cadenaConexion;
        }
    }
}
