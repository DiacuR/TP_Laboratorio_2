using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Archivos;
using Entidades;
using Interfaces;
using Excepciones;

namespace FormPrincipal
{
    public partial class FormPrincipal : Form
    {
        Correo correo;

        #region Constructor
        /// <summary>
        /// Constructor del Formulario
        /// </summary>
        public FormPrincipal()
        {
            InitializeComponent();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Inicializa atributos de la clase
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            correo = new Correo();
        }
        /// <summary>
        /// Cierra todos los hilos que puedan quedar vivos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            correo.finEntregas();
        } 
        /// <summary>
        /// Agrega un paquete nuevo al correo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Paquete nuevoPaquete = null;

            try
            {
                if(this.mtxtTrackingID.Text != string.Empty && this.txtDireccion.Text != string.Empty)
                {
                    nuevoPaquete = new Paquete(this.txtDireccion.Text, this.mtxtTrackingID.Text);
                    nuevoPaquete.InformarEstado += paq_InformaEstado;
                    correo += nuevoPaquete;
                    ActualizarEstados();
                }
            }
            catch (TrackingIdRepetidoException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        /// <summary>
        /// Muestra todos los paquetes dentro de la lista de correo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }
        /// <summary>
        /// Muestra el paquete seleccionado en la lista de paquetes entregados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }
        /// <summary>
        /// Actualiza los listBox, siempre comprobando estar el el hilo principal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if(this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.ActualizarEstados();
            }
        }
        /// <summary>
        /// Borra y vuelve a agregar los datos a los ListBoxs
        /// </summary>
        private void ActualizarEstados()
        {
            this.lstEstadoEntregado.Items.Clear();
            this.lstEstadoEnViaje.Items.Clear();
            this.lstEstadoIngresado.Items.Clear();

            foreach (Paquete paquete in correo.Paquetes)
            {
                switch (paquete.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        this.lstEstadoIngresado.Items.Add(paquete);
                        break;
                    case Paquete.EEstado.EnViaje:
                        this.lstEstadoEnViaje.Items.Add(paquete);
                        break;
                    case Paquete.EEstado.Entregado:
                        this.lstEstadoEntregado.Items.Add(paquete);
                        break;
                }
            }
        }
        /// <summary>
        /// Muestra la informacion en rtbMostrar de las clases que implementen IMostrar<> y
        /// Guarda esa informacion en un archivo de texto en el desktop
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento"></param>
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            string archivoAGuardar = "salida";
            try
            {
                if (!(elemento is null))
                {
                    this.rtbMostrar.Text = elemento.MostrarDatos(elemento);
                    this.rtbMostrar.Text.ToString().Guardar(archivoAGuardar);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        #endregion
    }
}
