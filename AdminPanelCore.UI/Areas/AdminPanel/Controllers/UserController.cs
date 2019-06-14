﻿using AdminPanelCore.BLL.Abstarct;
using AdminPanelCore.ENTITIES.Abstarct.Enum;
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
        string loginControl = System.Web.HttpContext.Current.User.Identity.Name.ToString();
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
                int RolID = _userService.Get(x => x.UserName == System.Web.HttpContext.Current.User.Identity.Name.ToString()).RolID;
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
        public ActionResult Create([Bind(Include = "Id,UserName,Name,SurName,Email,Password,RolID,DisplayOrder,IsDisplay,CreatedUserID,CreatedDate,ModifiedUserID,ModifiedDate,IsActive")] User user)
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
                        int MaxDisplayOrder = _userService.Max(x => x.IsActive == true, p => p.DisplayOrder) ?? 0;
                        user.DisplayOrder = ++MaxDisplayOrder;
                        user.CreatedDate = DateTime.Now;
                        user.CreatedUserID = _userService.Get(x => x.UserName == System.Web.HttpContext.Current.User.Identity.Name.ToString()).Id;
                        user.IsDisplay = true;
                        user.IsActive = true;
                        _userService.Add(user);
                        #endregion

                        #region User Rol Add
                        UserRole userRole = new UserRole();
                        userRole.UserID = user.Id;
                        userRole.RolID = user.RolID;
                        userRole.CreatedDate = DateTime.Now;
                        userRole.CreatedUserID = user.CreatedUserID;
                        userRole.IsActive = true;
                        _userRoleService.Add(userRole);
                        #endregion

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
                    _user.Name = user.Name;
                    _user.RolID = user.RolID;
                    _user.SurName = user.SurName;
                    _user.Email = user.Email;
                    _user.Password = user.Password;
                    _user.RolID = user.RolID;
                    _user.IsDisplay = user.IsDisplay;
                    _user.DisplayOrder = user.DisplayOrder;
                    _user.ModifiedDate = DateTime.Now;
                    _user.ModifiedUserID = _userService.Get(x => x.UserName == System.Web.HttpContext.Current.User.Identity.Name.ToString()).Id;
                    _user.IsActive = user.IsActive;
                    _userService.Update(_user);
                    #endregion

                    #region User Rol Update
                    UserRole _userRole = _userRoleService.GetById(x => x.UserID == user.Id);
                    _userRole.UserID = user.Id;
                    _userRole.RolID = user.RolID;
                    _userRole.ModifiedDate = DateTime.Now;
                    _userRole.ModifiedUserID = user.CreatedUserID;
                    _userRole.IsActive = true;
                    _userRoleService.Update(_userRole);
                    #endregion

                    return RedirectToAction("Index");
                }
                return View(user);
            }
        }

        private void roleGetAll()
        {
            int RolID = _userService.Get(x => x.UserName == System.Web.HttpContext.Current.User.Identity.Name.ToString()).RolID;
            if (RolID == (int)Roles.Admin)
                ViewBag.Rols = _roleService.GetList(x => x.Id == RolID);
            else
                ViewBag.Rols = _roleService.GetList();
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
                _user.IsActive = false;
                _user.IsDisplay = false;
                _user.ModifiedDate = DateTime.Now;
                _user.ModifiedUserID = _userService.Get(x => x.UserName == System.Web.HttpContext.Current.User.Identity.Name.ToString()).Id;
                _userService.Update(_user);
                return RedirectToAction("Index");
            }
        }


    }
}
