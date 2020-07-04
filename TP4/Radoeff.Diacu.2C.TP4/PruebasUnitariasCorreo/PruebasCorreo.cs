using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using System.Collections.Generic;
using Excepciones;

namespace PruebasUnitariasCorreo
{
    [TestClass]
    public class PruebasCorreo
    {
        /// <summary>
        /// Comprueva que se instancie correctamente la lista Paquetes de la clase Correo
        /// </summary>
        [TestMethod]
        public void ListaPaquetesInstanciada()
        {
            Correo correo = new Correo();

            Assert.IsInstanceOfType(correo.Paquetes, typeof(List<Paquete>));
        }
        /// <summary>
        /// Comprueba que no se puedan agregar 2 paquetes con el mismo TrackingID
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void TrackingIDRepetido()
        {
            Correo correo = new Correo();
            Paquete paquete1 = new Paquete("Calle SiempreViva 742", "234-567-890");
            Paquete paquete2 = new Paquete("Calle Falsa 123", "234-567-890");

            correo += paquete1;
            correo += paquete2;
        }
    }
}
