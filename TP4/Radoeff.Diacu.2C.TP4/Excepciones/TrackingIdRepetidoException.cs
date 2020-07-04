using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class TrackingIdRepetidoException : Exception
    {
        /// <summary>
        /// Costructor que recive un mensaje de excepcion
        /// </summary>
        /// <param name="mensaje">Mensaje de Error</param>
        public TrackingIdRepetidoException(string mensaje)
            : base(mensaje)
        {

        }
        /// <summary>
        /// Costructor que recive un mensaje de excepcion, y una Exception
        /// </summary>
        /// <param name="mensaje">Mensaje de error</param>
        /// <param name="inner">Excepcion lanzada anteriormente</param>
        public TrackingIdRepetidoException(string mensaje, Exception inner)
            : base(mensaje,inner)
        {

        }
    }
}
