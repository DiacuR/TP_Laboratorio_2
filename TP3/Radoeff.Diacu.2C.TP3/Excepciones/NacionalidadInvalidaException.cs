using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        /// <summary>
        /// Constructor. Llama a constructor padre con un mensaje por defecto
        /// </summary>
        public NacionalidadInvalidaException()
            : base("Nacionalidad Invalida.")
        {

        }
        /// <summary>
        /// Constructor. Llama a constructor padre con un mensaje ingresado por parametro
        /// </summary>
        /// <param name="message">Mensaje del error</param>
        public NacionalidadInvalidaException(string message)
            : base(message)
        {

        }
    }
}
