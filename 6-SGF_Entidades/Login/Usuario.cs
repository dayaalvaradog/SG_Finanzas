using _6_SGF_Entidades.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_SGF_Entidades.Login
{
    public class Usuario
    { 
        public DatosUsuario datosUsuario { get; set; }
        public List<PermisoUsuario> permisosUsuario { get; set; }

    }
}
