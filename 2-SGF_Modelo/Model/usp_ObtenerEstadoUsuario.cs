using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_SGF_Modelo.Model
{
    public class usp_ObtenerEstadoUsuario
    {
        public decimal Ingresos { get; set; }
        public decimal Gastos { get; set; }
        public decimal Saldo { get; set; }
        public int? Tipo { get; set; }
        public string? Mensaje { get; set; }

        public usp_ObtenerEstadoUsuario()
        {
            Ingresos = 0;
            Gastos = 0;
            Saldo = 0;
            Tipo = null;
            Mensaje = null;
        }
    }
}
