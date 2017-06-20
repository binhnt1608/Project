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
    public class LaborTypesController : Controller
    {
        private readonly AccountantSystemv5Context _context;

        public LaborTypesController(AccountantSystemv5Context context)
        {
            _context = context;    
        }

        // GET: LaborTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.LaborType.ToListAsync());
        }

        // GET: LaborTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laborType = await _context.LaborType
                .SingleOrDefaultAsync(m => m.LaborTypeID == id);
            if (laborType == null)
            {
                return NotFound();
            }

            return View(laborType);
        }

        // GET: LaborTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LaborTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LaborTypeID")] LaborType laborType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(laborType);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(laborType);
        }

        // GET: LaborTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laborType = await _context.LaborType.SingleOrDefaultAsync(m => m.LaborTypeID == id);
            if (laborType == null)
            {
                return NotFound();
            }
            return View(laborType);
        }

        // POST: LaborTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LaborTypeID")] LaborType laborType)
        {
            if (id != laborType.LaborTypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(laborType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LaborTypeExists(laborType.LaborTypeID))
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
            return View(laborType);
        }

        // GET: LaborTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laborType = await _context.LaborType
                .SingleOrDefaultAsync(m => m.LaborTypeID == id);
            if (laborType == null)
            {
                return NotFound();
            }

            return View(laborType);
        }

        // POST: LaborTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var laborType = await _context.LaborType.SingleOrDefaultAsync(m => m.LaborTypeID == id);
            _context.LaborType.Remove(laborType);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool LaborTypeExists(int id)
        {
            return _context.LaborType.Any(e => e.LaborTypeID == id);
        }
    }
}
