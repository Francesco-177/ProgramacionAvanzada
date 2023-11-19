using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NorthwindDB;
using NorthwindDataDataContext;
using System.Collections.Generic;
using System.Linq;



public class SuppliesModel : PageModel
{

    public List<Supplier> Suppliers { get; set; }

    [BindProperty]
    public string CompanyName { get; set; }

    [BindProperty]
    public string ContactName { get; set; }

    [BindProperty]
    public string Phone { get; set; }

    public void OnGet()
    {
        using (var db = new Northwind())
        {
            Suppliers = db.Suppliers.ToList();
        }
    }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid)
        {
            using (var db = new Northwind())
            {
            var newSupplier = new Supplier
            {
                CompanyName = CompanyName,
                ContactName = ContactName,
                Phone = Phone
            };

            db.Suppliers.Add(newSupplier);
            db.SaveChanges();
            }
        }

        return RedirectToPage();
    }
}

