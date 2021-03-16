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
    public class IndexModel : PageModel
    {
        private readonly Inkopslista.Data.InkopslistaContext _context;

        public IndexModel(Inkopslista.Data.InkopslistaContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; }

        public async Task OnGetAsync()
        {
            Product = await _context.Product.ToListAsync();
        }
    }
}
