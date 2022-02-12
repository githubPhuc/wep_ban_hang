using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace wep_ban_hang.Areas.Admin.Models
{
    public class ctsanpham
    {
        [Key]
        public int id { get; set; }
        [Display(Name = "Tên loại sản phẩm")]
        [Required(ErrorMessage = "Tên loại sản phẩm không được bỏ trống"), MinLength(2, ErrorMessage = "Tên loại sản phẩm phải có tối thiểu 2 ký tự"), MaxLength(250, ErrorMessage = "Tên loại sản phẩm có tối đa 250 ký tự")]
        public string tenloaisanpham { get; set; }
        [Display(Name = "Trạng thái")]
        public bool trangthai { get; set; }
        public List<sanpham> sanphams { get; set; }
    }
}
