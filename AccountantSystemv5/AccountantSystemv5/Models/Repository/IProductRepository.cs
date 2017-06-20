using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountantSystemv5.Models
{
    public interface IProductRepository
    {
        Task<int> CountAsync();

        IEnumerable<Inventory> Inventories { get; }

        Task<IEnumerable<Inventory>> InventorysAsync();

        Task<Inventory> SearchAsync(int id);
  
        
    }
}
