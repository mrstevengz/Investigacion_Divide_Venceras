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

        
}
