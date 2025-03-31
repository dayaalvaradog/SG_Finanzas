using _2_SGF_Modelo.Entidades;
using _4_SGF_API.Helpers;
using _5_SGF_Interfaces;
using _6_SGF_Entidades.Cuenta;
using _8_SGF_Log;
using Microsoft.AspNetCore.Mvc;

namespace _4_SGF_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CuentaController : Controller
    {
        ICuenta cuenta;
        public CuentaController(ICuenta _cuenta)
        {
            cuenta = _cuenta;
        }

        [HttpGet("ObtenerCuentasUsuario/{CodUsuario}")]
        public IActionResult ObtenerCuentasUsuario(int CodUsuario)
        {
            Respuesta<List<CuentaBancaria>> response = new Respuesta<List<CuentaBancaria>>();
            try
            {
                response.Result = cuenta.ObtenerCuentasUsuario(CodUsuario);
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.TextError = (ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                response.NumError = 1;
                WriteLog.Log("Cuenta ObtenerCuentasUsuario", response.TextError, DatosAppSettingsApi.GetData("Url:LogApi"), "");
                return BadRequest(response);
            }
        }

        [HttpGet("ObtenerEstadoCuenta/{CodCuenta}")]
        public IActionResult ObtenerEstadoCuenta(int CodCuenta)
        {
            Respuesta<EstadoCuenta> response = new Respuesta<EstadoCuenta>();
            try
            {
                response.Result = cuenta.ObtenerEstadoCuenta(CodCuenta);
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.TextError = (ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                response.NumError = 1;
                WriteLog.Log("Cuenta ObtenerEstadoCuenta", response.TextError, DatosAppSettingsApi.GetData("Url:LogApi"), "");
                return BadRequest(response);
            }
        }

        [HttpGet("ObtenerEstadoUsuario/{CodUsuario}")]
        public IActionResult ObtenerEstadoUsuario(int CodUsuario)
        {
            Respuesta<EstadoCuenta> response = new Respuesta<EstadoCuenta>();
            try
            {
                response.Result = cuenta.ObtenerEstadoUsuario(CodUsuario);
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.TextError = (ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                response.NumError = 1;
                WriteLog.Log("Cuenta ObtenerEstadoUsuario", response.TextError, DatosAppSettingsApi.GetData("Url:LogApi"), "");
                return BadRequest(response);
            }
        }
    }
}
