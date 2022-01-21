
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace wep_ban_hang.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<HomeController> _logger;





        public IActionResult products()
        {
            return View();
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
