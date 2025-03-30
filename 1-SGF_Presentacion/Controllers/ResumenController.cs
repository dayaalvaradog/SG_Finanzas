using Microsoft.AspNetCore.Mvc;

namespace _1_SGF_Presentacion.Controllers
{
    public class ResumenController : Controller
    {
        public IActionResult Resumen()
        {
            ViewBag.Usuario = HttpContext.Session.GetString("Usuario");
            return View();
        }
    }
}
