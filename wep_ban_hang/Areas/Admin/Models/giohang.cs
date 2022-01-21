using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace wep_ban_hang.Areas.Admin.Models
{
    public class giohang
    {
        [Key]
        public int id { get; set; }
        [Display(Name = "Mã khách hàng")]
        public int taikhoanid { get; set; }
        [Display(Name = "Mã sản phẩm")]
        public int sanphamid { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập số lượng")]
        [Display(Name = "Số lượng")]
        public int soluong { get; set; }
        [Display(Name = "Trạng thái")]
        public bool trangthai { get; set; }
        public sanpham sanpham { get; set; }
        public taikhoan taikhoans { get; set; }
    }
}
