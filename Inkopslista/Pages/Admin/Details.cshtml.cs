using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Inkopslista.Data;
using Inkopslista.Models;

namespace Inkopslista.Pages.Admin
{
    public class DetailsModel : PageModel
    {
        private readonly Inkopslista.Data.InkopslistaContext _context;

        public DetailsModel(Inkopslista.Data.InkopslistaContext context)
        {
            _context = context;
        }

        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Product.FirstOrDefaultAsync(m => m.ID == id);

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
