﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_SGF_Entidades.Login
{
    public class DatosUsuario
    {
        public int CodUsuario { get; set; }
        public string IdUsuario { get; set; }
        public string NombreCompleto { get; set; }
        public int CodTipo { get; set; }
        public string CorreoElectronico { get; set; }
        public string? Contrasenia { get; set; }
        public int? Pin { get; set; }
        public bool EsActivo { get; set; }

        public DatosUsuario()
        {
            CodUsuario = 0;
            IdUsuario = string.Empty;
            NombreCompleto = string.Empty;
            CodTipo = 0;
            CorreoElectronico = string.Empty;
            Contrasenia = null;
            Pin = null;
            EsActivo = true;
        }
    }
}
