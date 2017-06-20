using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AccountantSystemv5.Models;

namespace AccountantSystemv5.Controllers
{
    public class PurchaseOrdersController : Controller
    {
        private readonly AccountantSystemv5Context _context;

        public PurchaseOrdersController(AccountantSystemv5Context context)
        {
            _context = context;    
        }

        // GET: PurchaseOrders
        public async Task<IActionResult> Index()
        {
            var accountantSystemv5Context = _context.PurchaseOrder.Include(p => p.Employee).Include(p => p.Vendor);
            return View(await accountantSystemv5Context.ToListAsync());
        }

        // GET: PurchaseOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseOrder = await _context.PurchaseOrder
                .Include(p => p.Employee)
                .Include(p => p.Vendor)
                .SingleOrDefaultAsync(m => m.PurchaseOrderID == id);
            if (purchaseOrder == null)
            {
                return NotFound();
            }

            return View(purchaseOrder);
        }

        // GET: PurchaseOrders/Create
        public IActionResult Create()
        {
            ViewBag.ItemsVendor = GetVendorListItems();
            ViewBag.ItemsEmployee = GetEmployeeListItems();
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "EmployeeID");
            ViewData["VendorID"] = new SelectList(_context.Vendor, "VendorID", "VendorID");
            return View();
        }

        //listevendor
        private IEnumerable<SelectListItem> GetVendorListItems(int selected = -1)
        {
            var tmp = _context.Vendor.ToList();
            // Create cashaccounts list for <select> dropdown
            return tmp
                .OrderBy(vendor => vendor.VendorID)
                .Select(vendor => new SelectListItem
                {
                    Text = String.Format("{0}-{1}", vendor.VendorID, vendor.VendorName),
                    Value = vendor.VendorID.ToString(),
                    Selected = vendor.VendorID == selected
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
        // POST: PurchaseOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PurchaseOrderID,EmployeeID,VendorID,PurchaseOrderDate,ExpectedDeliveryDate,PurchaseOrderAmount")] PurchaseOrder purchaseOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(purchaseOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "EmployeeID", purchaseOrder.EmployeeID);
            ViewData["VendorID"] = new SelectList(_context.Vendor, "VendorID", "VendorID", purchaseOrder.VendorID);
            return View(purchaseOrder);
        }

        // GET: PurchaseOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.ItemsVendor = GetVendorListItems();
            ViewBag.ItemsEmployee = GetEmployeeListItems();
            var purchaseOrder = await _context.PurchaseOrder.SingleOrDefaultAsync(m => m.PurchaseOrderID == id);
            if (purchaseOrder == null)
            {
                return NotFound();
            }
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "EmployeeID", purchaseOrder.EmployeeID);
            ViewData["VendorID"] = new SelectList(_context.Vendor, "VendorID", "VendorID", purchaseOrder.VendorID);
            return View(purchaseOrder);
        }

        // POST: PurchaseOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PurchaseOrderID,EmployeeID,VendorID,PurchaseOrderDate,ExpectedDeliveryDate,PurchaseOrderAmount")] PurchaseOrder purchaseOrder)
        {
            if (id != purchaseOrder.PurchaseOrderID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purchaseOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurchaseOrderExists(purchaseOrder.PurchaseOrderID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "EmployeeID", purchaseOrder.EmployeeID);
            ViewData["VendorID"] = new SelectList(_context.Vendor, "VendorID", "VendorID", purchaseOrder.VendorID);
            return View(purchaseOrder);
        }

        // GET: PurchaseOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseOrder = await _context.PurchaseOrder
                .Include(p => p.Employee)
                .Include(p => p.Vendor)
                .SingleOrDefaultAsync(m => m.PurchaseOrderID == id);
            if (purchaseOrder == null)
            {
                return NotFound();
            }

            return View(purchaseOrder);
        }

        // POST: PurchaseOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var purchaseOrder = await _context.PurchaseOrder.SingleOrDefaultAsync(m => m.PurchaseOrderID == id);
            _context.PurchaseOrder.Remove(purchaseOrder);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool PurchaseOrderExists(int id)
        {
            return _context.PurchaseOrder.Any(e => e.PurchaseOrderID == id);
        }
    }
}
