using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        /// <summary>
        /// Constructor. Llama a constructor padre con un mensaje por defecto y una innerException
        /// </summary>
        /// <param name="innerException">Excepcion previa al lanzar esta</param>
        public ArchivosException(Exception innerException)
            : base("No se pudo Leer/Escribir el archivo",innerException)
        {

        }
    }
}
