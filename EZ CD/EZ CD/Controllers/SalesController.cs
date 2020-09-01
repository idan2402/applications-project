using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EZ_CD.Data;
using EZ_CD.Models;
using EZ_CD.Areas.Identity;
using Microsoft.AspNetCore.Authorization;
using EZ_CD.Areas.Identity.Data;

namespace EZ_CD.Controllers
{
    [Authorize(Roles = "Admins")]
    public class SalesController : Controller
    {
        private readonly EZ_CD_DBContext _context;

        public SalesController(EZ_CD_DBContext context)
        {
            _context = context;
        }

        // GET: Sales
        public async Task<IActionResult> Index()
        {
            var tempContext = await _context.Sale.Include(s => s.User).ToListAsync();
            foreach (var sale in tempContext)
            {
                var saleItems = await _context.SaleItem.Include(s => s.Disk).Include(s => s.Sale).Where(s => s.Sale.saleId == sale.saleId).ToListAsync();
                double sum = 0;
                foreach (var item in saleItems)
                    sum += item.Disk.price;
                ViewData[sale.saleId.ToString()] = sum;
            }
            return View(tempContext);
        }

        // GET: Sales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = await _context.Sale.Include(s => s.User)
                .FirstOrDefaultAsync(m => m.saleId == id);
            if (sale == null)
            {
                return NotFound();
            }

            ViewBag.Disks = await _context.SaleItem.Include(s => s.Disk).Include(s => s.Sale).Where(s => s.Sale.saleId == id).ToListAsync();
            return View(sale);
        }

        // GET: Sales/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Users, "customerId", "customerId");
            return View();
        }

        public async Task<IActionResult> Search(string filter)
        {
            if (String.IsNullOrEmpty(filter))
                filter = "";
            var temp1 = _context.Sale.Include(s => s.User);
            var temp = temp1.Where(s => s.User.UserName.Contains(filter));
            var finalList = temp.Select(item => new
            {
                item.User.UserName,
                ordertotal = _context.SaleItem.Include(s => s.Disk).Include(s => s.Sale).Where(s => s.Sale.saleId == item.saleId).Select(si => si.Disk.price).Sum(),
                date = item.date.ToShortDateString(),
                item.saleId
            })
            .ToList();
            return Json(finalList);
        }

        // POST: Sales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("saleId,date")] Sale sale)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Users, "customerId", "customerId", sale.User.Id);
            return View(sale);
        }

        // GET: Sales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var sale = await _context.Sale.Include(s => s.User).Where(s => s.saleId == id).FirstOrDefaultAsync();
            if (sale == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Users, "customerId", "customerId", sale.User.Id);
            return View(sale);
        }

        // POST: Sales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("saleId,date")] Sale sale)
        {
            if (id != sale.saleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaleExists(sale.saleId))
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
            ViewData["CustomerId"] = new SelectList(_context.Users, "customerId", "customerId", sale.User.Id);
            return View(sale);
        }

        // GET: Sales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = await _context.Sale
                .FirstOrDefaultAsync(m => m.saleId == id);
            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);
        }

        // POST: Sales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sale = await _context.Sale.FindAsync(id);
            _context.Sale.Remove(sale);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SaleExists(int id)
        {
            return _context.Sale.Any(e => e.saleId == id);
        }
    }
}
