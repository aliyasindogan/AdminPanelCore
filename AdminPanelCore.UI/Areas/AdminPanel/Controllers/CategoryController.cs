using AdminPanelCore.BLL.Abstarct;
using AdminPanelCore.CORE.Tools;
using AdminPanelCore.ENTITIES.Abstarct.Enums;
using AdminPanelCore.ENTITIES.ComplexTypes;
using AdminPanelCore.ENTITIES.Concrete;
using System;
using System.Net;
using System.Web.Mvc;

namespace AdminPanelCore.UI.Areas.AdminPanel.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryService _categoryService;
        private ICategoryTypeService _categoryTypeService;
        private IUserService _userService;
        private IRoleService _roleService;
        private string loginControl = System.Web.HttpContext.Current.User.Identity.Name.ToString();

        public CategoryController(
            ICategoryService categoryService,
            ICategoryTypeService categoryTypeService,
            IUserService userService, IRoleService roleService)
        {
            _categoryService = categoryService;
            _categoryTypeService = categoryTypeService;
            _userService = userService;
            _roleService = roleService;
        }

        // GET:
        public ActionResult Index()
        {
            if (String.IsNullOrEmpty(loginControl))
            { return RedirectToAction("Login", "Account"); }
            else
            {
                int RolID = _userService.Get(x => x.UserName == System.Web.HttpContext.Current.User.Identity.Name.ToString()).RoleID;
                return View(_categoryService.GetCategoryDetails(RolID));
            }
        }

        // GET: AdminPanel/Category/Create

        public ActionResult Create()
        {
            if (String.IsNullOrEmpty(loginControl))
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                categoryTypeGetAll();
                ViewBag.SubCategory = _categoryService.GetList(x => x.SubCategoryID == null);
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CategoryName,SubCategoryID,CategoryTypeID,SeoLink,Title,MetaDescription,MetaKeywords,IsDisplay,DisplayOrder,CreatedUserID,CreatedDate,ModifiedUserID,ModifiedDate,IsActive")] Category category)
        {
            if (String.IsNullOrEmpty(loginControl))
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                categoryTypeGetAll();
                ViewBag.SubCategory = _categoryService.GetList(x => x.SubCategoryID == null);
                if (ModelState.IsValid)
                {
                    if (_categoryService.Any(x => x.CategoryName == category.CategoryName && x.CategoryTypeID == category.CategoryTypeID) == false)
                    {
                        category.CategoryName = category.CategoryName.Trim();//Boşluklar alınıyor
                        int MaxDisplayOrder = _categoryService.Max(x => x.IsDisplay == true, p => p.DisplayOrder) ?? 0;
                        category.DisplayOrder = ++MaxDisplayOrder;
                        category.CreatedDate = DateTime.Now;
                        category.CreatedUserID = _userService.Get(x => x.UserName == System.Web.HttpContext.Current.User.Identity.Name.ToString()).Id;
                        category.IsDisplay = true;
                        if (String.IsNullOrEmpty(category.SeoLink))
                            category.SeoLink = SeoLink.SeoFrendlyLink(category.CategoryName);
                        if (String.IsNullOrEmpty(category.Title))
                            category.Title = category.CategoryName;
                        if (String.IsNullOrEmpty(category.MetaKeywords))
                            category.MetaKeywords = category.CategoryName.ToLower();
                        if (String.IsNullOrEmpty(category.MetaDescription))
                            category.MetaDescription = category.CategoryName;
                        _categoryService.Add(category);
                        return RedirectToAction("Index", "Category");
                    }
                    else
                    {
                        return View();
                    }
                }
                return View(category);
            }
        }

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
                categoryTypeGetAll();
                ViewBag.SubCategory = _categoryService.GetList(x => x.SubCategoryID == null);
                Category category = _categoryService.Get(x => x.Id == id);
                if (category == null)
                {
                    return HttpNotFound();
                }
                return View(category);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CategoryName,SubCategoryID,CategoryTypeID,SeoLink,Title,MetaDescription,MetaKeywords,IsDisplay,DisplayOrder,ModifiedUserID,ModifiedDate,IsActive")] Category category)
        {
            if (String.IsNullOrEmpty(loginControl))
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    Category _category = _categoryService.Get(x => x.Id == category.Id);
                    _category.CategoryName = category.CategoryName;
                    _category.SubCategoryID = category.SubCategoryID;
                    _category.CategoryTypeID = category.CategoryTypeID;
                    _category.SeoLink = category.SeoLink;
                    _category.Title = category.Title;
                    _category.MetaDescription = category.MetaDescription;
                    _category.MetaKeywords = category.CategoryName.ToLower();
                    _category.IsDisplay = category.IsDisplay;
                    _category.DisplayOrder = category.DisplayOrder;
                    _category.ModifiedDate = DateTime.Now;
                    _category.ModifiedUserID = _userService.Get(x => x.UserName == System.Web.HttpContext.Current.User.Identity.Name.ToString()).Id;
                    _categoryService.Update(_category);
                    return RedirectToAction("Index");
                }
                return View(category);
            }
        }

        [HttpGet]
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
                CategoryDetail categoryDetail = _categoryService.GetByIdCategoryDetails(id);

                if (categoryDetail == null)
                {
                    return HttpNotFound();
                }
                return View(categoryDetail);
            }
        }

        [HttpGet]
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
                CategoryDetail categoryDetail = _categoryService.GetByIdCategoryDetails(id);
                if (categoryDetail == null)
                {
                    return HttpNotFound();
                }
                return View(categoryDetail);
            }
        }

        // POST: AdminPanel/Category/Delete/5
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
                Category _category = _categoryService.Get(x => x.Id == id);
                _category.IsDisplay = false;
                _category.ModifiedDate = DateTime.Now;
                _category.ModifiedUserID = _userService.Get(x => x.UserName == System.Web.HttpContext.Current.User.Identity.Name.ToString()).Id;
                _categoryService.Update(_category);
                return RedirectToAction("Index");
            }
        }

        private void categoryTypeGetAll()
        {
            int RolID = _userService.Get(x => x.UserName == System.Web.HttpContext.Current.User.Identity.Name.ToString()).RoleID;
            string RolName = _roleService.Get(x => x.Id == RolID).RoleName;
            if (RolName == CategoryTypes.SystemAdminMenu.ToString())
                ViewBag.CategoryTypes = _categoryTypeService.GetList();
            else
                ViewBag.CategoryTypes = _categoryTypeService.GetList(x => x.Id != (int)CategoryTypes.SystemAdminMenu);
        }
    }
}