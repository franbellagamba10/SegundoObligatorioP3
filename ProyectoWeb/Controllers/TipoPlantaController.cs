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
    public class TipoPlantaController : Controller, IValidarSesion
    {
        public IManejadorPlantas manejadorPlantas { get; set; }
        public TipoPlantaController(IManejadorPlantas manejPlantas)
        {
            manejadorPlantas = manejPlantas;
        }
        // GET: TipoPlantasController
        public ActionResult Index()
        {
            if (!EstoyLogueado())
                return RedirectToAction("Logout", "Usuarios");            
            return View(CargarTiposPlantaIndexFormateado());
        }

        // GET: TipoPlantasController/Details/5
        public ActionResult Details(int id)
        {
            if (!EstoyLogueado())
                return RedirectToAction("Logout", "Usuarios");            
            TipoPlanta tipoPlanta = manejadorPlantas.ObtenerTipoPlantaPorId(id);
            return View(tipoPlanta);
        }

        // GET: TipoPlantasController/Create
        public ActionResult Create()
        {
            if (!EstoyLogueado())
                return RedirectToAction("Logout", "Usuarios");
            TipoPlantaViewModel tipoPlantaVM = new TipoPlantaViewModel();            

            return View(tipoPlantaVM);
        }

        // POST: TipoPlantasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoPlantaViewModel tipoPlantaVM)
        {
            try
            {
                TipoPlanta tipoPlanta = new TipoPlanta
                {
                    id = tipoPlantaVM.id,
                    nombre = tipoPlantaVM.nombre.Trim(),
                    descripcion = tipoPlantaVM.descripcion.Trim(),                    
                };

                bool pudeCrear = manejadorPlantas.AgregarNuevoTipoPlanta(tipoPlanta);
                if (pudeCrear) // ---->  aca mismo se setea la ruta de la foto de la planta
                {
                    tipoPlanta.id = manejadorPlantas.ObtenerTipoPlantaPorNombre(tipoPlanta.nombre).id; //obtengo el tTP para ponerle ID despues de creado
                    return RedirectToAction("Details", tipoPlanta);
                }

            }
            catch (Exception ex)
            {
                return View(tipoPlantaVM);
            }
            return View(tipoPlantaVM);
        }

        // GET: TipoPlantasController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!EstoyLogueado())
                return RedirectToAction("Logout", "Usuarios");
            TipoPlantaViewModel tipoPlanta = new TipoPlantaViewModel();
            TipoPlanta tipoPlantaBD = manejadorPlantas.ObtenerTipoPlantaPorId(id);
            #region Conversion para cargar ViewModel
                tipoPlanta.id = tipoPlantaBD.id;
                tipoPlanta.nombre = tipoPlantaBD.nombre;
                tipoPlanta.descripcion = tipoPlantaBD.descripcion;            
            #endregion
            return View(tipoPlanta);
        }

        // POST: TipoPlantasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TipoPlantaViewModel tipoPlantaVM)
        {
            try
            {
                TipoPlanta tipoPlanta = new TipoPlanta
                {
                    id = tipoPlantaVM.id,
                    nombre = tipoPlantaVM.nombre,
                    descripcion = tipoPlantaVM.descripcion,
                };
                bool pudeEditar = manejadorPlantas.ActualizarTipoPlanta(tipoPlanta);
                if (!pudeEditar)
                    return View(tipoPlantaVM);
                return RedirectToAction("Details", tipoPlanta); //Esto explota cuando lo devuelvo a la vista
                
            }
            catch (Exception ex)
            {
                return View(tipoPlantaVM); //deberia volver al formulario edicion de usuario
            }
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (!EstoyLogueado())
                return RedirectToAction("Logout", "Usuarios");
            return View(manejadorPlantas.ObtenerTipoPlantaPorId(id));

        }
        [HttpPost]
        public ActionResult Delete(TipoPlanta tipoPlanta)
        {
            if (!EstoyLogueado())
                return RedirectToAction("Logout", "Usuarios");
            bool pudeBorrar = manejadorPlantas.DarDeBajaTipoPlanta(tipoPlanta.id);
            if (!pudeBorrar)            
                ViewBag.mensaje = "No fue posible dar de baja el tipo de planta";
            
            return View("Index", CargarTiposPlantaIndexFormateado());
        }        

        public IEnumerable<TipoPlanta> CargarTiposPlantaIndexFormateado()
        {
            IEnumerable<TipoPlanta> tiposPlantas = manejadorPlantas.TraerTodosLosTiposDePlanta();
            foreach (TipoPlanta tp in tiposPlantas)
            {
                if (tp.descripcion.Length > 50)
                {
                    tp.descripcion = tp.descripcion.Substring(0, 50) + "[...]";
                }
            }
            return tiposPlantas;
        }


        public bool EstoyLogueado()
        {
            return HttpContext.Session.GetInt32("userId") != null;
        }
    }
}

