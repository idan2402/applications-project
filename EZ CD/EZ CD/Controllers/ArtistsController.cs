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
    public class ArtistsController : Controller
    {
        private readonly EZ_CD_DBContext _context;

        public ArtistsController(EZ_CD_DBContext context)
        {
            _context = context;
        }

        // GET: Artists
        public async Task<IActionResult> Index()
        {
            return View(await _context.Artist.ToListAsync());
        }

        // GET: Artists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artist = await _context.Artist
                .FirstOrDefaultAsync(m => m.artistId == id);
            if (artist == null)
            {
                return NotFound();
            }
            ViewBag.artistDisks = _context.Disk.Include(d => d.Artist).Where(d => d.Artist.artistId == id).ToList();
            return View(artist);
        }

        // GET: Artists/Create
        public IActionResult Create()
        {
            ViewBag.Countries = new SelectList(Countries.countries, Countries.countries[0]);
            return View();
        }

        // POST: Artists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("artistId,name,birthday,genre,country")] Artist artist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(artist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(artist);
        }

        // GET: Artists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artist = await _context.Artist.FindAsync(id);
            if (artist == null)
            {
                return NotFound();
            }
            ViewBag.Countries = new SelectList(Countries.countries, artist.country);
            return View(artist);
        }

        // POST: Artists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("artistId,name,birthday,genre,country")] Artist artist)
        {
            if (id != artist.artistId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(artist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtistExists(artist.artistId))
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
            return View(artist);
        }

        public IActionResult Search(string filter)
        {
            if (String.IsNullOrEmpty(filter))
                filter = "";
            var temp = _context.Artist.ToList().Where(a => a.name.Contains(filter, StringComparison.OrdinalIgnoreCase));
            var finalList = temp.Select(item => new
            {
                item.name,
                item.genre,
                birthday = item.birthday.ToShortDateString(),
                item.country,
                item.artistId
            }).ToList();
            return Json(finalList);
        }


        // GET: Artists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var artist = await _context.Artist
                .FirstOrDefaultAsync(m => m.artistId == id);
            if (artist == null)
            {
                return NotFound();
            }

            return View(artist);
        }

        // POST: Artists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var disks = _context.Disk.Where(d => d.Artist.artistId == id);
            foreach (var disk in disks)
            {
                _context.Remove(disk);
            }
            var artist = await _context.Artist.FindAsync(id);
            _context.Artist.Remove(artist);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArtistExists(int id)
        {
            return _context.Artist.Any(e => e.artistId == id);
        }
    }
}
