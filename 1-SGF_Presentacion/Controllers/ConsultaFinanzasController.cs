using _1_SGF_Presentacion.Helpers;
using _1_SGF_Presentacion.Models;
using _2_SGF_Modelo.Entidades;
using _6_SGF_Entidades.Catalogos;
using _6_SGF_Entidades.Cuenta;
using _6_SGF_Entidades.Login;
using _6_SGF_Entidades.Movimiento;
using _8_SGF_Log;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace _1_SGF_Presentacion.Controllers
{
    public class ConsultaFinanzasController : Controller
    {
        public IActionResult ConsultaMovimientos()
        {
            // Se obtiene el usuario logueado
            Usuario usuario = JsonConvert.DeserializeObject<Usuario>(HttpContext.Session.GetString("Usuario"));
            // Se valida que el usuario no sea nulo
            if (usuario == null)
            {
                // Si el usuario es nulo, se redirige a la página de inicio de sesión
                return RedirectToAction("Login", "Login");
            }
            else
            {
                //se obtiene la lista de movimientos
                List<Movimiento> resultado = MovimientoModel.ObtenerMovimientos(usuario.datosUsuario.CodUsuario).Result.Result;
                return View("~/Views/ConsultaFinanzas/ConsultaMovimientos.cshtml",resultado);
            }

        }

        public IActionResult ConsultaEstadoCuentas()
        {
            // Se obtiene el usuario logueado
            Usuario usuario = JsonConvert.DeserializeObject<Usuario>(HttpContext.Session.GetString("Usuario"));
            // Se valida que el usuario no sea nulo
            if (usuario == null)
            {
                // Si el usuario es nulo, se redirige a la página de inicio de sesión
                return RedirectToAction("Login", "Login");
            }
            else
            {
                //Por cada cuenta bancaria se obtiene el saldo
                List<CuentaBancaria> cuentas = usuario.cuentasBancarias;
                foreach (var cuenta in cuentas)
                {
                    // Se obtiene el saldo de la cuenta
                    EstadoCuenta resultado = CuentaModel.ObtenerEstadoCuenta(cuenta.CodCuenta).Result.Result;
                    // Se asigna el saldo a la cuenta
                    cuenta.Saldo = resultado.Saldo;
                    cuenta.Ingresos = resultado.Ingresos;
                    cuenta.Gastos = resultado.Gastos;
                }


                return View("~/Views/ConsultaFinanzas/ConsultaEstadoCuentas.cshtml", cuentas);
            }
        }

        [HttpGet]
        public async Task<Respuesta<List<Movimiento>>> ObtenerMovimientos(int Usuario)
        {
            var resultado = new Respuesta<List<Movimiento>>();
            try
            {
                resultado = await MovimientoModel.ObtenerMovimientos(Usuario);

                if (resultado.Result != null)
                {
                    return resultado;
                }
                else
                {
                    WriteLog.Log("ObtenerMovimientos", resultado.TextError, DatosAppSettings.GetData("Url:Log"), $"Usuario: {Usuario}");
                    resultado.TextError = "Ocurrió un error obteniendo los movimientos";
                    resultado.NumError = 1;
                    return resultado;
                }
            }
            catch (Exception ex)
            {
                WriteLog.Log("ObtenerMovimientos", (ex.InnerException != null ? ex.InnerException.Message : ex.Message),
                    DatosAppSettings.GetData("Url:Log"), $"Usuario: {Usuario}");
                resultado.TextError = "Ocurrió un error al consultar la información";
                resultado.NumError = 2;
                resultado.Result = null;

                return resultado;
            }
        }
    }
}
