using AdminPanelCore.BLL.Abstarct;
using AdminPanelCore.ENTITIES.Abstarct.Enums;
using AdminPanelCore.ENTITIES.ComplexTypes;
using AdminPanelCore.ENTITIES.Concrete;
using AdWebTemplate.Business.Abstarct;
using System;
using System.Net;
using System.Web.Mvc;

namespace AdminPanelCore.UI.Areas.AdminPanel.Controllers
{
    public class UserController : Controller
    {
        private IUserService _userService;
        private IRoleService _roleService;
        private IUserRoleService _userRoleService;
        private string loginControl = System.Web.HttpContext.Current.User.Identity.Name.ToString();

        public UserController(
            IUserService userService,
            IRoleService roleService,
            IUserRoleService userRoleService)
        {
            _userService = userService;
            _roleService = roleService;
            _userRoleService = userRoleService;
        }

        // GET: AdminPanel/User
        public ActionResult Index()
        {
            if (String.IsNullOrEmpty(loginControl))
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                int RolID = _userService.Get(x => x.UserName == System.Web.HttpContext.Current.User.Identity.Name.ToString()).RoleID;
                return View(_userService.GetUserDetails(RolID));
            }
        }

        // GET: AdminPanel/User/Create
        public ActionResult Create()
        {
            if (String.IsNullOrEmpty(loginControl))
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                roleGetAll();
                return View();
            }
        }

        // POST: AdminPanel/User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserName,Name,SurName,Email,Password,RoleID,DisplayOrder,IsDisplay,CreatedUserID,CreatedDate,ModifiedUserID,ModifiedDate")] User user)
        {
            if (String.IsNullOrEmpty(loginControl))
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                roleGetAll();
                if (ModelState.IsValid)
                {
                    if (_userService.Any(x => x.UserName == user.UserName.Trim()) == false)
                    {
                        #region User Add

                        user.UserName = user.UserName.Trim(); //Boşluklar alınıyor
                        int MaxDisplayOrder = _userService.Max(x => x.IsDisplay == true, p => p.DisplayOrder) ?? 0;
                        user.DisplayOrder = ++MaxDisplayOrder;
                        user.CreatedDate = DateTime.Now;
                        user.CreatedUserID = _userService.Get(x => x.UserName == System.Web.HttpContext.Current.User.Identity.Name.ToString()).Id;
                        user.IsDisplay = true;
                        _userService.Add(user);

                        #endregion User Add

                        #region User Rol Add

                        UserRole userRole = new UserRole();
                        userRole.UserID = user.Id;
                        userRole.RoleID = user.RoleID;
                        userRole.CreatedDate = DateTime.Now;
                        userRole.CreatedUserID = user.CreatedUserID;
                        _userRoleService.Add(userRole);

                        #endregion User Rol Add

                        return RedirectToAction("Index", "User");
                    }
                    else
                    {
                        return View();
                    }
                }
                return View(user);
            }
        }

        // GET: AdminPanel/User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (String.IsNullOrEmpty(loginControl))
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                roleGetAll();
                User user = _userService.Get(x => x.Id == id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                return View(user);
            }
        }

        // POST: AdminPanel/User/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            if (String.IsNullOrEmpty(loginControl))
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    #region User Update

                    roleGetAll();
                    User _user = _userService.Get(x => x.Id == user.Id);
                    _user.UserName = user.UserName.Trim();
                    _user.FirstName = user.FirstName;
                    _user.RoleID = user.RoleID;
                    _user.LastName = user.LastName;
                    _user.Email = user.Email;
                    _user.Password = user.Password;
                    _user.RoleID = user.RoleID;
                    _user.IsDisplay = user.IsDisplay;
                    _user.DisplayOrder = user.DisplayOrder;
                    _user.ModifiedDate = DateTime.Now;
                    _user.ModifiedUserID = _userService.Get(x => x.UserName == System.Web.HttpContext.Current.User.Identity.Name.ToString()).Id;
                    _userService.Update(_user);

                    #endregion User Update

                    #region User Rol Update

                    UserRole _userRole = _userRoleService.GetById(x => x.UserID == user.Id);
                    _userRole.UserID = user.Id;
                    _userRole.RoleID = user.RoleID;
                    _userRole.ModifiedDate = DateTime.Now;
                    _userRole.ModifiedUserID = user.CreatedUserID;
                    _userRoleService.Update(_userRole);

                    #endregion User Rol Update

                    return RedirectToAction("Index");
                }
                return View(user);
            }
        }

        private void roleGetAll()
        {
            int RoleID = _userService.Get(x => x.UserName == System.Web.HttpContext.Current.User.Identity.Name.ToString()).RoleID;
            if (RoleID == (int)Roles.Admin)
            {
                ViewBag.Rols = _roleService.GetList(x => x.Id == (int)Roles.User);
            }

            if (RoleID == (int)Roles.SystemAdmin)
            {
                ViewBag.Rols = _roleService.GetList();
            }
        }

        // GET: AdminPanel/User/Details/5
        public ActionResult Details(int? id)
        {
            if (String.IsNullOrEmpty(loginControl))
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                if (id == null)
                {
                    return RedirectToAction("Index");
                }
                UserDetail userDetail = _userService.GetByIdUserDetails(id);
                if (userDetail == null)
                {
                    return HttpNotFound();
                }
                return View(userDetail);
            }
        }

        // GET: AdminPanel/User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (String.IsNullOrEmpty(loginControl))
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                if (id == null)
                {
                    return RedirectToAction("Index");
                }
                UserDetail userDetail = _userService.GetByIdUserDetails(id);

                if (userDetail == null)
                {
                    return HttpNotFound();
                }
                return View(userDetail);
            }
        }

        // POST: AdminPanel/User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (String.IsNullOrEmpty(loginControl))
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                User _user = _userService.Get(x => x.Id == id);
                _user.IsDisplay = false;
                _user.ModifiedDate = DateTime.Now;
                _user.ModifiedUserID = _userService.Get(x => x.UserName == System.Web.HttpContext.Current.User.Identity.Name.ToString()).Id;
                _userService.Update(_user);
                return RedirectToAction("Index");
            }
        }
    }
}