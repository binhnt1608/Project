using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountantSystemv5.Models.Repository
{
    public class EFProductRepository : IProductRepository
    {
        private AccountantSystemv5Context _context;

        public EFProductRepository(AccountantSystemv5Context ctx)
        {
            _context = ctx;
        }

        public int Count() => _context.Inventory.Count();
        public async Task<int> CountAsync() => await _context.Inventory.CountAsync();

        public IEnumerable<Inventory> Inventories => _context.Inventory;

        public IEnumerable<Inventory> Inventory() => _context.Inventory;
        public async Task<IEnumerable<Inventory>> InventorysAsync() => await _context.Inventory.ToListAsync();

        public async Task<Inventory> SearchAsync(int id) =>
           await _context.Inventory
           .FirstOrDefaultAsync(p => p.InventoryID == id);
    }
}
