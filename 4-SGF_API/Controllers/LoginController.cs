﻿using _2_SGF_Modelo.Entidades;
using _2_SGF_Modelo.Entidades.Login;
using _3_SGF_AccesoDatos;
using _4_SGF_API.Helpers;
using _5_SGF_Interfaces;
using _6_SGF_Entidades.Catalogos;
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
            Respuesta<List<RespuestaLogin>> response = new Respuesta<List<RespuestaLogin>>();
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
    }
}
