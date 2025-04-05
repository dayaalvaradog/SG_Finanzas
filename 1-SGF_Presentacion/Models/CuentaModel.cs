using _1_SGF_Presentacion.Helpers;
using _2_SGF_Modelo.Entidades.Login;
using _2_SGF_Modelo.Entidades;
using _7_SGF_Comun.API;
using _6_SGF_Entidades.Cuenta;

namespace _1_SGF_Presentacion.Models
{
    public class CuentaModel
    {
        public static async Task<Respuesta<List<CuentaBancaria>>> ObtenerCuentasUsuario(int usuario)
        {
            // Se crea el objeto que se va a devolver
            Respuesta<List<CuentaBancaria>> result = new Respuesta<List<CuentaBancaria>>();

            try
            {
                // Se crea el objeto API para consumir el servicio
                API<Respuesta<List<CuentaBancaria>>> servicio = new API<Respuesta<List<CuentaBancaria>>>(new Uri($"{DatosAppSettings.GetUrlAPI()}/Cuenta/ObtenerCuentasUsuario/{usuario}"));

                result = await servicio.ObtenerResultadoAsync("GET");
            }
            catch (Exception)
            {
                throw; // Re-lanza la excepción para que el llamador la maneje
            }

            // Se retorna el resultado
            return result;
        }

        public static async Task<Respuesta<EstadoCuenta>> ObtenerEstadoCuenta(int codCuenta)
        {
            // Se crea el objeto que se va a devolver
            Respuesta<EstadoCuenta> result = new Respuesta<EstadoCuenta>();

            try
            {
                // Se crea el objeto API para consumir el servicio
                API<Respuesta<EstadoCuenta>> servicio = new API<Respuesta<EstadoCuenta>>(new Uri($"{DatosAppSettings.GetUrlAPI()}/Cuenta/ObtenerEstadoCuenta/{codCuenta}"));

                result = await servicio.ObtenerResultadoAsync("GET");
            }
            catch (Exception)
            {
                throw; // Re-lanza la excepción para que el llamador la maneje
            }

            // Se retorna el resultado
            return result;
        }

        public static async Task<Respuesta<EstadoCuenta>> ObtenerEstadoUsuario(int CodUsuario)
        {
            // Se crea el objeto que se va a devolver
            Respuesta<EstadoCuenta> result = new Respuesta<EstadoCuenta>();

            try
            {
                // Se crea el objeto API para consumir el servicio
                API<Respuesta<EstadoCuenta>> servicio = new API<Respuesta<EstadoCuenta>>(new Uri($"{DatosAppSettings.GetUrlAPI()}/Cuenta/ObtenerEstadoUsuario/{CodUsuario}"));

                result = await servicio.ObtenerResultadoAsync("GET");
            }
            catch (Exception)
            {
                throw; // Re-lanza la excepción para que el llamador la maneje
            }

            // Se retorna el resultado
            return result;
        }

    }
}
