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
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email, string contrasenia)
        {
            Usuario user = null;
            user = manejadorUsuarios.BuscarUsuarioPorSuEmail(email);
            if (user != null && user.activo && user.contrasenia == contrasenia)
            {
                HttpContext.Session.SetInt32("userId", user.id);
                return Redirect("Plantas/Index");
            }
            //mensaje de error al loguearse?
            return Redirect("Login/Index");
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("Login/Index");
        }

    }   
}
