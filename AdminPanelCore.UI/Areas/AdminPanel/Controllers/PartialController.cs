using AdminPanelCore.BLL.Abstarct;
using AdminPanelCore.ENTITIES.ComplexTypes;
using AdminPanelCore.ENTITIES.Concrete;
using System.Web.Mvc;

namespace AdminPanelCore.UI.Areas.AdminPanel.Controllers
{
    public class PartialController : Controller
    {
        //username içerir
        string loginControl = System.Web.HttpContext.Current.User.Identity.Name.ToString();
        IUserService _userService;
        ICategoryService _categoryService;
        public PartialController(IUserService userService, ICategoryService categoryService)
        {
            _userService = userService;
            _categoryService = categoryService;
        }

        public ActionResult BreadcrumbPartialView()
        {
            CategoryBreadcrumb categoryBreadcrumb = new CategoryBreadcrumb();
            string _url2 = Request.Url.AbsolutePath;
            Category category2;
            string _newUrl2 = _url2.Substring(0, _url2.LastIndexOf('/'));
            category2 = _categoryService.Get(x => x.SeoLink == _newUrl2);
            if (Request.Url.AbsolutePath == "/AdminPanel")
            {
                Category category = _categoryService.Get(x => x.SeoLink == "/AdminPanel/Home");
                categoryBreadcrumb.SubCategoryName = category.CategoryName;
                categoryBreadcrumb.MainCategoryName = _categoryService.Get(x => x.Id == category.Id).CategoryName;
                categoryBreadcrumb.MainCategoryLink = _categoryService.Get(x => x.Id == category.Id).SeoLink;
                return PartialView(categoryBreadcrumb);
            }
            else
            {
                string _url = Request.Url.AbsolutePath;
                Category category;
                string[] dizi = _url2.Split('/');
                int boyut = dizi.Length - 1;
                if (boyut == 3)
                {
                    string _newUrl = _url.Substring(0, _url.LastIndexOf('/'));
                    category = _categoryService.Get(x => x.SeoLink == _newUrl);
                    if (category.SubCategoryID == null)
                    {
                        categoryBreadcrumb.SubCategoryName = "";
                        categoryBreadcrumb.MainCategoryName = _categoryService.Get(x => x.Id == category.Id).CategoryName;
                        categoryBreadcrumb.MainCategoryLink = _categoryService.Get(x => x.Id == category.Id).SeoLink;
                        return PartialView(categoryBreadcrumb);
                    }
                    else
                    {
                        categoryBreadcrumb.SubCategoryName = category.CategoryName;
                        categoryBreadcrumb.MainCategoryName = _categoryService.Get(x => x.Id == category.SubCategoryID).CategoryName;
                        categoryBreadcrumb.MainCategoryLink = _categoryService.Get(x => x.Id == category.SubCategoryID).SeoLink;
                        return PartialView(categoryBreadcrumb);
                    }
                }
                else
                {
                    category = _categoryService.Get(x => x.SeoLink == Request.Url.AbsolutePath);
                    if (category.SubCategoryID == null)
                    {
                        categoryBreadcrumb.SubCategoryName = "";
                        categoryBreadcrumb.MainCategoryName = _categoryService.Get(x => x.Id == category.Id).CategoryName;
                        categoryBreadcrumb.MainCategoryLink = _categoryService.Get(x => x.Id == category.Id).SeoLink;
                        return PartialView(categoryBreadcrumb);
                    }
                    else
                    {
                        categoryBreadcrumb.SubCategoryName = category.CategoryName;
                        categoryBreadcrumb.MainCategoryName = _categoryService.Get(x => x.Id == category.SubCategoryID).CategoryName;
                        categoryBreadcrumb.MainCategoryLink = _categoryService.Get(x => x.Id == category.SubCategoryID).SeoLink;
                        return PartialView(categoryBreadcrumb);
                    }
                }
            }
        }
        public ActionResult HeaderPartialView()
        {
            User user = _userService.Get(x => x.UserName == System.Web.HttpContext.Current.User.Identity.Name.ToString());
            if (user != null)
            {
                ViewBag.AdSoyad = user.FirstName + " " + user.LastName;
                return PartialView();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        public ActionResult FooterPartialView()
        {
            return PartialView();
        }
    }
}