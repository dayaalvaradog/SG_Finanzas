using Microsoft.AspNetCore.Mvc;
using _5_SGF_Interfaces;
using _8_SGF_Log;
using _6_SGF_Entidades.Catalogos;
using _4_SGF_API.Helpers;
using _2_SGF_Modelo.Entidades;

namespace _4_SGF_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CatalogoController : Controller
    {
        ICatalogo catalogo;
        public CatalogoController(ICatalogo _catalogos)
        {
            catalogo = _catalogos;
        }

        [HttpGet("ObtenerCategorias")]
        public IActionResult ObtenerCategorias()
        {
            Respuesta<List<Categoria>> response = new Respuesta<List<Categoria>>();
            try
            {
                response.Result = catalogo.ObtenerCategorias();
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.TextError = (ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                response.NumError = 1;
                WriteLog.Log("Catalogos ObtenerCategorias", response.TextError, DatosAppSettingsApi.GetData("Url:LogApi"), "");
                return BadRequest(response);
            }
        }

        [HttpGet("ObtenerClasificaciones")]
        public IActionResult ObtenerClasificaciones()
        {
            Respuesta<List<Clasificacion>> response = new Respuesta<List<Clasificacion>>();
            try
            {
                response.Result = catalogo.ObtenerClasificaciones();
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.TextError = (ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                response.NumError = 1;
                WriteLog.Log("Catalogos ObtenerClasificaciones", response.TextError, DatosAppSettingsApi.GetData("Url:LogApi"), "");
                return BadRequest(response);
            }
        }

        [HttpGet("ObtenerTiposUsuario")]
        public IActionResult ObtenerTiposUsuario()
        {
            Respuesta<List<TiposUsuario>> response = new Respuesta<List<TiposUsuario>>();
            try
            {
                response.Result = catalogo.ObtenerTiposUsuario();
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.TextError = (ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                response.NumError = 1;
                WriteLog.Log("Catalogos ObtenerTiposUsuario", response.TextError, DatosAppSettingsApi.GetData("Url:LogApi"), "");
                return BadRequest(response);
            }
        }

        [HttpGet("ObtenerTiposPermiso")]
        public IActionResult ObtenerTiposPermiso()
        {
            Respuesta<List<PermisoUsuario>> response = new Respuesta<List<PermisoUsuario>>();
            try
            {
                response.Result = catalogo.ObtenerTiposPermiso();
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.TextError = (ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                response.NumError = 1;
                WriteLog.Log("Catalogos ObtenerTiposPermiso", response.TextError, DatosAppSettingsApi.GetData("Url:LogApi"), "");
                return BadRequest(response);
            }
        }
    }
}
