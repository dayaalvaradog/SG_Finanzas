using _1_SGF_Presentacion.Helpers;
using _2_SGF_Modelo.Entidades;
using _6_SGF_Entidades.Cuenta;
using _7_SGF_Comun.API;
using Newtonsoft.Json;

namespace _1_SGF_Presentacion.Models
{
    public class MantenimientoModel
    {
        public static async Task<Respuesta<bool>> InsertarCuenta(CuentaBancaria datos)
        {
            Respuesta<bool> result = new Respuesta<bool>();
            try
            {
                string json = JsonConvert.SerializeObject(datos);
                // Se crea el objeto API para consumir el servicio
                API<Respuesta<bool>> servicio = new API<Respuesta<bool>>(new Uri($"{DatosAppSettings.GetUrlAPI()}/Mantenimiento/InsertarCuenta"));
                result = await servicio.ObtenerResultadoAsync("POST", json);
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
