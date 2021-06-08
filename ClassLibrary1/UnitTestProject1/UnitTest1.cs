using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Examen3EV_NS;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CalcularEstadisticas_ListaConValoresValidos_ActualizaNotas()
        {
            // Preparación de la prueba
            List<int> notas = new List<int>();
            notas.Add(0);
            notas.Add(3);
            notas.Add(4);
            notas.Add(5);
            notas.Add(7);
            notas.Add(8);
            notas.Add(9);

            // Resultados esperados
            double mediaEsperada = 5.143;
            int susE = 3;
            int aprE = 1;
            int notE = 2;
            int sbrE = 1;

            // Ejecución del caso
            EstadisticasNotas estadistica = new EstadisticasNotas();
            double mediaActual = estadistica.CalcularEstadisticas(notas);

            // Comprobación
            Assert.AreEqual(mediaEsperada, mediaActual, 0.001, "Medias distintas. Esperada: " + mediaEsperada + ". Actual: " + mediaActual);
            Assert.AreEqual(estadistica.Suspensos, susE, 0, "No coincide el número de suspensos.");
            Assert.AreEqual(estadistica.Aprobados, aprE, 0, "No coincide el número de aprobados.");
            Assert.AreEqual(estadistica.Notables, notE, 0, "No coincide el número de notables.");
            Assert.AreEqual(estadistica.Sobresalientes, sbrE, 0, "No coincide el número de sobresalientes.");
        }

        [TestMethod]
        public void CalcularEstadisticas_ListaSinValores_ProvocaExcepcion()
        {
            // Preparación de la prueba
            List<int> notas = new List<int>();

            // Ejecución del caso
            try
            {
                EstadisticasNotas estadistica = new EstadisticasNotas();
                double mediaActual = estadistica.CalcularEstadisticas(notas);
            }
            catch (Exception exception)
            {
                StringAssert.Contains(exception.Message, "Lista vacia");
                return;
            }

            Assert.Fail("No ha devuelto excepción de lista vacía");
        }

        [TestMethod]
        public void CalcularEstadisticas_NotaNegativa_ProvocaExcepcion()
        {
            // Preparación de la prueba
            List<int> notas = new List<int>();
            notas.Add(0);
            notas.Add(3);
            notas.Add(4);
            notas.Add(5);
            notas.Add(-7);

            // Ejecución del caso
            try
            {
                EstadisticasNotas estadistica = new EstadisticasNotas();
                double mediaActual = estadistica.CalcularEstadisticas(notas);
            }
            catch (Exception exception)
            {
                StringAssert.Contains(exception.Message, "Nota invalida");
                return;
            }

            Assert.Fail("No ha devuelto excepción de lista vacía");
        }

        [TestMethod]
        public void CalcularEstadisticas_NotaSuperiorDiez_ProvocaExcepcion()
        {
            // Preparación de la prueba
            List<int> notas = new List<int>();
            notas.Add(4);
            notas.Add(5);
            notas.Add(12);

            // Ejecución del caso
            try
            {
                EstadisticasNotas estadistica = new EstadisticasNotas();
                double mediaActual = estadistica.CalcularEstadisticas(notas);
            }
            catch (Exception exception)
            {
                StringAssert.Contains(exception.Message, "Nota invalida");
                return;
            }

            Assert.Fail("No ha devuelto excepción de lista vacía");
        }

        [TestMethod]
        public void CalcularEstadisticas_ListaUnicoElemento_ActualizaNotas()
        {
            // Preparación de la prueba
            List<int> notas = new List<int>();
            notas.Add(6);

            // Resultados esperados
            double mediaEsperada = 6;
            int susE = 0;
            int aprE = 1;
            int notE = 0;
            int sbrE = 0;

            // Ejecución del caso
            EstadisticasNotas estadistica = new EstadisticasNotas();
            double mediaActual = estadistica.CalcularEstadisticas(notas);

            // Comprobación
            Assert.AreEqual(mediaEsperada, mediaActual, 0.001, "Medias distintas. Esperada: " + mediaEsperada + ". Actual: " + mediaActual);
            Assert.AreEqual(estadistica.Suspensos, susE, 0, "No coincide el número de suspensos.");
            Assert.AreEqual(estadistica.Aprobados, aprE, 0, "No coincide el número de aprobados.");
            Assert.AreEqual(estadistica.Notables, notE, 0, "No coincide el número de notables.");
            Assert.AreEqual(estadistica.Sobresalientes, sbrE, 0, "No coincide el número de sobresalientes.");
        }

        [TestMethod]
        public void CalcularEstadisticas_NotaCero_ActualizaNotas()
        {
            // Preparación de la prueba
            List<int> notas = new List<int>();
            notas.Add(0);

            // Resultados esperados
            double mediaEsperada = 0;
            int susE = 1;
            int aprE = 0;
            int notE = 0;
            int sbrE = 0;

            // Ejecución del caso
            EstadisticasNotas estadistica = new EstadisticasNotas();
            double mediaActual = estadistica.CalcularEstadisticas(notas);

            // Comprobación
            Assert.AreEqual(mediaEsperada, mediaActual, 0.001, "Medias distintas. Esperada: " + mediaEsperada + ". Actual: " + mediaActual);
            Assert.AreEqual(estadistica.Suspensos, susE, 0, "No coincide el número de suspensos.");
            Assert.AreEqual(estadistica.Aprobados, aprE, 0, "No coincide el número de aprobados.");
            Assert.AreEqual(estadistica.Notables, notE, 0, "No coincide el número de notables.");
            Assert.AreEqual(estadistica.Sobresalientes, sbrE, 0, "No coincide el número de sobresalientes.");
        }

        [TestMethod]
        public void CalcularEstadisticas_NotaDiez_ActualizaNotas()
        {
            // Preparación de la prueba
            List<int> notas = new List<int>();
            notas.Add(10);

            // Resultados esperados
            double mediaEsperada = 10;
            int susE = 0;
            int aprE = 0;
            int notE = 0;
            int sbrE = 1;

            // Ejecución del caso
            EstadisticasNotas estadistica = new EstadisticasNotas();
            double mediaActual = estadistica.CalcularEstadisticas(notas);

            // Comprobación
            Assert.AreEqual(mediaEsperada, mediaActual, 0.001, "Medias distintas. Esperada: " + mediaEsperada + ". Actual: " + mediaActual);
            Assert.AreEqual(estadistica.Suspensos, susE, 0, "No coincide el número de suspensos.");
            Assert.AreEqual(estadistica.Aprobados, aprE, 0, "No coincide el número de aprobados.");
            Assert.AreEqual(estadistica.Notables, notE, 0, "No coincide el número de notables.");
            Assert.AreEqual(estadistica.Sobresalientes, sbrE, 0, "No coincide el número de sobresalientes.");
        }
    }
}
