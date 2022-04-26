using Dominio.Entidades;
using Fachada;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace ProyectoWeb.Controllers
{
    public class PlantasController : Controller, IValidarSesion
    {
        public IManejadorPlantas ManejadorPlantas { get; set; }
        public IManejadorUsuarios ManejadorUsuarios { get; set; }
        public IWebHostEnvironment WebHostEnvironment { get; set; }
        public PlantasController(IManejadorPlantas manejPlantas, IManejadorUsuarios manejUsuarios, IWebHostEnvironment webHostEnv)
        {
            ManejadorPlantas = manejPlantas;
            ManejadorUsuarios = manejUsuarios;
            WebHostEnvironment = webHostEnv;
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
                Fichas = ManejadorPlantas.ObtenerTodasLasFichas(),
                TiposPlanta = ManejadorPlantas.TraerTodosLosTiposDePlanta(),
            };         

            return View(plantaVM);
        }
        [HttpPost]
        public ActionResult Create(PlantaViewModel plantaVM)
        {
            try
            {
                string nombreArchivo = FormatearNombreArchivo(plantaVM.nombreCientifico, plantaVM.imagen.FileName, plantaVM.foto);

                if (nombreArchivo == "ERROR")
                {
                    plantaVM.Fichas = ManejadorPlantas.ObtenerTodasLasFichas();
                    plantaVM.TiposPlanta = ManejadorPlantas.TraerTodosLosTiposDePlanta();
                    ViewBag.mensaje = "El nombre de la planta no puede ser vacío y su foto debe tener una única extension jpg o png";
                    return View(plantaVM);
                }

                Planta planta = new Planta
                {
                    id = plantaVM.id,
                    nombreCientifico = plantaVM.nombreCientifico,
                    nombresVulgares = plantaVM.nombresVulgares,
                    alturaMaxima = plantaVM.alturaMaxima,
                    descripcion = plantaVM.descripcion,
                    ambiente = (Planta.Ambiente)plantaVM.ambiente,
                    precio = plantaVM.precio,
                    foto = plantaVM.foto+ nombreArchivo,
                    ficha = ManejadorPlantas.ObtenerFichaPorId(plantaVM.IdFichaSeleccionada),
                    ingresadoPor = ManejadorUsuarios.BuscarUsuarioPorSuEmail(HttpContext.Session.GetString("userEmail")),
                    tipo = ManejadorPlantas.ObtenerTipoPlantaPorId(plantaVM.IdTipoPlantaSeleccionada),
                };                

                bool pudeCrear = ManejadorPlantas.AgregarNuevaPlanta(planta);
                if (pudeCrear)
                {
                    string rutaRaizApp = WebHostEnvironment.WebRootPath;
                    rutaRaizApp = Path.Combine(rutaRaizApp, "imagenes");
                    string rutaCompleta = Path.Combine(rutaRaizApp, nombreArchivo);
                    FileStream archivoStream = new FileStream(rutaCompleta, FileMode.Create);
                    plantaVM.imagen.CopyTo(archivoStream);


                    planta.id = ManejadorPlantas.ObtenerPlantaPorNombreCientifico(planta.nombreCientifico).id;
                    //planta.foto = plantabuscada.foto;
                    return RedirectToAction("Details", planta);
                }
                return View(plantaVM);
            }
            catch (Exception ex)
            {
                plantaVM.Fichas = ManejadorPlantas.ObtenerTodasLasFichas();
                plantaVM.TiposPlanta = ManejadorPlantas.TraerTodosLosTiposDePlanta();
                ViewBag.mensaje = "Ha ocurrido un error inesperado dando de alta su planta";
                return View(plantaVM);
            }             
            
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (!EstoyLogueado())
                return RedirectToAction("Logout", "Usuarios");
            PlantaViewModel planta = new PlantaViewModel();
            Planta plantaBD = ManejadorPlantas.ObtenerPlantaPorId(id);
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
            
            planta.Fichas = (IEnumerable<Ficha>)ManejadorPlantas.ObtenerTodasLasFichas();
            planta.TiposPlanta = (IEnumerable<TipoPlanta>)ManejadorPlantas.TraerTodosLosTiposDePlanta();
            #endregion
            return View(planta);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PlantaViewModel plantaVM)
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
                    ficha = ManejadorPlantas.ObtenerFichaPorId(plantaVM.IdFichaSeleccionada),
                    ingresadoPor = ManejadorUsuarios.BuscarUsuarioPorSuEmail(plantaVM.EmailUsuarioAutor),
                    tipo = ManejadorPlantas.ObtenerTipoPlantaPorId(plantaVM.IdTipoPlantaSeleccionada),
                
                };
                bool pudeEditar = ManejadorPlantas.ActualizarPlanta(planta);                
                if (!pudeEditar)
                {
                    plantaVM.ingresadoPor = ManejadorUsuarios.BuscarUsuarioPorSuEmail(planta.ingresadoPor.email);
                    plantaVM.FichaSeleccionada = planta.ficha;
                    plantaVM.IdFichaSeleccionada = planta.ficha.id;
                    plantaVM.TipoPlantaSeleccionado = planta.tipo;
                    plantaVM.IdTipoPlantaSeleccionada = planta.tipo.id;
                    plantaVM.Fichas = (IEnumerable<Ficha>)ManejadorPlantas.ObtenerTodasLasFichas();
                    plantaVM.TiposPlanta = (IEnumerable<TipoPlanta>)ManejadorPlantas.TraerTodosLosTiposDePlanta();
                    return View(plantaVM);
                }  
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
            Planta planta = ManejadorPlantas.ObtenerPlantaPorId(id);
            planta.foto = ObtenerUltimaFoto(planta.foto);                
            return View(planta);
        }

        public ActionResult Delete(int id)
        {
            if (!EstoyLogueado())
                return RedirectToAction("Logout", "Usuarios");
            Planta planta = ManejadorPlantas.ObtenerPlantaPorId(id);
            planta.foto = ObtenerUltimaFoto(planta.foto);
            return View(planta);

        }
        [HttpPost]
        public ActionResult Delete(Planta planta)
        {
            if (!EstoyLogueado())
                return RedirectToAction("Logout", "Usuarios");
            bool pudeBorrar = ManejadorPlantas.DarDeBajaPlanta(planta.id);            
            if (!pudeBorrar)            
                ViewBag.mensaje = "No fue posible dar de baja la planta";            
            return View("Index", CargarPlantasIndexFormateado());
        }

        [HttpGet]
        public ActionResult Busqueda()
        {
            if (!EstoyLogueado())
                return RedirectToAction("Logout", "Usuarios");
            PlantaViewModel plantaVM = new PlantaViewModel()
            {
                Fichas = ManejadorPlantas.ObtenerTodasLasFichas(),
                TiposPlanta = ManejadorPlantas.TraerTodosLosTiposDePlanta(),
            };
            return View("Busqueda", plantaVM);
        }

        [HttpPost]
        public ActionResult Busqueda(string nombre, int tipoPlanta,int alturaMaximaDesde, int alturaMaximaHasta, int ambiente)
        {

            //manejadorPlantas.BusquedaPlantas(nombre, tipoPlanta, alturaMaximaDesde, alturaMaximaHasta, ambiente);
            return View("Index", ManejadorPlantas.BusquedaPlantas(nombre, tipoPlanta, alturaMaximaDesde, alturaMaximaHasta, ambiente));
        }
        public bool EstoyLogueado()
        {
            return HttpContext.Session.GetInt32("userId") != null;
        }
        public IEnumerable<Planta> CargarPlantasIndexFormateado()
        {
            IEnumerable<Planta> plantas = ManejadorPlantas.ObtenerTodasLasPlantas();
            foreach (Planta p in plantas)
            {
                if (p.descripcion.Length > 50)
                {
                    p.descripcion = p.descripcion.Substring(0, 50) + "[...]";
                }
                p.foto = ObtenerUltimaFoto(p.foto);
            }
            return plantas;
        }

        public string ObtenerUltimaFoto(string cadenaCompleta)
        {
            return cadenaCompleta.Split(",").Last();
        }

        string FormatearNombreArchivo(string nombreCientifico, string fileName, string stringFotoBD)
        {
            string mensajeError = "ERROR";
            if (string.IsNullOrWhiteSpace(nombreCientifico))
                return mensajeError;

            string nombreFormateado = nombreCientifico.Trim();
            nombreFormateado = nombreFormateado.Replace(" ", "_").ToLower();

            bool esPng = false;
            bool esJpg = false;
            int indiceExtension = fileName.IndexOf(".png");
            if (indiceExtension != 0 && fileName.IndexOf(".png") + 4 == fileName.Length)
                esPng = true;

            if (!esPng)
            {
                indiceExtension = fileName.IndexOf(".jpg");
                if (indiceExtension != 0 && fileName.IndexOf(".jpg") + 4 == fileName.Length)
                    esJpg = true;
            }
            if (!esPng && !esJpg)
                return mensajeError;

            int numeracionConvertida = 0;
            if (string.IsNullOrWhiteSpace(stringFotoBD))
                nombreFormateado += "_001";
            else
            {
                string[] nombresFoto;
                nombresFoto = stringFotoBD.Split(",");
                string ultimaFoto = nombresFoto[nombresFoto.Count() - 1];

                string numeracionFoto = ultimaFoto.Substring(ultimaFoto.Length - 7, 3);
                numeracionConvertida = Convert.ToInt32(numeracionFoto) + 1;
                if (numeracionConvertida < 100 && numeracionConvertida >= 10)
                    numeracionFoto = "0" + numeracionConvertida.ToString();
                else if (numeracionConvertida < 10)
                    numeracionFoto = "00" + numeracionConvertida.ToString();
                else
                    numeracionFoto = numeracionConvertida.ToString();

                nombreFormateado = "," + nombreFormateado+"_" + numeracionFoto;
            }

            if (esPng)
                nombreFormateado += ".png";
            else
                nombreFormateado += ".jpg";
            return nombreFormateado;
        }
    }
}