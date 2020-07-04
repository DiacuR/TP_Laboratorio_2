using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Interfaces;
using Excepciones;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        #region Atributos
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;
        #endregion

        #region Propiedades
        /// <summary>
        /// Setea y devuelve la lista de paquetes
        /// </summary>
        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }
            set
            {
                this.paquetes = value;
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor por defecto que inicializa las listas de la Clase Correo
        /// </summary>
        public Correo()
        {
            mockPaquetes = new List<Thread>();
            paquetes = new List<Paquete>();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Finaliza todos los hilos relacionados con los paquetes
        /// </summary>
        public void finEntregas()
        {
            foreach (Thread hilo in this.mockPaquetes)
            {
                if (hilo.IsAlive)
                {
                    hilo.Abort();
                }
            }
        }
        /// <summary>
        /// Muestra los datos de una Lista de Paquetes
        /// </summary>
        /// <param name="elementos">Lista de Paquetes</param>
        /// <returns>Devuelve los datos de la Lista de Paquetes</returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            StringBuilder sb = new StringBuilder();
            string paquetes = string.Empty;
            
            foreach (Paquete p in ((Correo)elementos).Paquetes)
            {
                paquetes += sb.AppendFormat("{0} para {1} ({2})\n", p.TrackingID, p.DireccionEntrega, p.Estado.ToString());
            }
            
            return paquetes;
        }
        #endregion

        #region Operador
        /// <summary>
        /// Agrega un Paquete al Correo en caso de que el paquete no exista
        /// </summary>
        /// <param name="c">Instancia de Correo</param>
        /// <param name="p">Instancia de Paquete</param>
        /// <returns>Devuelve instancia de correo</returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            Thread hiloPaquete = null;

            if(!(c is null) && !(p is null))
            {
                foreach (Paquete paquete in c.Paquetes)
                {
                    if (paquete == p)
                    {
                        throw new TrackingIdRepetidoException("Error!. Paquete existente.");
                    }
                }
                try
                {
                    c.Paquetes.Add(p);
                    hiloPaquete = new Thread(p.MockCicloDeVida);
                    c.mockPaquetes.Add(hiloPaquete);
                    hiloPaquete.Start();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                
            }

            return c;
        }
        #endregion
    }
}
