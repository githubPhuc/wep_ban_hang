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
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Index(string searchString)
        //{
        //    var search = from l in _context.giohang  select l;
        //    if (!string.IsNullOrEmpty(searchString))
        //    {
        //        search = search.Where(a => a.tensanpham.Contains(searchString));
        //    }
        //    return View(search);
        //}
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
        public IActionResult pay()
        {
            string user = "phuc";
            ViewBag.Taikhoan = _context.taikhoan.Where(a => a.hoten == user&& a.isadmin==false).FirstOrDefault();
            ViewBag.thanhtoan = _context.giohang.Include(c => c.sanpham).Include(c => c.taikhoans)
                                              .Where(c => c.taikhoans.hoten == user && c.taikhoans.isadmin==false)
                                              .Sum(c => c.soluong * c.sanpham.gia);
            return View();
        }
        [HttpPost]
        public IActionResult pay([Bind("diachi,sodt,soluong")] hoadon hoaDon)
        {
            string user = "phuc";
            if (check(user))
            {
                ViewBag.ErrorMessage = "Sản phẩm đả hết hàng vui lòng kiểm tra lại :((";
                ViewBag.Taikhoan = _context.taikhoan.Where(a => a.hoten == user).FirstOrDefault();
                ViewBag.thanhtoan = _context.giohang.Include(c => c.sanpham).Include(c => c.taikhoans)
                                                  .Where(c => c.taikhoans.hoten == user && c.taikhoans.isadmin == false)
                                                  .Sum(c => c.soluong * c.sanpham.gia);
                return View();
            }
            DateTime now = DateTime.Now;
            hoaDon.mahd = now.ToString("yyMMddhhmmss");
            hoaDon.makh = _context.taikhoan.FirstOrDefault(a => a.hoten == user && a.isadmin == false).id;
            hoaDon.ngaylap = now;
            
            hoaDon.thanhtien= _context.giohang.Include(c => c.sanpham).Include(c => c.taikhoans)
                                              .Where(c => c.taikhoans.hoten == user)
                                              .Sum(c => c.soluong * c.sanpham.gia);
            _context.Add(hoaDon);
            _context.SaveChanges();

            //thêm chi tiết hóa đơn

            List<giohang> gioHang = _context.giohang.Include(c => c.sanpham).Include(c => c.taikhoans)
                                              .Where(c => c.taikhoans.hoten == user)
                                              .ToList();
            foreach (giohang c in gioHang)
            {
                cthoadon ct = new cthoadon();
                ct.hoadonid = hoaDon.id;
                ct.sanphamid = c.sanphamid;
                ct.soluong = c.soluong;
                ct.gia = c.sanpham.gia;
                _context.Add(ct);
            }
            _context.SaveChanges();
            foreach(giohang c in gioHang)
            {
                c.sanpham.soluong -= c.soluong;
                _context.giohang.Remove(c);
            }
            _context.SaveChanges();
            return View();
        }

        private bool check(string username)
        {
            List<giohang> gioHang = _context.giohang.Include(c => c.sanpham).Include(c => c.taikhoans)
                                             .Where(c => c.taikhoans.hoten == username)
                                             .ToList();
            foreach (giohang c in gioHang)
            {
                if(c.sanpham.soluong<c.soluong)
                {
                    return false;
                }    
            }
            return true;
        }
        private bool giohangExists(int id)
        {
            return _context.giohang.Any(e => e.id == id);
        }
    }
}
