using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSortEjemplo
{
    class Program
    {
        class Empleado
        {
            public string Nombre { get; set; }
            public decimal Salario { get; set; }

            public Empleado(string nombre, decimal salario)
            {
                Nombre = nombre;
                Salario = salario;
            }
        }

        static void Main()
        {
            Empleado[] empleados = {
                    new Empleado("Juan", 3000),
                    new Empleado("Ana", 2500),
                    new Empleado("Luis", 4000),
                    new Empleado("Maria", 3500),
                    new Empleado("Pedro", 2000)
                };

            Console.WriteLine("Lista de empleados original:");
            ImprimirEmpleados(empleados);

            MergeSort(empleados, 0, empleados.Length - 1);

            Console.WriteLine("\nLista de empleados ordenada por salario:");
            ImprimirEmpleados(empleados);
        }

        static void MergeSort(Empleado[] empleados, int inicio, int fin)
        {
            if (inicio < fin) //Se verifica que hay más de un elemento
            {
                int medio = (inicio + fin) / 2; //Calcula el punto medio del arreglo

                MergeSort(empleados, inicio, medio);
                MergeSort(empleados, medio + 1, fin);

                Combinar(empleados, inicio, medio, fin);
            }
        }

        static void Combinar(Empleado[] empleados, int inicio, int medio, int fin)
        {
            int n1 = medio - inicio + 1; //Calcula el tamaño de los subarreglos izquierdo y derecho
            int n2 = fin - medio;

            Empleado[] izquierda = new Empleado[n1];
            Empleado[] derecha = new Empleado[n2];

            Array.Copy(empleados, inicio, izquierda, 0, n1);
            Array.Copy(empleados, medio + 1, derecha, 0, n2);

            int i = 0, j = 0, k = inicio; //Algoritmo de combinación

            while (i < n1 && j < n2)
            {
                if (izquierda[i].Salario <= derecha[j].Salario)
                {
                    empleados[k] = izquierda[i];
                    i++;
                }
                else
                {
                    empleados[k] = derecha[j];
                    j++;
                }
                k++;
            }

            while (i < n1)
            {
                empleados[k] = izquierda[i];
                i++;
                k++;
            }

            while (j < n2)
            {
                empleados[k] = derecha[j];
                j++;
                k++;
            }
        }

        static void ImprimirEmpleados(Empleado[] empleados)
        {
            foreach (Empleado empleado in empleados)
            {
                Console.WriteLine($"Nombre: {empleado.Nombre}, Salario: {empleado.Salario}");
            }
        }
    }
}
