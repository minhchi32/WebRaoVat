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
    
    public partial class ThoiGianBaiDangTrangChu
    {
        public int maThoiGianBaiDangTrangChu { get; set; }
        public int maBaiDang { get; set; }
        public System.DateTime thoiGianBatDau { get; set; }
        public System.DateTime thoiGianKetThuc { get; set; }
    
        public virtual BaiDang BaiDang { get; set; }
    }
}
