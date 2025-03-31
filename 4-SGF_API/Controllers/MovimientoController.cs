using _2_SGF_Modelo.Entidades;
using _3_SGF_AccesoDatos;
using _4_SGF_API.Helpers;
using _5_SGF_Interfaces;
using _6_SGF_Entidades.Movimiento;
using _8_SGF_Log;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _4_SGF_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MovimientoController : Controller
    {
        IMovimiento movimiento;
        public MovimientoController(IMovimiento _movimiento)
        {
            movimiento = _movimiento;
        }

        [HttpPost]
        [Route("InsertarMovimiento")]
        public IActionResult InsertarMovimiento(Movimiento datos)
        {
            Respuesta<bool> response = new Respuesta<bool>();
            try
            {
                response.Result = movimiento.InsertarMovimiento(datos);
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.TextError = (ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                response.NumError = 1;
                WriteLog.Log("Login InsertarMovimiento", response.TextError, DatosAppSettingsApi.GetData("Url:LogApi"), "");
                return BadRequest(response);
            }
        }

        [HttpGet]
        [Route("ObtenerMovimientos/{Usuario}")]
        public IActionResult ObtenerMovimientos(int Usuario)
        {
            Respuesta<List<Movimiento>> response = new Respuesta<List<Movimiento>>();
            try
            {
                response.Result = movimiento.ObtenerMovimientos(Usuario);
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.TextError = (ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                response.NumError = 1;
                WriteLog.Log("Login ObtenerMovimientos", response.TextError, DatosAppSettingsApi.GetData("Url:LogApi"), "");
                return BadRequest(response);
            }
        }
    }
}
