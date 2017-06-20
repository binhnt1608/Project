using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AccountantSystemv5.Models.Repository;
using AccountantSystemv5.Models;
using AccountantSystemv5.Models.ViewModels;
using AccountantSystemv5.Infrastructure;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AccountantSystemv5.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository _repository;
        private Cart _cart;

        public CartController(IProductRepository repo, Cart cart)
        {
            _repository = repo;
            _cart = cart;
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = _cart,
                ReturnUrl = returnUrl
            });
        }

        public async Task<RedirectToActionResult> AddToCart(int inventoryID, string returnUrl, decimal price, int quantity)
        {
            Inventory inventory = await _repository.SearchAsync(inventoryID);
            if (inventory != null)
            {
                _cart.AddItem(inventory,price,quantity);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public async Task<RedirectToActionResult> RemoveFromCart(int inventoryID, string returnUrl)
        {
            Inventory inventory = await _repository.SearchAsync(inventoryID);
            if (inventory != null)
            {
                _cart.RemoveLine(inventory);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

    
    }
}
