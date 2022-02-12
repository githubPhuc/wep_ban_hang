using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace wep_ban_hang.Areas.Admin.Models
{
    public class taikhoan
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập họ tên")]
        [Display(Name = "Họ tên")]
        public string hoten { get; set; }
        [StringLength(50)]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email không được bỏ trống")]
        [EmailAddress(ErrorMessage = "Nhập sai email")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email không đúng định dạng")]
        public string email { get; set; }
        [StringLength(250)]
        [Display(Name = "Tên tài khoản")]
        [Required(ErrorMessage = "Tên tài khoản không được bỏ trống"), MinLength(2, ErrorMessage = "Tên tài khoản phải có tối thiểu 2 ký tự"), MaxLength(250, ErrorMessage = "Tên tài khoản có tối đa 250 ký tự")]
        public string tendangnhap { get; set; }
        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Mật khẩu không được bỏ trống")]
        public string matkhau { get; set; }
        [Display(Name = "Ảnh đại diện")]
        [RegularExpression(@"^[a-zA-Z0-9_]+\.(jpg|JPG|png|PNG)$", ErrorMessage = "Không đúng định dạng .jpg hoặc .png")]
        public string hinhanh { get; set; }
        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Địa chỉ không được bỏ trống")]
        public string diachi { get; set; }
        [Display(Name = "Admin")]
        public bool isadmin { get; set; }
        [Display(Name = "Trạng thái")]
        public bool trangthai { get; set; }
    }
}
