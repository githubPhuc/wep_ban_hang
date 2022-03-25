
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using wep_ban_hang.Areas.Admin.Controllers;
using wep_ban_hang.Areas.Admin.Models;
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
        public async Task<IActionResult> productsDetail(int ?id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanpham = await _context.sanpham
                .FirstOrDefaultAsync(m => m.id == id);
            
            if (sanpham == null)
            {
                return NotFound();
            }

            return View(sanpham);
        }
        public IActionResult themgiohang(int idsp, int sl, [Bind("id,taikhoanid,sanphamid,soluong,trangthai")] giohang giohang)
        {
            string name =   loginController.usename ;
            var check = _context.taikhoan.FirstOrDefault(s => s.tendangnhap == name);
            if (name == null)
            {
                return RedirectToAction("dangnhap", "Login");
            }
            else
            {
                var data = _context.giohang.Where(s => s.sanphamid == idsp && s.taikhoanid == check.id).ToList();
                var check1 = _context.giohang.FirstOrDefault(s => s.sanphamid == idsp && s.taikhoanid == check.id);

                if (data.Count == 0)
                {
                    giohang.taikhoanid = _context.taikhoan.FirstOrDefault(a => a.tendangnhap == name && a.isadmin == false).id;
                    giohang.sanphamid = idsp;
                    giohang.soluong = sl;
                    giohang.trangthai = false;
                    _context.Add(giohang);
                }
                else
                {
                    giohang = check1;
                    giohang.soluong = check1.soluong + sl;
                    _context.Update(giohang);
                }
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
           
        }
        public async Task<IActionResult> cart()
        {
            string name = loginController.usename;
            if(name==null)
            {
                return RedirectToAction("Login", "login");
            }
            else
            {

                var check = _context.taikhoan.FirstOrDefault(s => s.tendangnhap == name && s.isadmin == false);
                int makhachhang = _context.taikhoan.FirstOrDefault(a => a.tendangnhap == name && a.isadmin == false).id;
                ViewBag.tongtien = _context.giohang.Include(c => c.sanpham).Include(c => c.taikhoans)
                                                  .Where(c => c.taikhoans.tendangnhap == name)
                                                  .Sum(c => c.soluong * c.sanpham.gia);
            }


            var wep_ban_hangContext = _context.giohang.Include(g => g.sanpham).Include(g => g.taikhoans);
            return View(await wep_ban_hangContext.ToListAsync());

        }

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var giohang = await _context.giohang.FindAsync(id);
            _context.giohang.Remove(giohang);
            await _context.SaveChangesAsync();
            return RedirectToAction("cart", "Product");
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
