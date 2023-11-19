using WorkingWithEFCore;

Northwind db = new();
WriteLine($"Provider : {db.Database.ProviderName}");

// QueryingCategories();
// QueryingProducts();
// QueryingWithLike();

   Product Product = new()
    {
        ProductName = "BLIZZARD",
        SupplierId = 10,
        CategoryId = 5,
        QuantityPerUnit = "Uno",
        Cost = 50,
        Stock = 100,
        UnitsOnOrder = 10,
        ReorderLevel = 25,
        Discontinued = false
    };



    Product UpdatedProduct = new()
    {
        ProductId = 78,
        ProductName = "La hamburguesa de Don Chuy",
        Stock = 50,
        Cost = 10000
    };

var productToHighlight = new int[] {78};

ListProducts(productToHighlight);
WriteLine();
AddProduct(Product);
ListProducts(productToHighlight);
IncreaseProductPrice(UpdatedProduct);
ListProducts(productToHighlight);



// Using delete
WriteLine("About to delete all products whose name starts with La ");
Write("Press Enter to continue or any other key");
if(ReadKey(intercept: true).Key == ConsoleKey.Enter){
    int deleted = DeleteProducts(productsStartsWith: "La ");
    WriteLine($"{deleted} products were deleted.");
    ListProducts(productToHighlight);
}
else{
    WriteLine("Delete was canceled");
}