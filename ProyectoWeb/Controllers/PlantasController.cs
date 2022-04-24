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
        public IManejadorUsuarios manejadorUsuarios { get; set; }
        public PlantasController(IManejadorPlantas manejPlantas, IManejadorUsuarios manejUsuarios)
        {
            manejadorPlantas = manejPlantas;
            manejadorUsuarios = manejUsuarios;
        }
        public IActionResult Index()
        {
            IEnumerable<Planta> plantas = manejadorPlantas.ObtenerTodasLasPlantas();
            return View(plantas);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Planta planta)
        {
            bool pudeCrear = manejadorPlantas.AgregarNuevaPlanta(planta);
            if(pudeCrear) // ---->  aca mismo se setea la ruta de la foto de la planta
                RedirectToAction("Plantas/Index");
            return View(planta); // revisar si le paso este modelo o solo la View
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
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
            }
            catch (Exception ex)
            {
                return View(); //deberia volver al formulario edicion de usuario
            }
            return RedirectToAction("Index"); //  -----> REVISAR, necesitamos que vaya al Indice de plantas
        }

        public ActionResult Details(int id)
        {
            Planta planta = manejadorPlantas.ObtenerPlantaPorId(id);
            return View(planta);
        }
    }
}