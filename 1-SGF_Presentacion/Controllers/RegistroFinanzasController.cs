using Microsoft.AspNetCore.Mvc;

namespace _1_SGF_Presentacion.Controllers
{
    public class RegistroFinanzasController : Controller
    {
        public IActionResult Movimientos()
        {
            return View();
        }
    }
}
