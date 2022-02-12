using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using wep_ban_hang.Areas.Admin.Models;
using wep_ban_hang.Data;

using Microsoft.AspNetCore.Hosting;
using wep_ban_hang.Common;


namespace wep_ban_hang.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class loginController : Controller
    {
        
        private readonly wep_ban_hangContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public loginController(wep_ban_hangContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public ActionResult Index()
        {
            return View();
        }
        public bool login(string username,string passwork)
        {
            var resurt = _context.taikhoan.Count(x => x.tendangnhap == username && x.matkhau == passwork && x.trangthai == true);
            if (resurt > 0) { return true; }
            else { return false; }
        }
        public ActionResult login(taikhoan taikhoan)
        {
            if (ModelState.IsValid)
            {
                var resurt = login(taikhoan.tendangnhap, taikhoan.matkhau);
                if (resurt)
                {
                    Session.Add(commonConstants.USRE_SESSION);
                }
                else { ModelState.AddModelError("", "Đăng nhập không đúng "); }
            }
            return View("Index");
        }
    }
}
