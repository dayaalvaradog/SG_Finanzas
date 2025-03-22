using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_SGF_Modelo.Entidades.Login
{
    public class RespuestaLogin
    {
        public int TipoRespuesta { get; set; }
        public string MensajeRespuesta { get; set; }
        public RespuestaLogin()
        {
            TipoRespuesta = 0;
            MensajeRespuesta = string.Empty;
        }
    }
}
