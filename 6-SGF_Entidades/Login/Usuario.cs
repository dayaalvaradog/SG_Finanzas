using _6_SGF_Entidades.Catalogos;
using _6_SGF_Entidades.Cuenta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_SGF_Entidades.Login
{
    public class Usuario
    { 
        public DatosUsuario datosUsuario { get; set; }
        public List<PermisoUsuario>? permisosUsuario { get; set; }
        public List<CuentaBancaria>? cuentasBancarias { get; set; }

        public Usuario() {
            datosUsuario = new DatosUsuario();
            permisosUsuario = new List<PermisoUsuario>();
            cuentasBancarias = new List<CuentaBancaria>();
        }

    }
}
