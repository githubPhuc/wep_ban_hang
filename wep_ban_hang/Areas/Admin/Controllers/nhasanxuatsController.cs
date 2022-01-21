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
    public class nhasanxuatsController : Controller
    {
        private readonly wep_ban_hangContext _context;

        public nhasanxuatsController(wep_ban_hangContext context)
        {
            _context = context;
        }

        // GET: Admin/nhasanxuats
        public async Task<IActionResult> Index()
        {
            return View(await _context.nhasanxuat.ToListAsync());
        }

        // GET: Admin/nhasanxuats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhasanxuat = await _context.nhasanxuat
                .FirstOrDefaultAsync(m => m.id == id);
            if (nhasanxuat == null)
            {
                return NotFound();
            }

            return View(nhasanxuat);
        }

        // GET: Admin/nhasanxuats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/nhasanxuats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,tennsx,hinhanh,diachi,sdt,trangthai")] nhasanxuat nhasanxuat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhasanxuat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nhasanxuat);
        }

        // GET: Admin/nhasanxuats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhasanxuat = await _context.nhasanxuat.FindAsync(id);
            if (nhasanxuat == null)
            {
                return NotFound();
            }
            return View(nhasanxuat);
        }

        // POST: Admin/nhasanxuats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,tennsx,hinhanh,diachi,sdt,trangthai")] nhasanxuat nhasanxuat)
        {
            if (id != nhasanxuat.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhasanxuat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!nhasanxuatExists(nhasanxuat.id))
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
            return View(nhasanxuat);
        }

        // GET: Admin/nhasanxuats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhasanxuat = await _context.nhasanxuat
                .FirstOrDefaultAsync(m => m.id == id);
            if (nhasanxuat == null)
            {
                return NotFound();
            }

            return View(nhasanxuat);
        }

        // POST: Admin/nhasanxuats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nhasanxuat = await _context.nhasanxuat.FindAsync(id);
            _context.nhasanxuat.Remove(nhasanxuat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool nhasanxuatExists(int id)
        {
            return _context.nhasanxuat.Any(e => e.id == id);
        }
    }
}
