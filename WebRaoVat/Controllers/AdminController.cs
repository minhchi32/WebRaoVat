using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebRaoVat.Models;

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
        public ActionResult QuanLyNguoiDung()
        {
            return View(database.NguoiDungs.ToList());
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
            return View();
        }

        #endregion

        #region Quản lý chuyên mục

        #endregion

        #region Quản lý danh mục

        #endregion

        #region Quản lý bài đăng

        #endregion


        public ActionResult QuanLyChuyenMuc()
        {
            return View();
        }
        public ActionResult QuanLyDanhMuc()
        {
            return View();
        }
        public ActionResult QuanLyBaiDang()
        {
            return View();
        }
    }
}