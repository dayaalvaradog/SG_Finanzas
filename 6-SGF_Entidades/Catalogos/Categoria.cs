using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_SGF_Entidades.Catalogos
{
    public class Categoria
    {
        public int CodCategoria { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; } 

        public Categoria()
        {
            CodCategoria = 0;
            Descripcion = string.Empty;
            Activo = false;
        }
    }
}
