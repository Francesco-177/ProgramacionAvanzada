//  partial classes
//  subdividir clases en multiples archivos, el compilador lo toma como un solo archivo
//  NOMBRAR EL ARCHIVO (CLASE)DE QUIEN PERTENECE, BUENAS PRACTICAS 
using P2.Shared;
partial class Program{

    //  METHOD so the delegate have someone to call

    static void Jared_Shout(object? sender, EventArgs e){
        if(sender is null) return;
        Person? p = sender as Person;
        if(p is null) return;
        WriteLine($"{p.Name} is this Anger {p.AngerLevel}");
    }

}