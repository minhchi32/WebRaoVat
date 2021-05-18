using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebRaoVat.Models;

namespace WebRaoVat.Controllers
{
    public class TrangChuController : Controller
    {
        DBRaoVatEntities database = new DBRaoVatEntities();
        // GET: TrangChu
        public ActionResult Index()
        {
            ViewBag.DSBaiDang = database.BaiDangs.Where(s => s.maLoaiBaiDang == 1).ToList();
            ViewBag.Hinh = database.Hinhs.ToList();
            ViewBag.ChuyenMuc = database.ChuyenMucs.ToList();
            return View();
        }
    }
}