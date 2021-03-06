//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebRaoVat.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class NguoiDung
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NguoiDung()
        {
            this.BaiDangs = new HashSet<BaiDang>();
            this.BaiLuus = new HashSet<BaiLuu>();
            this.DanhGias = new HashSet<DanhGia>();
            this.DanhGias1 = new HashSet<DanhGia>();
        }
    
        public int maNguoiDung { get; set; }
        public int maQuyen { get; set; }
        [Display(Name = "Tên người dùng")]
        [Required(ErrorMessage = "Tên người dùng không được bỏ trống")]
        [StringLength(100, MinimumLength = 5)]
        public string ten { get; set; }
        [Display(Name = "Nhập tài khoản")]
        [Required(ErrorMessage = "Tài khoản không được bỏ trống")]
        public string username { get; set; }
        [Display(Name = "Nhập mật khẩu")]
        [Required(ErrorMessage = "Mật khẩu không được bỏ trống")]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [NotMapped]
        [Compare("Password")]
        [Display(Name = "Nhập lại mật khẩu")]
        [Required(ErrorMessage = "Mật khẩu không trùng khớp")]
        [DataType(DataType.Password)]
        public string ConfirmPass { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email không được bỏ trống")]
        [StringLength(100, MinimumLength = 10)]
        public string email { get; set; }
        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "Số điện thoại không được bỏ trống")]
        [StringLength(15, MinimumLength = 9)]
        public string SDT { get; set; }
        public int xu { get; set; }
        public Nullable<double> slRate { get; set; }
        public Nullable<double> tongRate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaiDang> BaiDangs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaiLuu> BaiLuus { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DanhGia> DanhGias { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DanhGia> DanhGias1 { get; set; }
        public virtual Quyen Quyen { get; set; }
    }
}
