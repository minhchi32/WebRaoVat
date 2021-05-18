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
    
    public partial class BaiDang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BaiDang()
        {
            this.BaiLuus = new HashSet<BaiLuu>();
            this.Hinhs = new HashSet<Hinh>();
            this.ThoiGianBaiDangTrangChus = new HashSet<ThoiGianBaiDangTrangChu>();
        }
    
        public int maBaiDang { get; set; }
        public int maNguoiDung { get; set; }
        public int maDanhMuc { get; set; }
        public int maTinhTrangSanPham { get; set; }
        public int maTinhTrangBaiDang { get; set; }
        public int maLoaiBaiDang { get; set; }
        public Nullable<int> maGiaoDich { get; set; }
        public int maVung { get; set; }
        public string tieuDe { get; set; }
        public string moTa { get; set; }
        public double gia { get; set; }
        public System.DateTime ngayDang { get; set; }
        public string diaChi { get; set; }
        public string ghiChu { get; set; }
        public Nullable<int> luotXem { get; set; }
    
        public virtual DanhMuc DanhMuc { get; set; }
        public virtual GiaoDich GiaoDich { get; set; }
        public virtual LoaiBaiDang LoaiBaiDang { get; set; }
        public virtual NguoiDung NguoiDung { get; set; }
        public virtual TinhTrangSanPham TinhTrangSanPham { get; set; }
        public virtual TinhTrangBaiDang TinhTrangBaiDang { get; set; }
        public virtual Vung Vung { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaiLuu> BaiLuus { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hinh> Hinhs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThoiGianBaiDangTrangChu> ThoiGianBaiDangTrangChus { get; set; }
    }
}