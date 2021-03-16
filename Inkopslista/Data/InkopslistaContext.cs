using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Inkopslista.Models;

namespace Inkopslista.Data
{
    public class InkopslistaContext : DbContext
    {
        public InkopslistaContext (DbContextOptions<InkopslistaContext> options)
            : base(options)
        {
        }

        public DbSet<Inkopslista.Models.Product> Product { get; set; }
    }
}
