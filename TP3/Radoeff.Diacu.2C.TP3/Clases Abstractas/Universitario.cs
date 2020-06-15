using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        #region Constructores
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Universitario()
        {

        }
        /// <summary>
        /// Constructor que inicializa los atributos de Universitario.
        /// </summary>
        /// <param name="legajo">Legajo del universitario</param>
        /// <param name="nombre">Nombre del universitario</param>
        /// <param name="apellido">Apellido del universitario</param>
        /// <param name="dni">D.N.I del universitario</param>
        /// <param name="nacionalidad">Nacionalidad del universitario</param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre,apellido,dni,nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo abstracto. Indicara en que clases se encuentran los miembros de la universidad.
        /// </summary>
        /// <returns>Un string de las calses en las que se encuentra</returns>
        protected abstract string ParticiparEnClase();
        /// <summary>
        /// Metodo virtual. Muestra la informacion de un Universitario
        /// </summary>
        /// <returns>String con los datos de universitario</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine("LEGAJO: " + this.legajo);

            return sb.ToString();
        }
        /// <summary>
        /// Sobre escritura del metodo Equals. Indica que dos Universitarios son iguales, si comparten mismo legajo o D.N.I
        /// </summary>
        /// <param name="obj">Objeto con el que se compara</param>
        /// <returns>Devuelve 'false' en caso de compartir legajo o D.N.I. Caso contrario 'true'</returns>
        public override bool Equals(object obj)
        {
            bool retorno = false;

            if(obj is Universitario)
            {
                if(((Universitario)obj).legajo == this.legajo || ((Universitario)obj).DNI == this.DNI)
                {
                    retorno = true;
                }
            }
            return retorno;
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Compara objetos Universitarios comprobando si son iguales en legajo o D.N.I
        /// </summary>
        /// <param name="pg1">Universitario a comparar</param>
        /// <param name="pg2">Universitario a comparar</param>
        /// <returns>Devuelve 'true' en caso de ser iguales caso contrario 'false'</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return pg1.Equals(pg2);
        }
        /// <summary>
        /// Compara objetos Universitarios comprobando si son diferentes en legajo y D.N.I
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        #endregion
    }
}
