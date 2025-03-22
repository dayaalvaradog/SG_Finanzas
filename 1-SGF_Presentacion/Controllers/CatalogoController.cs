using Microsoft.AspNetCore.Mvc;

namespace _1_SGF_Presentacion.Controllers
{
    public class CatalogoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
