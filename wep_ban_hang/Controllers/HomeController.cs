using wep_ban_hang.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using wep_ban_hang.Data;
using Microsoft.EntityFrameworkCore;

namespace wep_ban_hang.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly wep_ban_hangContext _context;
        public HomeController(wep_ban_hangContext context,ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var eshopContext = _context.sanpham.Include(p => p.ctsanphams.tenloaisanpham);

            return View(await _context.sanpham.ToListAsync());
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult products()
        {
            return View();
        }
        public IActionResult whyus()
        {
            return View();
        }


        public IActionResult Testimonial()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
