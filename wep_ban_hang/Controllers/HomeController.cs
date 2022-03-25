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
using wep_ban_hang.Areas.Admin.Controllers;

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
            
            var banner = from m in _context.banner select m;
            var banners = await _context.banner.ToListAsync();
            ViewData["banner"] = banners;
            
            var eshopContext = _context.sanpham.Include(p => p.ctsanphams.tenloaisanpham);
            return View(await _context.sanpham.ToListAsync());
        }
        public async Task<IActionResult> About()
        {

            int id = 1;
            var banner = await _context.banner.FirstOrDefaultAsync(m => m.id == id);
            if (banner == null)
            {
                return NotFound();
            }

            return View(banner);
           
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
