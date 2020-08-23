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
    public class DisksController : Controller
    {
        private readonly EZ_CD_DBContext _context;

        public DisksController(EZ_CD_DBContext context)
        {
            _context = context;
        }

        // GET: Disks
        public async Task<IActionResult> Index()
        {
            var eZ_CD_DBContext = _context.Disk.Include(d => d.artist);
            return View(await eZ_CD_DBContext.ToListAsync());
        }

        // GET: Disks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disk = await _context.Disk
                .Include(d => d.artist)
                .FirstOrDefaultAsync(m => m.diskId == id);
            if (disk == null)
            {
                return NotFound();
            }
            ViewBag.ArtistId = disk.ArtistId;
            return View(disk);
        }

        // GET: Disks/Create
        public IActionResult Create()
        {
            ViewData["Artists"] = new SelectList(_context.Artist, "artistId", "name");
            return View();
        }

        // POST: Disks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("diskId,price,name,date,ArtistId,genre,dateAdded,imagePath,videoUrl")] Disk disk)
        {
            if (ModelState.IsValid)
            {
                _context.Add(disk);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(disk);
        }

        // GET: Disks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disk = await _context.Disk.FindAsync(id);
            if (disk == null)
            {
                return NotFound();
            }
            ViewData["Artists"] = new SelectList(_context.Artist, "artistId", "name", disk.ArtistId);
            return View(disk);
        }

        // POST: Disks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("diskId,price,name,date,ArtistId,genre,dateAdded,imagePath,videoUrl")] Disk disk)
        {
            if (id != disk.diskId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(disk);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiskExists(disk.diskId))
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
            ViewData["ArtistId"] = new SelectList(_context.Artist, "artistId", "artistId", disk.ArtistId);
            return View(disk);
        }

        // GET: Disks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disk = await _context.Disk
                .Include(d => d.artist)
                .FirstOrDefaultAsync(m => m.diskId == id);
            if (disk == null)
            {
                return NotFound();
            }

            return View(disk);
        }

        // POST: Disks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var disk = await _context.Disk.FindAsync(id);
            _context.Disk.Remove(disk);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiskExists(int id)
        {
            return _context.Disk.Any(e => e.diskId == id);
        }
        public async Task<IActionResult> Search(string diskName, string pop = "", string rap = "", string rock = "", string metal = "", string classic = "",
            string fromYear = "", string toYear = "", string minPrice = "", string maxPrice = "")
        {
            // Validations:
            if (fromYear != "")
            {
                if (!isDigits(fromYear))
                    return View("_InvalidArguments");
                if (int.Parse(fromYear) <= 0)
                    return View("_InvalidArguments");
                if (int.Parse(fromYear) != double.Parse(fromYear))
                    return View("_InvalidArguments");
            }
            if (toYear != "")
            {
                if (!isDigits(toYear))
                    return View("_InvalidArguments");
                if (int.Parse(toYear) > int.Parse(DateTime.Now.Year.ToString()))
                    return View("_InvalidArguments");
                if (int.Parse(toYear) != double.Parse(toYear))
                    return View("_InvalidArguments");
                if (int.Parse(toYear) < int.Parse(fromYear))
                    return View("_InvalidArguments");
            }
            if (minPrice != "")
            {
                if (!isDigits(minPrice))
                    return View("_InvalidArguments");
                if (int.Parse(minPrice) < 0)
                    return View("_InvalidArguments");
            }
            if (minPrice != "")
            {
                if (!isDigits(maxPrice))
                    return View("_InvalidArguments");
                if (int.Parse(maxPrice) < int.Parse(minPrice))
                    return View("_InvalidArguments");
            }
            // End Of Validations

            // The Search:
            IQueryable<Disk> results = _context.Disk;

            if (!String.IsNullOrEmpty(diskName))
                results = results.Where(disk => (disk.name.Contains(diskName)));
            if (!String.IsNullOrEmpty(fromYear))
                results = results.Where(disk => (disk.date.Year >= int.Parse(fromYear)));
            if (!String.IsNullOrEmpty(toYear))
                results = results.Where(disk => (disk.date.Year <= int.Parse(toYear)));
            if (!String.IsNullOrEmpty(minPrice))
                results = results.Where(disk => (disk.price >= int.Parse(minPrice)));
            if (!String.IsNullOrEmpty(maxPrice))
                results = results.Where(disk => (disk.price <= int.Parse(maxPrice)));

            if (String.IsNullOrEmpty(pop) && String.IsNullOrEmpty(rap) && String.IsNullOrEmpty(rock) && String.IsNullOrEmpty(metal) && String.IsNullOrEmpty(classic))
                return View(await results.ToListAsync());

            return View(
                from disk in results
                where (disk.genre == pop) || (disk.genre == rap) || (disk.genre == rock) || (disk.genre == metal) || (disk.genre == classic)
                select disk
                );
        }

        private bool isDigits(string str)
        {
            char[] digitsArr = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '-', '.' };
            foreach (char c in str)
                if (!digitsArr.Contains(c))
                    return false;
            return true;
        }
    }
}
