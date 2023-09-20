using P2.Shared;
using System.Collections.Generic;


Person kaleb = new();
WriteLine($"Kaleb is : {kaleb.ToString()} ");
kaleb.DateOfBirth = new  DateTime(2005, 12, 21);
WriteLine(format:"{0} was born on {1:dddd, d MMMM yyyy}",
arg0:kaleb.Name,
arg1:kaleb.DateOfBirth);

/*

El mismo objeto tiene que ser capaz de inicializar todo lo que necesite

*/

kaleb.Children = new(true);

kaleb,Children.Add{

    new Pearson{
    Name = "kaleb jr";
    DateOfBirth = new DateTime(2023,1,24);
    }

}

WriteLine();


