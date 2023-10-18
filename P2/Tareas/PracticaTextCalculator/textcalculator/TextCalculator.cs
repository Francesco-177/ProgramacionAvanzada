namespace textcalculator;
using static System.IO.Directory; // Create or kill folders
using static System.IO.Path; // Creates URLS // C://Documentos...
using static System.Environment; // OS, Users, permissions
using System.Text;
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
            
            //Store the extracted and formatted operations
            List<string> Operations = ExtractOperations(fileContent);
            List<string> Results = GetResults(Operations);

            StringBuilder stringBuilder = new StringBuilder(fileContent);
            if(fileContent.Length==0){//Check for an empty file
                return "Empty file";
            }

            //Auxiliary variables
            int currentResult = 0;
            char newChar;

            //Rewrite the content of the file with the results
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
            if (newChar == 'r'||newChar == 'R'){ //Check for keyword Res
                for(int j=i;j<OperationText.Length;j++){
                    if(OperationText[j]=='='){//Check where it ends
                        i=j;
                        Operations.Add(newString);//Add found operation
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
            //Console.WriteLine("Se agrego");
            //Console.WriteLine($"{operation}");

            // Check if the operation is a fraction
            if (operation.Contains('/')){
                // Check if there are valid numbers on both sides of '/'
                string[] parts = operation.Split('/'); 
                if (parts.Length > 2){
                    // Valid fraction operation
                    //Console.WriteLine("Entro como fraccion");
                    result = OperateFractions(operation);
                    
                }
                else{
                    //Console.WriteLine("entro como entero");
                    result = OperateInts(operation);
                }
            }
            else{
                //Console.WriteLine("entro como entero");
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
            // Extract operands and operator
            var (num1, num2, oper) = ExtractOperandsAndOperator(operation);

            // Perform the operation based on the operator
            result = PerformOperation(num1, num2, oper);
        }
        catch (Exception ex){
            result = ex.Message; // Return error message if operation fails
        }

        return result;
    }


    public static (int num1, int num2, char oper) ExtractOperandsAndOperator(string operation){
        int num1, num2;
        char oper;

        //Operations that the calculator handles
        char[] Validoperators = { '+', '-', '*', '/' };

        string[] parts = operation.Split(Validoperators, StringSplitOptions.RemoveEmptyEntries);

        if (parts.Length != 2){
            throw new InvalidOperationException("Invalid operation format");
        }

        //Return each member of the operation that is needed to perform
        num1 = int.Parse(parts[0]);
        num2 = int.Parse(parts[1]);
        oper = operation.First(c => Validoperators.Contains(c));
        return (num1, num2, oper);
    }

    public static string PerformOperation(int num1, int num2, char oper){
    double result;
    // Call the appropriate operation method based on the operator
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

    public static double Add(int num1, int num2){
        try{
            return checked(num1 + num2);
        }
        catch (OverflowException){
            throw new InvalidOperationException("Overflow during addition");
        }
    }

    public static double Subtract(int num1, int num2){
        try{
            return checked(num1 - num2);
        }
        catch (OverflowException){
            throw new InvalidOperationException("Overflow during subtraction");
        }
    }

    public static double Multiply(int num1, int num2){
        try{
            return checked(num1 * num2);
        }
        catch (OverflowException){
            throw new InvalidOperationException("Overflow during multiplication");
        }
    }

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
        //Console.WriteLine("I received");
        //Console.WriteLine($"{op}");

        string[] parts = op.Split(new[] { '+', '-', '*' }, StringSplitOptions.RemoveEmptyEntries);

        /*Console.WriteLine("I separated it as");
        foreach (var part in parts){
            Console.WriteLine($"{part}");
        }*/

        if (parts.Length != 2){
            //Console.WriteLine("entered in this shit1");
            throw new InvalidOperationException("Invalid operation format");
        }

        Console.WriteLine("entered in this shit2");

        // Parse the fractions into numerators and denominators
        int[] numbers = new int[4];
        (numbers[0],numbers[1]) = ParseFraction(parts[0]);
        (numbers[2],numbers[3]) = ParseFraction(parts[1]);

        char oper = op.First(c => c == '+' || c == '-' || c == '*');

        /*Console.WriteLine("entered in this shit3");
        Console.WriteLine("I sent the following array");
        foreach (var part in numbers){
            Console.WriteLine($"{part}");
        }*/

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
        //Auxiliary variables
        int temp;
        int a = numerator;
        int b = denominator;

        // Use the Euclidean algorithm to find the greatest common divisor
        while (b != 0){
            temp = b;
            b = a % b;
            a = temp;
        }

        // Divide both numerator and denominator by the greatest common divisor
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