using _2_SGF_Modelo.Entidades;
using _2_SGF_Modelo.Entidades.Login;
using _3_SGF_AccesoDatos;
using _4_SGF_API.Helpers;
using _5_SGF_Interfaces;
using _6_SGF_Entidades.Catalogos;
using _6_SGF_Entidades.Login;
using _8_SGF_Log;
using Microsoft.AspNetCore.Mvc;

namespace _4_SGF_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        ILogin login;
        public LoginController(ILogin _login)
        {
            login = _login;
        }

        [HttpGet("ValidarUsuario/{Usuario}/{Contraseña}")]
        public IActionResult ValidarUsuario(string Usuario, string Contraseña)
        {
            Respuesta<RespuestaLogin> response = new Respuesta<RespuestaLogin>();
            try
            {
                response.Result = login.ValidarUsuario(Usuario,Contraseña);
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.TextError = (ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                response.NumError = 1;
                WriteLog.Log("Login ValidarUsuario", response.TextError, DatosAppSettingsApi.GetData("Url:LogApi"), "");
                return BadRequest(response);
            }
        }

        [HttpGet("ObtenerDatosUsuario/{Usuario}")]
        public IActionResult ObtenerDatosUsuario(int Usuario)
        {
            Respuesta<DatosUsuario> response = new Respuesta<DatosUsuario>();
            try
            {
                response.Result = login.ObtenerDatosUsuario(Usuario);
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.TextError = (ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                response.NumError = 1;
                WriteLog.Log("Login ObtenerDatosUsuario", response.TextError, DatosAppSettingsApi.GetData("Url:LogApi"), "");
                return BadRequest(response);
            }
        }

        [HttpGet("ObtenerPermisosUsuario/{Usuario}")]
        public IActionResult ObtenerPermisosUsuario(int Usuario)
        {
            Respuesta<List<PermisoUsuario>> response = new Respuesta<List<PermisoUsuario>>();
            try
            {
                response.Result = login.ObtenerPermisosUsuario(Usuario);
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.TextError = (ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                response.NumError = 1;
                WriteLog.Log("Login ObtenerPermisosUsuario", response.TextError, DatosAppSettingsApi.GetData("Url:LogApi"), "");
                return BadRequest(response);
            }
        }

        [HttpPost("RegistrarUsuario")]
        public IActionResult RegistrarUsuario(DatosRegistroUsuario datos)
        {
            Respuesta<bool> response = new Respuesta<bool>();
            try
            {
                response.Result = login.RegistrarUsuario(datos);
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.TextError = (ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                response.NumError = 1;
                WriteLog.Log("Login RegistrarUsuario", response.TextError, DatosAppSettingsApi.GetData("Url:LogApi"), "");
                return BadRequest(response);
            }
        }

        [HttpGet("RecuperarContrasenia")]
        public Respuesta<RespuestaLogin> RecuperarContrasenia(DatosUsuario datos)
        {
            Respuesta<RespuestaLogin> response = new Respuesta<RespuestaLogin>();
            try
            {
                response.Result = login.RecuperarContraseña(datos);
                return response;
            }
            catch (Exception ex)
            {
                response.TextError = (ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                response.NumError = 1;
                WriteLog.Log("Login RecuperarContraseña", response.TextError, DatosAppSettingsApi.GetData("Url:LogApi"), "");
                return response;
            }
        }

        [HttpGet("ValidaIdUsuarioExiste/{idUsuario}")]
        public IActionResult ValidaIdUsuarioExiste(string idUsuario)
        {
            Respuesta<bool> response = new Respuesta<bool>();
            try
            {
                response.Result = login.ValidaIdUsuarioExiste(idUsuario);
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.TextError = (ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                response.NumError = 1;
                WriteLog.Log("Login ValidaIdUsuarioExiste", response.TextError, DatosAppSettingsApi.GetData("Url:LogApi"), "");
                return BadRequest(response);
            }
        }

        [HttpGet("udf_ValidarCorreoExiste/{correo}")]
        public IActionResult ValidarCorreoExiste(string correo)
        {
            Respuesta<bool> response = new Respuesta<bool>();
            try
            {
                response.Result = login.ValidarCorreoExiste(correo);
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.TextError = (ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                response.NumError = 1;
                WriteLog.Log("Login ValidarCorreoExiste", response.TextError, DatosAppSettingsApi.GetData("Url:LogApi"), "");
                return BadRequest(response);
            }
        }
    }
}
