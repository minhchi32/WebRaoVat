using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebRaoVat.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult QuanLyNguoiDung()
        {
            return View();
        }
        public ActionResult QuanLyPhanQuyen()
        {
            return View();
        }
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