using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        #region Constructor 
        /// <summary>
        /// Constructor del Formulario Calculadora
        /// </summary>
        public FormCalculadora()
        {
            InitializeComponent();

            cmbOperador.Items.Add("+");
            cmbOperador.Items.Add("-");
            cmbOperador.Items.Add("*");
            cmbOperador.Items.Add("/");
        }
        #endregion

        #region Manejadores de Eventos
        /// <summary>
        /// Cierra el Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Limpia los campos del form al hacer click en btnLimpiar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
            DeshabilitarBotonesDeConversion();
        }

        /// <summary>
        /// Opera los numeros al hacer click en btnOperar y muestra el resultado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            if (txtOperando1 != null && txtOperando2 != null)
            {
                this.btnConvertirABinario.Enabled = true;
                this.btnConvertirADecimal.Enabled = false;
                this.lblResultado.Text = Operar(txtOperando1.Text, txtOperando2.Text, cmbOperador.Text).ToString();
            }
        }
        /// <summary>
        /// Convierte el resultado de decimal a binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero numero = new Numero();
            if (this.lblResultado.Text != "")
            {
                this.btnConvertirADecimal.Enabled = true;
                this.btnConvertirABinario.Enabled = false;
                this.lblResultado.Text = numero.DecimalBinario(this.lblResultado.Text);
            }

        }
        /// <summary>
        /// Convierte el resultado de binario a decimal 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero numero = new Numero();
            if (this.lblResultado.Text != "")
            {
                this.btnConvertirABinario.Enabled = true;
                this.btnConvertirADecimal.Enabled = false;
                this.lblResultado.Text = numero.BinarioDecimal(this.lblResultado.Text);
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Genera una operacion entre 2 numeros
        /// </summary>
        /// <param name="operando1">Primer operando</param>
        /// <param name="operando2">Segundo operando</param>
        /// <param name="operador">Operador</param>
        /// <returns>El resultado de la operacion</returns>
        private static double Operar(string operando1, string operando2, string operador)
        {
            double resultado = 0;

            Numero num1 = new Numero(operando1);
            Numero num2 = new Numero(operando2);


            resultado = Calculadora.Operar(num1, num2, operador);

            return resultado;
        }
        /// <summary>
        /// Limpia los campos del Form
        /// </summary>
        private void Limpiar()
        {
            this.txtOperando1.Clear();
            this.txtOperando2.Clear();
            this.lblResultado.ResetText();
            this.cmbOperador.ResetText();
            this.btnConvertirADecimal.Enabled = true;
            this.btnConvertirABinario.Enabled = true;
        }

        /// <summary>
        /// Desabilita los botones de convercion
        /// </summary>
        private void DeshabilitarBotonesDeConversion()
        {
            this.btnConvertirABinario.Enabled = false;
            this.btnConvertirADecimal.Enabled = false;
        }
        #endregion

        /// <summary>
        /// Se ejecuta al cargar el form Calculadora. Setea los botones de convercion en no accesible
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmCalculadora_Load(object sender, EventArgs e)
        {
            DeshabilitarBotonesDeConversion();
        }
    }
}
