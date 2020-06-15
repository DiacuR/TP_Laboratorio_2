using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using Clases_Instanciables;
using Archivos;
using System.IO;

namespace TestUniversidad
{
    [TestClass]
    public class TestExcepciones
    {
        /// <summary>
        /// Valida que se lanze un ArchivosException, al pasarle un path erroneo
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArchivosException))]
        public void ArchivoInvalido()
        {
            Texto txt = new Texto();
            string path = "a" + Directory.GetCurrentDirectory() + "\\prueva.txt";
            string datos = "Hola mundo";

            txt.Guardar(path, datos);
        }
        /// <summary>
        /// Valida que lanze un AlumnoRepetidoException, al agregar 2 alumnos con mismo dni a la universidad
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void AlumnoInvalido()
        {
            Universidad uni = new Universidad();
            Alumno a1 = new Alumno(15, "Ian", "Rodriguez", "35000000", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);
            Alumno a2 = new Alumno(20, "Alfonso", "Gonzales", "35000000", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Legislacion, Alumno.EEstadoCuenta.Becado);

            uni += a1;
            uni += a2;

        }
        /// <summary>
        /// Valida que se lanze una NacionalidadInvalidaException, al agregar un dni que no concuerde
        /// con la nacionalidad
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void NacionalidadInvalida()
        {
            Alumno a1 = new Alumno(15, "Ian", "Rodriguez", "35000000", EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);
        }
        /// <summary>
        /// Valida que se lanze un DniInvalidoException, al agregar un dni con caracteres no numericos
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void DniInvalido()
        {
            Alumno a1 = new Alumno(15, "Ian", "Rodriguez", "3500000¡", EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);
        }
        /// <summary>
        /// Valida que se lanze un SinProfesorException, al poner una EClase en universidad que no tenga profesor
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(SinProfesorException))]
        public void SinProfesor()
        {
            Profesor profesor;
            Universidad uni = new Universidad();

            profesor = uni == Universidad.EClases.SPD;
        }

    }
}
