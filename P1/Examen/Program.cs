using static System.Console;
using static System.Exception;

class Examen
{
    public static void Main(string[] args)
    {
        WriteLine("Please enter a Row number"); // pedimos que ingrese la fila
        try
        {
            string input = ReadLine();
            int numRows = int.Parse(input);

            generaPiramide(numRows);
        }
        catch (FormatException) // cachammos las ecepciones para que no meta valores que no son
        {
            WriteLine("Couldn't format");
        }
        catch (OverflowException)
        {
            WriteLine("The number is too large or too small");
        }
    }

    static void generaPiramide(int numRows) // generamos la piramide con el numero de filas que ingresamos
    {
        for (int i = 0; i < numRows; i++)  
        {
            int number = 1;

            for (int j = 0; j < numRows - i; j++)
            {
                Write("  "); // imprimimos el espacio para separar los numeros
            }

            for (int j = 0; j <= i; j++)
            {
                Write(number.ToString().PadLeft(4)); // casteamos a string, alineamos y escribimos el numero 
                number = number * (i - j) / (j + 1); //calculamos el numero de la fila a imprimir
            }

            WriteLine();// saltamos de linea para escribir la siguiente row
        }
    }
}
