/* 
LA EXCEPCION GENERALIZADA SIEMPRE VA AL ULTIMO.

3 pilares para hacer try catch.
interaccion de usuario, archivos y web.

No hacer try catch a lo baboso, solo donde veamos
que el codigo puede llegar a tronar

nulos no asigna espacio de memoria
empty si lo asigna pero esta vacio "0"
*/

using static System.Console;
using static System.Exception;

WriteLine("Before parsing");
WriteLine("What is your age?");
string? input = ReadLine();

try{
    int age = int.Parse(input);
    WriteLine($"your age is {age}");

}catch(FormatException){
    
    WriteLine("Couldn't format");

}catch(OverflowException){

    WriteLine("The number is too large or too small");

}catch(Exception ex){
    WriteLine($"{ex.GetType()}says{ex.Message}");
}

WriteLine("After parsing");

WriteLine("Enter an amount");
string amount = ReadLine();

if(string.IsNullOrEmpty(amount)){
    return;
}

try{

    decimal amountValue = decimal.Parse(amount);
    WriteLine($"Amount formatted as currency {amountValue:C3}");

}catch(FormatException)when(amount.Contains("$")){ // FILTERS

    WriteLine("Fatal error");
}catch(FormatException){

    WriteLine("Wrong Format");

}

