using _1_SGF_Presentacion.Helpers;
using _2_SGF_Modelo.Entidades;
using _6_SGF_Entidades.Catalogos;
using _6_SGF_Entidades.Login;
using _6_SGF_Entidades.Movimiento;
using _7_SGF_Comun.API;
using Newtonsoft.Json;

namespace _1_SGF_Presentacion.Models
{
    public class MovimientoModel
    {
        public static async Task<Respuesta<List<Movimiento>>> ObtenerMovimientos(int usuario)
        {
            // Se crea el objeto que se va a devolver
            Respuesta<List<Movimiento>> result = new Respuesta<List<Movimiento>>();

            try
            {
                // Se crea el objeto API para consumir el servicio
                API<Respuesta<List<Movimiento>>> servicio = new API<Respuesta<List<Movimiento>>>(new Uri($"{DatosAppSettings.GetUrlAPI()}/Movimiento/ObtenerMovimientos/{usuario}"));

                result = await servicio.ObtenerResultadoAsync("GET");
            }
            catch (Exception)
            {
                throw;
            }

            // Se retorna el resultado
            return result;
        }
    }
}
