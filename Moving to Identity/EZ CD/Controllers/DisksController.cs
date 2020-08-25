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
using EZ_CD.Utilities;

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
           var tempContext = _context.Disk.Include(d => d.Artist);
            return View(await tempContext.ToListAsync());
        }

        // GET: Disks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disk = await _context.Disk
                .FirstOrDefaultAsync(m => m.diskId == id);
            if (disk == null)
            {
                return NotFound();
            }
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
        public async Task<IActionResult> Create([Bind("diskId,price,name,date,genre,dateAdded,imagePath,featuredVideoUrl")] Disk disk, string artistId)
        {
            if (ModelState.IsValid)
            {
                disk.Artist = _context.Artist.Find(int.Parse(artistId));
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
           await _context.Disk
                .Include(d => d.Artist)
                .FirstOrDefaultAsync(m => m.diskId == id);
            ViewData["Artists"] = new SelectList(_context.Artist, "artistId", "name", disk.Artist.artistId);
            ViewBag.Countries = new SelectList(Countries.countries, disk.Artist.country);
            ViewBag.Songs = _context.Song.Where(song => song.Disk.diskId == id);
            return View(disk);
        }

        // POST: Disks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("diskId,price,name,date,genre,dateAdded,imagePath,featuredVideoUrl")] Disk disk, string artistId)
        {
            if (id != disk.diskId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    disk.Artist = _context.Artist.Find(int.Parse(artistId));
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
            ViewData["ArtistId"] = new SelectList(_context.Artist, "artistId", "artistId", disk.Artist.artistId);
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
    }
}
