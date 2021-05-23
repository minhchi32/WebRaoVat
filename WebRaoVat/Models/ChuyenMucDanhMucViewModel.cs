using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebRaoVat.Models
{
    public class ChuyenMucDanhMucViewModel
    {
        public ChuyenMucDanhMucViewModel()
        {
            path = "~/Content/images/img_default.JPG";
        }
        public int maDanhMuc { get; set; }
        public int maChuyenMuc { get; set; }
        public int maBaiDang { get; set; }

        [Display(Name = "Tiêu đề")]
        [Required(ErrorMessage = "Tiêu đề không được bỏ trống")]
        [StringLength(100, MinimumLength = 5)]
        public string tieuDe { get; set; }


        [Display(Name = "Mô tả")]
        [Required(ErrorMessage = "Mô tả không được bỏ trống")]
        [StringLength(1000, MinimumLength = 5)]
        public string moTa { get; set; }


        [Display(Name = "Giá")]
        [Required(ErrorMessage = "Giá không được bỏ trống")]
        [Range(2000, 999999999000)]
        public double gia { get; set; }


        [Display(Name = "Ngày đăng")]
        public System.DateTime ngayDang { get; set; }


        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Địa chỉ không được bỏ trống")]
        [StringLength(150, MinimumLength = 10)]
        public string diaChi { get; set; }
        public int maTinhTrangSanPham { get; set; }
        public int maTinhTrangBaiDang { get; set; }
        public int maNguoiDung { get; set; }
        public int maVung { get; set; }
        public int maLoaiBaiDang { get; set; }

        public virtual DanhMuc DanhMuc { get; set; }
        public virtual LoaiBaiDang LoaiBaiDang { get; set; }
        public virtual NguoiDung NguoiDung { get; set; }
        public virtual TinhTrangSanPham TinhTrangSanPham { get; set; }
        public virtual TinhTrangBaiDang TinhTrangBaiDang { get; set; }




        public int maHinh { get; set; }
        public string path { get; set; }

        //[NotMapped]
        //public HttpPostedFile File1 { get; set; }
        [NotMapped]
        public List<HttpPostedFile> File1 { get; set; }
    }
}