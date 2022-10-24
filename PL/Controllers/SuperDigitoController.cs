using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class SuperDigitoController : Controller
    {
        [HttpGet]
        public ActionResult Calcular()
        {
            ML.SuperDigito historial = new ML.SuperDigito();
            historial.Usuario = new ML.Usuario();
            historial.Usuario.IdUsuario = int.Parse(Session["IdUsuario"].ToString());
            ML.Result result = BL.Usuario.GetById(historial.Usuario.IdUsuario);
            ML.Result resultHistorial = BL.SuperDigito.GetHistorial(historial.Usuario.IdUsuario);
            historial.Usuario = (ML.Usuario)result.Object;
            if (resultHistorial.Correct)
            {
                historial.Historiales = resultHistorial.Objects;
            }
            else
            {
                resultHistorial.Correct = false;
            }
            return View(historial);
        }

        [HttpPost]
        public ActionResult Calcular(ML.SuperDigito historial)
        {
            historial.Usuario = new ML.Usuario();
            historial.Usuario.IdUsuario = int.Parse(Session["IdUsuario"].ToString());
            ML.Result resultDigito = BL.SuperDigito.GetByIdSuperDigito(historial.Numero);

            ML.Result resultUsuario = BL.Usuario.GetById(historial.Usuario.IdUsuario);
            historial.Usuario = (ML.Usuario)resultUsuario.Object;
            if (resultDigito.Correct)
            {
                ML.Result resultNumero = BL.SuperDigito.Update(historial);
            }
            else
            {
                int suma = 0;
                string numeros = historial.Numero.ToString();

                do
                {
                    suma = 0;
                    char[] arrayNumeros = numeros.ToCharArray();

                    foreach (char numero in arrayNumeros)
                    {
                        suma += int.Parse(numero.ToString());
                    }
                    if (suma >= 10)
                    {
                        numeros = suma.ToString();
                        arrayNumeros = numeros.ToCharArray();

                    }
                }
                while (suma >= 10);

                historial.Resultado = suma;

                ML.Result result = BL.SuperDigito.Add(historial);
            }
            ML.Result resultHistorial = BL.SuperDigito.GetHistorial(historial.Usuario.IdUsuario);
            {
                historial.Historiales = resultHistorial.Objects;
            }

            return View(historial);
        }

        [HttpGet]
        public ActionResult DeleteHistorial()
        {
            ML.SuperDigito historial = new ML.SuperDigito();
            historial.Usuario = new ML.Usuario();

            historial.Usuario.IdUsuario = int.Parse(Session["IdUsuario"].ToString());
            ML.Result resultUsuario = BL.Usuario.GetById(historial.Usuario.IdUsuario);
            historial.Usuario = (ML.Usuario)resultUsuario.Object;
            if (resultUsuario.Correct)
            {
                ML.Result resultNumero = BL.SuperDigito.DeleteHistorial(historial.Usuario.IdUsuario);
                ViewBag.MensajeDigito = "Historial borrado exitósamente";
            }
            else
            {
                ViewBag.MensajeDigito = "Error al borrar el historial";
            }
            return View("Modal");
        }
        public ActionResult DeleteHistorialById(int numero)
        {
            ML.SuperDigito historial = new ML.SuperDigito();
            historial.Usuario = new ML.Usuario();
            historial.Usuario.IdUsuario = int.Parse(Session["IdUsuario"].ToString());
            historial.Numero = numero;

            ML.Result resultDigito = BL.SuperDigito.GetByIdSuperDigito(historial.Numero);

            historial = (ML.SuperDigito)resultDigito.Object;

            ML.Result result = BL.SuperDigito.DeleteHistorialById(historial);
            if (resultDigito.Correct)
            {
                if (result.Correct)
                {
                    ViewBag.MensajeDigito = "Registro borrado correctamente";
                }
                else
                {
                    ViewBag.MensajeDigito = "Error al borrar el registro";
                }
            }
            return View("Modal");
        }
    }
}