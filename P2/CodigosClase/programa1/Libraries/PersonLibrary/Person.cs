namespace P2.Shared;
using System.Collections.Generic;

public class Person{

    [XmlAttribute("fname")]
    public string? Name;
    [XmlAttribute("lname")]
    public string? LastName {get; set;}
    [XmlAttribute("dob")]
    public Person(){

    }

    public Person(string Name,string LastName, DateTime DateOfBirth, bool WantChildren)
    {
        this.Name = Name;
        this.LastName = LastName;
        this.DateOfBirth = DateOfBirth;
        //this.favoriteFood = favoriteFood;
        if(WantChildren == true)
        {
        Children = new();
        }
    } 

    public Person(decimal InitialValue) 
    {
        Salary = InitialValue;
    }
    /*
    Constructor: called when new its executed, instance
    
    
    Member: data inside the class
    public int number = 0;
    public int getNumber() {return this.number}
    public void setNumer {int number}
    {
        this.number = number;
    }

    Property: Still data on the class
    string Name{get; set;}
    Simple property
    Full property

    Index: []
    Operators : + - & ^ | =>
    
    */


    public DateTime DateOfBirth;
    protected decimal Salary {get; set;}
    //public FavoriteFood favoriteFood;
    //feature : add children to person
    public HashSet<Person>? Children;
    public BankAccount bankAccount = new();

    /*

    // 1st Step of delegates
    // Create the method to call
    public int MethodIWantToCall(string input)
    {
        return input.Length;
    }

    // 2nd example of delegate using a primitive delegate
    // Rule N1 of delegates : ALL DELEGATES, check the signature of the method
    // Signature: Return type, Parameters
    public delegate int DelegateWithMatchingSignature (string s);

    // 3rd example , using delegates as Events
    public delegate void EventHandler(object? sender, EventArgs e);

    // delegate field
    public EventHandler? Shout;
    // data field
    public int AngerLevel;
    // Method that triggers everything
    public void Poke()
    {
        AngerLevel++;
        if(AngerLevel >= 3)
        {
            // if something is listening
            if(Shout != null)
            {
                // call the messenger, call the delegate
                Shout(this, EventArgs.Empty);
            }
        }
    }
    */
}