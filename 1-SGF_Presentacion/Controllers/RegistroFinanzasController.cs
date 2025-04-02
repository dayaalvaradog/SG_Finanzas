using _1_SGF_Presentacion.Helpers;
using _1_SGF_Presentacion.Models;
using _2_SGF_Modelo.Entidades;
using _6_SGF_Entidades.Login;
using _6_SGF_Entidades.Movimiento;
using _8_SGF_Log;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace _1_SGF_Presentacion.Controllers
{
    public class RegistroFinanzasController : Controller
    {
        public IActionResult RegistrarMovimiento()
        {
            return View();
        }

        public IActionResult RegistrarPresupuesto()
        {
            return View();
        }

        public IActionResult RegistroMetasPresupuesto()
        {
            return View();
        }

        [HttpPost]
        public async Task<Respuesta<bool>> InsertarMovimiento(string datos)
        {
            //Se deserializa el objeto de validacion
            Movimiento? DatosUsuario = JsonConvert.DeserializeObject<Movimiento>(datos);

            var resultado = new Respuesta<bool>();

            try
            {
                if (DatosUsuario != null)
                {
                    //resultado = await MovimientoModel.InsertarMovimiento(DatosUsuario);

                    //Se valida si el resultado es correcto
                    if (resultado.Result != false)
                    {
                        //Se retorna el resultado
                        return resultado;
                    }
                    else
                    {
                        WriteLog.Log("InsertarMovimiento", resultado.TextError, DatosAppSettings.GetData("Url:Log"), $"Datos: {datos}");
                        resultado.TextError = "Ocurrió un error en el registro del movimiento";
                        resultado.NumError = 1;
                        return resultado;
                    }
                }
                else
                {
                    WriteLog.Log("InsertarMovimiento", resultado.TextError, DatosAppSettings.GetData("Url:Log"), $"Datos: {datos}");
                    resultado.TextError = "Ocurrió un error en los datos del movimiento";
                    resultado.NumError = 3;
                    return resultado;
                }
            }
            catch (Exception ex)
            {
                WriteLog.Log("InsertarMovimiento", (ex.InnerException != null ? ex.InnerException.Message : ex.Message),
                    DatosAppSettings.GetData("Url:Log"), $"Datos: {datos}");
                resultado.TextError = "Ocurrió un error al consultar la información";
                resultado.NumError = 2;
                resultado.Result = false;

                return resultado;
            }
        }
    }
}
