using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace BL
{
    public class SuperDigito
    {
        public static ML.Result Add(ML.SuperDigito digito)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.APozosSuperDigitoEntities context = new DL.APozosSuperDigitoEntities())
                {
                    var query = context.DigitoAdd(digito.Numero, digito.Resultado, digito.FechaHora,digito.Usuario.IdUsuario);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;

                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result Update(ML.SuperDigito digito)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.APozosSuperDigitoEntities context = new DL.APozosSuperDigitoEntities())
                {
                    var query = context.DigitoUpdate(digito.Numero, digito.Usuario.IdUsuario);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;

                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result GetHistorial(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.APozosSuperDigitoEntities context = new DL.APozosSuperDigitoEntities())
                {
                    var query = context.DigitoHistorial(IdUsuario).ToList();
                    result.Objects = new List<object>();
                    if(query != null)
                    {
                        foreach(var obj in query)
                        {
                            ML.SuperDigito digito = new ML.SuperDigito();
                            digito.Numero = obj.Numero.Value;
                            digito.Resultado = obj.Resultado.Value;
                            digito.FechaHora = obj.FechaHora.ToString();

                            result.Objects.Add(digito);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result DeleteHistorial(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.APozosSuperDigitoEntities context = new DL.APozosSuperDigitoEntities())
                {
                    var query = context.HistorialDelete(IdUsuario);
                    if(query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result DeleteHistorialBy(ML.SuperDigito digito)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.APozosSuperDigitoEntities context = new DL.APozosSuperDigitoEntities())
                {
                    var query = context.HistorialDeleteBy(digito.Numero, digito.Usuario.IdUsuario);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }
}
