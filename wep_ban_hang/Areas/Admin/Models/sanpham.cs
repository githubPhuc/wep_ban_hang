using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace wep_ban_hang.Areas.Admin.Models
{
    public class sanpham
    {
        [Key]
        public int id { get; set; }
        [Display(Name = "Tên sản phẩm")]
        [Required(ErrorMessage = "Tên sản phẩm không được bỏ trống"), MinLength(2, ErrorMessage = "Tên sản phẩm phải có tối thiểu 2 ký tự"), MaxLength(250, ErrorMessage = "Tên sản phẩm có tối đa 250 ký tự")]
        public string tensanpham { get; set; }
        [Display(Name = "Giá tiền")]
        [DisplayFormat(DataFormatString = "{0:#,##0} VNĐ")]
        [Required(ErrorMessage = "Giá không được bỏ trống")]
        public int gia { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập đánh giá")]
        public string danhgia { get; set; }
        [Display(Name = "Ảnh sản phẩm")]
        [RegularExpression(@"^[a-zA-Z0-9_]+\.(jpg|JPG|png|PNG)$", ErrorMessage = "Không đúng định dạng .jpg hoặc .png")]
        public string hinhanh { get; set; }
        [Display(Name = "Loại sản phẩm")]
        [Required(ErrorMessage = "Mã loại sản phẩm không được bỏ trống")]
        public string lspham { get; set; }
        public ctsanpham ctsanphams { get; set; }
        [Display(Name = "Nhà sản xuất")]
        [Required(ErrorMessage = "Nhà sản xuất không được bỏ trống")]
        public string nsxuat { get; set; }
        public nhasanxuat nhasanxuat { get; set; }
        [Display(Name = "Trạng thái")]
        public bool trangthai { get; set; }
        public List<giohang> giohangs { get; set; }
        public List<cthoadon> cthoadons { get; set; }
    }
}
