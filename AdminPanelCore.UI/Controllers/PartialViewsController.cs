using AdminPanelCore.BLL.Abstarct;
using AdminPanelCore.ENTITIES.Abstarct.Enum;
using AdminPanelCore.ENTITIES.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminPanelCore.UI.Controllers
{
    public class PartialViewsController : Controller
    {
        private ICategoryService _categoryService;

        public PartialViewsController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: Partial
        public ActionResult HeaderPartial()
        {
            var category = _categoryService.GetList(x=> x.CategoryTypeID==(int)CategoryTypes.WebKurumsal);
            return PartialView(category);
        }

        public ActionResult FooterPartial()
        {
            return PartialView();
        }
   
} } 