using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EZ_CD.Data;
using EZ_CD.Models;

namespace EZ_CD.Controllers
{
    public class SaleDetailesController : Controller
    {
        private readonly EZ_CD_DBContext _context;

        public SaleDetailesController(EZ_CD_DBContext context)
        {
            _context = context;
        }

        // GET: SaleDetailes
        public async Task<IActionResult> Index()
        {
            var eZ_CD_DBContext = _context.SaleDetailes.Include(s => s.disk).Include(s => s.sale);
            return View(await eZ_CD_DBContext.ToListAsync());
        }

        // GET: SaleDetailes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleDetailes = await _context.SaleDetailes
                .Include(s => s.disk)
                .Include(s => s.sale)
                .FirstOrDefaultAsync(m => m.diskId == id);
            if (saleDetailes == null)
            {
                return NotFound();
            }

            return View(saleDetailes);
        }

        // GET: SaleDetailes/Create
        public IActionResult Create()
        {
            ViewData["diskId"] = new SelectList(_context.Disk, "diskId", "diskId");
            ViewData["saleId"] = new SelectList(_context.Sale, "saleId", "saleId");
            return View();
        }

        // POST: SaleDetailes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("diskId,saleId")] SaleDetailes saleDetailes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(saleDetailes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["diskId"] = new SelectList(_context.Disk, "diskId", "diskId", saleDetailes.diskId);
            ViewData["saleId"] = new SelectList(_context.Sale, "saleId", "saleId", saleDetailes.saleId);
            return View(saleDetailes);
        }

        // GET: SaleDetailes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleDetailes = await _context.SaleDetailes.FindAsync(id);
            if (saleDetailes == null)
            {
                return NotFound();
            }
            ViewData["diskId"] = new SelectList(_context.Disk, "diskId", "diskId", saleDetailes.diskId);
            ViewData["saleId"] = new SelectList(_context.Sale, "saleId", "saleId", saleDetailes.saleId);
            return View(saleDetailes);
        }

        // POST: SaleDetailes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("diskId,saleId")] SaleDetailes saleDetailes)
        {
            if (id != saleDetailes.diskId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(saleDetailes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaleDetailesExists(saleDetailes.diskId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["diskId"] = new SelectList(_context.Disk, "diskId", "diskId", saleDetailes.diskId);
            ViewData["saleId"] = new SelectList(_context.Sale, "saleId", "saleId", saleDetailes.saleId);
            return View(saleDetailes);
        }

        // GET: SaleDetailes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleDetailes = await _context.SaleDetailes
                .Include(s => s.disk)
                .Include(s => s.sale)
                .FirstOrDefaultAsync(m => m.diskId == id);
            if (saleDetailes == null)
            {
                return NotFound();
            }

            return View(saleDetailes);
        }

        // POST: SaleDetailes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var saleDetailes = await _context.SaleDetailes.FindAsync(id);
            _context.SaleDetailes.Remove(saleDetailes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SaleDetailesExists(int id)
        {
            return _context.SaleDetailes.Any(e => e.diskId == id);
        }
    }
}
