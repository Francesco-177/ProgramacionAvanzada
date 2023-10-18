namespace textcalculator;
using static System.IO.Directory;
using System.Text;
using static System.IO.Path; 
using static System.Environment; 
using System.Text.RegularExpressions;
using System.Globalization;
using System.Diagnostics;

public class TextCalculator{
    public string ProcessFile(string filePath){
        if (!File.Exists(filePath)){
            return "Path doesn't exist";
        }
        else{
            string fileContent;
            using (StreamReader textReader = File.OpenText(filePath)){
                fileContent = textReader.ReadToEnd();
            }
            
            List<string> Operations = ExtractOperations(fileContent);
            List<string> Results = GetResults(Operations);

            StringBuilder stringBuilder = new StringBuilder(fileContent);
            if(fileContent.Length==0){//Verificar si el archivo esta vacio
                return "Empty file";
            }

            int currentResult = 0;
            char newChar;

            //Reescribir el archivo con los resultados
            for(int i = 0; i < fileContent.Length; i++){
                newChar = fileContent[i]; 
                if(newChar == '='){
                    stringBuilder.Insert(i + 1, Results[currentResult]);
                    currentResult++;
                    fileContent=stringBuilder.ToString();
                    stringBuilder=new StringBuilder(fileContent);
                }           
            }    
            string finalResult = stringBuilder.ToString();
            File.WriteAllText(filePath,finalResult);
            return filePath;
        }
    }

    public static List<string> ExtractOperations(string OperationText){
        List<string> Operations = new List<string>();
        string newString="";
        char newChar;

        for(int i = 0;i < OperationText.Length;i++){
            newChar = OperationText[i];
            if (newChar == 'r'||newChar == 'R'){ //Revisar la palabra clave "Res"
                for(int j=i;j<OperationText.Length;j++){
                    if(OperationText[j]=='='){//Fin de la expresion
                        i=j;
                        Operations.Add(newString);//Guardar la operacion
                        newString="";
                        break;
                    }
                }
            }
            else{
                newString=newString+newChar; 
            }
        }
        return FormatOperations(Operations);
    }

    public static List<string> GetResults(List<string> operations){
        List<string> results = new List<string>();

        foreach (string operation in operations){
            string result;

            // Primero verificar si la operacion es una fraccion
            if (operation.Contains('/')){
                // Verificar si los numeros son validos en la expresion /
                string[] parts = operation.Split('/'); 
                if (parts.Length > 2){
                    result = OperateFractions(operation);
                
                }
                else{
                    result = OperateInts(operation);
                }
            }
            else{
                result = OperateInts(operation);
            }
            results.Add(result);
        }
        return results;
    }

    public static string OperateInts(string operation){
        string result;

        // Try to perform the operation
        try{
            // extraer operacion y las expresionen que la contienen
            var (num1, num2, oper) = ExtractOperandsAndOperator(operation);

            result = PerformOperation(num1, num2, oper);
        }
        catch (Exception ex){
            result = ex.Message; // Error si la operacion falla
        }

        return result;
    }


    public static (int num1, int num2, char oper) ExtractOperandsAndOperator(string operation){
        int num1, num2;
        char oper;

        //Operaciones que maneja el programa
        char[] Validoperators = { '+', '-', '*', '/' };

        string[] parts = operation.Split(Validoperators, StringSplitOptions.RemoveEmptyEntries);

        if (parts.Length != 2){
            throw new InvalidOperationException("Invalid operation format");
        }

        num1 = int.Parse(parts[0]);
        num2 = int.Parse(parts[1]);
        oper = operation.First(c => Validoperators.Contains(c));
        return (num1, num2, oper);
    }

    public static string PerformOperation(int num1, int num2, char oper){
    double result;
    // Hacer la operacion adecuada en base al operador encontrado
        switch (oper){
            case '+':
                result = Add(num1, num2);
                break;
            case '-':
                result = Subtract(num1, num2);
                break;
            case '*':
                result = Multiply(num1, num2);
                break;
            case '/':
                result = Divide(num1, num2);
                break;
            default:
                throw new InvalidOperationException("Invalid operator");
        }
        return result.ToString();
    }
    //Suma
    public static double Add(int num1, int num2){
        try{
            return checked(num1 + num2);
        }
        catch (OverflowException){
            throw new InvalidOperationException("Overflow during addition");
        }
    }
     
    //Resta
    public static double Subtract(int num1, int num2){
        try{
            return checked(num1 - num2);
        }
        catch (OverflowException){
            throw new InvalidOperationException("Overflow during subtraction");
        }
    }

    //Multiplicacion
    public static double Multiply(int num1, int num2){
        try{
            return checked(num1 * num2);
        }
        catch (OverflowException){
            throw new InvalidOperationException("Overflow during multiplication");
        }
    }

    //Division
    public static double Divide(int num1, int num2){
        try{
            return (double)num1 / num2;
        }
        catch (DivideByZeroException){
            throw new InvalidOperationException("Division by zero");
        }
        catch (OverflowException){
            throw new InvalidOperationException("Overflow during division");
        }
    }

    public static string OperateFractions(string op){
    try{

        string[] parts = op.Split(new[] { '+', '-', '*' }, StringSplitOptions.RemoveEmptyEntries);

        if (parts.Length != 2){
            throw new InvalidOperationException("Invalid operation format");
        }

        Console.WriteLine("entered in this shit2");

        // Parse a las fracciones 
        int[] numbers = new int[4];
        (numbers[0],numbers[1]) = ParseFraction(parts[0]);
        (numbers[2],numbers[3]) = ParseFraction(parts[1]);

        char oper = op.First(c => c == '+' || c == '-' || c == '*');

        switch (oper){
            case '+':
                return AddFractions(numbers);

            case '-':
                return SubtractFractions(numbers);

            case '*':
                return MultiplyFractions(numbers);

            default:
                throw new InvalidOperationException("Invalid operator");
        }
    }
    catch (Exception ex){
        return $"Error: {ex.Message}";
    }
}

    public static (int,int) ParseFraction(string fraction){
        try{
            string[] parts = fraction.Split('/');
            int numerator = int.Parse(parts[0]);
            int denominator = int.Parse(parts[1]);
            return (numerator,denominator);
        }
        catch (Exception ex){
            throw new InvalidOperationException($"Error parsing fraction '{fraction}': {ex.Message}");
        }
    }

    public static string AddFractions(int[] numbers){
        try{
            int num = numbers[0] * numbers[3] + numbers[2] * numbers[1];
            int den = numbers[1] * numbers[3];
            ReduceFraction(ref num, ref den);
            return $"{num}/{den}";
        }
        catch (Exception ex){
            return $"Error adding fractions: {ex.Message}";
        }
    }

    public static string SubtractFractions(int[] numbers){
        try{
            int num = numbers[0] * numbers[3] - numbers[2] * numbers[1];
            int den = numbers[1] * numbers[3];
            ReduceFraction(ref num, ref den);
            return $"{num}/{den}";
        }
        catch (Exception ex){
            return $"Error subtracting fractions: {ex.Message}";
        }
    }

    public static string MultiplyFractions(int[] numbers){
        try{
            int num = numbers[0] * numbers[2];
            int den = numbers[1] * numbers[3];
            ReduceFraction(ref num, ref den);
            return $"{num}/{den}";
        }
        catch (Exception ex){
            return $"Error multiplying fractions: {ex.Message}";
        }
    }

    public static void ReduceFraction(ref int numerator, ref int denominator){
        int temp;
        int a = numerator;
        int b = denominator;

        // Encontrar el comun denominador
        while (b != 0){
            temp = b;
            b = a % b;
            a = temp;
        }

        // dividir entre el comun denominador
        numerator /= a;
        denominator /= a;
    }

    public static List<string> FormatOperations(List<string> Operations){
        string currentString = "";
        bool completeString = false;
        char currentChar;
        List<string> Final = new List<string>();
        foreach (string op in Operations){
            currentString = "";
            for (int i = 0; i < op.Length; i++){
                currentChar = op[i];
                if (completeString == false){
                    if (char.IsNumber(currentChar)){
                        currentString += currentChar;
                        completeString = true;
                    }
                }
                else{
                    currentString += currentChar;
                }
            }
            Final.Add(currentString);
            completeString = false;
        }
        return Final;
    }
}