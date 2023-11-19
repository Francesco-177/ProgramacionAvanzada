using NorthwindDB;
using NorthwindDataDataContext;
using static System.Console; // System Console = new System();



Northwind db = new();
WriteLine($"Provider : {db.Database.ProviderName}");

ListProducts();

