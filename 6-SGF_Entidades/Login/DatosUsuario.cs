using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_SGF_Entidades.Login
{
    public class DatosUsuario
    {
        public int CodUsuario { get; set; }
        public string NombreCompleto { get; set; }
        public int CodTipo { get; set; }
        public string CorreoElectronico { get; set; }
        public DatosUsuario()
        {
            CodUsuario = 0;
            NombreCompleto = string.Empty;
            CodTipo = 0;
            CorreoElectronico = string.Empty;
        }
    }
}
