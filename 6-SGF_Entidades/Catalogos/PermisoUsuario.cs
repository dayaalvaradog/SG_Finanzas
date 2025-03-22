using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_SGF_Entidades.Catalogos
{
    public class PermisoUsuario
    {
        public int CodPermiso { get; set; }
        public string Descripcion { get; set; }
        public string Detalle { get; set; }
        public bool Activo { get; set; }

        public PermisoUsuario()
        {
            CodPermiso = 0;
            Descripcion = string.Empty;
            Detalle = string.Empty;
            Activo = false;
        }
    }
}
