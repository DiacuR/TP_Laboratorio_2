using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        /// <summary>
        /// Constructor. Llama a constructor padre con un mensaje por defecto
        /// </summary>
        public DniInvalidoException()
            : base("D.N.I Invalido.")
        {

        }
        /// <summary>
        /// Constructor. Llama a constructor padre con un mensaje que recive por parametro
        /// </summary>
        /// <param name="message">Mensaje de error</param>
        public DniInvalidoException(string message)
            : base(message)
        {

        }
        /// <summary>
        /// Constructor. Llama a constructor padre con un mensaje que recive por parametro, y la exception que se lanzo antes
        /// </summary>
        /// <param name="message"></param>
        /// <param name="e"></param>
        public DniInvalidoException(string message, Exception e)
            : base(message,e)
        {

        }
        /// <summary>
        /// Constructor. Llama al constructor padre con una excepcion lanzada antes de esta y pasandole
        /// el mensaje de esta excepcion, pasada como parametro
        /// </summary>
        /// <param name="e">Exception que se lanzo antes de esta</param>
        public DniInvalidoException(Exception e)
            : base(e.Message,e)
        {

        }
    }
}
