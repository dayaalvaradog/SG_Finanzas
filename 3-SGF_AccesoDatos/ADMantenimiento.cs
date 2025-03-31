using _2_SGF_Modelo;
using _2_SGF_Modelo.Entidades.Login;
using _5_SGF_Interfaces;
using _6_SGF_Entidades.Catalogos;
using _6_SGF_Entidades.Cuenta;
using _6_SGF_Entidades.Login;
using _6_SGF_Entidades.Movimiento;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_SGF_AccesoDatos
{
    public class ADMantenimiento : IMantenimiento
    {
        public SGFContext context;

        public ADMantenimiento(SGFContext _context)
        {
            context = _context;
        }

        public bool InsertarCuenta(CuentaBancaria cuenta)
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
                        context.Database.ExecuteSqlRaw("EXEC dbo.usp_InsertarCuenta  @NombreCuenta, " +
                                                                                    "@Cuenta, " +
                                                                                    "@CodUsuario, " +
                                                                                    "@EsActivo, " +
                                                                                    "@CodCuenta",
                                        new SqlParameter("@NombreCuenta", cuenta.AliasCuenta),
                                        new SqlParameter("@Cuenta", cuenta.NumeroCuenta),
                                        new SqlParameter("@CodUsuario", cuenta.CodUsuario),
                                        new SqlParameter("@EsActivo", cuenta.EsActivo),
                                        new SqlParameter("@CodCuenta", cuenta.CodCuenta));
                                    context.SaveChanges();
                        transaction.Commit();
                        respuesta = true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            });
            return respuesta;
        }

    }

}
