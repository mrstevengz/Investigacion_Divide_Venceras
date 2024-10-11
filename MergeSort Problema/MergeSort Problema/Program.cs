using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSortEjemplo
{
    class Program
    {
        static void Main()
        {
            int[] arreglo = { 38, 27, 43, 3, 9, 82, 10 };
            Console.WriteLine("Arreglo original:");
            ImprimirArreglo(arreglo);

            MergeSort(arreglo, 0, arreglo.Length - 1);

            Console.WriteLine("\nArreglo ordenado:");
            ImprimirArreglo(arreglo);
        }
        static void MergeSort(int[] arreglo, int inicio, int fin)
        {
            if (inicio < fin) //Se verifica que hay mas de un elemento
            {
                int medio = (inicio + fin) / 2; //Calcula el punto medio del arreglo

                MergeSort(arreglo, inicio, medio);
                MergeSort(arreglo, medio + 1, fin);

                Combinar(arreglo, inicio, medio, fin);
            }
        }
        static void Combinar(int[] arreglo, int inicio, int medio, int fin)
        {
            int n1 = medio - inicio + 1; //Calcula el tamaño de los subarreglos izquierdo y derecho
            int n2 = fin - medio;

            int[] izquierda = new int[n1];
            int[] derecha = new int[n2];

            Array.Copy(arreglo, inicio, izquierda, 0, n1);
            Array.Copy(arreglo, medio + 1, derecha, 0, n2);

            int i = 0, j = 0, k = inicio;

            while (i < n1 && j < n2)
            {
                if (izquierda[i] <= derecha[j])
                {
                    arreglo[k] = izquierda[i];
                    i++;
                }
                else
                {
                    arreglo[k] = derecha[j];
                    j++;
                }
                k++;
            }

            while (i < n1)
            {
                arreglo[k] = izquierda[i];
                i++;
                k++;
            }

            while (j < n2)
            {
                arreglo[k] = derecha[j];
                j++;
                k++;
            }
        }

    }
}
