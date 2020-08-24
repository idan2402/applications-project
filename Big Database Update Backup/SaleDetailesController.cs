using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EZ_CD.Data;
using EZ_CD.Models;
using Microsoft.AspNetCore.Authorization;


namespace EZ_CD.Controllers
{
    [Authorize(Roles = "Admins")]
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
                .FirstOrDefaultAsync(m => m.DiskId == id);
            if (saleDetailes == null)
            {
                return NotFound();
            }

            return View(saleDetailes);
        }

        // GET: SaleDetailes/Create
        public IActionResult Create()
        {
            ViewData["DiskId"] = new SelectList(_context.Disk, "diskId", "diskId");
            ViewData["SaleId"] = new SelectList(_context.Sale, "saleId", "saleId");
            return View();
        }

        // POST: SaleDetailes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DiskId,SaleId")] SaleItem saleDetailes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(saleDetailes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DiskId"] = new SelectList(_context.Disk, "diskId", "diskId", saleDetailes.Disk.diskId);
            ViewData["SaleId"] = new SelectList(_context.Sale, "saleId", "saleId", saleDetailes.Sale.saleId);
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
            ViewData["DiskId"] = new SelectList(_context.Disk, "diskId", "diskId", saleDetailes.DiskId);
            ViewData["SaleId"] = new SelectList(_context.Sale, "saleId", "saleId", saleDetailes.SaleId);
            return View(saleDetailes);
        }

        // POST: SaleDetailes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DiskId,SaleId")] SaleItem saleDetailes)
        {
            if (id != saleDetailes.Disk.diskId)
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
                    if (!SaleDetailesExists(saleDetailes.Disk.diskId))
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
            ViewData["DiskId"] = new SelectList(_context.Disk, "diskId", "diskId", saleDetailes.Disk.diskId);
            ViewData["SaleId"] = new SelectList(_context.Sale, "saleId", "saleId", saleDetailes.Sale.saleId);
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
                .FirstOrDefaultAsync(m => m.DiskId == id);
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
            return _context.SaleDetailes.Any(e => e.DiskId == id);
        }
    }
}
