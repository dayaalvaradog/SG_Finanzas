using _1_SGF_Presentacion.Helpers;
using _1_SGF_Presentacion.Models;
using _2_SGF_Modelo.Entidades;
using _2_SGF_Modelo.Entidades.Login;
using _4_SGF_API.Controllers;
using _6_SGF_Entidades.Catalogos;
using _6_SGF_Entidades.Login;
using _8_SGF_Log;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
            var datosUsuario = new Respuesta<DatosUsuario>();
            var permisos = new Respuesta<List<PermisoUsuario>>();
            var UsuarioAutenticado = new Usuario();
            try
            {
                resultado = await LoginModel.ValidarUsuario(Usuario, Contraseña);
                HttpContext.Session.Remove("Usuario");

                if (resultado.Result != null)
                {
                    if ((resultado.Result.TipoRespuesta == 1) && (resultado.Result.CodUsuario.HasValue))
                    {
                        datosUsuario = await LoginModel.ObtenerDatosUsuario(resultado.Result.CodUsuario.Value); 
                        if (datosUsuario.Result != null)
                        {
                            UsuarioAutenticado.datosUsuario = datosUsuario.Result;
                        }
                        var permisosUsuario = await LoginModel.ObtenerPermisosUsuario(resultado.Result.CodUsuario.Value); 
                        if (permisosUsuario.Result != null)
                        {
                            UsuarioAutenticado.permisosUsuario = permisosUsuario.Result;
                        }
                        //Se guarda el usuario en la sesión
                        HttpContext.Session.SetString("Usuario", JsonConvert.SerializeObject(UsuarioAutenticado));
                        ViewBag.Usuario = UsuarioAutenticado;
                    }
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

        [HttpGet]
        public async Task<Respuesta<DatosUsuario>> ObtenerDatosUsuario(int Usuario)
        {
            var resultado = new Respuesta<DatosUsuario>();
            try
            {
                resultado = await LoginModel.ObtenerDatosUsuario(Usuario); // Usar await

                if (resultado.Result != null)
                {
                    return resultado;
                }
                else
                {
                    WriteLog.Log("ObtenerDatosUsuario", resultado.TextError, DatosAppSettings.GetData("Url:Log"), $"Usuario: {Usuario}");
                    resultado.TextError = "Ocurrió un error obteniendo los datos del usuario";
                    resultado.NumError = 1;
                    return resultado;
                }
            }
            catch (Exception ex)
            {
                WriteLog.Log("ObtenerDatosUsuario", (ex.InnerException != null ? ex.InnerException.Message : ex.Message),
                    DatosAppSettings.GetData("Url:Log"), $"Usuario: {Usuario}");
                resultado.TextError = "Ocurrió un error al consultar la información";
                resultado.NumError = 2;
                resultado.Result = null;

                return resultado;
            }
        }

        [HttpGet]
        public async Task<Respuesta<List<PermisoUsuario>>> ObtenerPermisosUsuario(int Usuario)
        {
            var resultado = new Respuesta<List<PermisoUsuario>>();
            try
            {
                resultado = await LoginModel.ObtenerPermisosUsuario(Usuario); // Usar await

                if (resultado.Result != null)
                {
                    return resultado;
                }
                else
                {
                    WriteLog.Log("ObtenerPermisosUsuario", resultado.TextError, DatosAppSettings.GetData("Url:Log"), $"Usuario: {Usuario}");
                    resultado.TextError = "Ocurrió un error obteniendo los permisos del usuario";
                    resultado.NumError = 1;
                    return resultado;
                }
            }
            catch (Exception ex)
            {
                WriteLog.Log("ObtenerPermisosUsuario", (ex.InnerException != null ? ex.InnerException.Message : ex.Message),
                    DatosAppSettings.GetData("Url:Log"), $"Usuario: {Usuario}");
                resultado.TextError = "Ocurrió un error al consultar la información";
                resultado.NumError = 2;
                resultado.Result = null;

                return resultado;
            }
        }
    }
}
