using System;
using System.Collections.Generic;
using static System.Console;
using static System.Exception;

public class Examen
{
    public int[] TwoSum(int[] numbers, int target)
    {
        // Diccionario para hacer un seguimiento de los valores vistos en el arreglo
        Dictionary<int, int> seen = new Dictionary<int, int>();

        // Recorremos el arreglo de numeros
        for (int i = 0; i < numbers.Length; i++)
        {
            // Calculamos el complemento necesario para alcanzar el target
            int complement = target - numbers[i];

            // verificar si complement esta en el diccionario
            if (seen.ContainsKey(complement))
            {
                // Si si esta retornamos los índices de los dos números que suman al target
                // Añadimos 1 a cada índice para que las posiciones concuerden 
                return new int[] { seen[complement] + 1, i + 1 };
            }

            // Si el complement no se encuentra almacenamos el número actual en el diccionario
            seen[numbers[i]] = i;
        }

        // Si no hay solucion retorna un arreglo vacio
        return new int[0];
    }

    public static void Main(string[] args)
    {
        // Creamos una instancia de la clase Examen
        Examen examen = new Examen();

        // Valores de prueba
        int[] numbers = { 0, 0, 1, 7, 10, 23, 4, 7 };
        int target = 8;

        // llamamos al metodo
        int[] result = examen.TwoSum(numbers, target);

        // imprimir resultado en consola
        Console.WriteLine(string.Join(", ", result)); 
    }
}
