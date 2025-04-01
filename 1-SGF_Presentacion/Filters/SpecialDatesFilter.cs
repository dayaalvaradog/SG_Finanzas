using _2_SGF_Modelo.Entidades;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;

namespace _1_SGF_Presentacion.Filters
{
    public class SpecialDatesFilter : IActionFilter
    {
        private readonly List<SpecialDate> _specialDates;

        public SpecialDatesFilter(IOptionsMonitor<List<SpecialDate>> opciones)
        {
            _specialDates = opciones.CurrentValue;
        }

        public void OnActionExecuted(ActionExecutedContext context) { }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            context.HttpContext.Session.Remove("SpecialDateMessage");
            var now = DateTime.Now;
            foreach (var rango in _specialDates)
            {
                // si la fecha actual está dentro de un rango especial
                if (now >= rango.DateFrom && now <= rango.DateTo)
                {
                    context.HttpContext.Session.SetString("SpecialDateMessage", $"Esta opción no está habilitada hasta el {rango.DateTo.ToString("dd/MM/yyyy HH:mm")}.");
                    context.HttpContext.Response.Redirect("/Resumen/Resumen");
                    return;
                }
            }
        }
    }
}

