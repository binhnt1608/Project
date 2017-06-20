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
    public class CashDisbursementsController : Controller
    {
        private readonly AccountantSystemv5Context _context;

        public CashDisbursementsController(AccountantSystemv5Context context)
        {
            _context = context;    
        }

        // GET: CashDisbursements
        public async Task<IActionResult> Index()
        {
            var accountantSystemv5Context = _context.CashDisbursement.Include(c => c.CashAccount).Include(c => c.CashDisbursementType).Include(c => c.Purchase);
            return View(await accountantSystemv5Context.ToListAsync());
        }

        // GET: CashDisbursements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cashDisbursement = await _context.CashDisbursement
                .Include(c => c.CashAccount)
                .Include(c => c.CashDisbursementType)
                .Include(c => c.Purchase)
                .SingleOrDefaultAsync(m => m.CheckNumber == id);
            if (cashDisbursement == null)
            {
                return NotFound();
            }

            return View(cashDisbursement);
        }

        // GET: CashDisbursements/Create
        public IActionResult Create()
        {
            ViewData["CashAccountID"] = new SelectList(_context.CashAccount, "CashAccountID", "AccountDescription");
            ViewData["CDTypeID"] = new SelectList(_context.CashDisbursementType, "CDTypeID", "EventTypeName");
            ViewData["InventoryReceiptID"] = new SelectList(_context.Purchase, "InventoryReceiptID", "ReceivingReportVendorInvoiceID");
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "EmployeeLastName");
            ViewData["VendorID"] = new SelectList(_context.Vendor, "VendorID", "VendorName");
            return View();
        }

        // POST: CashDisbursements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CheckNumber,CashAccountID,CDTypeID,VendorID,EmployeeID,InventoryReceiptID,CashDisbursementAmount,CashDisbursementDate")] CashDisbursement cashDisbursement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cashDisbursement);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["CashAccountID"] = new SelectList(_context.CashAccount, "CashAccountID", "AccountDescription", cashDisbursement.CashAccountID);
            ViewData["CDTypeID"] = new SelectList(_context.CashDisbursementType, "CDTypeID", "EventTypeName", cashDisbursement.CDTypeID);
            ViewData["InventoryReceiptID"] = new SelectList(_context.Purchase, "InventoryReceiptID", "ReceivingReportVendorInvoiceID", cashDisbursement.InventoryReceiptID);
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "EmployeeLastName", cashDisbursement.EmployeeID);
            ViewData["VendorID"] = new SelectList(_context.Vendor, "VendorID", "VendorName",cashDisbursement.VendorID);
            return View(cashDisbursement);
        }

        // GET: CashDisbursements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cashDisbursement = await _context.CashDisbursement.SingleOrDefaultAsync(m => m.CheckNumber == id);
            if (cashDisbursement == null)
            {
                return NotFound();
            }
            ViewData["CashAccountID"] = new SelectList(_context.CashAccount, "CashAccountID", "AccountDescription", cashDisbursement.CashAccountID);
            ViewData["CDTypeID"] = new SelectList(_context.CashDisbursementType, "CDTypeID", "EventTypeName", cashDisbursement.CDTypeID);
            ViewData["InventoryReceiptID"] = new SelectList(_context.Purchase, "InventoryReceiptID", "ReceivingReportVendorInvoiceID", cashDisbursement.InventoryReceiptID);
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "EmployeeLastName", cashDisbursement.EmployeeID);
            ViewData["VendorID"] = new SelectList(_context.Vendor, "VendorID", "VendorName", cashDisbursement.VendorID);
            return View(cashDisbursement);
        }

        // POST: CashDisbursements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CheckNumber,CashAccountID,CDTypeID,VendorID,EmployeeID,InventoryReceiptID,CashDisbursementAmount,CashDisbursementDate")] CashDisbursement cashDisbursement)
        {
            if (id != cashDisbursement.CheckNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cashDisbursement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CashDisbursementExists(cashDisbursement.CheckNumber))
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
            ViewData["CashAccountID"] = new SelectList(_context.CashAccount, "CashAccountID", "AccountDescription", cashDisbursement.CashAccountID);
            ViewData["CDTypeID"] = new SelectList(_context.CashDisbursementType, "CDTypeID", "EventTypeName", cashDisbursement.CDTypeID);
            ViewData["InventoryReceiptID"] = new SelectList(_context.Purchase, "InventoryReceiptID", "ReceivingReportVendorInvoiceID", cashDisbursement.InventoryReceiptID);
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "EmployeeLastName", cashDisbursement.EmployeeID);
            ViewData["VendorID"] = new SelectList(_context.Vendor, "VendorID", "VendorName", cashDisbursement.VendorID);
            return View(cashDisbursement);
        }

        // GET: CashDisbursements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cashDisbursement = await _context.CashDisbursement
                .Include(c => c.CashAccount)
                .Include(c => c.CashDisbursementType)
                .Include(c => c.Purchase)
                .SingleOrDefaultAsync(m => m.CheckNumber == id);
            if (cashDisbursement == null)
            {
                return NotFound();
            }

            return View(cashDisbursement);
        }

        // POST: CashDisbursements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cashDisbursement = await _context.CashDisbursement.SingleOrDefaultAsync(m => m.CheckNumber == id);
            _context.CashDisbursement.Remove(cashDisbursement);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CashDisbursementExists(int id)
        {
            return _context.CashDisbursement.Any(e => e.CheckNumber == id);
        }
    }
}
