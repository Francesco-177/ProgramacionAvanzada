using System.Diagnostics.Contracts;
using System.Collections.Generic

namespace P2.Shared;

public class Person
{

    public Person(bool wantChildren){

        if(eantChildren){
            Children = new():
        }
    
    }
    /*
    Constructor: it's called when 
    new() is executed instance 
    Member: data inside class
    public int number = 0;
    public int getNumber() {return this,number }
    public void setNumber (int:number){
        this.number = number;
    }

    Propety: 
    string Name {get; set;} //  simple propety


    Two types:
    Simple propety
    Full Propety

    Index : []
    Operators: + - * / => &




    */

    public string? Name;
    public DateTime DateOfBirth;

    public FavoriteFood favoriteFood;

    public List<Person>? Children;

    

}
