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
using System.Text;
using System.Threading.Tasks;

namespace _3_SGF_AccesoDatos
{
    public class ADCuenta : ICuenta
    {
        public SGFContext context;

        public ADCuenta(SGFContext _context)
        {
            context = _context;
        }

        public List<CuentaBancaria> ObtenerCuentasUsuario(int CodUsuario)
        {
            try
            {
                var pUsuario = new SqlParameter("@CodUsuario", CodUsuario);

                return context.usp_ObtenerCuentasUsuario
                       .FromSqlRaw("EXECUTE dbo.usp_ObtenerCuentasUsuario {0}",
                       pUsuario.Value)
                       .AsNoTracking()
                       .AsEnumerable()
                       .Select(x => new CuentaBancaria
                       {
                           CodCuenta = x.CodCuenta,
                           NumeroCuenta = x.NumeroCuenta,
                           AliasCuenta = x.AliasCuenta
                       })
                       .ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public EstadoCuenta ObtenerEstadoCuenta(int CodCuenta)
        {
            try
            {
                var pCuenta = new SqlParameter("@CodCuenta", CodCuenta);

                return context.usp_ObtenerEstadoCuenta
                       .FromSqlRaw("EXECUTE dbo.usp_ObtenerEstadoCuenta {0}",
                       pCuenta.Value)
                       .AsNoTracking()
                       .AsEnumerable()
                       .Select(x => new EstadoCuenta
                       {
                           Ingresos = x.Ingresos,
                           Gastos = x.Gastos,
                           Saldo = x.Saldo
                       })
                       .ToList().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public EstadoCuenta ObtenerEstadoUsuario(int CodUsuario)
        {
            try
            {
                var pUsuario = new SqlParameter("@ObtenerEstadoUsuario", CodUsuario);

                return context.usp_ObtenerEstadoUsuario
                       .FromSqlRaw("EXECUTE dbo.usp_ObtenerEstadoUsuario {0}",
                       pUsuario.Value)
                       .AsNoTracking()
                       .AsEnumerable()
                       .Select(x => new EstadoCuenta
                       {
                           Ingresos = x.Ingresos,
                           Gastos = x.Gastos,
                           Saldo = x.Saldo
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
