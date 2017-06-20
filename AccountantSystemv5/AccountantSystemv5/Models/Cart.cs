using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountantSystemv5.Models
{
    public interface Cart
    {
        void AddItem(Inventory inventory,decimal price,int quantity);

        void RemoveLine(Inventory inventory);

        decimal ComputeTotalValue();

        void Clear();

        ICollection<CartLine> Lines { get; }
    }
}
