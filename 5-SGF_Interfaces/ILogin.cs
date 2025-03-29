using _2_SGF_Modelo.Entidades.Login;
using _6_SGF_Entidades.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_SGF_Interfaces
{
    public interface ILogin
    {
        public RespuestaLogin ValidarUsuario(string Usuario, string Contraseña);
    }
}
