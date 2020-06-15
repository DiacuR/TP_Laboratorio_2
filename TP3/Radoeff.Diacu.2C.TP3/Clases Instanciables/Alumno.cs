using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Clases_Instanciables
{
    public class Alumno : Universitario
    {
        #region Enumerados
        /// <summary>
        /// Enumerado con los estados de cuenta de los alumnos
        /// </summary>
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }
        #endregion

        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        #region Constructores
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Alumno()
        {

        }
        /// <summary>
        /// Constructor que inicializa los atributos de Alumno
        /// </summary>
        /// <param name="id">Id unico del alumno</param>
        /// <param name="nombre">Nombre del alumno</param>
        /// <param name="apellido">Apellido del alumno</param>
        /// <param name="dni">D.N.I del alumno</param>
        /// <param name="nacionalidad">Nacionalidad del alumno</param>
        /// <param name="claseQueToma">Clase que toma el alumno</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }
        /// <summary>
        /// Constructor que inicializa los atributos de Alumno
        /// </summary>
        /// <param name="id">Id unico del alumno</param>
        /// <param name="nombre">Nombre del alumno</param>
        /// <param name="apellido">Apellido del alumno</param>
        /// <param name="dni">D.N.I del alumno</param>
        /// <param name="nacionalidad">Nacionalidad del alumno</param>
        /// <param name="claseQueToma">Clase que toma el alumno</param>
        /// <param name="estadoCuenta">Estado de cuenta del alumno</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id,nombre,apellido,dni,nacionalidad,claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Indica la clase en la que participa el alumno, atravez de un string
        /// </summary>
        /// <returns>String con la clase en la que participa el alumno</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("CLASE DEL DIA: " + this.claseQueToma);

            return sb.ToString();
        }
        /// <summary>
        /// Indica todos los datos de Alumno en un string
        /// </summary>
        /// <returns>String con los datos de Alumno</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());
            if (this.estadoCuenta == EEstadoCuenta.AlDia)
            {
                sb.AppendLine("ESTADO DE CUENTA: Cuota al dia");
            }
            else
            {
                sb.AppendLine("ESTADO DE CUENTA: " + this.estadoCuenta);
            }
            sb.AppendLine("TOMA CLASES DE " + this.claseQueToma);
            return sb.ToString();
        }
        /// <summary>
        /// Sobreescritura de metodo. Llama a MostrarDatos para mostrar los datos de Alumno
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Indica que un alumno es igual a una clase, si este pertenece a la misma y su estado de
        /// cuenta es diferente a 'Deudor'
        /// </summary>
        /// <param name="a">Objeto Alumno</param>
        /// <param name="clase">Enumerado de EClase</param>
        /// <returns>Devuelve 'true' si el alumno si este pertenece a la misma y su estado de 
        /// cuenta es diferente a 'Deudor'. Y 'false' caso contrario</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor;
        }
        /// <summary>
        /// Indica que un alumno es diferente a una clase, si este no pertenece a la misma
        /// </summary>
        /// <param name="a">Objeto Alumno</param>
        /// <param name="clase">Enumerado de EClase</param>
        /// <returns>Devuelve 'true' si el alumno si este no pertenece a la misma  Y 'false' caso contrario</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return a.claseQueToma != clase;
        }
        #endregion
    }
}
