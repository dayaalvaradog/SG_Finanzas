using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_SGF_Entidades.Login
{
    public class DatosRegistroUsuario
    {
        public string NombreCompleto { get; set; }
        public string Correo { get; set; }
        public string IdUsuario { get; set; }
        public string Contraseña { get; set; }
        public int Pin { get; set; }
        public int TipoUsuario { get; set; }
        public bool EsActivo { get; set; }
        public DatosRegistroUsuario()
        {
            NombreCompleto = string.Empty;
            Correo = string.Empty;
            IdUsuario = string.Empty;
            Contraseña = string.Empty;
            Pin = 0;
            TipoUsuario = 0;
            EsActivo = false;
        }
    }
}
