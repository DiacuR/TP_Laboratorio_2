using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class AlumnoRepetidoException : Exception
    {
        /// <summary>
        /// Constructor. Llama a constructor padre con un mensaje por defecto
        /// </summary>
        public AlumnoRepetidoException()
            :base("Alumno Repetido.")
        {

        }
    }
}
