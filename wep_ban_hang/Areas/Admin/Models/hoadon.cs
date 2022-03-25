using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace wep_ban_hang.Areas.Admin.Models
{
    public class hoadon
    {
        [Key]
        public int id { get; set; }
        [Display(Name = "Mã hoá đơn")]
        [Required(ErrorMessage = "Mã hóa đơn không được bỏ trống")]
        public string mahd { get; set; }
        [Display(Name = "Mã khách hàng")]
        [Required(ErrorMessage = "Mã khách hàng không được bỏ trống")]
        public int makh { get; set; }
        [Display(Name = "Ngày tạo")]
        public DateTime ngaylap { get; set; }
        [Display(Name = "Địa chỉ giao hàng")]
        [Required(ErrorMessage = "Địa chỉ không được bỏ trống")]
        public string diachi { get; set; }
        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "Số điện thoại không được bỏ trống")]
        public string sodt { get; set; }
        [Display(Name = "Tổng tiền")]
        [DisplayFormat(DataFormatString = "{0:#,##0} VNĐ")]
        public int thanhtien { get; set; }
        [Display(Name = "Trạng thái")]
        public bool trangthai { get; set; }
        public taikhoan taikhoan { get; set; }

        public List<cthoadon> cthoadons { get; set; }

    }
}
