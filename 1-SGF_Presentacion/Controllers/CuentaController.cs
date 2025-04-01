using _1_SGF_Presentacion.Helpers;
using _1_SGF_Presentacion.Models;
using _2_SGF_Modelo.Entidades;
using _6_SGF_Entidades.Catalogos;
using _6_SGF_Entidades.Cuenta;
using _8_SGF_Log;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace _1_SGF_Presentacion.Controllers
{
    public class CuentaController : Controller
    {
        private readonly List<SpecialDate> _SpecialDates;
        public CuentaController(IOptionsMonitor<List<SpecialDate>> options)
        {
            _SpecialDates = options.CurrentValue;
        }

        [HttpGet]
        public async Task<Respuesta<List<CuentaBancaria>>> ObtenerCuentasUsuario(int CodUsuario)
        {
            Respuesta<List<CuentaBancaria>> resultado = new Respuesta<List<CuentaBancaria>>();
            try
            {
                resultado = await CuentaModel.ObtenerCuentasUsuario(CodUsuario);

                if (resultado.Result != null)
                {
                    return resultado;
                }
                else
                {
                    WriteLog.Log("ObtenerCuentasUsuario", resultado.TextError, DatosAppSettings.GetData("Url:Log"), "");
                    resultado.TextError = "Ocurrió un error obteniendo los datos de cuentas del usuario";
                    resultado.NumError = 1;
                    return resultado;
                }
            }
            catch (Exception ex)
            {
                WriteLog.Log("ObtenerCuentasUsuario", (ex.InnerException != null ? ex.InnerException.Message : ex.Message),
                    DatosAppSettings.GetData("Url:Log"), "");
                resultado.TextError = "Ocurrió un error al consultar la información";
                resultado.NumError = 2;
                resultado.Result = null;

                return resultado;
            }

        }

        [HttpGet]
        public async Task<Respuesta<List<CuentaBancaria>>> ObtenerEstadoCuenta(int CodCuenta)
        {
            Respuesta<List<CuentaBancaria>> resultado = new Respuesta<List<CuentaBancaria>>();
            try
            {
                resultado = await CuentaModel.ObtenerEstadoCuenta(CodCuenta);

                if (resultado.Result != null)
                {
                    return resultado;
                }
                else
                {
                    WriteLog.Log("ObtenerEstadoCuenta", resultado.TextError, DatosAppSettings.GetData("Url:Log"), "");
                    resultado.TextError = "Ocurrió un error obteniendo los datos de la cuenta";
                    resultado.NumError = 1;
                    return resultado;
                }
            }
            catch (Exception ex)
            {
                WriteLog.Log("ObtenerEstadoCuenta", (ex.InnerException != null ? ex.InnerException.Message : ex.Message),
                    DatosAppSettings.GetData("Url:Log"), "");
                resultado.TextError = "Ocurrió un error al consultar la información";
                resultado.NumError = 2;
                resultado.Result = null;

                return resultado;
            }

        }

        [HttpGet]
        public async Task<Respuesta<EstadoCuenta>> ObtenerEstadoUsuario(int CodUsuario)
        {
            Respuesta<EstadoCuenta> resultado = new Respuesta<EstadoCuenta>();
            try
            {
                resultado = await CuentaModel.ObtenerEstadoUsuario(CodUsuario);

                if (resultado.Result != null)
                {
                    return resultado;
                }
                else
                {
                    WriteLog.Log("ObtenerEstadoUsuario", resultado.TextError, DatosAppSettings.GetData("Url:Log"), "");
                    resultado.TextError = "Ocurrió un error obteniendo el estado de cuentas del usuario";
                    resultado.NumError = 1;
                    return resultado;
                }
            }
            catch (Exception ex)
            {
                WriteLog.Log("ObtenerEstadoUsuario", (ex.InnerException != null ? ex.InnerException.Message : ex.Message),
                    DatosAppSettings.GetData("Url:Log"), "");
                resultado.TextError = "Ocurrió un error al consultar la información";
                resultado.NumError = 2;
                resultado.Result = null;

                return resultado;
            }

        }
    }
}
