using _6_SGF_Entidades.Cuenta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_SGF_Interfaces
{
    public interface ICuenta
    {
        public List<CuentaBancaria> ObtenerCuentasUsuario(int CodUsuario);
        public CuentaBancaria ObtenerEstadoCuenta(int CodCuenta);
        public EstadoCuenta ObtenerEstadoUsuario(int CodUsuario);

    }
}
