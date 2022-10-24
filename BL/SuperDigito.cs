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
                    var query = context.DigitoAdd(digito.Numero, digito.Resultado, digito.Fecha,digito.Usuario.IdUsuario);
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
                    var query = context.DigitoUpdate(digito.Numero);
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
                            digito.Fecha = obj.Fecha.ToString();

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
        public static ML.Result DeleteHistorialById(ML.SuperDigito digito)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.APozosSuperDigitoEntities context = new DL.APozosSuperDigitoEntities())
                {
                    var query = context.HistorialDeleteById(digito.IdSuperDigito);
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
        public static ML.Result GetByIdSuperDigito(int numero)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.APozosSuperDigitoEntities context = new DL.APozosSuperDigitoEntities())
                {
                    var query = context.DigitoGetByNumero(numero).FirstOrDefault();

                    if (query != null)
                    {
                        ML.SuperDigito digito = new ML.SuperDigito();
                        digito.IdSuperDigito = query.IdSuperDigito;
                        digito.Numero = query.Numero.Value;
                        digito.Resultado = query.Resultado.Value;
                        digito.Fecha = query.Fecha.ToString();

                        digito.Usuario = new ML.Usuario();
                        digito.Usuario.IdUsuario = query.IdUsuario.Value;

                        result.Object = digito;
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
    }
}
