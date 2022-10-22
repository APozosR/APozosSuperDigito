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

            ML.Result resultHistorial = BL.SuperDigito.GetHistorial(historial.Usuario.IdUsuario);

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
       //     ML.Result result = BL.Usuario.GetByUserName();
           // ML.Result resultHistorial = BL.SuperDigito.GetHistorial(historial.Usuario.IdUsuario);   //DESPUES DE ADD O UPDATE

            //GETBYSUPERDIGITO //IDHISTORIAL //RESULTADO
            //TRUE   //UPDATE 
            //FALSE  //CALCULAR //ADD
            //if (historial.Usuario.IdUsuario == 0)
            //{
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
                if (result.Correct)
                {
                    ViewBag.MensajeDigito = "Cálculo agregado correctamente";
                }
                else
                {
                    ViewBag.MensajeDigito = "Error al añadir el cálculo";
                }
            //}
            //else
            //{
            //    ML.Result result = BL.SuperDigito.Update(historial);
            //    if (result.Correct)
            //    {
            //        ViewBag.MensajeDigito = "Resultado existente, fecha actualizada";
            //    }
            //    else
            //    {
            //        ViewBag.MensajeDigito = "Error al actualizar";
            //    }
        //}

            return View(historial);
        }

        [HttpGet]
        public ActionResult DeleteHistorial()
        {
            ML.SuperDigito historial = new ML.SuperDigito();
            historial.Usuario = new ML.Usuario();
            historial.Usuario.IdUsuario = int.Parse(Session["IdUsuario"].ToString());
            ML.Result result = BL.SuperDigito.DeleteHistorial(historial.Usuario.IdUsuario);
            if (result.Correct)
            {
                ViewBag.MensajeDigito = "Historial borrrado correctamente";
            }
            else
            {
                ViewBag.MensajeDigito = "Error al borrar el historial";
            }
            return View("Modal");
        }
        public ActionResult DeleteHistorialBy(int numero)
        {
            ML.SuperDigito historial = new ML.SuperDigito();
            historial.Usuario = new ML.Usuario();
            historial.Usuario.IdUsuario = int.Parse(Session["IdUsuario"].ToString());
            historial.Numero = numero;
            ML.Result result = BL.SuperDigito.DeleteHistorialBy(historial);
            if (result.Correct)
            {
                ViewBag.MensajeDigito = "Registro borrado correctamente";
            }
            else
            {
                ViewBag.MensajeDigito = "Error al borrar el registro";
            }
            return View("Modal");
        }
    }
}