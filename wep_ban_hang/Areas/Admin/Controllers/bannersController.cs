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
    public class bannersController : Controller
    {
        private readonly wep_ban_hangContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public bannersController(wep_ban_hangContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Admin/banners
        public async Task<IActionResult> Index()
        {
            return View(await _context.banner.ToListAsync());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string searchString)
        {
            var search = from l in _context.banner select l;
            if (!string.IsNullOrEmpty(searchString))
            {
                search = search.Where(a => a.tenquangcao.ToString().Contains(searchString));
            }
            return View(search);
        }
        // GET: Admin/banners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var banner = await _context.banner
                .FirstOrDefaultAsync(m => m.id == id);
            if (banner == null)
            {
                return NotFound();
            }

            return View(banner);
        }

        // GET: Admin/banners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/banners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,tenquangcao,hinhanh,mota,trangthai")] banner banner, IFormFile ful_hinhanh)
        {
            if (ModelState.IsValid)
            {
                _context.Add(banner);
                await _context.SaveChangesAsync();
                if (ful_hinhanh != null)
                {
                    var fileName = banner.id.ToString() + Path.GetExtension(ful_hinhanh.FileName);
                    var uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "img", "quangcao");
                    var filePath = Path.Combine(uploadPath, fileName);
                    using (FileStream fs = System.IO.File.Create(filePath))
                    {
                        ful_hinhanh.CopyTo(fs);
                        fs.Flush();
                    }
                    banner.hinhanh = fileName;
                    _context.Update(banner);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(banner);
        }

        // GET: Admin/banners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var banner = await _context.banner.FindAsync(id);
            if (banner == null)
            {
                return NotFound();
            }
            return View(banner);
        }

        // POST: Admin/banners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,tenquangcao,hinhanh,mota,trangthai")] banner banner, IFormFile ful_hinhanh)
        {
            if (id != banner.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (ful_hinhanh != null)
                    {
                        var fileToDelete = Path.Combine(_webHostEnvironment.WebRootPath, "img", "quangcao", banner.hinhanh);
                        FileInfo file = new FileInfo(fileToDelete);
                        file.Delete();
                        var fileName = banner.id.ToString() + Path.GetExtension(ful_hinhanh.FileName);
                        var uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "img", "banners");
                        var filePath = Path.Combine(uploadPath, fileName);
                        using (FileStream fs = System.IO.File.Create(filePath))
                        {
                            ful_hinhanh.CopyTo(fs);
                            fs.Flush();
                        }
                        banner.hinhanh = fileName;
                    }
                    
                    _context.Update(banner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!bannerExists(banner.id))
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
            return View(banner);
        }

        // GET: Admin/banners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var banner = await _context.banner
                .FirstOrDefaultAsync(m => m.id == id);
            if (banner == null)
            {
                return NotFound();
            }

            return View(banner);
        }

        // POST: Admin/banners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var banner = await _context.banner.FindAsync(id);
           
            if (banner.hinhanh != null)
            {
                var fileToDelete = Path.Combine(_webHostEnvironment.WebRootPath, "img", "quangcao", banner.hinhanh);
                FileInfo file = new FileInfo(fileToDelete);
                file.Delete();
            }
            _context.banner.Remove(banner);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool bannerExists(int id)
        {
            return _context.banner.Any(e => e.id == id);
        }
    }
}
