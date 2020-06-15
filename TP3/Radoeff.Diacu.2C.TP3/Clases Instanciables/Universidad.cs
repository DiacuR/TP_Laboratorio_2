using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace Clases_Instanciables
{
    public class Universidad
    {
        #region Enumerados
        /// <summary>
        /// Enumerado con las clases que se pueden tomar o dar
        /// </summary>
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
        #endregion

        private List<Jornada> jornada;
        private List<Profesor> profesores;
        private List<Alumno> alumnos;

        #region Propiedades
        /// <summary>
        /// Setea y/o devuelve la lista de jornadas
        /// </summary>
        public List<Jornada> Jornada
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }
        /// <summary>
        /// Setea y/o devuelve la lista de profesores
        /// </summary>
        public List<Profesor> Profesores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }
        /// <summary>
        /// Setea y/o devuelve la lista de alumnos
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
        /// <summary>
        /// Setea y/o devuelve un elemento especifico de la lista de jornadas
        /// </summary>
        public Jornada this[int i]
        {
            get
            {
                return this.jornada[i];
            }
            set
            {
                this.jornada[i] = value;
            }
        }

        #endregion

        #region Constructores
        /// <summary>
        /// Constructor inicializa los atributos de universidad
        /// </summary>
        public Universidad()
        {
            this.Jornada = new List<Jornada>();
            this.Profesores = new List<Profesor>();
            this.Alumnos = new List<Alumno>();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Indica los datos de la universidad
        /// </summary>
        /// <param name="uni">Objeto universidad</param>
        /// <returns>String con los datos de universidad</returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("JORNADA: \n");
            foreach (Jornada item in uni.Jornada)
            {
                sb.AppendLine(item.ToString());
                sb.AppendLine("\n<------------------------------------------------------------------------------>\n");
            }

            return sb.ToString();
        }
        /// <summary>
        /// Metodo ToString() sobreescrito.  
        /// </summary>
        /// <returns>String con los datos de universidad</returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }
        /// <summary>
        /// Guarda un objeto universidad en formato XML
        /// </summary>
        /// <param name="uni">Objeto universidada a guardar</param>
        /// <returns>Retorna 'true' si se pudo guardar, si no 'false'</returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            string path = Directory.GetCurrentDirectory() + @"\Universidad.xml";

            return xml.Guardar(path, uni);

        }
        /// <summary>
        /// Lee un archivo XML, y lo retorna por referencia como un objeto universidad
        /// </summary>
        /// <returns>Universidad con los datos del archivo</returns>
        public static Universidad Leer()
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            string path = Directory.GetCurrentDirectory() + @"\Universidad.xml";
            Universidad uni;

            xml.Leer(path, out uni);
            
            return uni;
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Indica que el obj Universidad es igual a un Alumno, si este esta inscripto en la Universidad
        /// </summary>
        /// <param name="g">Objeto Universidad</param>
        /// <param name="a">Objeto Alumno</param>
        /// <returns>Devuelve 'true' si el Alumno esta inscripto en la universidad, si no 'false</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool retorno = false;

            if (!(g is null) && !(a is null))
            {
                foreach (Alumno item in g.Alumnos)
                {
                    if (item == a)
                    {
                        retorno = true;
                        break;
                    }
                }
            }

            return retorno;
        }
        /// <summary>
        /// Indica que el obj Universidad es diferente a un Alumno, si este esta no inscripto en la Universidad
        /// </summary>
        /// <param name="g">Objeto Universidad</param>
        /// <param name="a">Objeto Alumno</param>
        /// <returns>Devuelve 'true' si el Alumno no esta inscripto en la universidad, si no 'false</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
        /// <summary>
        /// Indica que el obj Universidad es igual a un Profesor, si este esta inscripto en la Universidad
        /// </summary>
        /// <param name="g">Objeto Universidad</param>
        /// <param name="a">Objeto Alumno</param>
        /// <returns>Devuelve 'true' si el Profesor esta inscripto en la universidad, si no 'false</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool retorno = false;

            if (!(g is null) && !(i is null))
            {
                foreach (Profesor item in g.Profesores)
                {
                    if (item == i)
                    {
                        retorno = true;
                        break;
                    }
                }
            }

            return retorno;
        }
        /// <summary>
        /// Indica que el obj Universidad es diferente a un Profesor, si este no esta inscripto en la Universidad
        /// </summary>
        /// <param name="g">Objeto Universidad</param>
        /// <param name="a">Objeto Alumno</param>
        /// <returns>Devuelve 'true' si el Profesor no esta inscripto en la universidad, si no 'false</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }
        /// <summary>
        /// Busca un profesor que este en la universidad y que de esa clase
        /// </summary>
        /// <param name="u">Objeto universidad</param>
        /// <param name="clase">Clase para la que se busca profesor</param>
        /// <returns>Si hay un profesor para esa clase lo retorna. Si no lo hay, se tira un SinProfesorException()</returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            Profesor profesor = null;

            if(!(u is null))
            {
                foreach (Profesor item in u.Profesores)
                {
                    if(item == clase)
                    {
                        profesor = item;
                        break;
                    }
                }
                if (profesor is null)
                {
                    throw new SinProfesorException();
                }
            }

            return profesor;
        }
        /// <summary>
        /// Busca un profesor que este en la universidad y que no de esa clase
        /// </summary>
        /// <param name="u">Objeto universidad</param>
        /// <param name="clase">Clase para la que se busca profesor que no la dé</param>
        /// <returns>Si no hay un profesor para esa clase lo retorna el primero en encontrar
        /// Caso contrario devuelve null</returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor profesor = null;

            if (!(u is null))
            {
                foreach (Profesor item in u.Profesores)
                {
                    if (item != clase)
                    {
                        profesor = item;
                        break;
                    }
                }
            }

            return profesor;
        }
        /// <summary>
        /// Agrega un alumno a la universidad, en caso de que no se encuentre en ella
        /// </summary>
        /// <param name="g">Objeto universidad</param>
        /// <param name="a">Objeto Alumno</param>
        /// <returns>Universidad con el alumno cargado en caso de exito. Caso contrario tira un AlumnoRepetidoException()</returns>
        public static Universidad operator +(Universidad g, Alumno a)
        {
            if (!(g is null) && !(a is null))
            {
               if (g != a)
                {
                    g.Alumnos.Add(a);
                }
                else
                {
                    throw new AlumnoRepetidoException();
                }
            } 

            return g;
        }
        /// <summary>
        /// Agrega un profesor a la universidad, en caso de que no se encuentre en ella
        /// </summary>
        /// <param name="g">Objeto universidad</param>
        /// <param name="a">Objeto profesor</param>
        /// <returns>Universidad con el profesor cargado en caso de exito. Caso contrario no agrega al profesor</returns>
        public static Universidad operator +(Universidad g, Profesor i)
        {
            if (!(g is null) && !(i is null))
            {
                if (g != i)
                {
                    g.Profesores.Add(i);
                }
            }

            return g;
        }
        /// <summary>
        /// Crea una jornada,con una clase, un profesor, alumnos que tengan esa materia y la agrega a la universidad
        /// </summary>
        /// <param name="g">Objeto Universidad</param>
        /// <param name="clase">Enumerado del tipo Eclases</param>
        /// <returns>Una Universidad con una jornada nueva en caso de exito.</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada jornada = null;

            if (!(g is null))
            {
                jornada = new Jornada(clase, g == clase);

                foreach (Alumno item in g.Alumnos)
                {
                    if(item == clase)
                    {
                        jornada += item;
                    }
                }
                g.Jornada.Add(jornada);
            }

            return g;
        }
        #endregion
    }
}
