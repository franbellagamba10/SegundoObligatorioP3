using Dominio.Entidades;
using Fachada;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoWeb.Controllers
{
    public class UsuariosController : Controller
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
            HttpContext.Session.Clear();
            return Redirect("Login");
        }

        [HttpPost]
        public ActionResult Login(string email, string contrasenia)
        {
            Usuario user = null;
            user = manejadorUsuarios.BuscarUsuarioPorSuEmail(email);
            if (user != null && user.activo && user.contrasenia == contrasenia)
            {
                HttpContext.Session.SetInt32("userId", user.id);
                HttpContext.Session.SetString("userEmail", user.email);
                return Redirect("Plantas/Index");
            }
            //mensaje de error al loguearse?
            return View();
        }
        [HttpPost]
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
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
                    return View(user); //deberia volver al formulario de edicion de usuario
            }
            catch (Exception ex)
            {
                return View(user); //deberia volver al formulario edicion de usuario
            }
            return RedirectToAction("Login"); //  -----> REVISAR, necesitamos que vaya al Indice de plantas
        }


        [HttpGet]
        public ActionResult Edit()
        {
            Usuario user = manejadorUsuarios.BuscarUsuarioPorSuEmail(HttpContext.Session.GetString("userEmail"));
            if(user.id == HttpContext.Session.GetInt32("userId"))
                return Redirect("Usuarios/Edit");
            return RedirectToAction("Logout");      
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Usuario user) // ----> consultar con Plinio, capaz hay que pasarle usuario completo
        {            
            try
            {
                bool pudeEditar = manejadorUsuarios.ActualizarUsuario(user);
                if (!pudeEditar)                    
                    return View(); //deberia volver al formulario de edicion de usuario
            }             
            catch (Exception ex)
            {
                return View(); //deberia volver al formulario edicion de usuario
            }
            return RedirectToAction("Plantas/Index"); //  -----> REVISAR, necesitamos que vaya al Indice de plantas
        }
        [HttpGet]
        public ActionResult Delete()
        {
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
                    return View(); // ---> Revisar, lo devuelvo a la vista de delete?
            }
            catch (Exception ex)
            {
                return View(); //deberia volver al formulario edicion de usuario
            }
            return RedirectToAction("Logout"); //  -----> REVISAR, necesitamos que vaya al Indice de plantas
        }
    }   

 
}
