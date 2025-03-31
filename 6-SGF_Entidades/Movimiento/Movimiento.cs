using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_SGF_Entidades.Movimiento
{
    public class Movimiento
    {
        public int CodMovimiento { get; set; }
        public int CodCuenta { get; set; }
        public int CodCategoria { get; set; }
        public int CodClasificacion { get; set; }
        public double Monto { get; set; }
        public DateTime Fecha { get; set; }
        public int CodUsuario { get; set; }
        public bool EsActivo { get; set; }

        public Movimiento()
        {
            CodMovimiento = 0;
            CodCuenta = 0;
            CodCategoria = 0;
            CodClasificacion = 0;
            Monto = 0;
            Fecha = DateTime.Now;
            CodUsuario = 0;
            EsActivo = true;
        }
    }
}
