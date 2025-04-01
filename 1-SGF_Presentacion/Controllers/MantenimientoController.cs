using _1_SGF_Presentacion.Helpers;
using _1_SGF_Presentacion.Models;
using _2_SGF_Modelo.Entidades;
using _6_SGF_Entidades.Cuenta;
using _6_SGF_Entidades.Login;
using _8_SGF_Log;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace _1_SGF_Presentacion.Controllers
{
    public class MantenimientoController : Controller
    {
        [HttpPost]
        public async Task<Respuesta<bool>> InsertarCuenta(string datos)
        {
            //Se deserializa el objeto de validacion
            CuentaBancaria? cuentaBancaria = JsonConvert.DeserializeObject<CuentaBancaria>(datos);

            var resultado = new Respuesta<bool>();

            try
            {
                if (cuentaBancaria != null)
                {
                    resultado = await MantenimientoModel.InsertarCuenta(cuentaBancaria);

                    //Se valida si el resultado es correcto
                    if (resultado.Result != false)
                    {
                        //Se retorna el resultado
                        return resultado;
                    }
                    else
                    {
                        WriteLog.Log("InsertarCuenta", resultado.TextError, DatosAppSettings.GetData("Url:Log"), $"Datos: {datos}");
                        resultado.TextError = "Ocurrió un error en el registro de la cuenta";
                        resultado.NumError = 1;
                        return resultado;
                    }
                }
                else
                {
                    WriteLog.Log("InsertarCuenta", resultado.TextError, DatosAppSettings.GetData("Url:Log"), $"Datos: {datos}");
                    resultado.TextError = "Ocurrió un error en los datos de la cuenta";
                    resultado.NumError = 3;
                    return resultado;
                }
            }
            catch (Exception ex)
            {
                WriteLog.Log("InsertarCuenta", (ex.InnerException != null ? ex.InnerException.Message : ex.Message),
                    DatosAppSettings.GetData("Url:Log"), $"Datos: {datos}");
                resultado.TextError = "Ocurrió un error al consultar la información";
                resultado.NumError = 2;
                resultado.Result = false;

                return resultado;
            }
        }
    }
}
