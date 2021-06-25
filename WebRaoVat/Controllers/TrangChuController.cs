using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebRaoVat.Models;
using PagedList;
using PagedList.Mvc;

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

        public ActionResult TimKiem(string ten, int? page)
        {
            int pageSize = 12;
            int pageNum = (page ?? 1);
            var result = database.BaiDangs.Where(s => s.maLoaiBaiDang == 1).ToList();
            ViewBag.DSBaiDang = result;
            ViewBag.Hinh = database.Hinhs.ToList();
            ViewBag.ChuyenMuc = database.ChuyenMucs.ToList();
            if (ten != null)
            {
                ViewBag.ten = ten;
                result = result.Where(s => s.tieuDe.Contains(ten)|| s.moTa.Contains(ten)).ToList();
            }
            else
            {
                ViewBag.ten = null;
            }
            return View(result.ToPagedList(pageNum, pageSize));
        }
    }
}