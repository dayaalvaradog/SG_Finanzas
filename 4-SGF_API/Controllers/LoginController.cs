using _5_SGF_Interfaces;
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

        public IActionResult Index()
        {
            return View();
        }
    }
}
