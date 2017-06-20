using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AccountantSystemv5.Models;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AccountantSystemv5.Controllers
{
    public class InventoryListController : Controller
    {
       
        private readonly AccountantSystemv5Context _context;
        public InventoryListController(AccountantSystemv5Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var query = from c in _context.Inventory
                        join d in _context.InventoryComposition on c.InventoryCompositionID equals d.CompositionID
                        join a in _context.InventoryDiameter on c.InventoryDiameterID equals a.CompositionID
                        join b in _context.InventoryType on c.InventoryTypeID equals b.CompositionID
                        select new InventoryList
                        {
                           Inventory = c,
                           InventoryDiameter = a,
                           InventoryComposition = d,
                           InventoryType = b
                        
                        };

            // ViewBag.query = query;
            return View(query);
        }

    }
}


