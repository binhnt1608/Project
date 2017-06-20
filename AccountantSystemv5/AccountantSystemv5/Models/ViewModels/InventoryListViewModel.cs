using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountantSystemv5.Models.ViewModels
{
    public class InventoryListViewModel
    {
        public IEnumerable<Inventory> Inventories { get; set; }
       
    }
}
