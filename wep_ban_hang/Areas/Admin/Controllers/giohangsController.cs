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
    public class giohangsController : Controller
    {
        private readonly wep_ban_hangContext _context;

        public giohangsController(wep_ban_hangContext context)
        {
            _context = context;
        }

        // GET: Admin/giohangs
        public async Task<IActionResult> Index()
        {
            var wep_ban_hangContext = _context.giohang.Include(g => g.sanpham).Include(g => g.taikhoans);
            return View(await wep_ban_hangContext.ToListAsync());
        }

        // GET: Admin/giohangs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giohang = await _context.giohang
                .Include(g => g.sanpham)
                .Include(g => g.taikhoans)
                .FirstOrDefaultAsync(m => m.id == id);
            if (giohang == null)
            {
                return NotFound();
            }

            return View(giohang);
        }

        // GET: Admin/giohangs/Create
        public IActionResult Create()
        {
            ViewData["sanphamid"] = new SelectList(_context.Set<sanpham>(), "id", "danhgia");
            ViewData["taikhoanid"] = new SelectList(_context.Set<taikhoan>(), "id", "diachi");
            return View();
        }

        // POST: Admin/giohangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,taikhoanid,sanphamid,soluong,trangthai")] giohang giohang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(giohang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["sanphamid"] = new SelectList(_context.Set<sanpham>(), "id", "danhgia", giohang.sanphamid);
            ViewData["taikhoanid"] = new SelectList(_context.Set<taikhoan>(), "id", "diachi", giohang.taikhoanid);
            return View(giohang);
        }

        // GET: Admin/giohangs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giohang = await _context.giohang.FindAsync(id);
            if (giohang == null)
            {
                return NotFound();
            }
            ViewData["sanphamid"] = new SelectList(_context.Set<sanpham>(), "id", "danhgia", giohang.sanphamid);
            ViewData["taikhoanid"] = new SelectList(_context.Set<taikhoan>(), "id", "diachi", giohang.taikhoanid);
            return View(giohang);
        }

        // POST: Admin/giohangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,taikhoanid,sanphamid,soluong,trangthai")] giohang giohang)
        {
            if (id != giohang.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(giohang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!giohangExists(giohang.id))
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
            ViewData["sanphamid"] = new SelectList(_context.Set<sanpham>(), "id", "danhgia", giohang.sanphamid);
            ViewData["taikhoanid"] = new SelectList(_context.Set<taikhoan>(), "id", "diachi", giohang.taikhoanid);
            return View(giohang);
        }

        // GET: Admin/giohangs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giohang = await _context.giohang
                .Include(g => g.sanpham)
                .Include(g => g.taikhoans)
                .FirstOrDefaultAsync(m => m.id == id);
            if (giohang == null)
            {
                return NotFound();
            }

            return View(giohang);
        }

        // POST: Admin/giohangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var giohang = await _context.giohang.FindAsync(id);
            _context.giohang.Remove(giohang);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool giohangExists(int id)
        {
            return _context.giohang.Any(e => e.id == id);
        }
    }
}
