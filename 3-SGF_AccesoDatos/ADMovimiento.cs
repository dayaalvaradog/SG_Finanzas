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
    public class ADMovimiento : IMovimiento
    {
        public SGFContext context;

        public ADMovimiento(SGFContext _context)
        {
            context = _context;
        }

        public bool InsertarMovimiento(Movimiento movimiento)
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
                        context.Database.ExecuteSqlRaw("EXEC dbo.usp_InsertarMovimiento  @CodUsuario, " +
                                                                                        "@CodCategoria, " +
                                                                                        "@CodClasificacion, " +
                                                                                        "@CodCuenta, " +
                                                                                        "@Monto, " +
                                                                                        "@FechaMovimiento, " +
                                                                                        "@CodMovimiento, " +
                                                                                        "@EsActivo",
                                new SqlParameter("@CodUsuario", movimiento.CodUsuario),
                                new SqlParameter("@CodCategoria", movimiento.CodCategoria),
                                new SqlParameter("@CodClasificacion", movimiento.CodClasificacion),
                                new SqlParameter("@CodCuenta", movimiento.CodCuenta),
                                new SqlParameter("@Monto", movimiento.Monto),
                                new SqlParameter("@FechaMovimiento", movimiento.Fecha),
                                new SqlParameter("@CodMovimiento", movimiento.CodMovimiento),
                                new SqlParameter("@EsActivo", movimiento.EsActivo));
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

        public List<Movimiento> ObtenerMovimientos(int Usuario)
        {
            try
            {
                var pUsuario = new SqlParameter("@CodUsuario", Usuario);

                return context.usp_ObtenerMovimientos
                       .FromSqlRaw("EXECUTE dbo.usp_ObtenerMovimientos {0}",
                       pUsuario.Value)
                       .AsNoTracking()
                       .AsEnumerable()
                       .Select(x => new Movimiento
                       {
                           CodMovimiento = x.CodMovimiento,
                           CodCuenta = x.CodCuenta,
                           AliasCuenta = x.AliasCuenta,
                           CodCategoria = x.CodCategoria,
                           Categoria = x.Categoria,
                           CodClasificacion = x.CodClasificacion,
                           Clasificacion = x.Clasificacion,
                           Monto = x.Monto,
                           Fecha = x.FechaMovimiento
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
