using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult LoginInicio()
        {
            ML.Usuario usuario = new ML.Usuario();
            return View(usuario);
        }
        [HttpPost]
        public ActionResult LoginInicio(ML.Usuario usuarioLogin)
        {
            ML.Result result = BL.Usuario.GetByUserName(usuarioLogin.UserName);

            if (result.Correct)
            {
                ML.Usuario usuario = (ML.Usuario)result.Object;
                if (usuarioLogin.Password == usuario.Password)
                {
                    Session["IdUsuario"] = usuario.IdUsuario;
                    return RedirectToAction("Calcular", "SuperDigito");
                }
                else
                {
                    ViewBag.LoginMensaje = "Datos incorrectos";
                    return View("Modal");
                }
            }
            else
            {
                ViewBag.LoginMensaje = "El correo no está registrado";
            }
            return View("Modal");
        }

        [HttpGet]
        public ActionResult LoginRegistro()
        {
            ML.Usuario usuario = new ML.Usuario();
            return View(usuario);
        }
        [HttpPost]

        public ActionResult LoginRegistro(ML.Usuario usuario)
        {

            ML.Result result = BL.Usuario.Add(usuario);
            if (result.Correct)
            {
                ViewBag.LoginMensaje = "Registro exitoso";
            }
            else
            {
                ViewBag.LoginMensaje = "Ocurrio un error" + result.ErrorMessage;

            }
            return View("Modal");
        }
    }
}