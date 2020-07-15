using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        #region Metodos
        /// <summary>
        /// Se encarga de realizar la operacion entre los dos operandos
        /// </summary>
        /// <param name="num1">Primer operando</param>
        /// <param name="num2">Segundo operando</param>
        /// <param name="operador">Operador que indica que operacion realizar</param>
        /// <returns>El resultado de la operacion</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado = 0;
            operador = validarOperador(operador);

            switch (operador)
            {
                case "+":
                    resultado = num1 + num2;
                    break;
                case "-":
                    resultado = num1 - num2;
                    break;
                case "*":
                    resultado = num1 * num2;
                    break;
                case "/":
                    resultado = num1 / num2;
                    break;
                default:
                    resultado = 0;
                    break;
            }

            return resultado;
        }

        /// <summary>
        /// Valida que el operador sea correcto
        /// </summary>
        /// <param name="operador">Operador a validar</param>
        /// <returns>En caso de exito retorna el operador. En caso contrario '+'</returns>
        private static string validarOperador(string operador)
        {
            string retornoOperador = "+";
            if (operador != string.Empty)
            {
                if (operador == "-" || operador == "*" || operador == "/")
                {
                    retornoOperador = operador;
                }
            }
            return retornoOperador;
        }
        #endregion
    }
}
