﻿using _2_SGF_Modelo;
using _5_SGF_Interfaces;
using _6_SGF_Entidades.Catalogos;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_SGF_AccesoDatos
{
    public class ADLogin : ILogin
    {
        public SGFContext context;

        public ADLogin(SGFContext _context)
        {
            context = _context;
        }

       


    }

}
