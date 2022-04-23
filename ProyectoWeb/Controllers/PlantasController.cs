using Dominio.Entidades;
using Fachada;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoWeb.Controllers
{
    public class PlantasController : Controller
    {
        public IManejadorPlantas manejadorPlantas { get; set; }
        public PlantasController(IManejadorPlantas manejPlantas)
        {
            manejadorPlantas = manejPlantas;
        }
        public IActionResult Index()
        {
            IEnumerable<Planta> plantas = manejadorPlantas.ObtenerTodasLasPlantas();
            return View(plantas);
        }        
    }
}
