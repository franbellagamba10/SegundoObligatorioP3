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
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Dominio.Entidades.EntidadesAuxiliares;

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
                        
            services.AddScoped<IManejadorUsuarios, ManejadorUsuarios>();
            services.AddScoped<IRepositorioUsuarios, RepositorioUsuariosEF>();
            services.AddScoped<IManejadorPlantas, ManejadorPlantas>();
            services.AddScoped<IRepositorioPlantas, RepositorioPlantasEF>();
            services.AddScoped<IRepositorio<TipoPlanta>, RepositorioTiposPlantaEF>();
            services.AddScoped<IRepositorio<Ficha>, RepositorioFichasEF>();
            services.AddScoped<IRepositorio<TipoIluminacion>, RepositorioTipoIluminacionEF>();
            services.AddScoped<IRepositorio<FrecuenciaRiego>, RepositorioFrecuenciaRiegoEF>();
            services.AddScoped<IManejadorCompras, ManejadorCompras>();
            services.AddScoped<IRepositorioCompras, RepositorioComprasEF>();
            
          


            services.AddSession();

            services.AddDbContext<ViveroContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("ConexionBDEntityFramework")));
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
                    pattern: "{controller=Usuarios}/{action=Login}/{id?}");
            });

        }        
    }
}