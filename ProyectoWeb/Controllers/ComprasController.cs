using Dominio.Entidades;
using Fachada;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ViveroDTOs;

namespace ProyectoWeb.Controllers
{
    public class ComprasController : Controller
    {

        public IManejadorCompras manejadorCompras { get; set; }
        public ComprasController(IManejadorCompras unMC)
        {
            manejadorCompras = unMC;
        }


        // GET: ComprasController
        public ActionResult Index()
        {
            return View(ObtenerTodasLasCompras());//Revisar como se manejan los objetos cando llegan a la vista. Esta recibiendo generico, pero tiene la data de ambos especializados
        }

        // GET: ComprasController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ComprasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ComprasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: ComprasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ComprasController/Edit/5
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

        // GET: ComprasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ComprasController/Delete/5
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
        public IEnumerable<Compra> ObtenerTodasLasCompras()
        {
            return manejadorCompras.ObtenerTodasLasCompras();
        }
        public ActionResult ComprasPorTipoPlantaId(int id)
        {

            HttpClient cliente = new HttpClient();
            List<CompraDTO> dtos = new List<CompraDTO>();
            Task<HttpResponseMessage> respuesta = cliente.GetAsync("http://localhost:5000/api/compras/ComprasTipoPlanta/"+ id);
            respuesta.Wait();

            if (respuesta.Result.IsSuccessStatusCode)
            {
                Task<string> contenido = respuesta.Result.Content.ReadAsStringAsync();
                contenido.Wait();

                string json = contenido.Result;
                dtos = JsonConvert.DeserializeObject<List<CompraDTO>>(json);
            }
            else
                ViewBag.Error = "No se han podido obtener las compras solicitadas";

            return View(dtos);
        }
    }
}
