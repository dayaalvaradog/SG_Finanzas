using _6_SGF_Entidades.Movimiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_SGF_Interfaces
{
    public interface IMovimiento
    {
        public bool InsertarMovimiento(IMovimiento movimiento);
        public List<Movimiento> ObtenerMovimientos(int CodUsuario);
    }
}
