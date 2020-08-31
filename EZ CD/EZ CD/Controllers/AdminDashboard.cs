using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EZ_CD.Areas.Identity.Data;
using EZ_CD.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Web;
using Microsoft.VisualBasic;
using EZ_CD.Models;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Manage.Internal;
using System.Data.SqlTypes;

namespace EZ_CD.Controllers
{
    
    [Authorize(Roles = "Admins")]
    public class AdminDashboard : Controller
    {
        private UserManager<User> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private readonly EZ_CD_DBContext _context;

        public AdminDashboard(EZ_CD_DBContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }


        public IActionResult Index()
        {
            // Setting the data for the pie chart
            String[] all_generes = { "Pop", "Rap", "Rock", "Metal", "Classic" };
            List<String> generes = new List<string>();
            Dictionary<String, int> data = new Dictionary<String, int>();
            foreach (String genere in all_generes)
            {
                int count = _context.Disk.Count(m => m.genre == genere);
                if (count > 0)
                {
                    generes.Add(genere);
                    data.Add(genere, count);
                }

            }
            ViewBag.data = data;
            ViewBag.generes = generes.ToArray();

            List<Dictionary<String, String>> tmp = new List<Dictionary<String, String>>();

            var sales = _context.Sale.GroupBy(s => s.date.Date).Select(g => new
            {
                date = g.Key.ToShortDateString(),
                count = g.Count()
            });

            ViewBag.sales = sales;

            return View();
        }

        // GET: AdminDashboard/Create
        public IActionResult AddAdmin()
        {
            ViewData["Users"] = new SelectList(_context.Users, "Id", "Email");
            return View();
        }

        // POST: Disks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAdmin(string selectedUser)
        {
            var currentUser = await _userManager.FindByIdAsync(selectedUser);

            if (!await _roleManager.RoleExistsAsync("Admins"))
            {
                var roleResult = await _roleManager.CreateAsync(new IdentityRole("Admins"));

            }
            var roleresult = await _userManager.AddToRoleAsync(currentUser, "Admins");            
            return View();
        }

    }

        class RandomPasswordGenerator
        {

            const string LOWER_CASE = "abcdefghijklmnopqursuvwxyz";
            const string UPPER_CAES = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string NUMBERS = "123456789";
            const string SPECIALS = @"!@£$%^&*()#€";


            public string GeneratePassword(bool useLowercase=true, bool useUppercase = true, bool useNumbers = true, bool useSpecial = true,
                int passwordSize = 6)
            {
                char[] _password = new char[passwordSize];
                string charSet = ""; // Initialise to blank
                System.Random _random = new Random();
                int counter;

                // Build up the character set to choose from
                if (useLowercase) charSet += LOWER_CASE;

                if (useUppercase) charSet += UPPER_CAES;

                if (useNumbers) charSet += NUMBERS;

                if (useSpecial) charSet += SPECIALS;

                for (counter = 0; counter < passwordSize; counter++)
                {
                    _password[counter] = charSet[_random.Next(charSet.Length - 1)];
                }

                return String.Join(null, _password);
            }
        }
}
