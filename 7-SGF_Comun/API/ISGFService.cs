using _6_SGF_Entidades.Login;

namespace _7_SGF_Comun.API
{
    public interface ISGFService
    {
        Task<ResponseDto?> RegistrarUsuario(DatosRegistroUsuario datos);
        Task<ResponseDto?> RecuperarContrasenia(DatosUsuario datos);
    }
}
