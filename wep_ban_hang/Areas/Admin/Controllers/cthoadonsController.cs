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
    public class cthoadonsController : Controller
    {
        private readonly wep_ban_hangContext _context;

        public cthoadonsController(wep_ban_hangContext context)
        {
            _context = context;
        }

        // GET: Admin/cthoadons
        public async Task<IActionResult> Index()
        {
            var wep_ban_hangContext = _context.cthoadon.Include(c => c.hoadons).Include(c => c.sanphams);
            return View(await wep_ban_hangContext.ToListAsync());
        }

        // GET: Admin/cthoadons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cthoadon = await _context.cthoadon
                .Include(c => c.hoadons)
                .Include(c => c.sanphams)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cthoadon == null)
            {
                return NotFound();
            }

            return View(cthoadon);
        }

        // GET: Admin/cthoadons/Create
        public IActionResult Create()
        {
            ViewData["hoadonid"] = new SelectList(_context.hoadon, "id", "diachi");
            ViewData["sanphamid"] = new SelectList(_context.sanpham, "id", "danhgia");
            return View();
        }

        // POST: Admin/cthoadons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,hoadonid,sanphamid,soluong,gia")] cthoadon cthoadon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cthoadon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["hoadonid"] = new SelectList(_context.hoadon, "id", "diachi", cthoadon.hoadonid);
            ViewData["sanphamid"] = new SelectList(_context.sanpham, "id", "danhgia", cthoadon.sanphamid);
            return View(cthoadon);
        }

        // GET: Admin/cthoadons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cthoadon = await _context.cthoadon.FindAsync(id);
            if (cthoadon == null)
            {
                return NotFound();
            }
            ViewData["hoadonid"] = new SelectList(_context.hoadon, "id", "diachi", cthoadon.hoadonid);
            ViewData["sanphamid"] = new SelectList(_context.sanpham, "id", "danhgia", cthoadon.sanphamid);
            return View(cthoadon);
        }

        // POST: Admin/cthoadons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,hoadonid,sanphamid,soluong,gia")] cthoadon cthoadon)
        {
            if (id != cthoadon.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cthoadon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!cthoadonExists(cthoadon.Id))
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
            ViewData["hoadonid"] = new SelectList(_context.hoadon, "id", "diachi", cthoadon.hoadonid);
            ViewData["sanphamid"] = new SelectList(_context.sanpham, "id", "danhgia", cthoadon.sanphamid);
            return View(cthoadon);
        }

        // GET: Admin/cthoadons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cthoadon = await _context.cthoadon
                .Include(c => c.hoadons)
                .Include(c => c.sanphams)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cthoadon == null)
            {
                return NotFound();
            }

            return View(cthoadon);
        }

        // POST: Admin/cthoadons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cthoadon = await _context.cthoadon.FindAsync(id);
            _context.cthoadon.Remove(cthoadon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool cthoadonExists(int id)
        {
            return _context.cthoadon.Any(e => e.Id == id);
        }
    }
}
