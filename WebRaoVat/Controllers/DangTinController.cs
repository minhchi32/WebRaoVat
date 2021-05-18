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
        
    }
}