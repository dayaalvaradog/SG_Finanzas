using _1_SGF_Presentacion.Helpers;
using _2_SGF_Modelo.Entidades.Login;
using _2_SGF_Modelo.Entidades;
using _7_SGF_Comun.API;
using _6_SGF_Entidades.Catalogos;

namespace _1_SGF_Presentacion.Models
{
    public class CatalogoModel
    {
        public static async Task<Respuesta<List<Categoria>>> ObtenerCategorias()
        {
            // Se crea el objeto que se va a devolver
            Respuesta<List<Categoria>> result = new Respuesta<List<Categoria>>();

            try
            {
                // Se crea el objeto API para consumir el servicio
                API<Respuesta<List<Categoria>>> servicio = new API<Respuesta<List<Categoria>>>(new Uri($"{DatosAppSettings.GetUrlAPI()}/Catalogo/ObtenerCategorias/"));

                result = await servicio.ObtenerResultadoAsync("GET");
            }
            catch (Exception)
            {
                throw; // Re-lanza la excepción para que el llamador la maneje
            }

            // Se retorna el resultado
            return result;
        }

        public static async Task<Respuesta<List<Clasificacion>>> ObtenerClasificaciones()
        {
            // Se crea el objeto que se va a devolver
            Respuesta<List<Clasificacion>> result = new Respuesta<List<Clasificacion>>();

            try
            {
                // Se crea el objeto API para consumir el servicio
                API<Respuesta<List<Clasificacion>>> servicio = new API<Respuesta<List<Clasificacion>>>(new Uri($"{DatosAppSettings.GetUrlAPI()}/Catalogo/ObtenerClasificaciones/"));

                result = await servicio.ObtenerResultadoAsync("GET");
            }
            catch (Exception)
            {
                throw; // Re-lanza la excepción para que el llamador la maneje
            }

            // Se retorna el resultado
            return result;
        }

        public static async Task<Respuesta<List<TiposUsuario>>> ObtenerTiposUsuario()
        {
            // Se crea el objeto que se va a devolver
            Respuesta<List<TiposUsuario>> result = new Respuesta<List<TiposUsuario>>();

            try
            {
                // Se crea el objeto API para consumir el servicio
                API<Respuesta<List<TiposUsuario>>> servicio = new API<Respuesta<List<TiposUsuario>>>(new Uri($"{DatosAppSettings.GetUrlAPI()}/Catalogo/ObtenerTiposUsuario/"));

                result = await servicio.ObtenerResultadoAsync("GET");
            }
            catch (Exception)
            {
                throw; // Re-lanza la excepción para que el llamador la maneje
            }

            // Se retorna el resultado
            return result;
        }

        public static async Task<Respuesta<List<PermisoUsuario>>> ObtenerTiposPermiso()
        {
            // Se crea el objeto que se va a devolver
            Respuesta<List<PermisoUsuario>> result = new Respuesta<List<PermisoUsuario>>();

            try
            {
                // Se crea el objeto API para consumir el servicio
                API<Respuesta<List<PermisoUsuario>>> servicio = new API<Respuesta<List<PermisoUsuario>>>(new Uri($"{DatosAppSettings.GetUrlAPI()}/Catalogo/ObtenerTiposPermiso/"));

                result = await servicio.ObtenerResultadoAsync("GET");
            }
            catch (Exception)
            {
                throw; // Re-lanza la excepción para que el llamador la maneje
            }

            // Se retorna el resultado
            return result;
        }

        public static async Task<Respuesta<List<TipoMenu>>> ObtenerTiposMenu()
        {
            // Se crea el objeto que se va a devolver
            Respuesta<List<TipoMenu>> result = new Respuesta<List<TipoMenu>>();

            try
            {
                // Se crea el objeto API para consumir el servicio
                API<Respuesta<List<TipoMenu>>> servicio = new API<Respuesta<List<TipoMenu>>>(new Uri($"{DatosAppSettings.GetUrlAPI()}/Catalogo/ObtenerTiposMenu/"));

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
