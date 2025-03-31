using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_SGF_Entidades.Movimiento
{
    public class usp_ObtenerMovimientos
    {
        public int CodMovimiento { get; set; }
        public int CodCuenta { get; set; }
        public int CodCategoria { get; set; }
        public int CodClasificacion { get; set; }
        public float Monto { get; set; }
        public DateTime FechaMovimiento { get; set; }
    }
}
