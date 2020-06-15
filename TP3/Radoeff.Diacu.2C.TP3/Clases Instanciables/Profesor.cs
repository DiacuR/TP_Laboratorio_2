using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        #region Constructores
        /// <summary>
        /// Constructor estatico. Inicializa coleccion Queue.
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }
        /// <summary>
        /// Constructor por defecto 
        /// </summary>
        public Profesor()
        {

        }
        /// <summary>
        /// Constructor que inicializa los atributos de Profesor
        /// </summary>
        /// <param name="id">Id unico para el profesor</param>
        /// <param name="nombre">Nombre del profesor</param>
        /// <param name="apellido">Apellido del profesor</param>
        /// <param name="dni">D.N.I del profesor</param>
        /// <param name="nacionalidad">Nacionalidad del profesor</param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id,nombre,apellido,dni,nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._ramdomClase();
            this._ramdomClase();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Genera una clase Random de las que hay en el enumerado Eclase
        /// </summary>
        private void _ramdomClase()
        {
            int aleatorio = random.Next(0, 4);
            this.clasesDelDia.Enqueue((Universidad.EClases)aleatorio);
        }
        /// <summary>
        /// Indica las clases que tiene el profesor. En un string
        /// </summary>
        /// <returns>Devuelve el string con las clases que tiene el profesor</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Clases Del Dia: ");

            foreach (Universidad.EClases item in this.clasesDelDia)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }
        /// <summary>
        /// Metodo protegido. Indica los datos del profesor
        /// </summary>
        /// <returns>String con los datos del profesor</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());
            
            return sb.ToString();
        }
        /// <summary>
        /// LLama a MostrarDatos para poder mostrar los datos fuere del arbol de herencia
        /// </summary>
        /// <returns>String con los datos del profesor</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Indica que un profesor es igual a una clase si el profesor da la clase(atributo clasesDelDia)
        /// </summary>
        /// <param name="i">Objeto Profesor</param>
        /// <param name="clase">Enumerado de Eclase</param>
        /// <returns>Devuelve 'true' si da la clase. Caso contrario 'false'</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            return i.clasesDelDia.Contains(clase);
        }
        /// <summary>
        /// Indica que un profesor es diferente a una clase si el profesor no da la clase(atributo clasesDelDia)
        /// </summary>
        /// <param name="i">Objeto Profesor</param>
        /// <param name="clase">Enumerado de Eclase</param>
        /// <returns>Devuelve 'true' si no da la clase. Caso contrario 'false'</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
        #endregion
    }
}
