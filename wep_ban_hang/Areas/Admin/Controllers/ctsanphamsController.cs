using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using wep_ban_hang.Areas.Admin.Models;
using wep_ban_hang.Data;

namespace wep_ban_hang.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ctsanphamsController : Controller
    {
        private readonly wep_ban_hangContext _context;

        public ctsanphamsController(wep_ban_hangContext context)
        {
            _context = context;
        }

        // GET: Admin/ctsanphams
        public async Task<IActionResult> Index()
        {
            var loaisp = await _context.ctsanpham.ToListAsync();
            ViewData["ctsanpham"] = loaisp;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(string searchString)
        {
            var search = from l in _context.ctsanpham select l;
            if (!string.IsNullOrEmpty(searchString))
            {
                search = search.Where(a => a.tenloaisanpham!.Contains(searchString));
            }
            var loaisp = await search.ToListAsync();
            ViewData["ctsanpham"] = loaisp;
            return View();
        }
        // GET: Admin/ctsanphams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ctsanpham = await _context.ctsanpham
                .FirstOrDefaultAsync(m => m.id == id);
            if (ctsanpham == null)
            {
                return NotFound();
            }

            return View(ctsanpham);
        }

        // GET: Admin/ctsanphams/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/ctsanphams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,tenloaisanpham,trangthai")] ctsanpham ctsanpham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ctsanpham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ctsanpham);
        }

        // GET: Admin/ctsanphams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ctsanpham = await _context.ctsanpham.FindAsync(id);
            if (ctsanpham == null)
            {
                return NotFound();
            }
            return View(ctsanpham);
        }

        // POST: Admin/ctsanphams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,tenloaisanpham,trangthai")] ctsanpham ctsanpham)
        {
            if (id != ctsanpham.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ctsanpham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ctsanphamExists(ctsanpham.id))
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
            return View(ctsanpham);
        }

        // GET: Admin/ctsanphams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ctsanpham = await _context.ctsanpham
                .FirstOrDefaultAsync(m => m.id == id);
            if (ctsanpham == null)
            {
                return NotFound();
            }

            return View(ctsanpham);
        }

        // POST: Admin/ctsanphams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ctsanpham = await _context.ctsanpham.FindAsync(id);
            _context.ctsanpham.Remove(ctsanpham);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ctsanphamExists(int id)
        {
            return _context.ctsanpham.Any(e => e.id == id);
        }
    }
}
