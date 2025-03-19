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

        [HttpGet("Categorias")]
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
    }
}
