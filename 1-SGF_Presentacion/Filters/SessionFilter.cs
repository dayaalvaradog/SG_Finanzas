using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace _1_SGF_Presentacion.Filters
{
    public class SessionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("Termino");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetString("Usuario") == null)
            {
                context.Result = new RedirectResult("~/Login/Index");
                return;
            }
        }
    }
}