using _6_SGF_Entidades.Login;
using Newtonsoft.Json;
using System.Text;

namespace _7_SGF_Comun.API
{
    public class APIService : ISGFService
    {
        private readonly IHttpClientFactory _clientFactory;

        public APIService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        private async Task<ResponseDto> SendAsync(RequestDto requestDto)
        {
            var response = new ResponseDto();
            try
            {
                HttpClient client = _clientFactory.CreateClient("AtlasAPI");

                HttpRequestMessage message = new HttpRequestMessage();

                message.Headers.Add("Accept", "application/json");

                message.RequestUri = new Uri(requestDto.Url);

                if (requestDto.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8, "application/json");
                }

                switch (requestDto.ApiType)
                {
                    case SD.ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case SD.ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case SD.ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }

                HttpResponseMessage apiResponse = await client.SendAsync(message);

                switch (apiResponse.StatusCode)
                {
                    case System.Net.HttpStatusCode.NotFound:
                        response.IsSuccess = false;
                        response.Message = "Not Found";
                        break;
                    case System.Net.HttpStatusCode.Unauthorized:
                        response.IsSuccess = false;
                        response.Message = "Unauthorized";
                        break;
                    case System.Net.HttpStatusCode.Forbidden:
                        response.IsSuccess = false;
                        response.Message = "Access Denied";
                        break;
                    case System.Net.HttpStatusCode.InternalServerError:
                        response.IsSuccess = false;
                        response.Message = "Internal Server Error";
                        break;
                    default:
                        var apiContent = await apiResponse.Content.ReadAsStringAsync();
                        response.IsSuccess = true;
                        response.Message = "Operation Successful";
                        response.Data = apiContent;
                        //response = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
                        break;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ResponseDto?> RegistrarUsuario(DatosRegistroUsuario datos)
        {
            return await SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Url = SD.SGFAPIBase + "/Login/RegistrarUsuario",
                Data = datos,
            });
        }

        public async Task<ResponseDto?> RecuperarContrasenia(DatosUsuario datos)
        {
            return await SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.SGFAPIBase + "/Login/RecuperarContrasenia",
                Data = datos,
            });
        }
    }

}
