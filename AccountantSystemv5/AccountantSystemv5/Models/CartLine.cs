using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountantSystemv5.Models
{
    public class CartLine
    {
        public int CartLineID { get; set; }
        public Inventory Inventory { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
