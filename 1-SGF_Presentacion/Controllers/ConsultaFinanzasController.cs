using _1_SGF_Presentacion.Helpers;
using _1_SGF_Presentacion.Models;
using _2_SGF_Modelo.Entidades;
using _6_SGF_Entidades.Catalogos;
using _6_SGF_Entidades.Movimiento;
using _8_SGF_Log;
using Microsoft.AspNetCore.Mvc;

namespace _1_SGF_Presentacion.Controllers
{
    public class ConsultaFinanzasController : Controller
    {
        public IActionResult ConsultaMovimientos()
        {
            return View();
        }

        [HttpGet]
        public async Task<Respuesta<List<Movimiento>>> ObtenerMovimientos(int Usuario)
        {
            var resultado = new Respuesta<List<Movimiento>>();
            try
            {
                resultado = await MovimientoModel.ObtenerMovimientos(Usuario);

                if (resultado.Result != null)
                {
                    return resultado;
                }
                else
                {
                    WriteLog.Log("ObtenerMovimientos", resultado.TextError, DatosAppSettings.GetData("Url:Log"), $"Usuario: {Usuario}");
                    resultado.TextError = "Ocurrió un error obteniendo los movimientos";
                    resultado.NumError = 1;
                    return resultado;
                }
            }
            catch (Exception ex)
            {
                WriteLog.Log("ObtenerMovimientos", (ex.InnerException != null ? ex.InnerException.Message : ex.Message),
                    DatosAppSettings.GetData("Url:Log"), $"Usuario: {Usuario}");
                resultado.TextError = "Ocurrió un error al consultar la información";
                resultado.NumError = 2;
                resultado.Result = null;

                return resultado;
            }
        }
    }
}
