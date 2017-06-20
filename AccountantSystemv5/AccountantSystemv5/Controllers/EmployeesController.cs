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
    public class EmployeesController : Controller
    {
        private readonly AccountantSystemv5Context _context;

        public EmployeesController(AccountantSystemv5Context context)
        {
            _context = context;    
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var accountantSystemv5Context = _context.Employee.Include(e => e.EmployeeType).Include(e => e.Exemptions).Include(e => e.Withholding);
            return View(await accountantSystemv5Context.ToListAsync());
        }

   
        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .Include(e => e.EmployeeType)
                .Include(e => e.Exemptions)
                .Include(e => e.Withholding)
                .SingleOrDefaultAsync(m => m.EmployeeID == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewBag.ItemsWithholding = GetWithholdingListItems();
            ViewData["EmployeeTypeID"] = new SelectList(_context.EmployeeType, "EmployeeTypeID", "EmployeeTypeName");
            ViewData["ExemptionNum"] = new SelectList(_context.Exemptions, "ExemptionNum", "ExemptionNum");
            ViewData["MaritalStatusID"] = new SelectList(_context.Withholding, "MaritalStatusID", "FWTRate");
            return View();
        }

        //listwithholding
        private IEnumerable<SelectListItem> GetWithholdingListItems(int selected = -1)
        {
            var tmp = _context.Withholding.ToList();
            // Create cashaccounts list for <select> dropdown
            return tmp
                .OrderBy(maritalstatus => maritalstatus.MaritalStatusID)
                .Select(maritalstatus => new SelectListItem
                {
                    Text = String.Format("{0}-{1}", maritalstatus.MaritalStatus, maritalstatus.FWTRate),
                    Value = maritalstatus.MaritalStatusID.ToString(),
                    Selected = maritalstatus.MaritalStatusID == selected
                });
        }
       
        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeID,EmployeeLastName,EmployeeFirstName,MI,EmployeeSSN,EmAddress1,EmAddress2,EmCity,EmState,EmZipcode,EmTelephone,MaritalStatusID,ExemptionNum,EmPayRate,EmployeeTypeID,EmStartDate")] Employee employee)
        {
            employee.EmState= employee.EmState.ToUpper();
            employee.MI = employee.MI.ToUpper();
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["EmployeeTypeID"] = new SelectList(_context.Set<EmployeeType>(), "EmployeeTypeID", "EmployeeTypeName", employee.EmployeeTypeID);
            ViewData["ExemptionNum"] = new SelectList(_context.Set<Exemptions>(), "ExemptionNum", "ExemptionNum", employee.ExemptionNum);
            ViewData["MaritalStatusID"] = new SelectList(_context.Set<Withholding>(), "MaritalStatusID", "FWTRate", employee.MaritalStatusID);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.ItemsWithholding = GetWithholdingListItems();
            var employee = await _context.Employee.SingleOrDefaultAsync(m => m.EmployeeID == id);
            if (employee == null)
            {
                return NotFound();
            }
            //ViewData["EmployeeTypeID"] = new SelectList(_context.EmployeeType, "EmployeeTypeID", "EmployeeTypeName", employee.EmployeeTypeID);
            //ViewData["ExemptionNum"] = new SelectList(_context.Exemptions, "ExemptionNum", "ExemptionNum", employee.ExemptionNum);
            //ViewData["MaritalStatusID"] = new SelectList(_context.Withholding, "MaritalStatusID", "FWTRate", employee.MaritalStatusID);
            ViewData["EmployeeTypeID"] = new SelectList(_context.Set<EmployeeType>(), "EmployeeTypeID", "EmployeeTypeName", employee.EmployeeTypeID);
            ViewData["ExemptionNum"] = new SelectList(_context.Set<Exemptions>(), "ExemptionNum", "ExemptionNum", employee.ExemptionNum);
            ViewData["MaritalStatusID"] = new SelectList(_context.Set<Withholding>(), "MaritalStatusID", "FWTRate", employee.MaritalStatusID);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeID,EmployeeLastName,EmployeeFirstName,MI,EmployeeSSN,EmAddress1,EmAddress2,EmCity,EmState,EmZipcode,EmTelephone,MaritalStatusID,ExemptionNum,EmPayRate,EmployeeTypeID,EmStartDate")] Employee employee)
        {
            if (id != employee.EmployeeID)
            {
                return NotFound();
            }
            employee.EmState = employee.EmState.ToUpper();
            employee.MI = employee.MI.ToUpper();
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmployeeID))
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
            //ViewData["EmployeeTypeID"] = new SelectList(_context.EmployeeType, "EmployeeTypeID", "EmployeeTypeName", employee.EmployeeTypeID);
            //ViewData["ExemptionNum"] = new SelectList(_context.Exemptions, "ExemptionNum", "ExemptionNum", employee.ExemptionNum);
            //ViewData["MaritalStatusID"] = new SelectList(_context.Withholding, "MaritalStatusID", "FWTRate", employee.MaritalStatusID);
            ViewData["EmployeeTypeID"] = new SelectList(_context.Set<EmployeeType>(), "EmployeeTypeID", "EmployeeTypeName", employee.EmployeeTypeID);
            ViewData["ExemptionNum"] = new SelectList(_context.Set<Exemptions>(), "ExemptionNum", "ExemptionNum", employee.ExemptionNum);
            ViewData["MaritalStatusID"] = new SelectList(_context.Set<Withholding>(), "MaritalStatusID", "FWTRate", employee.MaritalStatusID);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .Include(e => e.EmployeeType)
                .Include(e => e.Exemptions)
                .Include(e => e.Withholding)
                .SingleOrDefaultAsync(m => m.EmployeeID == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employee.SingleOrDefaultAsync(m => m.EmployeeID == id);
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.EmployeeID == id);
        }
    }
}
