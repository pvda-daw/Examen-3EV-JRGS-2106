using System.Collections.Generic;
using System;

namespace Examen3EV_NS
{
    /// <summary>
    /// Esta clase nos calcula las estadísticas de un conjunto de notas.
    /// </summary>
    public class EstadisticasNotas 
    {
        /// <summary>
        /// Numero de suspensos.
        /// </summary>
        private int suspensos;

        /// <summary>
        /// Número de aprobados.
        /// </summary>
        private int aprobados;

        /// <summary>
        /// Número de notables.
        /// </summary>
        private int notables;

        /// <summary>
        /// Número de sobresalientes.
        /// </summary>
        private int sobresalientes;

        private double notaMedia;

        public int Suspensos { get => suspensos; set => suspensos = value; }
        public int Aprobados { get => aprobados; set => aprobados = value; }
        public int Notables { get => notables; set => notables = value; }
        public int Sobresalientes { get => sobresalientes; set => sobresalientes = value; }
        public double NotaMedia { get => notaMedia; set => notaMedia = value; }

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        /// <remarks>
        /// Inicializa todos los valores a 0.
        /// </remarks>
        public EstadisticasNotas()
        {
            suspensos = 0;
            aprobados = 0;
            notables = 0;
            sobresalientes = 0;
            notaMedia = 0.0;
        }

        /// <summary>
        /// Constructor sobrecargado. Calcula las estadísticas al crear el objeto a partir de <paramref name="listaNotas"/>.
        /// </summary>
        /// <param name="listaNotas">Lista de notas.</param>
        /// <remarks>Utiliza el método <see cref="CalcularEstadisticas(List{int})"/> para generar las estadísticas.</remarks>
        public EstadisticasNotas(List<int> listaNotas)
        {
            notaMedia = CalcularEstadisticas(listaNotas);
        }

        /// <summary>
        /// <para>Para un conjunto de <paramref name="listaNotas"/>, calculamos las estadisticas.</para>
        /// <para>calcula la media y el número de suspensos/aprobados/notables/sobresalientes.</para>
        /// </summary>
        /// <remarks>En los casos en los que se introduzcan listas vacias o elementos inválidos devoverá <see cref="Exception"/>.</remarks>
        /// <param name="listaNotas">Lista de notas</param>
        /// <returns>Media total de las notas.</returns>
        public double CalcularEstadisticas(List<int> listaNotas)
        {                                 
             // Si la lista no contiene elementos, devolvemos un error
            if (listaNotas.Count <= 0) {
                throw new Exception("Lista vacia");
            }

            for (int i = 0; i < listaNotas.Count; i++) {
                // comprobamos que las notas están entre 0 y 10 (mínimo y máximo), si no, error
                if (listaNotas[i] < 0 || listaNotas[i] > 10)
                {
                    throw new Exception("Nota invalida");
                }
            }

            for (int i = 0; i < listaNotas.Count; i++)
            {
                if (listaNotas[i] < 5)
                {
                    // Por debajo de 5 suspenso
                    suspensos++;
                }
                else if (listaNotas[i] >= 5 && listaNotas[i] < 7)
                {
                    // Nota para aprobar: 5
                    aprobados++;
                }
                else if (listaNotas[i] >= 7 && listaNotas[i] < 9)
                {
                    // Nota para notable: 7
                    notables++;
                }
                else if (listaNotas[i] >= 9)
                {
                    // Nota para sobresaliente: 9
                    sobresalientes++;
                }

                notaMedia = notaMedia + listaNotas[i];
            }

            notaMedia = notaMedia / listaNotas.Count;

            return notaMedia;
        }
    }
}
