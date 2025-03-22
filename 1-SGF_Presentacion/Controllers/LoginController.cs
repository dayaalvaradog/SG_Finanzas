using Microsoft.AspNetCore.Mvc;

namespace _1_SGF_Presentacion.Controllers
{
    public class LoginController : Controller
    {

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Registrarse()
        {
            return View();
        }
    }
}
