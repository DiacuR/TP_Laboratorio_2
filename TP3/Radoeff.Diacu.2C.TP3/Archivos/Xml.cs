using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Guarda un archivo en formato xml
        /// </summary>
        /// <param name="archivo">Ruta del archivo a guardar</param>
        /// <param name="datos">Datos a guardar en el archivo</param>
        /// <returns>'true' en caso de exito, si no 'false'</returns>
        public bool Guardar(string archivo, T datos)
        {
            XmlTextWriter writer = null;
            XmlSerializer ser = null;
            bool retorno = false;
            try
            {
                if (!(archivo is null) && (datos != null))
                {
                    writer = new XmlTextWriter(archivo, Encoding.Default);
                    
                    ser = new XmlSerializer(typeof(T));

                    ser.Serialize(writer, datos);
                    retorno = true;
                }
            }
            catch (IOException e)
            {
                throw new ArchivosException(e);
            }
            finally
            {
                if (!(writer is null))
                {
                    writer.Close();
                }
            }

            return retorno;
            
        }
        /// <summary>
        /// Leer archivos en el formato .xml
        /// </summary>
        /// <param name="archivo">Ruta del archivo a leer</param>
        /// <param name="datos">Datos a pasar del archivo, al programa</param>
        /// <returns>'true' en caso de exito, si no 'false'</returns>
        public bool Leer(string archivo, out T datos)
        {
            XmlTextReader reader = null;
            XmlSerializer ser = null;
            datos = default(T);
            bool retorno = false; 

            try
            {
                if (!(archivo is null))
                {
                    reader = new XmlTextReader(archivo);

                    ser = new XmlSerializer(typeof(T));

                    datos = (T)ser.Deserialize(reader);
                    retorno = true;
                }
            }
            catch (IOException e)
            {
                throw new ArchivosException(e);
            }
            finally
            {
                if (!(reader is null))
                {
                    reader.Close();
                }
            }

            return retorno;
        }

 
        
    }
}
