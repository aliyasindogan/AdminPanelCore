using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminPanelCore.UI.Areas.AdminPanel.Controllers
{
    public class DashboardController : Controller
    {
        string loginControl = System.Web.HttpContext.Current.User.Identity.Name.ToString();

        // GET: AdminPanel/Home
        public ActionResult Index()
        {
            if (String.IsNullOrEmpty(loginControl))
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                return View();
            }
        }
    }
}