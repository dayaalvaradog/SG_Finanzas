using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_SGF_Entidades.Catalogos
{
    public class ListaCatalogos
    {
        #region Movimientos
        public List<Categoria> Categorias { get; set; }
        public List<Clasificacion> Clasificaciones { get; set; }
        public List<Moneda> TiposMoneda { get; set; } 
        #endregion
        #region Administracion
        public List<PermisoUsuario> PermisoUsuario { get; set; }
        public List<TiposUsuario> TiposUsuario { get; set; } 
        public List<TipoMenu> TiposMenu { get; set; } 
        #endregion 
    }
}
