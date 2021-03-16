using Inkopslista.Data;
using Inkopslista.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Inkopslista.Pages
{
    public class IndexModel : PageModel
    {
        private readonly InkopslistaContext _context;

        [BindProperty]
        public string ProductName { get; set; }

        [BindProperty]
        public int Amount { get; set; }

        [BindProperty]
        public bool Bought { get; set; }

        public IndexModel(InkopslistaContext context)
        {
            _context = context;
        }

        public IList<Product> Products { get; set; }

        [BindProperty(SupportsGet = true)]
        public string UserId { get; set; }

        [BindProperty(SupportsGet = true)]
        public int ProductDeleteID { get; set; }

        [BindProperty(SupportsGet = true)]
        public int EditProductID { get; set; }

        [BindProperty]
        public string Message { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (User.Identity != null)
            {
                Product products = new Product();

                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                products.ProductName = ProductName;
                products.Amount = Amount;
                products.Bought = Bought;
                products.UserID = userId;

                _context.Product.Add(products);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnGetAsync()
        {
            if (User.Identity != null)
            {
                Products = await _context.Product.ToListAsync();

                if (ProductDeleteID != 0)
                {
                    Product product = await _context.Product.FindAsync(ProductDeleteID);

                    if (product != null)
                    {
                        _context.Product.Remove(product);
                        await _context.SaveChangesAsync();

                        return RedirectToPage("./Index");
                    }
                }
            }

            if (EditProductID != 0)
            {
                Product product = await _context.Product.FindAsync(EditProductID);

                if (product != null)
                {
                    if (product.Bought == false)
                    {
                        product.Bought = true;
                    }
                    else
                    {
                        product.Bought = false;
                    }

                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");
                }
            }
            return Page();
        }
    }
}
