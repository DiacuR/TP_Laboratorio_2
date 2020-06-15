using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Guarda un archivo en formato string
        /// </summary>
        /// <param name="archivo">Ruta del archivo a guardar</param>
        /// <param name="datos">Datos a guardar en el archivo</param>
        /// <returns>'true' en caso de exito, si no 'false'</returns>
        public bool Guardar(string archivo, string datos)
        {
            StreamWriter sw = null;
            bool retorno = false;

            try
            {
                if (!(archivo is null) && !(datos is null))
                {
                    sw = new StreamWriter(archivo);
                    sw.WriteLine(datos);
                    retorno = true;
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            finally
            {
                if (!(sw is null))
                {
                    sw.Close();
                }
            }

            return retorno;
        }
        /// <summary>
        /// Lee archivos de tipo string
        /// </summary>
        /// <param name="archivo">Ruta del archivo a leer</param>
        /// <param name="datos">Datos a pasar del archivo, al programa</param>
        /// <returns>'true' en caso de exito, si no 'false'</returns>
        public bool Leer(string archivo, out string datos)
        {
            StreamReader sr = null;
            datos = string.Empty;
            bool retorno = false;

            try
            {
                if (!(archivo is null))
                {
                    sr = new StreamReader(archivo, Encoding.Default);
                    datos = sr.ReadToEnd();
                    retorno = true;
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            finally
            {
                if (!(sr is null))
                {
                    sr.Close();
                }
            }

            return retorno;
        }
    }
}
