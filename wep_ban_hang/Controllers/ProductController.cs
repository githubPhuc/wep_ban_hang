
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using wep_ban_hang.Data;

namespace wep_ban_hang.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly wep_ban_hangContext _context;
        public ProductController(wep_ban_hangContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<IActionResult> products()
        {
            var eshopContext = _context.sanpham.Include(p => p.ctsanphams.tenloaisanpham);

            return View(await _context.sanpham.ToListAsync());
        }
        public IActionResult productsDetail()
        {
            return View();
        }
        public IActionResult cart()
        {
            return View();
        }
        public IActionResult account()
        {

            return View();
        }
        public IActionResult Editaccount()
        {
            return View();
        }





    }
}
