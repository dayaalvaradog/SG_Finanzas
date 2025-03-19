using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_SGF_Modelo.Entidades
{
    public class Respuesta<T>
    {
        public int NumError { get; set; }
        public string TextError { get; set; }
        public T? Result { get; set; }

        public Respuesta()
        {
            NumError = 0;
            TextError = string.Empty;
        }
    }
}
