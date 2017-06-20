using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using AccountantSystemv5.Infrastructure;

namespace AccountantSystemv5.Models
{
    public class SessionCart : Cart
    {
        private ICollection<CartLine> _lineCollection = new List<CartLine>();

        [JsonIgnore]
        public ISession Session { get; set; }
        public ICollection<CartLine> Lines => _lineCollection;

        public void AddItem(Inventory inventory,  decimal price, int quantity)
        {
            CartLine line = _lineCollection
                .Where(p => p.Inventory.InventoryID == inventory.InventoryID)
                .FirstOrDefault();
            if (line == null)
            {
                _lineCollection.Add(new CartLine
                {
                    Inventory = inventory,
                    Price = price,
                    Quantity = quantity

                });
            }
            else
            {
                line.Quantity += quantity;
            }

            Session.SetJson("Cart", this);
        }

        public void RemoveLine(Inventory inventory)
        {
            CartLine line = _lineCollection.SingleOrDefault(l => l.Inventory.InventoryID == inventory.InventoryID);
            _lineCollection.Remove(line);
            Session.SetJson("Cart", this);
        }

        public decimal ComputeTotalValue() =>
            _lineCollection.Sum(e => e.Price * e.Quantity);

        public void Clear()
        {
            _lineCollection.Clear();
            Session.Remove("Cart");
        }

        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            SessionCart cart = session?.GetJson<SessionCart>("Cart") ?? new SessionCart();
            cart.Session = session;
            return cart;
        }
    }
}
