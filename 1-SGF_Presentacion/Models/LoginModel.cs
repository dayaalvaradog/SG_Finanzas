using _1_SGF_Presentacion.Helpers;
using _2_SGF_Modelo.Entidades;
using _2_SGF_Modelo.Entidades.Login;
using _4_SGF_API.Helpers;
using _6_SGF_Entidades.Catalogos;
using _6_SGF_Entidades.Login;
using _7_SGF_Comun.API;
using _8_SGF_Log;
using Azure;
using Newtonsoft.Json;

namespace _1_SGF_Presentacion.Models
{
    public static class LoginModel
    {
        public static async Task<Respuesta<RespuestaLogin>> ValidarUsuario(string usuario, string contrasenia)
        {
            // Se crea el objeto que se va a devolver
            Respuesta<RespuestaLogin> result = new Respuesta<RespuestaLogin>();

            try
            {
                // Se crea el objeto API para consumir el servicio
                API<Respuesta<RespuestaLogin>> servicio = new API<Respuesta<RespuestaLogin>>(new Uri($"{DatosAppSettings.GetUrlAPI()}/Login/ValidarUsuario/{usuario}/{contrasenia}"));

                result = await servicio.ObtenerResultadoAsync("GET");
            }
            catch (Exception)
            {
                throw; // Re-lanza la excepción para que el llamador la maneje
            }

            // Se retorna el resultado
            return result;
        }

        public static async Task<Respuesta<DatosUsuario>> ObtenerDatosUsuario(int usuario)
        {
            // Se crea el objeto que se va a devolver
            Respuesta<DatosUsuario> result = new Respuesta<DatosUsuario>();

            try
            {
                // Se crea el objeto API para consumir el servicio
                API<Respuesta<DatosUsuario>> servicio = new API<Respuesta<DatosUsuario>>(new Uri($"{DatosAppSettings.GetUrlAPI()}/Login/ObtenerDatosUsuario/{usuario}"));

                result = await servicio.ObtenerResultadoAsync("GET");
            }
            catch (Exception)
            {
                throw; // Re-lanza la excepción para que el llamador la maneje
            }

            // Se retorna el resultado
            return result;
        }

        public static async Task<Respuesta<List<PermisoUsuario>>> ObtenerPermisosUsuario(int usuario)
        {
            // Se crea el objeto que se va a devolver
            Respuesta<List<PermisoUsuario>> result = new Respuesta<List<PermisoUsuario>>();

            try
            {
                // Se crea el objeto API para consumir el servicio
                API<Respuesta<List<PermisoUsuario>>> servicio = new API<Respuesta<List<PermisoUsuario>>>(new Uri($"{DatosAppSettings.GetUrlAPI()}/Login/ObtenerPermisosUsuario/{usuario}"));

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
