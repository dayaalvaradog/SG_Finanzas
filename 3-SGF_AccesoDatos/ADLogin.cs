using _2_SGF_Modelo;
using _2_SGF_Modelo.Entidades.Login;
using _5_SGF_Interfaces;
using _6_SGF_Entidades.Catalogos;
using _6_SGF_Entidades.Login;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_SGF_AccesoDatos
{
    public class ADLogin : ILogin
    {
        public SGFContext context;

        public ADLogin(SGFContext _context)
        {
            context = _context;
        }

        public RespuestaLogin ValidarUsuario(string Usuario, string Contraseña)
        {
            try
            {
                var pUsuario = new SqlParameter("@Usuario", Usuario);
                var pContraseña = new SqlParameter("@Contraseña", Contraseña);

                return context.usp_ValidarUsuario
                       .FromSqlRaw("EXECUTE dbo.usp_ValidarUsuario {0}, {1}", 
                       pUsuario.Value, pContraseña.Value)
                       .AsNoTracking()
                       .AsEnumerable()
                       .Select(x => new RespuestaLogin
                       {
                           TipoRespuesta = x.TipoRespuesta,
                           MensajeRespuesta = x.MensajeRespuesta,
                           CodUsuario = x.CodUsuario
                       })
                       .ToList().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DatosUsuario ObtenerDatosUsuario(int Usuario)
        {
            try
            {
                var pUsuario = new SqlParameter("@Usuario", Usuario);

                return context.usp_ObtenerDatosUsuario
                       .FromSqlRaw("EXECUTE dbo.usp_ObtenerDatosUsuario {0}",
                       pUsuario.Value)
                       .AsNoTracking()
                       .AsEnumerable()
                       .Select(x => new DatosUsuario
                       {
                           CodUsuario = x.CodUsuario,
                           NombreCompleto = x.NombreCompleto,
                           CodTipo = x.CodTipo,
                           CorreoElectronico = x.CorreoElectronico
                       })
                       .ToList().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PermisoUsuario> ObtenerPermisosUsuario(int Usuario)
        {
            try
            {
                var pUsuario = new SqlParameter("@Usuario", Usuario);

                return context.usp_ObtenerPermisosUsuario
                       .FromSqlRaw("EXECUTE dbo.usp_ObtenerPermisosUsuario {0}",
                       pUsuario.Value)
                       .AsNoTracking()
                       .AsEnumerable()
                       .Select(x => new PermisoUsuario
                       {
                           CodPermiso = x.CodPermiso,
                           Descripcion = x.Descripcion,
                           CodMenu = x.CodMenu
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
