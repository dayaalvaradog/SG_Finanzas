using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_SGF_Entidades.Catalogos
{
    public class Clasificacion
    {
        public int CodClasificacion { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }

        public Clasificacion()
        {
            CodClasificacion = 0;
            Descripcion = string.Empty;
            Activo = false;
        }
    }
}
