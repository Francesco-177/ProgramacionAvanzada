partial class Program{

    static void SelectionTitle(string title){
        ConsoleColor previusColor = ForegroundColor;
        ForegroundColor = ConsoleColor.Yellow;
        WriteLine("*");
        WriteLine($"*{title}");
        WriteLine("*");

        ForegroundColor = previusColor;


    }
}