using AdminPanelCore.BLL.Abstarct;
using AdminPanelCore.CORE.CrossCuttingConcers.Security.Web;
using AdminPanelCore.ENTITIES.Concrete;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace AdminPanelCore.UI.Areas.AdminPanel.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            User _user = _userService.GetByUserNameAndPassword(user.UserName, user.Password);
            if (_user != null)
            {
                AuthenticationHelper.CreateAuthCookie(
                Guid.NewGuid(), _user.UserName,
                _user.Email,
                DateTime.Now.AddDays(30),
                _userService.GetUserRoles(_user).Select(u => u.RoleName).ToArray(),
                false,
                _user.Name,
                _user.SurName);
                return RedirectToAction("Index", "Dashboard");
            }
            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

    }
}