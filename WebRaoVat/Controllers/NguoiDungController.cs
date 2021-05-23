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
                Session["ten"] = check.ten;
                Session["maQuyen"] = check.maQuyen;
                Session["id"] = check.maNguoiDung;
                ViewBag.ten = check.ten;
                if (check.maQuyen==2)
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
    }
}