using System.Diagnostics.Contracts;
using System.Collections.Generic;

namespace P2.Shared;

public class Person
{
    // Composition
    // Let the same Object take care of the initialization
    // of the FUCKING fields
    public Person(){

    }
    public Person(string Name, DateTime dateOfBirth, FavoriteFood favoriteFood, bool wantChildren){
        this.Name = Name;
        this.DateOfBirth = dateOfBirth;
        this.favoriteFood = favoriteFood;
        if(wantChildren)
        {
            Children = new();
        }
    }
    /*
     Constructor:  its called whe
     new () is executed, instance

     Member : data inside the class
     public int number = 0;
     public int getNumber () { return this.number };
     public void setNumber (int number)
     {
        thisk.number = number;
     }

     Property: Still data on the class
     string Name {get; set;}
     Simple Property
     Full Property

     Index : []

     Operators : + - & ^ | =>
    */

    //fields
    public string? Name;
    public DateTime DateOfBirth;

    public FavoriteFood favoriteFood;
    // feature : add children to person
    public List<Person>? Children;
    public BankAccount bankAccount = new();

    //1st step of delegates
    //Create yteh method to call

    public int MethodIWantToCall(string input){
        return input.Length;
    }

    //  2nd example of delegates using a primitive delegate 
    //  rule 1 of delegates : ALL DELEGATES, check de signature od the method
    //  signature : return type, parameters 
    //  UN DELEGADO EN UN PUNTERO

    public delegate int DelegateWithMatchingSignature (string s);
    //es un puntero (variable), no es una funcion

    //  3rd example, using delegates as Events

    public delegate void EventHandler(object? sender, EventArgs e);

    //  delegate field
    public EventHandler? Shout;

    //  data field
    public int AngerLevel;

    //   Method that triggers everything
    public void Poke(){
        AngerLevel++;

        if(AngerLevel >= 3){

            //if something is listening
            if(Shout != null){
                //call the mesenger, call the delegate
                Shout(this, EventArgs.Empty);

            }

        }
    }






    
}
