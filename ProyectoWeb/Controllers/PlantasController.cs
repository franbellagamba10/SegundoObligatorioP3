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
    public class PlantasController : Controller, IValidarSesion
    {
        public IManejadorPlantas manejadorPlantas { get; set; }
        public IManejadorUsuarios manejadorUsuarios { get; set; }
        public PlantasController(IManejadorPlantas manejPlantas, IManejadorUsuarios manejUsuarios)
        {
            manejadorPlantas = manejPlantas;
            manejadorUsuarios = manejUsuarios;
        }
        public IActionResult Index()
        {
            if (!EstoyLogueado())
                return RedirectToAction("Logout", "Usuarios");            
            return View(CargarPlantasIndexFormateado());
        }
        [HttpGet]
        public ActionResult Create()
        {
            if (!EstoyLogueado())
                return RedirectToAction("Logout", "Usuarios");
            PlantaViewModel plantaVM = new PlantaViewModel
            {
                Fichas = manejadorPlantas.TraerTodasLasFichas(),
                TiposPlanta = manejadorPlantas.TraerTodosLosTiposDePlanta(),
            };         

            return View(plantaVM);
        }
        [HttpPost]
        public ActionResult Create(PlantaViewModel plantaVM)
        {
            try
            {
                Planta planta = new Planta
                {
                    id = plantaVM.id,
                    nombreCientifico = plantaVM.nombreCientifico,
                    nombresVulgares = plantaVM.nombresVulgares,
                    alturaMaxima = plantaVM.alturaMaxima,
                    descripcion = plantaVM.descripcion,
                    ambiente = (Planta.Ambiente)plantaVM.ambiente,
                    precio = plantaVM.precio,
                    foto = plantaVM.foto,
                    ficha = manejadorPlantas.ObtenerFichaPorId(plantaVM.IdFichaSeleccionada),
                    ingresadoPor = manejadorUsuarios.BuscarUsuarioPorSuEmail(HttpContext.Session.GetString("userEmail")),
                    tipo = manejadorPlantas.ObtenerTipoPlantaPorId(plantaVM.IdTipoPlantaSeleccionada),
                };

                bool pudeCrear = manejadorPlantas.AgregarNuevaPlanta(planta);
                if (pudeCrear) // ---->  aca mismo se setea la ruta de la foto de la planta
                {
                    planta.id = manejadorPlantas.ObtenerPlantaPorNombreCientifico(planta.nombreCientifico).id;
                    return RedirectToAction("Details", planta);
                }
                    
            }
            catch (Exception ex)
            {
                return View(plantaVM);
            }             
            return View(plantaVM);
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (!EstoyLogueado())
                return RedirectToAction("Logout", "Usuarios");
            PlantaViewModel planta = new PlantaViewModel();
            Planta plantaBD = manejadorPlantas.ObtenerPlantaPorId(id);
            #region Conversion para cargar ViewModel
            planta.id = plantaBD.id;
            planta.nombreCientifico = plantaBD.nombreCientifico;
            planta.nombresVulgares = plantaBD.nombresVulgares;
            planta.alturaMaxima = plantaBD.alturaMaxima;
            planta.descripcion = plantaBD.descripcion;
            planta.ambiente = (PlantaViewModel.Ambiente)plantaBD.ambiente;
            planta.precio = plantaBD.precio;
            planta.foto = plantaBD.foto;
            planta.FichaSeleccionada = plantaBD.ficha;
            planta.IdFichaSeleccionada = plantaBD.ficha.id;
            planta.TipoPlantaSeleccionado = plantaBD.tipo;
            planta.IdTipoPlantaSeleccionada = plantaBD.tipo.id;
            planta.ingresadoPor = plantaBD.ingresadoPor;
            
            planta.Fichas = (IEnumerable<Ficha>)manejadorPlantas.TraerTodasLasFichas();
            planta.TiposPlanta = (IEnumerable<TipoPlanta>)manejadorPlantas.TraerTodosLosTiposDePlanta();
            #endregion
            return View(planta);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PlantaViewModel plantaVM) // ----> consultar con Plinio, capaz hay que pasarle usuario completo
        {
            try
            {
                Planta planta = new Planta
                {
                    id = plantaVM.id,
                    nombreCientifico = plantaVM.nombreCientifico,
                    nombresVulgares = plantaVM.nombresVulgares,
                    alturaMaxima = plantaVM.alturaMaxima,
                    descripcion = plantaVM.descripcion,
                    ambiente = (Planta.Ambiente)plantaVM.ambiente,
                    precio = plantaVM.precio,
                    foto = plantaVM.foto,
                    ficha = manejadorPlantas.ObtenerFichaPorId(plantaVM.IdFichaSeleccionada),
                    ingresadoPor = manejadorUsuarios.BuscarUsuarioPorSuEmail(plantaVM.EmailUsuarioAutor),
                    tipo = manejadorPlantas.ObtenerTipoPlantaPorId(plantaVM.IdTipoPlantaSeleccionada),
                
                };
                bool pudeEditar = manejadorPlantas.ActualizarPlanta(planta);
                if (!pudeEditar)
                    return View(planta);
                return RedirectToAction("Details", planta);
            }
            catch (Exception ex)
            {
                return View(); //deberia volver al formulario edicion de usuario
            }            
        }
        public ActionResult Details(int id)
        {
            if (!EstoyLogueado())
                return RedirectToAction("Logout", "Usuarios");
            return View(manejadorPlantas.ObtenerPlantaPorId(id));
        }

        public ActionResult Delete(int id)
        {
            if (!EstoyLogueado())
                return RedirectToAction("Logout", "Usuarios");
            return View(manejadorPlantas.ObtenerPlantaPorId(id));
             
        }
        [HttpPost]
        public ActionResult Delete(Planta planta)
        {
            if (!EstoyLogueado())
                return RedirectToAction("Logout", "Usuarios");
            bool pudeBorrar = manejadorPlantas.DarDeBajaPlanta(planta.id);            
            if (!pudeBorrar)            
                ViewBag.mensaje = "No fue posible dar de baja la planta";            
            return View("Index", CargarPlantasIndexFormateado());
        }

        public bool EstoyLogueado()
        {
            return HttpContext.Session.GetInt32("userId") != null;
        }
        public IEnumerable<Planta> CargarPlantasIndexFormateado()
        {
            IEnumerable<Planta> plantas = manejadorPlantas.ObtenerTodasLasPlantas();
            foreach (Planta p in plantas)
            {
                if (p.descripcion.Length > 50)
                {
                    p.descripcion = p.descripcion.Substring(0, 50) + "[...]";
                }
            }
            return plantas;
        }
    }
}