using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using wep_ban_hang.Areas.Admin.Models;

namespace wep_ban_hang.Data
{
    public class wep_ban_hangContext : DbContext
    {
        public wep_ban_hangContext (DbContextOptions<wep_ban_hangContext> options)
            : base(options)
        {
        }

        public DbSet<wep_ban_hang.Areas.Admin.Models.giohang> giohang { get; set; }

        public DbSet<wep_ban_hang.Areas.Admin.Models.hoadon> hoadon { get; set; }

        public DbSet<wep_ban_hang.Areas.Admin.Models.sanpham> sanpham { get; set; }

        public DbSet<wep_ban_hang.Areas.Admin.Models.nhasanxuat> nhasanxuat { get; set; }

        public DbSet<wep_ban_hang.Areas.Admin.Models.ctsanpham> ctsanpham { get; set; }

        public DbSet<wep_ban_hang.Areas.Admin.Models.cthoadon> cthoadon { get; set; }

        public DbSet<wep_ban_hang.Areas.Admin.Models.taikhoan> taikhoan { get; set; }
    }
}
