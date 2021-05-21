using System;
using System.Collections.Generic;
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
            //ViewBag.BaiDang = database.BaiDangs.Where(s => s.maDanhMuc == maDanhMuc).FirstOrDefault();
            return View(ctBaiDang);
        }
    }
}