using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebRaoVat.Models;

namespace WebRaoVat.Controllers
{
    public class NguoiDungController : Controller
    {
        // GET: NguoiDung
        DBRaoVatEntities database = new DBRaoVatEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(NguoiDung _user)
        {
            var check = database.NguoiDungs.Where(s => s.username == _user.username && s.password == _user.password).FirstOrDefault();
            if (check == null)
            {
                ViewBag.ErrorInfo = "Sai Info";
                return View("Index");
            }
            else
            {
                database.Configuration.ValidateOnSaveEnabled = false;
                Session["NguoiDung"] = check.ten;
                Session["ten"] = check.ten;
                Session["maQuyen"] = check.maQuyen;
                Session["id"] = check.maNguoiDung;
                ViewBag.ten = check.ten;
                if (check.maQuyen == 2)
                {
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    return RedirectToAction("Index", "TrangChu");
                }
            }
        }
        public ActionResult LogOutUser()
        {
            Session.Abandon();
            return RedirectToAction("Index", "TrangChu");
        }

        public ActionResult XemThongTinCaNhan(int id)
        {
            return View(database.NguoiDungs.Where(s => s.maNguoiDung == id).FirstOrDefault());
        }

        public ActionResult RegisterUser()
        {
            NguoiDung nguoidung = new NguoiDung();
            return View(nguoidung);
        }

        [HttpPost]
        public ActionResult RegisterUser(NguoiDung _user)
        {
            var check_ID = database.NguoiDungs.Where(s => s.username == _user.username).FirstOrDefault();
            if (ModelState.IsValid)
            {
                if (check_ID == null)
                {
                    database.Configuration.ValidateOnSaveEnabled = false;
                    _user.maQuyen = 1;
                    database.NguoiDungs.Add(_user);
                    database.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.ErrorRegister = "This ID is exixst";
                    return View();
                }
            }
            return View();
        }
        public ActionResult QuanLyBaiDang(int? page, int id, int maTrangThai)
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
                case 4:
                    ViewBag.TrangThaiBD = "Bài đăng đã ẩn";
                    break;
            }
            ViewBag.Hinh = database.Hinhs.ToList();
            var dsBaiDang = database.BaiDangs.Where(s => s.maNguoiDung == id && s.maTinhTrangBaiDang == maTrangThai).ToList();
            return View(dsBaiDang.ToPagedList(pageNum, pageSize));
        }
    }
}