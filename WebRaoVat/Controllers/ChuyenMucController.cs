using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebRaoVat.Models;

namespace WebRaoVat.Controllers
{
    public class ChuyenMucController : Controller
    {
        DBRaoVatEntities database = new DBRaoVatEntities();
        // GET: ChuyenMuc
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DSBaiDang(int maDanhMuc,int maChuyenMuc)
        {
            ViewBag.ChuyenMuc = database.ChuyenMucs.ToList();
            var dsTin = database.BaiDangs.Where(s => s.maDanhMuc == maDanhMuc).ToList();
            ViewBag.Hinh = database.Hinhs.ToList();
            ViewBag.BaiDang = database.BaiDangs.Where(s => s.maDanhMuc == maDanhMuc).FirstOrDefault();
            return View(dsTin);
        }
        public ActionResult DSDanhMuc(int maChuyenMuc)
        {
            ViewBag.ChuyenMuc = database.ChuyenMucs.ToList();
            var dsDanhMuc = database.DanhMucs.Where(s => s.maChuyenMuc == maChuyenMuc).ToList();

            return View(dsDanhMuc);
        }
        public PartialViewResult NavDanhMuc(int maChuyenMuc)
        {
            var dsDanhMuc = database.DanhMucs.Where(s=>s.maChuyenMuc==maChuyenMuc).ToList();
            return PartialView(dsDanhMuc);
        }
        public PartialViewResult NavChuyenMuc()
        {
            var dschuyenmuc = database.ChuyenMucs.ToList();
            return PartialView(dschuyenmuc);
        }
    }
}