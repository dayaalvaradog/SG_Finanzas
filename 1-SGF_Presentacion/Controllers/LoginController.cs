using _1_SGF_Presentacion.Helpers;
using _1_SGF_Presentacion.Models;
using _2_SGF_Modelo.Entidades;
using _2_SGF_Modelo.Entidades.Login;
using _4_SGF_API.Controllers;
using _8_SGF_Log;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace _1_SGF_Presentacion.Controllers
{
    public class LoginController : Controller
    {
        private readonly List<SpecialDate> _SpecialDates;
        public LoginController(IOptionsMonitor<List<SpecialDate>> options)
        {
            _SpecialDates = options.CurrentValue;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Registrarse()
        {
            return View();
        }

        [HttpGet]
        public async Task<Respuesta<RespuestaLogin>> ValidarUsuario(string Usuario, string Contraseña)
        {
            var resultado = new Respuesta<RespuestaLogin>();
            try
            {
                resultado = await LoginModel.ValidarUsuario(Usuario, Contraseña); // Usar await

                if (resultado.Result != null)
                {
                    return resultado;
                }
                else
                {
                    WriteLog.Log("ValidarUsuario", resultado.TextError, DatosAppSettings.GetData("Url:Log"), $"Usuario: {Usuario}, Contraseña: {Contraseña}");
                    resultado.TextError = "Ocurrió un error obteniendo los datos";
                    resultado.NumError = 1;
                    return resultado;
                }
            }
            catch (Exception ex)
            {
                WriteLog.Log("ValidarUsuario", (ex.InnerException != null ? ex.InnerException.Message : ex.Message),
                    DatosAppSettings.GetData("Url:Log"), $"Usuario: {Usuario} Contraseña: {Contraseña}");
                resultado.TextError = "Ocurrió un error al consultar la información";
                resultado.NumError = 2;
                resultado.Result = null;

                return resultado;
            }
        }
    }
}
