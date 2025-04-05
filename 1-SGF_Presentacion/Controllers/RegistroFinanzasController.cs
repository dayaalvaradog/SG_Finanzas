using _1_SGF_Presentacion.Helpers;
using _1_SGF_Presentacion.Models;
using _2_SGF_Modelo.Entidades;
using _6_SGF_Entidades.Login;
using _6_SGF_Entidades.Movimiento;
using _7_SGF_Comun.API;
using _8_SGF_Log;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace _1_SGF_Presentacion.Controllers
{
    public class RegistroFinanzasController : Controller
    {
        private readonly ISGFService _service;

        public RegistroFinanzasController(ISGFService sgfService)
        {
            _service = sgfService;
        }

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
            try
            {
                //Se deserializa el objeto de validacion
                Movimiento? movimiento = JsonConvert.DeserializeObject<Movimiento>(datos);

                if (ModelState.IsValid)
                {
                    ResponseDto? response = await _service.InsertarMovimiento(movimiento);

                    if (response != null && response.IsSuccess == true)
                    {
                        return new Respuesta<bool> { Result = true };
                    }

                }
                return new Respuesta<bool> { Result = false, NumError = 1, TextError = "Ocurrió un error en el registro del movimiento" };
            }
            catch (Exception ex)
            {
                WriteLog.Log("InsertarMovimiento", (ex.InnerException != null ? ex.InnerException.Message : ex.Message),
                    DatosAppSettings.GetData("Url:Log"), $"Datos: {datos}");
                return new Respuesta<bool> { Result = false, NumError = 1, TextError = "Ocurrió un error en el registro del movimiento" };

            }
        }
    }
}
