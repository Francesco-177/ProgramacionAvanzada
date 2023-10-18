using Microsoft.VisualBasic;
using P2.Shared;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Serialization;//Xml serializer
using static System.Environment;
using static System.IO.Path;

List<Person> people = new()
{
    new(30000M)
    {
        Name = "Gretta",
        LastName = "Medrano",
        DateOfBirth = new(year: 2005, month : 11, day: 2)
    },
    new(20000M)
    {
        Name = "Jared",
        LastName = "Flores",
        DateOfBirth = new(year: 2001, month : 03, day: 2)
    },
    
    new(40000M)
    {
        Name = "Denahi",
        LastName = "Lopez",
        DateOfBirth = new(year: 2004, month : 08, day: 10)
    },
    new(8000M)
    {
        Name = "Fernando",
        LastName = "Garcia",
        DateOfBirth = new(year: 2005, month : 10, day: 04),
        Children = new()
        {
            new(0M)
            {
                Name = "Marisol",
                LastName = "Garcia",
                DateOfBirth = new(year: 20023, month : 10, day: 01),
            },
            new(0M)
            {
                Name = "Cesar",
                LastName = "Apolinar",
                DateOfBirth = new(year: 20021, month : 08, day: 20),
            }
        }
    },

};