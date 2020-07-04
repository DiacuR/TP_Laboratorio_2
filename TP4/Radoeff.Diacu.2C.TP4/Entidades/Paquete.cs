using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Interfaces;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        #region Enumerado
        /// <summary>
        /// Enumerado del Estado en el que se encuentre el Estado del mismo
        /// </summary>
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }
        #endregion

        #region Atributos
        public delegate void DelegadoEstado(object sender, EventArgs e);
        public event DelegadoEstado InformarEstado;
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;
        #endregion

        #region Propiedades
        /// <summary>
        /// Setea y devuelve la Direccion de Entrega del Paquete
        /// </summary>
        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }
            set
            {
                this.direccionEntrega = value;
            }
        }
        /// <summary>
        /// Setea y devuelve el Estado en el que se encuentra el Paquete
        /// </summary>
        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }
        /// <summary>
        /// Setea y devuelve el TrackingID del Paquete
        /// </summary>
        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }
            set
            {
                this.trackingID = value;
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor Parametrizado
        /// </summary>
        /// <param name="direccionEntrega">Direccion de entrega del Paquete</param>
        /// <param name="trackingID">ID del Paquete</param>
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.DireccionEntrega = direccionEntrega;
            this.TrackingID = trackingID;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Hace que el paquete cumpla su ciclo de vida pasando por todos los Estados 
        /// e inserta el paquete al final en la base de datos
        /// </summary>
        public void MockCicloDeVida()
        {
            while (this.Estado != EEstado.Entregado)
            {
                Thread.Sleep(4000);
                this.Estado++;
                this.InformarEstado(this, EventArgs.Empty);
            }
            try
            {
                PaqueteDAO.Insertar(this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Muestra los datos del Paquete
        /// </summary>
        /// <param name="elemento">Paquete a mostrar</param>
        /// <returns>Devuelve los datos del Paquete</returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            Paquete p = (Paquete)elemento;
            return string.Format("{0} para {1}",  p.TrackingID, p.direccionEntrega);
        }
        #endregion

        #region Sobreescritura
        /// <summary>
        /// Sobreescritura de ToString()
        /// </summary>
        /// <returns>Devuelve los datos de la instancia actual de Paquete</returns>
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Compara los paquetes ID
        /// </summary>
        /// <param name="p1">Paquete a comparar</param>
        /// <param name="p2">Paquete a comparar</param>
        /// <returns>Devuelve 'true' en caso de que sean iguales. Y 'false' en caso contrario</returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return p1.TrackingID == p2.TrackingID;
        }
        /// <summary>
        /// Compara los paquetes ID
        /// </summary>
        /// <param name="p1">Paquete a comparar</param>
        /// <param name="p2">Paquete a comparar</param>
        /// <returns>Devuelve 'true' en caso de que no sean iguales. Y 'false' en caso contrario</returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }
        #endregion
    }
}
