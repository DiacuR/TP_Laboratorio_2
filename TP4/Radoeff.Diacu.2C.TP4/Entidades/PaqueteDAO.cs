using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class PaqueteDAO
    {
        #region Atributos
        private static SqlCommand comando;
        private static SqlConnection conexion;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor estatico que inicializa la conexion con la Base de Datos y el tipo de comando que se va a usar 
        /// </summary>
        static PaqueteDAO()
        {
            conexion = new SqlConnection(@"Data Source = .\SQLEXPRESS; Database = correo-sp-2017; Trusted_Connection = true;");
            comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Inserta el Paquete en la Base de Datos
        /// </summary>
        /// <param name="p">Paquete a ingresar</param>
        /// <returns>Devuelve 'true' en caso de exito. Y 'false' caso contrario</returns>
        public static bool Insertar(Paquete p)
        {
            bool pudoAgregarse = false;
            int insertado = 0;

            try
            {
                comando.Connection = conexion;
                comando.CommandText = $"INSERT INTO Paquetes (direccionEntrega,trackingID,alumno) values('{p.DireccionEntrega}','{p.TrackingID}','Diacu Demetrio Radoeff');";

                conexion.Open();
                insertado = comando.ExecuteNonQuery();

                if (insertado != 1)
                {
                    pudoAgregarse = true;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al insertar paquete el la base de datos");
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conexion.State != System.Data.ConnectionState.Closed)
                {
                    conexion.Close();
                }
            }

            return pudoAgregarse;
        }
        #endregion
    }
}
