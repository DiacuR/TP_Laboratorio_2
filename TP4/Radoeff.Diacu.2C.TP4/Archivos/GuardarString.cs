using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public static class Extencion
    {
        #region Metodo de Extencion
        /// <summary>
        /// Extencion de la clase String que se encarga de guardar en el desktop un archivo .txt,
        /// en caso de no existir el archivo lo crea, y si existe le agrega el texto sin borrar lo anterior
        /// </summary>
        /// <param name="texto">Texto a ser guardado en el archivo .txt</param>
        /// <param name="archivo">Nombre del archivo</param>
        /// <returns>Devuelve 'true' en caso de exito. Y 'false' caso contrario </returns>
        public static bool Guardar(this string texto, string archivo)
        {
            StreamWriter sw = null;
            bool retorno = false;

            try
            {
                if (!(archivo is null) && !(texto is null))
                {
                    sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) +
                    @"\"+ archivo +".txt", true);
                    sw.WriteLine(texto);
                    retorno = true;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al guardar el string en el archivo",e);
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
        #endregion
    }
}
