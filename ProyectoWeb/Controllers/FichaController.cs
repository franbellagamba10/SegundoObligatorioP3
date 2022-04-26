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
    public class FichaController : Controller, IValidarSesion
    {
        IManejadorPlantas manejadorPlantas { get; set; }
        public FichaController(IManejadorPlantas manejPlantas)
        {
            manejadorPlantas = manejPlantas;
        }
        // GET: FichaController
        public ActionResult Index()
        {
            if (!EstoyLogueado())
                return RedirectToAction("Logout", "Usuarios");
            return View(manejadorPlantas.ObtenerTodasLasFichas());
        }

        // GET: FichaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FichaController/Create
        public ActionResult Create()
        {
            if (!EstoyLogueado())
                return RedirectToAction("Logout", "Usuarios");
            FichaViewModel fichaVM = new FichaViewModel()
            {
                frecuenciasRiego = manejadorPlantas.ObtenerTodasLasFR(),
                tiposIluminacion = manejadorPlantas.ObtenerTodosLosTI(),
            };

            return View(fichaVM);
        }

        // POST: FichaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FichaViewModel fichaVM)
        {
            try
            {
                Ficha ficha = new Ficha
                {
                    id = fichaVM.id,
                    tipoIluminacion = manejadorPlantas.ObtenerTIPorId(fichaVM.tipoIluminacionSeleccionado),
                    frecuenciaRiego = manejadorPlantas.ObtenerFRPorId(fichaVM.frecuenciaRiegoSeleccionada),
                    temperatura = fichaVM.temperatura,
                };

                bool pudeCrear = manejadorPlantas.AgregarNuevaFicha(ficha);
                if (pudeCrear) // ---->  aca mismo se setea la ruta de la foto de la planta
                {
                    //ficha.id = manejadorPlantas.ObtenerTipoPlantaPorNombre(ficha.nombre).id; //obtengo el tTP para ponerle ID despues de creado
                    return View("Index", manejadorPlantas.ObtenerTodasLasFichas());
                }
                
            }
            catch (Exception ex)
            {
                return View(fichaVM);
            }
            return View(fichaVM);
        }

        // GET: FichaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FichaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FichaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FichaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public bool EstoyLogueado()
        {
            return HttpContext.Session.GetInt32("userId") != null;
        }
    }
}
