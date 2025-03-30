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
        public float Ingresos { get; set; }
        public float Gastos { get; set; }
        public float Saldo { get; set; }
        public int CodUsuario { get; set; }

        public CuentaBancaria()
        {
            CodCuenta = 0;
            NumeroCuenta = "";
            AliasCuenta = "";
            Ingresos = 0;
            Gastos = 0;
            Saldo = 0;
            CodUsuario = 0;
        }
    }
}
