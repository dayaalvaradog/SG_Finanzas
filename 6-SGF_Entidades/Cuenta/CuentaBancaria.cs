using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_SGF_Entidades.Cuenta
{
    public class CuentaBancaria
    {
        public int CodCuenta { get; set; }
        public string NumeroCuenta { get; set; }
        public string AliasCuenta { get; set; }
        public decimal Ingresos { get; set; }
        public decimal Gastos { get; set; }
        public decimal Saldo { get; set; }
        public int CodUsuario { get; set; }
        public bool EsActivo { get; set; }

        public CuentaBancaria()
        {
            CodCuenta = 0;
            NumeroCuenta = "";
            AliasCuenta = "";
            Ingresos = 0;
            Gastos = 0;
            Saldo = 0;
            CodUsuario = 0;
            EsActivo = true;
        }
    }
}
