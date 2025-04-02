using _6_SGF_Entidades.Catalogos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace _1_SGF_Presentacion.Controllers
{
    public class ResumenController : Controller
    {
        public IActionResult Resumen()
        {
            ViewBag.Usuario = HttpContext.Session.GetString("Usuario");
            //se carga la lista de catálogos
            ListaCatalogos catalogos = CatalogoController.CargarCatalogos();
            ViewBag.Catalogos = catalogos;
            ViewBag.TiposMenu = catalogos.TiposMenu;
            HttpContext.Session.SetString("Catalogos", JsonConvert.SerializeObject(catalogos));
            HttpContext.Session.SetString("TiposMenu", JsonConvert.SerializeObject(catalogos.TiposMenu));
            return View();
        }
    }
}
