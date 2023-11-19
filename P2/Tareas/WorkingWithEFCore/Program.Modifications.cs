using System.Data.Common;
using System.Runtime.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WorkingWithEFCore;

partial class Program
{
    static void ListProducts(int []? productsIdToHighlight = null){
        using (Northwind db  = new())
        {
            if((db.Products is null) || (!db.Products.Any()))
            {
                Fail("There are no products");
                return;
            }
            WriteLine("{0,-3} | {1,-35} | {2,8} | {3,5} | {4}",
            "Id", "Product Name", "Cost", "Stock", "Disc.");

            foreach (var product in db.Products)
            {
                ConsoleColor backgroundColor = ForegroundColor;
                if((productsIdToHighlight is not null) && productsIdToHighlight.Contains(product.ProductId))
                {
                    ForegroundColor = ConsoleColor.Green;
                }
                WriteLine($"{product.ProductId:000} | {product.ProductName,-35} | {product.Cost:#,##0.00,8} | {product.Stock,5} | {product.Discontinued}");
                ForegroundColor = backgroundColor;
            }
        }
    }

static (int affected, int ProductId) AddProduct(Product product){

        using(Northwind db = new()){  

            if(db.Products is null){
                return (0,0);
            } 

            EntityEntry<Product> entity = db.Products.Add(product);

            WriteLine($"State:{entity.State},ProductId:{product.ProductId}");
            int affected = db.SaveChanges(); // esta linea representa los cambios que se hacen dentro de la bd en un variable entera
            return (affected,product.ProductId);
        }
    } 

     static (int affected,int productId) IncreaseProductPrice(Product Product){
        using(Northwind db = new())
        {
            if(db.Products is null) return (0,0);

            Product updateProduct = db.Products.First(
                product => product.ProductId==Product.ProductId
            );
            WriteLine(updateProduct.ProductName);

            if(Product.SupplierId!=null){
                updateProduct.SupplierId=Product.SupplierId;
            }
            if(Product.CategoryId!=null){
                updateProduct.CategoryId=Product.CategoryId;
            }
            if(Product.QuantityPerUnit!=null){
                updateProduct.QuantityPerUnit=Product.QuantityPerUnit;
            }
            if(Product.Cost!=null){
                updateProduct.Cost=Product.Cost;
            }
            if(Product.Stock!=null){
                updateProduct.Stock=Product.Stock;
            }
            if(Product.UnitsOnOrder!=null){
                updateProduct.UnitsOnOrder=Product.UnitsOnOrder;
            }
            if(Product.ReorderLevel!=null){
                updateProduct.UnitsOnOrder=Product.UnitsOnOrder;
            }
            updateProduct.Discontinued=Product.Discontinued;
            
            updateProduct.ProductName=Product.ProductName;
            
            WriteLine(updateProduct.ProductName);
            int affected = db.SaveChanges();
            return (affected,updateProduct.ProductId);
        }
    }


    // If you create the Update, you create the Delete basically
    static int DeleteProducts(string productsStartsWith)
    {
        using (Northwind db = new())
        {
            IQueryable<Product>? products = db.Products?.Where(
                p => p.ProductName.StartsWith(productsStartsWith)
            );
            if((products is null) || (!products.Any()))
            {
                WriteLine("No products found to delete");
                return 0;
            }
            else
            {
                if (db.Products is null) return 0;
                db.Products.RemoveRange(products);
            }
            int affected = db.SaveChanges();
            return affected;
        }
    }
}