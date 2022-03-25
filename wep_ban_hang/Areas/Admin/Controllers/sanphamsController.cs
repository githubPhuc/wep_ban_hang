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
    public class sanphamsController : Controller
    {
        private readonly wep_ban_hangContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public sanphamsController(wep_ban_hangContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Admin/sanphams
        public async Task<IActionResult> Index()
        {
            var eshopContext = _context.sanpham.Include(p => p.ctsanphams.tenloaisanpham);
            
            return View(await _context.sanpham.ToListAsync());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult Index(string searchString)
        {
            var search = from l in _context.sanpham select l;
            if(!string.IsNullOrEmpty(searchString))
            {
                search = search.Where(a => a.tensanpham.Contains(searchString));
            }    
            return View(search);
        }

        // GET: Admin/sanphams/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: Admin/sanphams/Create
        public IActionResult Create()
        {
            ViewData["lspham"] = new SelectList(_context.ctsanpham, "id", "tenloaisanpham");
            ViewData["nsxuat"] = new SelectList(_context.nhasanxuat, "id", "tennsx");
            return View();
        }

        // POST: Admin/sanphams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,tensanpham,gia,danhgia,soluong,lspham,nsxuat,hinhanh,trangthai")] sanpham sanpham, IFormFile ful_hinhanh)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sanpham);
                await _context.SaveChangesAsync();
                if (ful_hinhanh != null)
                {
                    var fileName = sanpham.id.ToString() + Path.GetExtension(ful_hinhanh.FileName);
                    var uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "img", "sanphams");
                    var filePath = Path.Combine(uploadPath, fileName);
                    using (FileStream fs = System.IO.File.Create(filePath))
                    {
                        ful_hinhanh.CopyTo(fs);
                        fs.Flush();
                    }
                    sanpham.hinhanh = fileName;
                    _context.Update(sanpham);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["lspham"] = new SelectList(_context.sanpham, "Id", "tenloai", sanpham.lspham);
            ViewData["nsxuat"] = new SelectList(_context.sanpham, "Id", "tennsx", sanpham.nhasanxuat);
            return View(sanpham);
        }

        // GET: Admin/sanphams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewData["lspham"] = new SelectList(_context.ctsanpham, "id", "tenloaisanpham");
            ViewData["nsxuat"] = new SelectList(_context.nhasanxuat, "id", "tennsx");
            var sanpham = await _context.sanpham.FindAsync(id);
            if (sanpham == null)
            {
                return NotFound();
            }
            return View(sanpham);
        }

        // POST: Admin/sanphams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,tensanpham,gia,danhgia,soluong,lspham,nsxuat,hinhanh,trangthai")] sanpham sanpham, IFormFile ful_hinhanh)
        {
            if (id != sanpham.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (ful_hinhanh != null)
                    {
                        var fileToDelete = Path.Combine(_webHostEnvironment.WebRootPath, "img", "sanphams", sanpham.hinhanh);
                        FileInfo file = new FileInfo(fileToDelete);
                        file.Delete();
                        var fileName = sanpham.id.ToString() + Path.GetExtension(ful_hinhanh.FileName);
                        var uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "img", "sanphams");
                        var filePath = Path.Combine(uploadPath, fileName);
                        using (FileStream fs = System.IO.File.Create(filePath))
                        {
                            ful_hinhanh.CopyTo(fs);
                            fs.Flush();
                        }
                        sanpham.hinhanh = fileName;
                    }
                    ViewData["lspham"] = new SelectList(_context.sanpham, "Id", "tenloai", sanpham.lspham);
                    ViewData["nsxuat"] = new SelectList(_context.sanpham, "Id", "tennsx", sanpham.nhasanxuat);
                    _context.Update(sanpham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!sanphamExists(sanpham.id))
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
            return View(sanpham);
        }

        // GET: Admin/sanphams/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: Admin/sanphams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sanpham = await _context.sanpham.FindAsync(id);
            if (sanpham.hinhanh != null)
            {
                var fileToDelete = Path.Combine(_webHostEnvironment.WebRootPath, "img", "sanphams", sanpham.hinhanh);
                FileInfo file = new FileInfo(fileToDelete);
                file.Delete();
            }
            _context.sanpham.Remove(sanpham);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool sanphamExists(int id)
        {
            return _context.sanpham.Any(e => e.id == id);
        }
    }
}
