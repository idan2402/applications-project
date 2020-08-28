using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EZ_CD.Models;
using EZ_CD.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using EZ_CD.Areas.Identity.Data;
using Microsoft.AspNetCore.Http;
using System.Globalization;
using Newtonsoft.Json;
using RestSharp;

namespace EZ_CD.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly ILogger<HomeController> _logger;
        private readonly EZ_CD_DBContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _singInManager;
        public HomeController(ILogger<HomeController> logger, EZ_CD_DBContext context, UserManager<User> userManager, SignInManager<User> singInManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _singInManager = singInManager;
        }

        public async Task<IActionResult> Index()
        {
            IRestClient restClient = new RestClient();
            IRestRequest request = new RestRequest("https://api.genius.com/artists/16775/songs?access_token=8rGdEOfCmCnCHLMotGkGr9SGv_uGJZQgchokUOcwydzfI25vq5iYGvDSJZHN36E6");
            var response = restClient.Get(request);
            dynamic obj = JsonConvert.DeserializeObject(response.Content);
            var tempContext = _context.Disk.Include(d => d.Artist);
            User currentUser = await _userManager.GetUserAsync(HttpContext.User);
            HttpContext.Session.SetInt32("cartSize", _context.CartItem.Count(m => m.User == currentUser));
            return View("Index", tempContext);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> DiskDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.songs = _context.Song.Where(s => s.Disk.diskId == id);
            string[] timeformats = { @"m\:ss", @"mm\:ss", @"h\:mm\:ss" };
            string totalTime = " ";
            double totalTimeinSecs = 0;
            try //calculating the total time in seconds of this album
            {
                foreach (Song song in ViewBag.songs)
                {
                    totalTimeinSecs += TimeSpan.ParseExact(song.length, timeformats, CultureInfo.InvariantCulture).TotalSeconds;
                }
                TimeSpan time = TimeSpan.FromSeconds(totalTimeinSecs);
                if (totalTimeinSecs > 3600)
                {
                    totalTime += time.Hours.ToString();
                    if (totalTimeinSecs < 7200)
                        totalTime += " hour ";
                    else
                        totalTime += " hours ";
                }
                totalTime += time.Minutes.ToString();
                totalTime += " minutes";
                ViewBag.totalTime = totalTime;
            }
            catch
            {
                throw new Exception();
            }

            var disk = await _context.Disk.Include(d => d.Artist)
                .FirstOrDefaultAsync(m => m.diskId == id);

            if (disk == null)
            {
                return NotFound();
            }

            var audioDbClient = new RestClient("https://www.theaudiodb.com/api/v1/json/1/searchalbum.php?a=" + disk.name); //making a rest request to TheAudioDB API
            var requestAudioDb = new RestRequest(Method.GET);
            requestAudioDb.AddHeader("x-rapidapi-host", "theaudiodb.p.rapidapi.com");
            requestAudioDb.AddHeader("x-rapidapi-key", "1f93d82fecmsh6b9145790737872p198302jsn573fbd3516e4");
            requestAudioDb.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };

            try //if the current disk inst on TheAudioDB's database, skip this part
            {
                IRestResponse response = audioDbClient.Execute(requestAudioDb);
                dynamic obj = JsonConvert.DeserializeObject(response.Content);
                string description = obj.album[0].strDescriptionEN;
                if(description == null)
                    ViewBag.description = "This disk doesn't have a description yet";
                else
                    ViewBag.description = description;               
            }
            catch {
                ViewBag.description = "This disk doesn't have a description yet";
            }
           
            var tempContext = _context.Song.Include(d => d.Disk);
            var songs = tempContext.Where(s => s.Disk.diskId == id).ToList(); //seraching for all the songs that the current disk contains


            return View("DiskDetails", disk);
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
                return View("index", await results.ToListAsync());

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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Cart()
        {
            User currentUser = await _userManager.GetUserAsync(HttpContext.User);
            List<CartItem> items = _context.CartItem.Where(m => m.User == currentUser).Include(m => m.Disk).ToList();
            double sum = 0;
            foreach (var item in items)
            {
                sum += item.Disk.price;
            }
            ViewData["sum"] = sum;
            return View("cart", items);
        }

        public async Task<IActionResult> AddToCart(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }
            
            User currentUser = await _userManager.GetUserAsync(HttpContext.User);
            if(currentUser == null)
            {
                return Redirect("~/Identity/Account/Login");
            }
            else
            {
                CartItem cartItem = new CartItem();
                cartItem.User = currentUser;
                cartItem.Disk = await _context.Disk.FirstAsync(m => m.diskId == id);
                _context.Add(cartItem);
                await _context.SaveChangesAsync();
                HttpContext.Session.SetInt32("cartSize", _context.CartItem.Count(m => m.User == currentUser));
                return RedirectToAction(nameof(Cart));
            }
        }

        public async Task<IActionResult> RemoveFromCart(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            User currentUser = await _userManager.GetUserAsync(HttpContext.User);

            CartItem cartItem = await _context.CartItem.FirstAsync(m => m.cartItemId== id);
            _context.Remove(cartItem);
            await _context.SaveChangesAsync();
            HttpContext.Session.SetInt32("cartSize", _context.CartItem.Count(m => m.User == currentUser));
            return RedirectToAction(nameof(Cart));
        }

        public async Task<IActionResult> Purhcased()
        {
            User currentUser = await _userManager.GetUserAsync(HttpContext.User);

            List<CartItem> items = _context.CartItem.Where(m => m.User == currentUser).Include(m => m.Disk).ToList();
            
            // Creates a sale
            Sale sale = new Sale();
            sale.date = DateTime.Now;
            sale.User = currentUser;

            _context.Add(sale); // Adds the new sale to the sales table

            foreach (CartItem cartItem in items)
            {
                //Creates a new saleItem from the data of the cartItem
                SaleItem saleItem = new SaleItem();
                saleItem.Disk = cartItem.Disk;
                saleItem.Sale = sale;

                _context.Add(saleItem); // Adds the saleItem to the datbase

                _context.Remove(cartItem); // Removes the cartItem from the database
            }
             
            await _context.SaveChangesAsync(); // Saves the changes
            HttpContext.Session.SetInt32("cartSize", 0); // Sets the new size cart (0 cuz empty)
            return RedirectToAction(nameof(Index));
        }
        public IActionResult About()
        {
            ViewBag.numOfDisks = _context.Disk.Count();
            ViewBag.numOfArtists = _context.Artist.Count();
            ViewBag.numOfSongs = _context.Song.Count();
            ViewBag.numOfSales = _context.SaleItem.Count();
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult QnA()
        {
            return View();
        }

    }
}