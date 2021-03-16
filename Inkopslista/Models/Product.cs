using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inkopslista.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public int Amount { get; set; }
        public bool Bought { get; set; }
        public string UserID { get; set; }
    }
}
