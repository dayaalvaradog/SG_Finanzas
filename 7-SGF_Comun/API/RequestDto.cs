using static _7_SGF_Comun.API.SD;

namespace _7_SGF_Comun.API
{
    public class RequestDto
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object? Data { get; set; }
    }
}
