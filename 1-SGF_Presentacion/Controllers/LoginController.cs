using _1_SGF_Presentacion.Helpers;
using _1_SGF_Presentacion.Models;
using _2_SGF_Modelo.Entidades;
using _2_SGF_Modelo.Entidades.Login;
using _4_SGF_API.Controllers;
using _6_SGF_Entidades.Catalogos;
using _6_SGF_Entidades.Login;
using _7_SGF_Comun.API;
using _8_SGF_Log;
using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace _1_SGF_Presentacion.Controllers
{
    public class LoginController : Controller
    {
        private readonly ISGFService _service;

        public LoginController(ISGFService sgfService)
        {
            _service = sgfService;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Registrarse()
        {
            return View();
        }

        public IActionResult CambiarContraseña()
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
                HttpContext.Session.Remove("Catalogos");

                if (resultado.Result != null)
                {
                    if ((resultado.Result.TipoRespuesta == 1) && (resultado.Result.CodUsuario.HasValue))
                    {
                        datosUsuario = ObtenerDatosUsuario(resultado.Result.CodUsuario.Value).Result; 
                        if (datosUsuario.Result != null)
                        {
                            UsuarioAutenticado.datosUsuario = datosUsuario.Result;
                        }
                        var permisosUsuario = ObtenerPermisosUsuario(resultado.Result.CodUsuario.Value).Result; 
                        if (permisosUsuario.Result != null)
                        {
                            UsuarioAutenticado.permisosUsuario = permisosUsuario.Result;
                        }
                        //Se guarda el usuario en la sesión
                        HttpContext.Session.SetString("Usuario", JsonConvert.SerializeObject(UsuarioAutenticado));
                        ViewBag.Usuario = UsuarioAutenticado;
                    }
                    //se carga la lista de catálogos
                    ListaCatalogos catalogos = CatalogoController.CargarCatalogos();
                    ViewBag.Catalogos = catalogos;
                    HttpContext.Session.SetString("Catalogos", JsonConvert.SerializeObject(catalogos));

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
                resultado = await LoginModel.ObtenerPermisosUsuario(Usuario);

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

        [HttpPost]
        public async Task<Respuesta<bool>> RegistrarUsuario(string datos)
        {
            try
            {
                DatosRegistroUsuario? DatosUsuario = JsonConvert.DeserializeObject<DatosRegistroUsuario>(datos);
                if (ModelState.IsValid)
                {
                    ResponseDto? response = await _service.RegistrarUsuario(DatosUsuario);

                    if (response != null && response.IsSuccess == true)
                    {
                        return new Respuesta<bool> { Result = true };
                    }

                }
                return new Respuesta<bool> { Result = false, NumError = 1, TextError = "Ocurrió un error en el registro del usuario" };
            }
            catch (Exception ex)
            {
                WriteLog.Log("RegistrarUsuario", (ex.InnerException != null ? ex.InnerException.Message : ex.Message),
                    DatosAppSettings.GetData("Url:Log"), $"Datos: {datos}");
                return new Respuesta<bool> { Result = false, NumError = 1, TextError = "Ocurrió un error en el registro del usuario" };

            }
        }

        [HttpGet]
        public async Task<Respuesta<RespuestaLogin>> RecuperarContrasenia(string datos)
        {
            //Se deserializa el objeto de validacion
            DatosUsuario? DatosUsuario = JsonConvert.DeserializeObject<DatosUsuario>(datos);
            Respuesta<RespuestaLogin> respuesta = new Respuesta<RespuestaLogin>();

            try
            {
                if (DatosUsuario != null)
                {
                    ResponseDto? resultado = await _service.RecuperarContrasenia(DatosUsuario);

                    //Se valida si el resultado es correcto
                    if (resultado != null && resultado.IsSuccess == true)
                    {
                        string json = Convert.ToString(resultado.Data);
                        respuesta = JsonConvert.DeserializeObject<Respuesta<RespuestaLogin>>(json);
                        //Se retorna el resultado
                        return respuesta;
                    }
                    else
                    {
                        WriteLog.Log("RecuperarContraseña", respuesta.TextError, DatosAppSettings.GetData("Url:Log"), $"Datos: {datos}");
                        respuesta.TextError = "Ocurrió un error en la recuperación de la contraseña";
                        respuesta.NumError = 1;
                        return respuesta;
                    }
                }
                else
                {
                    WriteLog.Log("RecuperarContraseña", respuesta.TextError, DatosAppSettings.GetData("Url:Log"), $"Datos: {datos}");
                    respuesta.TextError = "Ocurrió un error en los datos del usuario";
                    respuesta.NumError = 3;
                    return respuesta;
                }
            }
            catch (Exception ex)
            {
                WriteLog.Log("RecuperarContraseña", (ex.InnerException != null ? ex.InnerException.Message : ex.Message),
                    DatosAppSettings.GetData("Url:Log"), $"Datos: {datos}");
                respuesta.TextError = "Ocurrió un error al consultar la información";
                respuesta.NumError = 2;
                respuesta.Result = null;

                return respuesta;
            }
        }

        [HttpGet]
        public async Task<Respuesta<bool>> ValidaIdUsuarioExiste(string Usuario) 
        { 
            var resultado = new Respuesta<bool>();
            try
            {
                resultado = await LoginModel.ValidaIdUsuarioExiste(Usuario);

                if (resultado.Result != false)
                {
                    return resultado;
                }
                else
                {
                    WriteLog.Log("ValidaIdUsuarioExiste", resultado.TextError, DatosAppSettings.GetData("Url:Log"), $"Usuario: {Usuario}");
                    resultado.TextError = "Ocurrió un error validando el usuario";
                    resultado.NumError = 1;
                    return resultado;
                }
            }
            catch (Exception ex)
            {
                WriteLog.Log("ValidaIdUsuarioExiste", (ex.InnerException != null ? ex.InnerException.Message : ex.Message),
                    DatosAppSettings.GetData("Url:Log"), $"Usuario: {Usuario}");
                resultado.TextError = "Ocurrió un error al consultar la información";
                resultado.NumError = 2;
                resultado.Result = false;

                return resultado;
            }
        }

        [HttpGet]
        public async Task<Respuesta<bool>> ValidarCorreoExiste(string correo) 
        { 
            var resultado = new Respuesta<bool>();
            try
            {
                resultado = await LoginModel.ValidarCorreoExiste(correo);

                if (resultado.Result != false)
                {
                    return resultado;
                }
                else
                {
                    WriteLog.Log("ValidarCorreoExiste", resultado.TextError, DatosAppSettings.GetData("Url:Log"), $"Correo: {correo}");
                    resultado.TextError = "Ocurrió un error validando el correo";
                    resultado.NumError = 1;
                    return resultado;
                }
            }
            catch (Exception ex)
            {
                WriteLog.Log("ValidarCorreoExiste", (ex.InnerException != null ? ex.InnerException.Message : ex.Message),
                    DatosAppSettings.GetData("Url:Log"), $"Correo: {correo}");
                resultado.TextError = "Ocurrió un error al consultar la información";
                resultado.NumError = 2;
                resultado.Result = false;

                return resultado;
            }
        }
    }
}
