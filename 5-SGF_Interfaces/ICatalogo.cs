using _6_SGF_Entidades.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_SGF_Interfaces
{
    public interface ICatalogo
    {
        public List<Categoria> ObtenerCategorias();
    }
}
