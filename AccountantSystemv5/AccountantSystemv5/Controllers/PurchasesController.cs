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
    public class PurchasesController : Controller
    {
        private readonly AccountantSystemv5Context _context;

        public PurchasesController(AccountantSystemv5Context context)
        {
            _context = context;    
        }

        // GET: Purchases
        public async Task<IActionResult> Index()
        {
            var accountantSystemv5Context = _context.Purchase.Include(p => p.PurchaseOrder);
            return View(await accountantSystemv5Context.ToListAsync());
        }

        // GET: Purchases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchase = await _context.Purchase
                .Include(p => p.PurchaseOrder)
                .SingleOrDefaultAsync(m => m.InventoryReceiptID == id);
            if (purchase == null)
            {
                return NotFound();
            }

            return View(purchase);
        }

        // GET: Purchases/Create
        public IActionResult Create()
        {
            ViewBag.ItemsVendor = GetVendorListItems();
            ViewBag.ItemsEmployee = GetEmployeeListItems();
            ViewData["PurchaseOrderID"] = new SelectList(_context.PurchaseOrder, "PurchaseOrderID", "PurchaseOrderID");
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
        // POST: Purchases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InventoryReceiptID,PurchaseOrderID,EmployeeID,VendorID,ReceivingReportDate,InventoryReceiptAmount,ReceivingReportVendorInvoiceID")] Purchase purchase)
        {
            if (ModelState.IsValid)
            {
                _context.Add(purchase);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["PurchaseOrderID"] = new SelectList(_context.PurchaseOrder, "PurchaseOrderID", "PurchaseOrderID", purchase.PurchaseOrderID);
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "EmployeeID", purchase.EmployeeID);
            ViewData["VendorID"] = new SelectList(_context.Vendor, "VendorID", "VendorID", purchase.VendorID);
            return View(purchase);
        }

        // GET: Purchases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.ItemsVendor = GetVendorListItems();
            ViewBag.ItemsEmployee = GetEmployeeListItems();
            var purchase = await _context.Purchase.SingleOrDefaultAsync(m => m.InventoryReceiptID == id);
            if (purchase == null)
            {
                return NotFound();
            }
            ViewData["PurchaseOrderID"] = new SelectList(_context.PurchaseOrder, "PurchaseOrderID", "PurchaseOrderID", purchase.PurchaseOrderID);
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "EmployeeID");
            ViewData["VendorID"] = new SelectList(_context.Vendor, "VendorID", "VendorID");
            return View(purchase);
        }

        // POST: Purchases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InventoryReceiptID,PurchaseOrderID,EmployeeID,VendorID,ReceivingReportDate,InventoryReceiptAmount,ReceivingReportVendorInvoiceID")] Purchase purchase)
        {
            if (id != purchase.InventoryReceiptID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purchase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurchaseExists(purchase.InventoryReceiptID))
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
            ViewData["PurchaseOrderID"] = new SelectList(_context.PurchaseOrder, "PurchaseOrderID", "PurchaseOrderID", purchase.PurchaseOrderID);
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "EmployeeID", purchase.EmployeeID);
            ViewData["VendorID"] = new SelectList(_context.Vendor, "VendorID", "VendorID", purchase.VendorID);
            return View(purchase);
        }

        // GET: Purchases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchase = await _context.Purchase
                .Include(p => p.PurchaseOrder)
                .SingleOrDefaultAsync(m => m.InventoryReceiptID == id);
            if (purchase == null)
            {
                return NotFound();
            }

            return View(purchase);
        }

        // POST: Purchases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var purchase = await _context.Purchase.SingleOrDefaultAsync(m => m.InventoryReceiptID == id);
            _context.Purchase.Remove(purchase);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool PurchaseExists(int id)
        {
            return _context.Purchase.Any(e => e.InventoryReceiptID == id);
        }
    }
}
