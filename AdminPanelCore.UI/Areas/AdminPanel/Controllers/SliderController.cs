using AdminPanelCore.BLL.Abstarct;
using AdminPanelCore.CORE.Entities.Concrete;
using AdminPanelCore.ENTITIES.Concrete;
using System;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace AdminPanelCore.UI.Areas.AdminPanel.Controllers
{
    public class SliderController : Controller
    {
        string loginControl = System.Web.HttpContext.Current.User.Identity.Name.ToString();

        private ISliderService _sliderService;
        private IUserService _userService;
        public SliderController(ISliderService sliderService, IUserService userService)
        {
            _sliderService = sliderService;
            _userService = userService;
        }


        // GET: AdminPanel/Slider
        public ActionResult Index()
        {
            if (String.IsNullOrEmpty(loginControl))
            { return RedirectToAction("Login", "Account"); }
            else
            {
                return View(_sliderService.GetList());
            }
        }

        // GET: AdminPanel/Slider/Create
        public ActionResult Create()
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

        // POST: AdminPanel/Slider/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Slider slider, HttpPostedFileBase Foto)
        {
            if (String.IsNullOrEmpty(loginControl))
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    if (Foto != null)
                    {

                        WebImage webImageLarge = new WebImage(Foto.InputStream);
                        FileInfo fileInfoLarge = new FileInfo(Foto.FileName);
                        string newFotoNameLarge = Guid.NewGuid().ToString() + fileInfoLarge.Extension;
                        webImageLarge.Resize(850, 400);
                        webImageLarge.Save("~"+ConstantParameter.LargeImageFilePath + newFotoNameLarge);
                        slider.SliderImageUrlLarge = ConstantParameter.LargeImageFilePath + newFotoNameLarge;
                    }
                    int MaxDisplayOrder = _sliderService.Max(x => x.IsActive == true, p => p.DisplayOrder) ?? 0;
                    slider.DisplayOrder = ++MaxDisplayOrder;
                    slider.CreatedDate = DateTime.Now;
                    slider.CreatedUserID = _userService.Get(x => x.UserName == System.Web.HttpContext.Current.User.Identity.Name.ToString()).Id;
                    slider.StartDate = DateTime.Now;
                    slider.EndDate = DateTime.Now.AddDays(15);
                    _sliderService.Add(slider);
                    return RedirectToAction("Index", "Slider");
                }
                return View(slider);
            }
        }

        // GET: AdminPanel/Slider/Edit/5
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
                Slider slider = _sliderService.Get(x => x.Id == id);
                if (slider == null)
                {
                    return HttpNotFound();
                }
                return View(slider);
            }
        }

        // POST: AdminPanel/Slider/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Slider slider, HttpPostedFileBase Foto)
        {
            if (String.IsNullOrEmpty(loginControl))
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    Slider _slider = _sliderService.Get(x => x.Id == slider.Id);
                    if (Foto != null)
                    {
                        WebImage webImageLarge = new WebImage(Foto.InputStream);
                        FileInfo fileInfoLarge = new FileInfo(Foto.FileName);
                        string newFotoNameLarge = Guid.NewGuid().ToString() + fileInfoLarge.Extension;
                        webImageLarge.Resize(850, 400);
                        webImageLarge.Save("~" + ConstantParameter.LargeImageFilePath + newFotoNameLarge);
                        _slider.SliderImageUrlLarge = ConstantParameter.LargeImageFilePath + newFotoNameLarge;
                    }
                    else
                    {
                        _slider.SliderNewsUrl = slider.SliderImageUrlLarge;
                    }
                    _slider.SliderTitle = slider.SliderTitle;
                    _slider.SliderDescription = slider.SliderDescription;
                    _slider.SliderNewsUrl = slider.SliderNewsUrl;
                    _slider.DisplayOrder = slider.DisplayOrder;
                    _slider.ModifiedDate = DateTime.Now;
                    _slider.ModifiedUserID = _userService.Get(x => x.UserName == System.Web.HttpContext.Current.User.Identity.Name.ToString()).Id;
                    _slider.IsDisplay = slider.IsDisplay;
                    _slider.IsActive = slider.IsActive;
                    _sliderService.Update(_slider);
                    return RedirectToAction("Index");
                }
                return View(slider);
            }
        }


        // GET: AdminPanel/Slider/Details/5
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
                Slider slider = _sliderService.Get(x => x.Id == id);
                if (slider == null)
                {
                    return HttpNotFound();
                }
                return View(slider);
            }
        }

        // GET: AdminPanel/Slider/Delete/5
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
                Slider slider = _sliderService.Get(x => x.Id == id);
                if (slider == null)
                {
                    return HttpNotFound();
                }
                return View(slider);
            }
        }

        // POST: AdminPanel/Slider/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Slider slider = _sliderService.Get(x => x.Id == id);
            _sliderService.Delete(slider);
            return RedirectToAction("Index");
        }


    }
}
