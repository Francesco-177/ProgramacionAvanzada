/*
Practica 2: Conversion de bytes a String

Por: Francisco Emiliano Jimenez Mejorada 20300692 7B1

El programa crea un arreglo unidimensional de tipo byte 
de 128 bits de espacio, generados aleatoriamente, lo 
imprime, despues lo convierte a un String base 64 y lo 
vuelve a imprimir.
*/

using static System.Console; 

byte[] byteArray = new byte[128];
Random random = new Random();
random.NextBytes(byteArray);
WriteLine("\nBinary Object as Bytes\n");

foreach (byte a in byteArray){

    Write($"{a:X2} ");

}

WriteLine("\n");

string stringBase64 = Convert.ToBase64String(byteArray);

WriteLine("Binary Object as Base64\n");
WriteLine(stringBase64 + "\n");