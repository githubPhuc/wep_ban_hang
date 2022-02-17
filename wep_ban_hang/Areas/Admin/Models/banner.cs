using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace wep_ban_hang.Areas.Admin.Models
{
    public class banner
    {
        [Key]
        public int id { get; set; }
        [Display(Name = "Tên Quảng Cáo")]
        [Required(ErrorMessage = "Tên Quảng Cáo không được bỏ trống"), MinLength(2, ErrorMessage = "Tên Quảng Cáo phải có tối thiểu 2 ký tự"), MaxLength(250, ErrorMessage = "Tên Quảng Cáo có tối đa 250 ký tự")]
        public string tenquangcao { get; set; }
        [Display(Name = "Ảnh sản phẩm")]
        [RegularExpression(@"^[a-zA-Z0-9_]+\.(jpg|JPG|png|PNG)$", ErrorMessage = "Không đúng định dạng .jpg hoặc .png")]
        public string hinhanh { get; set; }
        [Display(Name = "Mô Tả")]
        [Required(ErrorMessage = "Mô tả không được bỏ trống")]
        public string mota { get; set; }
        [Display(Name = "Trạng thái")]
        public bool trangthai { get; set; }
    }
}
