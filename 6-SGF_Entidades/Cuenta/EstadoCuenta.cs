using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_SGF_Entidades.Cuenta
{
    public class EstadoCuenta
    {
        public decimal Ingresos { get; set; }
        public decimal Gastos { get; set; }
        public decimal Saldo { get; set; }
        public int? Tipo { get; set; }
        public string? Mensaje { get; set; }

        public EstadoCuenta()
        {
            Ingresos = 0;
            Gastos = 0;
            Saldo = 0;
            Tipo = null;
            Mensaje = null;
        }

    }
}
