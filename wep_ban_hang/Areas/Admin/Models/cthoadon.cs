using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace wep_ban_hang.Areas.Admin.Models
{
    public class cthoadon
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Mã hoá đơn")]
        public int hoadonid { get; set; }
        [Display(Name = "Mã sản phẩm")]
        public int sanphamid { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập số lượng")]
        [Display(Name = "Số lượng")]
        public int soluong { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập giá")]
        [Display(Name = "Đơn giá")]
        public int gia { get; set; }
        public hoadon hoadons { get; set; }
        public sanpham sanphams { get; set; }
    }
}
