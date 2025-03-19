using _2_SGF_Modelo;
using _5_SGF_Interfaces;
using _6_SGF_Entidades.Catalogos;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_SGF_AccesoDatos
{
    public class ADCatalogo : ICatalogo
    {
        public SGFContext context;

        public ADCatalogo(SGFContext _context)
        {
            context = _context;
        }

        public List<Categoria> ObtenerCategorias()
        {
            try
            {
                return context.usp_ObtenerCategorias
                       .FromSqlRaw("EXECUTE dbo.usp_ObtenerCategorias")
                       .AsNoTracking()
                       .AsEnumerable()
                       .Select(x => new Categoria
                       {
                           CodCategoria = x.CodCategoria,
                           Descripcion = x.Descripcion,
                           Activo = x.Activo
                       })
                       .ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }

}
