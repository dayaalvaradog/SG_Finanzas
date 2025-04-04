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

        public List<Clasificacion> ObtenerClasificaciones()
        {
            try
            {
                return context.usp_ObtenerClasificaciones
                       .FromSqlRaw("EXECUTE dbo.usp_ObtenerClasificaciones")
                       .AsNoTracking()
                       .AsEnumerable()
                       .Select(x => new Clasificacion
                       {
                           CodClasificacion = x.CodClasificacion,
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

        public List<TiposUsuario> ObtenerTiposUsuario()
        {
            try
            {
                return context.usp_ObtenerTiposUsuario
                       .FromSqlRaw("EXECUTE dbo.usp_ObtenerTiposUsuario")
                       .AsNoTracking()
                       .AsEnumerable()
                       .Select(x => new TiposUsuario
                       {
                           CodTipoUsuario = x.CodTipoUsuario,
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

        public List<PermisoUsuario> ObtenerTiposPermiso()
        {
            try
            {
                return context.usp_ObtenerTiposPermiso
                       .FromSqlRaw("EXECUTE dbo.usp_ObtenerTiposPermiso")
                       .AsNoTracking()
                       .AsEnumerable()
                       .Select(x => new PermisoUsuario
                       {
                           CodPermiso = x.CodPermiso,
                           Descripcion = x.Descripcion,
                           Detalle = x.Detalle,
                           Activo = x.Activo
                       })
                       .ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TipoMenu> ObtenerTiposMenu()
        {
            try
            {
                return context.usp_ObtenerTiposMenu
                       .FromSqlRaw("EXECUTE dbo.usp_ObtenerTiposMenu")
                       .AsNoTracking()
                       .AsEnumerable()
                       .Select(x => new TipoMenu
                       {
                           CodMenu = x.CodMenu,
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

        public List<Moneda> ObtenerTiposMoneda()
        {
            try
            {
                return context.usp_ObtenerTiposMoneda
                       .FromSqlRaw("EXECUTE dbo.usp_ObtenerTiposMoneda")
                       .AsNoTracking()
                       .AsEnumerable()
                       .Select(x => new Moneda
                       {
                           CodMoneda = x.CodMoneda,
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
