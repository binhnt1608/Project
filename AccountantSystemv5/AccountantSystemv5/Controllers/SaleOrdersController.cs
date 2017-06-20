using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AccountantSystemv5.Models;
using AccountantSystemv5.Models.ViewModels;

namespace AccountantSystemv5.Controllers
{
    public class SaleOrdersController : Controller
    {
        private IProductRepository _repository;
        private readonly AccountantSystemv5Context _context;
        private Cart _cart;

        public SaleOrdersController(AccountantSystemv5Context context, IProductRepository repository, Cart cart)
        {
            _context = context;
            _repository = repository;
            _cart = cart;
        }

        // GET: SaleOrders
        public async Task<IActionResult> Index()
        {
            //var accountantSystemv5Context = _context.SaleOrder.Include(s => s.Customer).Include(s => s.Employee);
            //return View(await accountantSystemv5Context.ToListAsync());
            return View(new InventoryListViewModel
            {
                Inventories = _repository.Inventories
            });
        }

        public async Task<IActionResult> List()
        {
            return View(await _context.SaleOrder.ToListAsync());
        }

        // GET: SaleOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleOrder = await _context.SaleOrder
                .Include(s => s.Customer)
                .Include(s => s.Employee)
                .SingleOrDefaultAsync(m => m.SaleOrderID == id);
            if (saleOrder == null)
            {
                return NotFound();
            }

            return View(saleOrder);
        }

        // GET: SaleOrders/Create
        public IActionResult Create(decimal total)
        {
            ViewBag.ItemsCustomer = GetCustomerListItems();
            ViewBag.ItemsEmployee = GetEmployeeListItems();
            ViewData["SaleOrderAmount"] = total;
            ViewData["CustomerID"] = new SelectList(_context.Customer, "CustomerID", "CustomerName");
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "EmployeeLastName");
            return View();
        }

     

            //listcustomer
            private IEnumerable<SelectListItem> GetCustomerListItems(int selected = -1)
        {
            var tmp = _context.Customer.ToList();
            // Create cashaccounts list for <select> dropdown
            return tmp
                .OrderBy(customer => customer.CustomerID)
                .Select(customer => new SelectListItem
                {
                    Text = String.Format("{0}-{1}", customer.CustomerID, customer.CustomerName),
                    Value = customer.CustomerID.ToString(),
                    Selected = customer.CustomerID == selected
                });
        }

        //listemployee
        private IEnumerable<SelectListItem> GetEmployeeListItems(int selected = -1)
        {
            var tmp = _context.Employee.ToList();
            // Create cashaccounts list for <select> dropdown
            return tmp
                .OrderBy(employee => employee.EmployeeID)
                .Select(employee => new SelectListItem
                {
                    Text = String.Format("{0}-{1}", employee.EmployeeID, employee.EmployeeLastName),
                    Value = employee.EmployeeID.ToString(),
                    Selected = employee.EmployeeID == selected
                });
        }
        // POST: SaleOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SaleOrderID,EmployeeID,SaleOrderDate,CustomerID,CustomerPO,SaleOrderAmount")] SaleOrder saleOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(saleOrder);
                await _context.SaveChangesAsync();
                _cart.Clear();
                return RedirectToAction("List");
            }
            ViewData["CustomerID"] = new SelectList(_context.Customer, "CustomerID", "CustomerID", saleOrder.CustomerID);
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "EmployeeID", saleOrder.EmployeeID);

            return View(saleOrder);
        }

        //public ViewResult Completed()
        //{
        //    _cart.Clear();
        //    return View();
        //}


        // GET: SaleOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.ItemsCustomer = GetCustomerListItems();
            ViewBag.ItemsEmployee = GetEmployeeListItems();
            var saleOrder = await _context.SaleOrder.SingleOrDefaultAsync(m => m.SaleOrderID == id);
            if (saleOrder == null)
            {
                return NotFound();
            }
            ViewData["CustomerID"] = new SelectList(_context.Customer, "CustomerID", "CustomerID", saleOrder.CustomerID);
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "EmployeeID", saleOrder.EmployeeID);
            return View(saleOrder);
        }

     

        // POST: SaleOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SaleOrderID,EmployeeID,SaleOrderDate,CustomerID,CustomerPO,SaleOrderAmount")] SaleOrder saleOrder)
        {
            if (id != saleOrder.SaleOrderID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(saleOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaleOrderExists(saleOrder.SaleOrderID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("List");
            }
            ViewData["CustomerID"] = new SelectList(_context.Customer, "CustomerID", "Customer", saleOrder.CustomerID);
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "EmployeeID", saleOrder.EmployeeID);
            return View(saleOrder);
        }

        // GET: SaleOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleOrder = await _context.SaleOrder
                .Include(s => s.Customer)
                .Include(s => s.Employee)
                .SingleOrDefaultAsync(m => m.SaleOrderID == id);
            if (saleOrder == null)
            {
                return NotFound();
            }

            return View(saleOrder);
        }

        // POST: SaleOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var saleOrder = await _context.SaleOrder.SingleOrDefaultAsync(m => m.SaleOrderID == id);
            _context.SaleOrder.Remove(saleOrder);
            await _context.SaveChangesAsync();
            return RedirectToAction("List");
        }

        private bool SaleOrderExists(int id)
        {
            return _context.SaleOrder.Any(e => e.SaleOrderID == id);
        }
    }
}
