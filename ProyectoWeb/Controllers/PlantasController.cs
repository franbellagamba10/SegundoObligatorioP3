using Dominio.Entidades;
using Fachada;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoWeb.Models;
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
        [HttpGet]
        public ActionResult Edit(int id)
        {
            PlantaDTO planta = new PlantaDTO();
            planta.TiposPlanta = (IEnumerable<TipoPlanta>)manejadorPlantas.TraerTodosLosTiposDePlanta();


            return View(planta);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Usuario user) // ----> consultar con Plinio, capaz hay que pasarle usuario completo
        {
            //try
            //{
            //    bool pudeEditar = manejadorUsuarios.ActualizarUsuario(user);
            //    if (!pudeEditar)
            //        return View(); //deberia volver al formulario de edicion de usuario
            //}
            //catch (Exception ex)
            //{
            //    return View(); //deberia volver al formulario edicion de usuario
            //}            
            return RedirectToAction("Plantas/Index"); //  -----> REVISAR, necesitamos que vaya al Indice de plantas
        }
        
        public ActionResult Details(int id)
        {
            Planta planta = manejadorPlantas.ObtenerPlantaPorId(id);
            return View(planta);
        }
    }
}
