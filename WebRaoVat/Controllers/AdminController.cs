using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebRaoVat.Models;
using PagedList;
using PagedList.Mvc;

namespace WebRaoVat.Controllers
{
    public class AdminController : Controller
    {
        DBRaoVatEntities database = new DBRaoVatEntities();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        #region Quản lý người dùng
        public ActionResult QuanLyNguoiDung(int? page)
        {
            int pageSize = 25;
            int pageNum = (page ?? 1);
            var dsNguoiDung = database.NguoiDungs.ToList();
            return View(dsNguoiDung.ToPagedList(pageNum, pageSize));
        }

        public ActionResult ThemNguoiDung()
        {
            var dsQuyen = database.Quyens.ToList();
            ViewBag.DsQuyen = new SelectList(dsQuyen, "maQuyen", "tenQuyen");
            return View();
        }
        [HttpPost]
        public ActionResult ThemNguoiDung(NguoiDung nguoiDung)
        {
            try
            {
                var dsQuyen = database.Quyens.ToList();
                ViewBag.DsQuyen = new SelectList(dsQuyen, "maQuyen", "tenQuyen");
                database.NguoiDungs.Add(nguoiDung);
                database.SaveChanges();
                return RedirectToAction("QuanLyNguoiDung");
            }
            catch
            {
                return Content("lỗi thêm mới");
            }
        }
        public ActionResult SuaThongTinNguoiDung(int maNguoiDung)
        {
            var dsQuyen = database.Quyens.ToList();
            ViewBag.DsQuyen = new SelectList(dsQuyen, "maQuyen", "tenQuyen");
            return View(database.NguoiDungs.Where(s => s.maNguoiDung == maNguoiDung).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult SuaThongTinNguoiDung(int maNguoiDung, NguoiDung nguoiDung)
        {
            try
            {
                var dsQuyen = database.Quyens.ToList();
                ViewBag.DsQuyen = new SelectList(dsQuyen, "maQuyen", "tenQuyen");
                database.Entry(nguoiDung).State = System.Data.Entity.EntityState.Modified;
                database.SaveChanges();
                return RedirectToAction("QuanLyNguoiDung");
            }
            catch (Exception e)
            {
                return Content(e.ToString());
            }
        }
        public ActionResult ChiTietThongTinNguoiDung(int maNguoiDung)
        {
            return View(database.NguoiDungs.Where(s => s.maNguoiDung == maNguoiDung).FirstOrDefault());
        }
        #endregion

        #region Quản lý phân quyền
        public ActionResult QuanLyPhanQuyen()
        {
            return View(database.Quyens.ToList());
        }

        public ActionResult ThemPhanQuyen()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemPhanQuyen(Quyen quyen)
        {
            if (ModelState.IsValid)
            {
                database.Quyens.Add(quyen);
                database.SaveChanges();
                return RedirectToAction("QuanLyPhanQuyen");
            }
            else
            {
                return View();
            }
        }
        public ActionResult SuaPhanQuyen(int maQuyen)
        {
            return View(database.Quyens.Where(s => s.maQuyen == maQuyen).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult SuaPhanQuyen(int maQuyen, Quyen quyen)
        {
            if (ModelState.IsValid)
            {
                database.Entry(quyen).State = System.Data.Entity.EntityState.Modified;
                database.SaveChanges();
                return RedirectToAction("QuanLyPhanQuyen");
            }
            else
            {
                return View();
            }
        }
        public ActionResult XoaPhanQuyen(int maQuyen)
        {
            return View(database.Quyens.Where(s => s.maQuyen == maQuyen).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult XoaPhanQuyen(int maQuyen, Quyen quyen)
        {
            try
            {

                quyen = database.Quyens.Where(s => s.maQuyen == maQuyen).FirstOrDefault();
                database.Quyens.Remove(quyen);
                database.SaveChanges();
                return RedirectToAction("QuanLyPhanQuyen");
            }
            catch
            {
                return Content("This data is using in other table, Error Delete!");
            }
        }

        #endregion

        #region Quản lý chuyên mục
        public ActionResult QuanLyChuyenMuc()
        {
            return View(database.ChuyenMucs.ToList());
        }

        public ActionResult ThemChuyenMuc()
        {
            ChuyenMuc chuyemuc = new ChuyenMuc();
            return View(chuyemuc);
        }
        [HttpPost]
        public ActionResult ThemChuyenMuc(ChuyenMuc chuyenMuc)
        {
            if (chuyenMuc.UploadImage != null)
            {
                string filename = Path.GetFileNameWithoutExtension(chuyenMuc.UploadImage.FileName);
                string extent = Path.GetExtension(chuyenMuc.UploadImage.FileName);
                filename = filename + extent;
                chuyenMuc.hinhChuyenMuc = "~/Content/images/" + filename;
                chuyenMuc.UploadImage.SaveAs(Path.Combine(Server.MapPath("~/Images/"), filename));
            }
            if (ModelState.IsValid)
            {
                database.ChuyenMucs.Add(chuyenMuc);
                database.SaveChanges();
                return RedirectToAction("QuanLyChuyenMuc");
            }
            else
            {
                return View();
            }
        }
        public ActionResult SuaChuyenMuc(int maChuyenMuc)
        {
            return View(database.ChuyenMucs.Where(s => s.maChuyenMuc == maChuyenMuc).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult SuaChuyenMuc(int maChuyenMuc, ChuyenMuc chuyenMuc)
        {
            var a = chuyenMuc.UploadImage;
            if (chuyenMuc.UploadImage != null)
            {
                string filename = Path.GetFileNameWithoutExtension(chuyenMuc.UploadImage.FileName);
                string extent = Path.GetExtension(chuyenMuc.UploadImage.FileName);
                filename = filename + extent;
                var path = "~/Content/images/" + filename;
                if (path != "~/Content/images/img_default.png")
                {
                    chuyenMuc.hinhChuyenMuc = path;
                    chuyenMuc.UploadImage.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), filename));
                }
            }
            if (ModelState.IsValid)
            {
                database.Entry(chuyenMuc).State = System.Data.Entity.EntityState.Modified;
                database.SaveChanges();
                return RedirectToAction("QuanLyChuyenMuc");
            }
            else
            {
                return View();
            }
        }
        public ActionResult XoaChuyenMuc(int maChuyenMuc)
        {
            return View(database.ChuyenMucs.Where(s => s.maChuyenMuc == maChuyenMuc).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult XoaChuyenMuc(int maChuyenMuc, ChuyenMuc chuyenMuc)
        {
            try
            {

                chuyenMuc = database.ChuyenMucs.Where(s => s.maChuyenMuc == maChuyenMuc).FirstOrDefault();
                database.ChuyenMucs.Remove(chuyenMuc);
                database.SaveChanges();
                return RedirectToAction("QuanLyChuyenMuc");
            }
            catch
            {
                return Content("This data is using in other table, Error Delete!");
            }
        }
        #endregion

        #region Quản lý danh mục
        public ActionResult QuanLyDanhMuc()
        {
            return View(database.DanhMucs.ToList());
        }
        public ActionResult ThemDanhMuc()
        {
            var dsChuyenMuc = database.ChuyenMucs.ToList();
            ViewBag.DsChuyenMuc = new SelectList(dsChuyenMuc, "maChuyenMuc", "tenChuyenMuc");
            return View();
        }
        [HttpPost]
        public ActionResult ThemDanhMuc(DanhMuc danhMuc)
        {
            danhMuc.soLuongBai = 0;
            var dsChuyenMuc = database.ChuyenMucs.ToList();
            ViewBag.DsChuyenMuc = new SelectList(dsChuyenMuc, "maChuyenMuc", "tenChuyenMuc");
            if (ModelState.IsValid)
            {
                database.DanhMucs.Add(danhMuc);
                database.SaveChanges();
                return RedirectToAction("QuanLyDanhMuc");
            }
            else
            {
                return View();
            }
        }
        public ActionResult SuaDanhMuc(int maDanhMuc)
        {
            var dsChuyenMuc = database.ChuyenMucs.ToList();
            ViewBag.DsChuyenMuc = new SelectList(dsChuyenMuc, "maChuyenMuc", "tenChuyenMuc");
            return View(database.DanhMucs.Where(s => s.maDanhMuc == maDanhMuc).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult SuaDanhMuc(int maDanhMuc, DanhMuc danhMuc)
        {
            var dsChuyenMuc = database.ChuyenMucs.ToList();
            ViewBag.DsChuyenMuc = new SelectList(dsChuyenMuc, "maChuyenMuc", "tenChuyenMuc");
            if (ModelState.IsValid)
            {
                database.Entry(danhMuc).State = System.Data.Entity.EntityState.Modified;
                database.SaveChanges();
                return RedirectToAction("QuanLyDanhMuc");
            }
            else
            {
                return View();
            }
        }
        public ActionResult XoaDanhMuc(int maDanhMuc)
        {
            return View(database.DanhMucs.Where(s => s.maDanhMuc == maDanhMuc).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult XoaDanhMuc(int maDanhMuc, DanhMuc danhMuc)
        {
            try
            {

                danhMuc = database.DanhMucs.Where(s => s.maDanhMuc == maDanhMuc).FirstOrDefault();
                database.DanhMucs.Remove(danhMuc);
                database.SaveChanges();
                return RedirectToAction("QuanLyDanhMuc");
            }
            catch
            {
                return Content("This data is using in other table, Error Delete!");
            }
        }
        #endregion

        #region Quản lý bài đăng
        public ActionResult QuanLyBaiDang(int? page, int maTrangThai = 1)
        {
            int pageSize = 12;
            int pageNum = (page ?? 1);
            switch (maTrangThai)
            {
                case 1:
                    ViewBag.TrangThaiBD = "Bài đăng chờ duyệt";
                    break;
                case 2:
                    ViewBag.TrangThaiBD = "Bài đăng đã duyệt";
                    break;
                case 3:
                    ViewBag.TrangThaiBD = "Bài đăng không duyệt";
                    break;
            }
            ViewBag.Hinh = database.Hinhs.ToList();
            var dsBaiDang = database.BaiDangs.Where(s => s.maTinhTrangBaiDang == maTrangThai).ToList();
            return View(dsBaiDang.ToPagedList(pageNum, pageSize));
        }

        public ActionResult ThayDoiTrangThaiBaiDang(int maBaiDang)
        {
            var dsTTBD = database.TinhTrangBaiDangs.ToList();
            ViewBag.DSTTBD = new SelectList(dsTTBD, "maTinhTrangBaiDang", "tenTinhTrangBaiDang");
            var a = database.BaiDangs.Where(s => s.maBaiDang == maBaiDang).FirstOrDefault();
            return View(a);
        }
        [HttpPost]
        public ActionResult ThayDoiTrangThaiBaiDang(int maBaiDang, BaiDang baiDang)
        {
            var dsTTBD = database.TinhTrangBaiDangs.ToList();
            ViewBag.DSTTBD = new SelectList(dsTTBD, "maTinhTrangBaiDang", "tenTinhTrangBaiDang");
            if (ModelState.IsValid)
            {
                database.Entry(baiDang).State = System.Data.Entity.EntityState.Modified;
                database.SaveChanges();
                return RedirectToAction("QuanLyBaiDang");
            }
            else
            {
                return View();
            }
        }
        public ActionResult ChiTietBaiDang(int maBaiDang)
        {
            var dsTTBD = database.TinhTrangBaiDangs.ToList();
            ViewBag.DSTTBD = new SelectList(dsTTBD, "maTinhTrangBaiDang", "tenTinhTrangBaiDang");
            ViewBag.Hinh = database.Hinhs.Where(s => s.maBaiDang == maBaiDang).ToList();
            ViewBag.count = ViewBag.Hinh.Count;
            return View(database.BaiDangs.Where(s => s.maBaiDang == maBaiDang).FirstOrDefault());
        }
        #endregion





    }
}