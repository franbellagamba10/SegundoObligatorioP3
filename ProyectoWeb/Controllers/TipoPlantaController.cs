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
        public IManejadorPlantas ManejadorPlantas { get; set; }
        public TipoPlantaController(IManejadorPlantas manejPlantas)
        {
            ManejadorPlantas = manejPlantas;
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
            TipoPlanta tipoPlanta = ManejadorPlantas.ObtenerTipoPlantaPorId(id);
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

                bool pudeCrear = ManejadorPlantas.AgregarNuevoTipoPlanta(tipoPlanta);
                if (pudeCrear)
                {
                    tipoPlanta.id = ManejadorPlantas.ObtenerTipoPlantaPorNombre(tipoPlanta.nombre).id;
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
            TipoPlanta tipoPlantaBD = ManejadorPlantas.ObtenerTipoPlantaPorId(id);
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
                bool pudeEditar = ManejadorPlantas.ActualizarTipoPlanta(tipoPlanta);                
                if (!pudeEditar)
                    return View(tipoPlantaVM);
                return RedirectToAction("Details", tipoPlanta);                
            }
            catch (Exception ex)
            {
                return View(tipoPlantaVM);
            }
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (!EstoyLogueado())
                return RedirectToAction("Logout", "Usuarios");
            return View(ManejadorPlantas.ObtenerTipoPlantaPorId(id));
        }
        [HttpPost]
        public ActionResult Delete(TipoPlanta tipoPlanta)
        {
            if (!EstoyLogueado())
                return RedirectToAction("Logout", "Usuarios");
            bool pudeBorrar = ManejadorPlantas.DarDeBajaTipoPlanta(tipoPlanta.id);
            if (!pudeBorrar)            
                ViewBag.mensaje = "No fue posible dar de baja el tipo de planta";            
            return View("Index", CargarTiposPlantaIndexFormateado());
        }        

        public IEnumerable<TipoPlanta> CargarTiposPlantaIndexFormateado()
        {
            IEnumerable<TipoPlanta> tiposPlantas = ManejadorPlantas.TraerTodosLosTiposDePlanta();
            foreach (TipoPlanta tp in tiposPlantas)
            {
                if (tp.descripcion.Length > 50)               
                    tp.descripcion = tp.descripcion.Substring(0, 50) + "[...]";                
            }
            return tiposPlantas;
        }

        public ActionResult Busqueda(string cadena)
        {            
            return View("Details",ManejadorPlantas.ObtenerTipoPlantaPorNombre(cadena));
        }
        public bool EstoyLogueado()
        {
            return HttpContext.Session.GetInt32("userId") != null;
        }
        public ActionResult IndexSinLogin()
        {
            return View(CargarTiposPlantaIndexFormateado());
        }
    }
}

