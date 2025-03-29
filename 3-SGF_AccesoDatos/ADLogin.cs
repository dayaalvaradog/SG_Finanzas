using _2_SGF_Modelo;
using _2_SGF_Modelo.Entidades.Login;
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
                           MensajeRespuesta = x.MensajeRespuesta
                       })
                       .ToList().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




    }

}
