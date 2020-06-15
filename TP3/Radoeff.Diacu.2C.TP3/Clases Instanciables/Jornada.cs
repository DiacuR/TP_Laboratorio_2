
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using EntidadesAbstractas;

namespace Clases_Instanciables
{
    public class Jornada
    {
        private Profesor instructor;
        private Universidad.EClases clase;
        private List<Alumno> alumnos;

        #region Propiedades
        /// <summary>
        /// Setea y/o devuelve el valor de instructor
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }
        /// <summary>
        /// Setea y/o devuelve el valor de clase
        /// </summary>
        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }
        /// <summary>
        /// Setea y/o devuelve el valor de la lista de alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor privado. Inicializa la lista de alumnos
        /// </summary>
        private Jornada()
        {
            alumnos = new List<Alumno>();
        }
        /// <summary>
        /// Constructor que inicializa los atributos de Jornada
        /// </summary>
        /// <param name="clase">Clase de la jornada</param>
        /// <param name="instructor">Profesor de la Jornada</param>
        public Jornada(Universidad.EClases clase, Profesor instructor)
            :this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Guarda un objeto Jornada en formato .txt
        /// </summary>
        /// <param name="jornada">Objeto Jornada a guardar</param>
        /// <returns>Devuelve 'true' si se pudo guardar. Y 'false' caso contrario</returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto texto = new Texto();
            string path = Directory.GetCurrentDirectory() + "\\Jornada.txt";

            return texto.Guardar(path, jornada.ToString());
        }
        /// <summary>
        /// Lee un archivo .txt y lo mete en el programa como un objeto
        /// </summary>
        /// <returns>Un string con los datos leidos en caso de exito. Caso contrario un string vacio</returns>
        public static string Leer()
        {
            Texto texto = new Texto();
            string retorno;
            string path = Directory.GetCurrentDirectory() + "\\Jornada.txt";

            texto.Leer(path, out retorno);

            return retorno;
        }
        /// <summary>
        /// Indica los datos del objeto Jornada
        /// </summary>
        /// <returns>String con los datos de jornada</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format("CLASE DE {0} POR {1}",this.Clase.ToString(),this.Instructor.ToString()));
            sb.AppendLine("ALUMNOS: \n");

            foreach (Alumno item in this.Alumnos)
            {
                sb.AppendLine(item.ToString());
            }
            
            return sb.ToString();
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Indica si un alumno pertenece a la jornada
        /// </summary>
        /// <param name="j">Objeto jornada</param>
        /// <param name="a">Objeto Alumno</param>
        /// <returns>'true' si el alumno se encuentra en la jornada. Caso contrario 'false'</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool pertenece = false;

            if (!(j is null) && !(a is null))
            {
                foreach (Alumno item in j.Alumnos)
                {
                    if (item == a)
                    {
                        pertenece = true;
                    }
                }
            }

            return pertenece;
        }
        /// <summary>
        /// Indica si un alumno no pertenece a la jornada
        /// </summary>
        /// <param name="j">Objeto jornada</param>
        /// <param name="a">Objeto Alumno</param>
        /// <returns>'true' si el alumno no se encuentra en la jornada. Caso contrario 'false'</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return  !(j == a);
        }
        /// <summary>
        /// Agrega un alumno a una jornada si el alumno todavia no existe en dicha jornada
        /// </summary>
        /// <param name="j">Objeto jornada</param>
        /// <param name="a">Objeto Alumno</param>
        /// <returns>Devuelve la jornada</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (!(j is null) && !(a is null))
            {
                if (j != a)
                {
                    j.Alumnos.Add(a);
                }
            }

            return j;
        }
        #endregion
    }
}
