using AppMVC06.Dao;
using AppMVC06.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppMVC06.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Autenticar(Empleado usuario)
        {
            EmpleadoDao dao = new EmpleadoDao();
            try
            {
                Empleado usuario1 = dao.validar(usuario.Nombre, usuario.Apellidos);
                if (usuario1 == null)
                {
                    usuario.LoginErrorMessage = "Usuario o Password es Incorrecto.";
                    return View("Index", usuario);
                }
                else
                {
                    Session["userID"] = usuario.IdEmpleado;
                    Session["userName"] = usuario.Nombre;
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public ActionResult LogOut()
        {
            int userId = (int)Session["userID"];
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

    }
}