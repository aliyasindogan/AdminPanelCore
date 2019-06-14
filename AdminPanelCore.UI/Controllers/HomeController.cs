using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminPanelCore.UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: anasayfa
        public ActionResult Index()
        {
            return View();
        }
        // GET: iletişim
        public ActionResult Contact()
        {
            return View();
        }

        // GET: hakkımızda
        public ActionResult About()
        {
            return View();
        }

        public ActionResult Products()
        {
            return View();
        }
    }
}