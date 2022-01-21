using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace wep_ban_hang.Areas.Admin.Models
{
    public class nhasanxuat
    {
        [Key]
        public int id { get; set; }
        [Display(Name = "Tên sản phẩm")]
        [Required(ErrorMessage = "Tên sản phẩm không được bỏ trống"), MinLength(2, ErrorMessage = "Tên sản phẩm phải có tối thiểu 2 ký tự"), MaxLength(250, ErrorMessage = "Tên sản phẩm có tối đa 250 ký tự")]
        public string tennsx { get; set; }
        [Display(Name = "Ảnh đại diện")]
        [RegularExpression(@"^[a-zA-Z0-9_]+\.(jpg|JPG|png|PNG)$", ErrorMessage = "Không đúng định dạng .jpg hoặc .png")]
        public string hinhanh { get; set; }
        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Địa chỉ không được bỏ trống")]
        public string diachi { get; set; }
        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "Số điện thoại không được bỏ trống")]
        public int sdt { get; set; }
        [Display(Name = "Trạng thái")]
        public bool trangthai { get; set; }
    }
}
