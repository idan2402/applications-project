using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EZ_CD.Data;
using EZ_CD.Models;
using Microsoft.AspNetCore.Authorization;
using EZ_CD.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Collections.Generic;
using System;

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
            ViewBag.songs = _context.Song.Where(s => s.Disk.diskId == id);

            if (id == null)
            {
                return NotFound();
            }

            var disk = await _context.Disk.Include(d => d.Artist)
                .FirstOrDefaultAsync(m => m.diskId == id);
            if (disk == null)
            {
                return NotFound();
            }
            ViewBag.ArtistId = disk.Artist.artistId;
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
        public async Task<IActionResult> Create([Bind("diskId,price,name,date,genre,dateAdded,imagePath,featuredVideoUrl")] Disk disk, string artistId, string songsJSON)
        {
            IRestClient geniusClient = new RestClient();
            if (ModelState.IsValid)
            {
                dynamic array = JsonConvert.DeserializeObject(songsJSON);
                if (((JArray)array).Count == 0)
                {
                    ViewBag.Error = "You must enter at least one song";
                    return View("Error");
                }

                foreach (var song in array)
                {
                    Song temp = new Song();
                    temp.name = song.name;
                    temp.length = song.length;
                    temp.Disk = disk;
                    _context.Song.Add(temp);
                }
                IRestRequest requestGenius = new RestRequest("https://api.genius.com/search?q=" + array[0].name + _context.Artist.Find(int.Parse(artistId)).name);
                requestGenius.AddHeader("Authorization", "Bearer IBWzJOsCp1yX3P_jd3SVGV8m7HvR-nS8FDbrPy1hp4s6teuS3ygbytt98qZmuGFA");
                requestGenius.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
                try
                {
                    var responseGenius = geniusClient.Get(requestGenius);
                    dynamic obj = JsonConvert.DeserializeObject(responseGenius.Content);
                    disk.imagePath = (string)obj.response.hits[0].result.song_art_image_url;
                }
                catch
                {

                }

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
        public async Task<IActionResult> Edit(int id, [Bind("diskId,price,name,date,genre,dateAdded,imagePath,featuredVideoUrl")] Disk disk, string artistId, string songsJSON)
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

                    var songs = _context.Song.Where(s => s.Disk.diskId == id);
                    foreach (var s in songs)
                        _context.Song.Remove(s);
                    dynamic array = JsonConvert.DeserializeObject(songsJSON);
                    foreach (var song in array)
                    {
                        Song temp = new Song();
                        temp.name = song.name;
                        temp.length = song.length;
                        temp.Disk = disk;
                        _context.Song.Add(temp);
                    }

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
            var songs = _context.Song.Where(s => s.Disk.diskId == id);
            foreach (var s in songs)
                _context.Song.Remove(s);
            _context.Disk.Remove(disk);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiskExists(int id)
        {
            return _context.Disk.Any(e => e.diskId == id);
        }

        // GET: Disks/Delete/5
        public async Task<IActionResult> Search(string filter, string state,string minprice, string maxprice)
        {
            if (String.IsNullOrEmpty(filter))
                filter = "";

            IEnumerable<Disk> list = new List<Disk>();
            list = await _context.Disk.Include(d => d.Artist).ToListAsync();
            if (state == "artist")
                list = list.Where(d => d.Artist.name.Contains(filter, StringComparison.OrdinalIgnoreCase));
            else
                list = list.Where(d => d.name.Contains(filter, StringComparison.OrdinalIgnoreCase));
            if (!string.IsNullOrEmpty(minprice) && isDigits(minprice))
                list = list.Where(d => d.price >= double.Parse(minprice));
            if (!string.IsNullOrEmpty(maxprice) && isDigits(maxprice))
                list = list.Where(d => d.price <= double.Parse(maxprice));

            IEnumerable<object> finalList = new List<object>();
            finalList = list.Select(item => new
            {
                ArtistId = item.Artist.artistId,
                Artist = item.Artist.name,
                item.name,
                item.imagePath,
                date = item.date.ToShortDateString(),
                item.genre,
                dateAdded = item.dateAdded.ToShortDateString(),
                item.featuredVideoUrl,
                item.diskId,
                item.price
            }).ToList();

            return Json(finalList);
        }
        private bool isDigits(string str)
        {
            char[] digitsArr = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.' };
            foreach (char c in str)
                if (!digitsArr.Contains(c))
                    return false;
            return true;
        }
    }
}
