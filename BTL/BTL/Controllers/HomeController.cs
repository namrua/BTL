using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace BTL.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Slides = new SlideDao().ListAll();
            ViewBag.Products = new ProductDao().ListAll();
            ViewBag.ListLaptop = new ProductDao().ListAllByProductCategoryID();
            return View();
        }
        [ChildActionOnly]
        public ActionResult MainMenu()
        {
            var model = new MenuDao().ListMenubyGroupID(1);
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult TopMenu()
        {
            var model = new MenuDao().ListMenubyGroupID(2);
            return PartialView(model);
        }
        [ChildActionOnly]
        public ActionResult Slide()
        {
            var model = new SlideDao().ListAll();
            return PartialView(model);
        }
    }
}