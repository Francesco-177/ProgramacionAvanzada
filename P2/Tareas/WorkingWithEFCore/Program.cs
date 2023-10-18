using WorkingWithEFCore;

Northwind db = new();
WriteLine($"Provider : {db.Database.ProviderName}");

//Querys Practica

Query4();

//Querys Practica

QueryingCategories();
QueryingProducts();
QueryingWithLike();

