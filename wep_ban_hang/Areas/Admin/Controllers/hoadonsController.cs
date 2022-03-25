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
    public class hoadonsController : Controller
    {
        private readonly wep_ban_hangContext _context;

        public hoadonsController(wep_ban_hangContext context)
        {
            _context = context;
        }

        // GET: Admin/hoadons
        public async Task<IActionResult> Index()
        {
            return View(await _context.hoadon.ToListAsync());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string searchString)
        {
            var search = from l in _context.hoadon select l;
            if (String.IsNullOrEmpty(searchString))
            {
                int epKieu = Convert.ToInt32(searchString);
                if (epKieu > 0 && epKieu < 32)
                {
                    search = search.Where(a => a.ngaylap.Day.ToString().Contains(searchString));
                }
                else
                {
                    
                }
            }
            return View(search);
        }
        // GET: Admin/hoadons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoadon = await _context.hoadon
                .FirstOrDefaultAsync(m => m.id == id);
            if (hoadon == null)
            {
                return NotFound();
            }

            return View(hoadon);
        }

        // GET: Admin/hoadons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/hoadons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,mahd,makh,ngaylap,diachi,sodt,thanhtien,trangthai")] hoadon hoadon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hoadon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hoadon);
        }

        // GET: Admin/hoadons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoadon = await _context.hoadon.FindAsync(id);
            if (hoadon == null)
            {
                return NotFound();
            }
            return View(hoadon);
        }

        // POST: Admin/hoadons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,mahd,makh,ngaylap,diachi,sodt,thanhtien,trangthai")] hoadon hoadon)
        {
            if (id != hoadon.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hoadon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!hoadonExists(hoadon.id))
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
            return View(hoadon);
        }

        // GET: Admin/hoadons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoadon = await _context.hoadon
                .FirstOrDefaultAsync(m => m.id == id);
            if (hoadon == null)
            {
                return NotFound();
            }

            return View(hoadon);
        }

        // POST: Admin/hoadons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hoadon = await _context.hoadon.FindAsync(id);
            _context.hoadon.Remove(hoadon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult statistic()
        {
            // báo cáo doanh thu theo tháng gần nhất
            DateTime date = DateTime.Now;
            DateTime lastdate = new DateTime(date.Year, date.Month, 1);
            var invoices = _context.hoadon.Where(i => i.ngaylap >= lastdate && i.ngaylap <= date);
            ViewBag.Total = invoices.Sum(i => i.thanhtien);

            // báo cáo doanh thu theo các ngày trong `

            // Top 5, 10, 15… sản phẩm bán chạy nhất.


            return View(invoices);

        }
        private bool hoadonExists(int id)
        {
            return _context.hoadon.Any(e => e.id == id);
        }
    }
}
