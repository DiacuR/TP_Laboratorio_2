using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        #region Enumerado

        /// <summary>
        /// Enumerado con Nacionalidad
        /// </summary>
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
        #endregion

        private string nombre;
        private string apellido;
        private ENacionalidad nacionalidad;
        private int dni;

        #region Propiedades
        /// <summary>
        /// Setea un nombre y/o devuelve un string con el nombre
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = this.ValidarNombreApellido(value);
            }
        }
        /// <summary>
        /// Setea un apellido y/o devuelve un string con el nombre
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = this.ValidarNombreApellido(value);
            }
        }
        /// <summary>
        /// Setea un nacionalidad y/o devuelve un ENacionalidad con el valor
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }
        /// <summary>
        /// Setea un dni y/o devuelve un entero con el dni
        /// </summary>
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                dni = this.ValidarDni(this.Nacionalidad,value);
            }
        }
        /// <summary>
        /// Setea un dni y/o devuelve un string con el dni
        /// </summary>
        public string StringToDNI
        {
            set
            {
                this.dni = this.ValidarDni(this.Nacionalidad, value);
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Persona()
        {

        }
        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="apellido">Apellido de la persona</param>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
            : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }
        /// <summary>
        /// Constructor con parametros, inicializa dni como int
        /// </summary>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="apellido">Apellido de la persona</param>
        /// <param name="dni">D.N.I de la persona</param>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            :this(nombre,apellido,nacionalidad)
        {
            this.DNI = dni;
        }
        /// <summary>
        /// Constructor con parametros, inicializa dni como string
        /// </summary>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="apellido">Apellido de la persona</param>
        /// <param name="dni">D.N.I de la persona</param>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion
        
        #region Metodos
        /// <summary>
        /// Valida que el nro de dni, corresponda con la nacionalidad
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        /// <param name="dato">D.N.I de la persona a validar</param>
        /// <returns>Devuelve el dni en caso de exito. Caso contrario devuelve '0'</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            int retornoDni = 0;

            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    
                    if(dato >= 1 && dato <= 89999999)
                    {
                        retornoDni = dato;
                    }
                    else
                    {
                        throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI.");
                    }
                    break;

                case ENacionalidad.Extranjero:
                    
                    if (dato >= 90000000 && dato <= 99999999)
                    {
                        retornoDni = dato;
                    }
                    else
                    {
                        throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI.");
                    }
                    break;
            }

            return retornoDni;
        }
        /// <summary>
        /// Valida que el dni solo sea numerico
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        /// <param name="dato">D.N.I de la persona a validar</param>
        /// <returns>Devuelve el dni en caso de exito. Caso contrario tira un DniInvalidoException</returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int dniValidado;

            if(int.TryParse(dato,out dniValidado))
            {
                dniValidado = ValidarDni(nacionalidad, dniValidado);
            }
            else
            {
                throw new DniInvalidoException();
            }
            return dniValidado;
        }
        /// <summary>
        /// Valida que el string recivido sean solo letras
        /// </summary>
        /// <param name="dato">String a validar</param>
        /// <returns>Devuelve el string en caso de exito. Caso contrario null</returns>
        private string ValidarNombreApellido(string dato)
        {
            string aux = null;
            bool validacion = false;

            foreach (char item in dato)
            {
                if(item >= 65 && item <= 90 || item >= 97 && item <= 122)
                {
                    validacion = true;
                }
                else
                {
                    validacion = false;
                    break;
                }
            }
            if (validacion)
            {
                aux = dato;
            }

            return aux;
        }
        /// <summary>
        /// Muestra la info de persona
        /// </summary>
        /// <returns>Un string con los datos de persona</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format("NOMBRE COMPLETO: {0}, {1}", this.Apellido, this.Nombre));
            sb.AppendLine("NACIONALIDAD: " + this.Nacionalidad);
            sb.Append("D.N.I: " + this.DNI);

            return sb.ToString();
        }
        #endregion
    }
}
