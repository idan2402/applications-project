using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EZ_CD.Controllers
{
    public class AdminDashboard : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
