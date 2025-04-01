using _2_SGF_Modelo;
using _2_SGF_Modelo.Entidades.Login;
using _5_SGF_Interfaces;
using _6_SGF_Entidades.Catalogos;
using _6_SGF_Entidades.Cuenta;
using _6_SGF_Entidades.Login;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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

        public List<PermisoUsuario> ObtenerPermisosUsuario(int usuario)
        {
            try
            {
                var pUsuario = new SqlParameter("@Usuario", usuario);

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

        public bool RegistrarUsuario(DatosRegistroUsuario usuario)
        {
            bool respuesta = false;
            var strategy = context.Database.CreateExecutionStrategy();
            strategy.Execute(() =>
            {
            //Se crea el scope de la transaccion
            using (var transaction = context.Database.BeginTransaction())
            {
                try
            {
                        context.Database.ExecuteSqlRaw("EXEC dbo.usp_RegistrarUsuario   @IdUsuario, " +
                                                                                        "@NombreCompleto, " +
                                                                                        "@Contraseña, " +
                                                                                        "@Correo, " +
                                                                                        "@Pin, " +
                                                                                        "@EsActivo, " +
                                                                                        "@CodTipo, " +
                                                                                        "@CodUsuario",
                                        new SqlParameter("@IdUsuario", usuario.IdUsuario),
                                        new SqlParameter("@NombreCompleto", usuario.NombreCompleto),
                                        new SqlParameter("@Contraseña", usuario.Contrasenia),
                                        new SqlParameter("@Correo", usuario.Correo),
                                        new SqlParameter("@Pin", usuario.Pin),
                                        new SqlParameter("@EsActivo", usuario.EsActivo),
                                        new SqlParameter("@CodTipo", usuario.TipoUsuario),
                                        new SqlParameter("@CodUsuario", usuario.CodUsuario));
                        context.SaveChanges();
                        transaction.Commit();
                        respuesta = true;
                    }
                    catch (Exception)
                    {
                        //transaction.Rollback();
                        throw;
                    }
                }
            });
            return respuesta;
        }

        public RespuestaLogin RecuperarContraseña(DatosUsuario usuario)
        {
            try
            {
                var pPin = new SqlParameter("@Pin", usuario.Pin);
                var pContrasena = new SqlParameter("@Contrasena", usuario.Contrasenia);
                var pIdUsuario = new SqlParameter("@IdUsuario", usuario.IdUsuario);
                var pCorreo = new SqlParameter("@Correo", usuario.CorreoElectronico);

                RespuestaLogin resp = context.usp_RecuperarContraseña
                       .FromSqlRaw("EXECUTE dbo.usp_RecuperarContraseña {0},{1},{2},{3}",
                       pPin.Value, pContrasena.Value, pIdUsuario.Value, pCorreo.Value)
                       .AsNoTracking()
                       .AsEnumerable()
                       .Select(x => new RespuestaLogin
                       {
                           TipoRespuesta = x.TipoRespuesta,
                           MensajeRespuesta = x.MensajeRespuesta,
                           CodUsuario = x.CodUsuario
                       })
                       .ToList().FirstOrDefault();
                if (resp.TipoRespuesta > 0)
                {
                    return resp;
                }
                else
                {
                    return new RespuestaLogin
                    {
                        TipoRespuesta = 0,
                        MensajeRespuesta = "No se pudo recuperar la contraseña",
                        CodUsuario = 0
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ValidaIdUsuarioExiste(string idUsuario)
        {
            try
            {
                bool resultado = context.Database.SqlQueryRaw<bool>("SELECT dbo.udf_ValidarIdUsuarioExiste(@IdUsuario)", new SqlParameter("@IdUsuario", idUsuario))
                .AsEnumerable()
                .FirstOrDefault();

                return resultado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ValidarCorreoExiste(string correo)
        {
            try
            {
                bool resultado = context.Database.SqlQueryRaw<bool>("SELECT dbo.udf_ValidarCorreoExiste(@Correo)", new SqlParameter("@Correo", correo))
                .AsEnumerable()
                .FirstOrDefault();

                return resultado;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }

}
