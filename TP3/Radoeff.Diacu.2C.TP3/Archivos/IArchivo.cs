using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public interface IArchivo<T>
    {
        /// <summary>
        /// Metodo sin implementar. Se va a encargar de guardar archivos
        /// </summary>
        /// <param name="archivo">Ruta del archivo a guardar</param>
        /// <param name="datos">Datos a guardar en el archivo</param>
        /// <returns>'true' en caso de exito, si no 'false'</returns>
        bool Guardar(string archivo, T datos);
        /// <summary>
        /// Metodo sin implementar. Se va a encargar de leer archivos
        /// </summary>
        /// <param name="archivo">Ruta del archivo a leer</param>
        /// <param name="datos">Datos a pasar en el archivo del archivo al programa</param>
        /// <returns>'true' en caso de exito, si no 'false'</returns>
        bool Leer(string archivo, out T datos);
    }
}
