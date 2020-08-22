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

namespace EZ_CD.Controllers
{
    
    [Authorize]
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

            return RedirectToAction("Index");
        }

    }
}
