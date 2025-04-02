using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_SGF_Entidades.Catalogos
{
    public class TipoMenu
    {
        public int CodMenu { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }

        public TipoMenu()
        {
            CodMenu = 0;
            Descripcion = string.Empty;
            Activo = true;
        }
    }
}
