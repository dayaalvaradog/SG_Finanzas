﻿using _2_SGF_Modelo.Entidades.Login;
using _6_SGF_Entidades.Catalogos;
using _6_SGF_Entidades.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_SGF_Interfaces
{
    public interface ILogin
    {
        public RespuestaLogin ValidarUsuario(string Usuario, string Contraseña);
        public DatosUsuario ObtenerDatosUsuario(int Usuario);
        public List<PermisoUsuario> ObtenerPermisosUsuario(int Usuario);
        public bool RegistrarUsuario(DatosRegistroUsuario datos);
        public RespuestaLogin RecuperarContraseña(int Pin, string Contraseña, string IdUsuario, string Correo);
    }
}
