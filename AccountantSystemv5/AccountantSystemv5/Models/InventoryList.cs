using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountantSystemv5.Models
{
    public class InventoryList
    {
        public Inventory Inventory { get; set; }
        public InventoryComposition InventoryComposition { get; set; }
        public InventoryDiameter InventoryDiameter { get; set; }
        public InventoryType InventoryType { get; set; }
    }
}
