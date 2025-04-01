using _2_SGF_Modelo.Entidades;
using Newtonsoft.Json;
using System.Text;

namespace _7_SGF_Comun.API
{
    public class API<T>
    {
        private readonly HttpClient _httpClient;
        private readonly Uri _direccionServicio;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="direccion">Direccion del servicio</param>
        public API(Uri direccion)
        {
            if (direccion == null)
            {
                throw new ArgumentNullException(nameof(direccion));
            }
            _direccionServicio = direccion;
            _httpClient = new HttpClient(); // Inicializa HttpClient
        }

        /// <summary>
        /// Obtener la lista de pronosticos
        /// </summary>
        /// <returns></returns>
        public async Task<T> ObtenerResultadoAsync(string method)
        {
            return await ObtenerResultadoAsync(method, null);
        }

        public async Task<T> ObtenerResultadoAsync(string method, string datos)
        {
            try
            {
                HttpResponseMessage response;

                if (string.IsNullOrEmpty(datos))
                {
                    // Solicitud GET (o similar)
                    response = await _httpClient.SendAsync(new HttpRequestMessage(new HttpMethod(method), _direccionServicio));
                }
                else
                {
                    // Solicitud POST, PUT, etc. con datos
                    var content = new StringContent(datos, Encoding.UTF8, "application/json");
                    response = await _httpClient.SendAsync(new HttpRequestMessage(new HttpMethod(method), _direccionServicio) { Content = content });
                }

                response.EnsureSuccessStatusCode(); // Lanza excepción si no es 2xx

                string contenido = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(contenido);
            }
            catch (HttpRequestException ex)
            {
                // Manejar errores de solicitud HTTP
                Console.WriteLine($"Error de HttpRequestException: {ex.Message}");
                throw; // Re-lanza la excepción para que el llamador la maneje
            }
            catch (Exception)
            {
                throw; // Re-lanza la excepción para que el llamador la maneje
            }
        }
    }

}
