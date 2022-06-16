using Dominio.Entidades;
using Fachada;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;


namespace ProyectoWeb.Controllers
{
    public class UsuariosController : Controller, IValidarSesion
    {
        public IManejadorUsuarios manejadorUsuarios { get; set; }

        public UsuariosController(IManejadorUsuarios manejUsuarios)
        {
            manejadorUsuarios = manejUsuarios;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {            
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(string email, string contrasenia)
        {
            Usuario user = null;
            user = manejadorUsuarios.BuscarUsuarioPorSuEmail(email);
            if (user != null && user.Activo && user.Contrasenia == contrasenia)
            {
                HttpContext.Session.SetInt32("userId", user.id);
                
                HttpContext.Session.SetString("userEmail", user.Email);
                return RedirectToAction("Index", "Plantas");
            }           
            return View();
        }
        
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            var valor = HttpContext.Session.GetInt32("userId");
            return RedirectToAction("Login");
        }
        [HttpGet]
        public ActionResult Create()
        {
            Usuario user = new Usuario();
            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario user)
        {
            try
            {
                bool pudeCrear = manejadorUsuarios.AgregarNuevoUsuario(user);
                if (!pudeCrear)
                    return View(user);
            }
            catch (Exception ex)
            {
                return View(user);
            }
            return RedirectToAction("Login");
        }


        [HttpGet]
        public ActionResult Edit()
        {
            if (!EstoyLogueado())
                return RedirectToAction("Logout", "Usuarios");
            Usuario user = manejadorUsuarios.BuscarUsuarioPorSuEmail(HttpContext.Session.GetString("userEmail"));
            if (user.id == HttpContext.Session.GetInt32("userId"))
                return Redirect("Usuarios/Edit");
            return RedirectToAction("Logout");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Usuario user)
        {
            try
            {
                bool pudeEditar = manejadorUsuarios.ActualizarUsuario(user);
                if (!pudeEditar)
                    return View();
            }
            catch (Exception ex)
            {
                return View();
            }
            return RedirectToAction("Plantas/Index");
        }
        [HttpGet]
        public ActionResult Delete()
        {
            if (!EstoyLogueado())
                return RedirectToAction("Logout", "Usuarios");

            Usuario user = manejadorUsuarios.BuscarUsuarioPorSuEmail(HttpContext.Session.GetString("userEmail"));
            if (user.id == HttpContext.Session.GetInt32("userId"))
                return Redirect("Usuarios/Delete");
            return RedirectToAction("Logout");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Usuario user)
        {
            try
            {
                bool pudeBorrar = manejadorUsuarios.DarDeBajaUsuario(user.id);
                if (!pudeBorrar)
                    return View();
            }
            catch (Exception ex)
            {
                return View();
            }
            return RedirectToAction("Logout");
        }

        public bool EstoyLogueado()
        {
            return HttpContext.Session.GetInt32("userId") != null;
        }
    }


}