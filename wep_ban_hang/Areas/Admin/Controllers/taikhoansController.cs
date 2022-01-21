using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using wep_ban_hang.Areas.Admin.Models;
using wep_ban_hang.Data;

namespace wep_ban_hang.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class taikhoansController : Controller
    {
        private readonly wep_ban_hangContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public taikhoansController(wep_ban_hangContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Admin/taikhoans
        public async Task<IActionResult> Index()
        {
            return View(await _context.taikhoan.ToListAsync());
        }

        // GET: Admin/taikhoans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taikhoan = await _context.taikhoan
                .FirstOrDefaultAsync(m => m.id == id);
            if (taikhoan == null)
            {
                return NotFound();
            }

            return View(taikhoan);
        }

        // GET: Admin/taikhoans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/taikhoans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,hoten,email,tendangnhap,matkhau,hinhanh,diachi,isadmin,trangthai")] taikhoan taikhoan, IFormFile ful_hinhanh)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taikhoan);
                await _context.SaveChangesAsync();
                if (ful_hinhanh != null)
                {
                    var fileName = taikhoan.id.ToString() + Path.GetExtension(ful_hinhanh.FileName);
                    var uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "img", "accounts");
                    var filePath = Path.Combine(uploadPath, fileName);
                    using (FileStream fs = System.IO.File.Create(filePath))
                    {
                        ful_hinhanh.CopyTo(fs);
                        fs.Flush();
                    }
                    taikhoan.hinhanh = fileName;
                    _context.Update(taikhoan);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(taikhoan);
        }

        // GET: Admin/taikhoans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taikhoan = await _context.taikhoan.FindAsync(id);
            if (taikhoan == null)
            {
                return NotFound();
            }
            return View(taikhoan);
        }

        // POST: Admin/taikhoans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,hoten,email,tendangnhap,matkhau,hinhanh,diachi,isadmin,trangthai")] taikhoan taikhoan, IFormFile ful_hinhanh)
        {
            if (id != taikhoan.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (ful_hinhanh != null)
                    {
                        var fileToDelete = Path.Combine(_webHostEnvironment.WebRootPath, "img", "accounts", taikhoan.hinhanh);
                        FileInfo file = new FileInfo(fileToDelete);
                        file.Delete();
                        var fileName = taikhoan.id.ToString() + Path.GetExtension(ful_hinhanh.FileName);
                        var uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "img", "accounts");
                        var filePath = Path.Combine(uploadPath, fileName);
                        using (FileStream fs = System.IO.File.Create(filePath))
                        {
                            ful_hinhanh.CopyTo(fs);
                            fs.Flush();
                        }
                        taikhoan.hinhanh = fileName;
                    }

                    _context.Update(taikhoan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!taikhoanExists(taikhoan.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(taikhoan);
        }

        // GET: Admin/taikhoans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taikhoan = await _context.taikhoan
                .FirstOrDefaultAsync(m => m.id == id);
            if (taikhoan == null)
            {
                return NotFound();
            }

            return View(taikhoan);
        }

        // POST: Admin/taikhoans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taikhoan = await _context.taikhoan.FindAsync(id);
            var fileToDelete = Path.Combine(_webHostEnvironment.WebRootPath, "img", "accounts", taikhoan.hinhanh);
            FileInfo file = new FileInfo(fileToDelete);
            file.Delete();
            _context.taikhoan.Remove(taikhoan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool taikhoanExists(int id)
        {
            return _context.taikhoan.Any(e => e.id == id);
        }
    }
}
