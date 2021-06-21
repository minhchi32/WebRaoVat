using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebRaoVat.Models;

namespace WebRaoVat.Controllers
{
    public class DangTinController : Controller
    {
        DBRaoVatEntities database = new DBRaoVatEntities();
        // GET: DangTin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CTBaiDang(int maBaiDang,int maChuyenMuc)
        {
            ViewBag.ChuyenMuc = database.ChuyenMucs.ToList();
            var ctBaiDang = database.BaiDangs.Where(s => s.maBaiDang == maBaiDang).FirstOrDefault();
            ViewBag.Hinh = database.Hinhs.ToList();
            ctBaiDang.luotXem += 1;
            database.Entry(ctBaiDang).State = EntityState.Modified;
            database.SaveChanges();
            //ViewBag.BaiDang = database.BaiDangs.Where(s => s.maDanhMuc == maDanhMuc).FirstOrDefault();
            return View(ctBaiDang);
        }



        public ActionResult DangBaiDang(int manguoidung)
        {
            var dsTTSP = database.TinhTrangSanPhams.ToList();
            ViewBag.DSTTSP = new SelectList(dsTTSP, "maTinhTrangSanPham", "tenTinhTrangSanPham");
            ViewBag.DSChuyenMuc = new SelectList(GetChuyenMuc(), "maChuyenMuc", "tenChuyenMuc");

            var vung = database.Vungs.ToList();
            ViewBag.Vung = new SelectList(vung, "maVung", "tenVung");

            ViewBag.MaNguoiDung = manguoidung;

            ChuyenMucDanhMucViewModel CMDM = new ChuyenMucDanhMucViewModel();

            return View(CMDM);
        }

        public List<ChuyenMuc> GetChuyenMuc()
        {
            List<ChuyenMuc> chuyenmuc = database.ChuyenMucs.ToList();
            return chuyenmuc;
        }
        public ActionResult GetDanhMuc(int maChuyenMuc)
        {
            List<DanhMuc> dsdanhmuc = database.DanhMucs.Where(x => x.maChuyenMuc == maChuyenMuc).ToList();
            ViewBag.DSDanhMuc = new SelectList(dsdanhmuc, "maDanhMuc", "tenDanhMuc");
            return PartialView("DanhMucOptionPartial");
        }



        [HttpPost]
        public ActionResult DangBaiDang(ChuyenMucDanhMucViewModel model)
        {
            var dsTTSP = database.TinhTrangSanPhams.ToList();
            ViewBag.DSTTSP = new SelectList(dsTTSP, "maTinhTrangSanPham", "tenTinhTrangSanPham");
            ViewBag.DSChuyenMuc = new SelectList(GetChuyenMuc(), "maChuyenMuc", "tenChuyenMuc");

            var vung = database.Vungs.ToList();
            ViewBag.Vung = new SelectList(vung, "maVung", "tenVung");


            try
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    HttpPostedFileBase file = Request.Files[i];
                    if (file.ContentLength > 0)
                    {
                        string filename = Path.GetFileNameWithoutExtension(file.FileName);
                        string extent = Path.GetExtension(file.FileName);
                        filename = filename + extent;
                        model.path = "~/Content/images/" + filename;
                        file.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), filename));
                        Hinh hinhs = new Hinh();
                        hinhs.path = model.path;
                        hinhs.maBaiDang = model.maBaiDang;
                        database.Hinhs.Add(hinhs);
                    }
                }


                BaiDang baid = new BaiDang();
                baid.tieuDe = model.tieuDe;
                baid.moTa = model.moTa;
                baid.gia = model.gia;
                baid.ngayDang = DateTime.Now;
                baid.maTinhTrangBaiDang = 1;
                baid.maLoaiBaiDang = 1;
                baid.diaChi = model.diaChi;
                baid.maTinhTrangSanPham = model.maTinhTrangSanPham;
                baid.maDanhMuc = model.maDanhMuc;
                baid.maVung = model.maVung;
                baid.maNguoiDung = model.maNguoiDung;
                baid.maGiaoDich = 1;
                baid.luotXem = 0;
                database.BaiDangs.Add(baid);
                database.SaveChanges();

                return RedirectToAction("Index", "TrangChu");
            }
            catch
            {
                return View("DangBaiDang", model);
            }


        }

        public ActionResult ToiBan(int id)
        {
            var baidang = database.BaiDangs.Where(s => s.maNguoiDung == id).ToList();
            ViewBag.Hinh = database.Hinhs.ToList();
            ViewBag.BaiDang = baidang;
            return View(baidang);
        }
        public ActionResult CTToiBan(int maBaiDang)
        {
            var ctBaiDang = database.BaiDangs.Where(s => s.maBaiDang == maBaiDang).FirstOrDefault();
            ViewBag.Hinh = database.Hinhs.ToList();
            return View(ctBaiDang);
        }

        public ActionResult SuaBaiDang(int maBaiDang)
        {
            //ViewBag.Hinh = database.Hinhs.ToList();
            var baidang = database.BaiDangs.Where(s => s.maBaiDang == maBaiDang).FirstOrDefault();
            var dsTTSP = database.TinhTrangSanPhams.ToList();
            ViewBag.DSTTSP = new SelectList(dsTTSP, "maTinhTrangSanPham", "tenTinhTrangSanPham");
            ViewBag.DSChuyenMuc = new SelectList(GetChuyenMuc(), "maChuyenMuc", "tenChuyenMuc");

            var vung = database.Vungs.ToList();
            ViewBag.Vung = new SelectList(vung, "maVung", "tenVung");

            var hinh = database.Hinhs.ToList();
            List<Hinh> listhinh = new List<Hinh>();
            foreach (var item in hinh)
            {
                if (item.maBaiDang == baidang.maBaiDang)
                {
                    listhinh.Add(item);
                }
            }
            ViewBag.Hinh = listhinh;

            ChuyenMucDanhMucViewModel CMDM = new ChuyenMucDanhMucViewModel();
            CMDM.tieuDe = baidang.tieuDe;
            CMDM.moTa = baidang.moTa;
            CMDM.gia = baidang.gia;
            CMDM.diaChi = baidang.diaChi;
            CMDM.maTinhTrangSanPham = baidang.maTinhTrangSanPham;
            CMDM.maVung = baidang.maVung;
            CMDM.maBaiDang = baidang.maBaiDang;
            CMDM.maNguoiDung = baidang.maNguoiDung;
            ViewBag.BaiDang = baidang;
            return View(CMDM);
        }
        [HttpPost]
        public ActionResult SuaBaiDang(ChuyenMucDanhMucViewModel model)
        {
            var dsTTSP = database.TinhTrangSanPhams.ToList();
            ViewBag.DSTTSP = new SelectList(dsTTSP, "maTinhTrangSanPham", "tenTinhTrangSanPham");
            ViewBag.DSChuyenMuc = new SelectList(GetChuyenMuc(), "maChuyenMuc", "tenChuyenMuc");

            var vung = database.Vungs.ToList();
            ViewBag.Vung = new SelectList(vung, "maVung", "tenVung");

            try
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    HttpPostedFileBase file = Request.Files[i];
                    if (file.ContentLength > 0)
                    {
                        string filename = Path.GetFileNameWithoutExtension(file.FileName);
                        string extent = Path.GetExtension(file.FileName);
                        filename = filename + extent;
                        model.path = "~/Content/images/" + filename;
                        file.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), filename));
                        Hinh hinhs = new Hinh();
                        hinhs.path = model.path;
                        hinhs.maBaiDang = model.maBaiDang;
                        database.Hinhs.Add(hinhs);
                    }
                }

                var baid = database.BaiDangs.Where(s => s.maBaiDang == model.maBaiDang).FirstOrDefault();
                baid.tieuDe = model.tieuDe;
                baid.moTa = model.moTa;
                baid.gia = model.gia;
                baid.diaChi = model.diaChi;
                baid.maTinhTrangSanPham = model.maTinhTrangSanPham;
                baid.maDanhMuc = model.maDanhMuc;
                baid.maVung = model.maVung;
                baid.maNguoiDung = model.maNguoiDung;
                database.Entry(baid).State = EntityState.Modified;
                database.SaveChanges();

                return RedirectToAction("ToiBan", "DangTin",new { id=model.maNguoiDung});
            }
            catch
            {
                return View("SuaBaiDang", model);
            }
        }
        public ActionResult XoaHinh(int maHinh, int maBaiDang)
        {
            var Hinh = database.Hinhs.Where(s => s.maHinh == maHinh).FirstOrDefault();        
            database.Hinhs.Remove(Hinh);
            database.SaveChanges();
            return RedirectToAction("SuaBaiDang", "DangTin", new { maBaiDang = maBaiDang });
        }
    }
}