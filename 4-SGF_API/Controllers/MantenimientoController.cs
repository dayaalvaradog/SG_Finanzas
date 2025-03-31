using _2_SGF_Modelo.Entidades;
using _3_SGF_AccesoDatos;
using _4_SGF_API.Helpers;
using _5_SGF_Interfaces;
using _6_SGF_Entidades.Cuenta;
using _6_SGF_Entidades.Movimiento;
using _8_SGF_Log;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _4_SGF_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MantenimientoController : Controller
    {
        IMantenimiento mantenimiento;
        public MantenimientoController(IMantenimiento _mantenimiento)
        {
            mantenimiento = _mantenimiento;
        }

        [HttpPost]
        [Route("InsertarCuenta")]
        public IActionResult InsertarCuenta(CuentaBancaria cuenta)
        {
            Respuesta<bool> response = new Respuesta<bool>();
            try
            {
                response.Result = mantenimiento.InsertarCuenta(cuenta);
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.TextError = (ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                response.NumError = 1;
                WriteLog.Log("Login InsertarCuenta", response.TextError, DatosAppSettingsApi.GetData("Url:LogApi"), "");
                return BadRequest(response);
            }
        }

    }
}
