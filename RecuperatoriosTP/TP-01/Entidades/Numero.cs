using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        #region Constructores
        /// <summary>
        /// Constructor Vacio
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }
        /// <summary>
        /// Constructor que inicializa el atributo numero
        /// </summary>
        /// <param name="numero">Numero con que se inicializa</param>
        public Numero(double numero)
        {
            this.numero = numero;
        }
        /// <summary>
        /// Constructor que inicializa el atributo numero, validando que sea numero
        /// </summary>
        /// <param name="strNumero">Numero que inicializa, si se puede validar</param>
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad que setea el atributo numero validando que sea uno
        /// </summary>
        private string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Valida numero
        /// </summary>
        /// <param name="numero">Numero a validar</param>
        /// <returns>En caso de exito retorna el numero. Caso contrario 0 </returns>
        private static double ValidarNumero(string numero)
        {
            double num;
            double retorno = 0;

            if (numero != string.Empty)
            {
                if (double.TryParse(numero, out num))
                {
                    retorno = num;
                }
            }
            return retorno;

        }
        /// <summary>
        /// Valida si un numero es binario
        /// </summary>
        /// <param name="binario">Numero a validar</param>
        /// <returns>Retorna 'true' en caso de exito, caso contrario 'false'</returns>
        private static bool EsBinario(string binario)
        {
            bool retorno = false;

            if (binario != string.Empty)
            {
                foreach (char item in binario)
                {
                    if (item == '1' || item == '0')
                    {
                        retorno = true;
                    }
                    else
                    {
                        retorno = false;
                        break;
                    }
                }
            }

            return retorno;
        }

        /// <summary>
        /// Convierte un numero de decimal a binario
        /// </summary>
        /// <param name="nroDecimal">Numero a convertir</param>
        /// <returns>El numero en binario</returns>
        public string DecimalBinario(double nroDecimal)
        {
            return this.DecimalBinario(nroDecimal.ToString());
        }
        /// <summary>
        /// Convierte de decimal a binario
        /// </summary>
        /// <param name="nroDecimal">Numero a convertir</param>
        /// <returns>El numero binario en caso de exito. Caso contrario 'Valor Invalido'</returns>
        public string DecimalBinario(string nroDecimal)
        {
            double num;
            string retorno = string.Empty;
            Double.TryParse(nroDecimal, out num);
            num = Math.Floor(num);

            if (num > 0)
            {
                while (num > 0)
                {
                    retorno = (num % 2).ToString() + retorno;
                    num = num / 2;
                    num = Math.Floor(num);
                }
            }
            else
            {
                retorno = "Valor Invalido";
            }

            return retorno;
        }
        /// <summary>
        /// Convierte de binario a decimal
        /// </summary>
        /// <param name="binario">Numero a convertir</param>
        /// <returns>Retorna el numero decimal. Y en caso de error 'Valor Invalido'</returns>
        public String BinarioDecimal(string binario)   //Convierte un número binario a entero.
        {
            double nroDecimal = 0;
            int nroBinario = 0;
            String num = "";

            if (EsBinario(binario))
            {
                char[] cadena = binario.ToCharArray();
                for (int i = cadena.Length - 1; i >= 0; i--)
                {
                    nroDecimal += Math.Pow(2, nroBinario) * (int)char.GetNumericValue(cadena[i]);
                    nroBinario++;
                }
                num = Convert.ToString(nroDecimal);
            }
            else
            {
                num = "Valor Invalido";
            }


            return num;
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Sobreescritura del operador '+'
        /// </summary>
        /// <param name="num1">Primer operando</param>
        /// <param name="num2">Segundo operando</param>
        /// <returns>El resultado de la operacion</returns>
        public static double operator +(Numero num1, Numero num2)
        {
            return num1.numero + num2.numero;
        }

        /// <summary>
        /// Sobreescritura del operador '-'
        /// </summary>
        /// <param name="num1">Primer operando</param>
        /// <param name="num2">Segundo operando</param>
        /// <returns>El resultado de la operacion</returns>
        public static double operator -(Numero num1, Numero num2)
        {
            return num1.numero - num2.numero;
        }

        /// <summary>
        /// Sobreescritura del operador '*'
        /// </summary>
        /// <param name="num1">Primer operando</param>
        /// <param name="num2">Segundo operando</param>
        /// <returns>El resultado de la operacion</returns>
        public static double operator *(Numero num1, Numero num2)
        {
            return num1.numero * num2.numero;
        }

        /// <summary>
        /// Sobreescritura del operador '/'
        /// </summary>
        /// <param name="num1">Primer operando</param>
        /// <param name="num2">Segundo operando</param>
        /// <returns>El resultado de la operacion</returns>
        public static double operator /(Numero num1, Numero num2)
        {
            double retorno = double.MinValue;
            if (num2.numero != 0)
            {
                retorno = num1.numero / num2.numero;
            }
            return retorno;

        }
        #endregion
    }
}
