using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTL.Controllers
{
    public class ProductController : Controller
    {
        // GET: ProductCategory
        public ActionResult Index()
        {
            return View();
        }
        //[ChildActionOnly]
        public ActionResult ListCategory()
        {
            var model = new ProductCategoryDao().ListProductCategory();
            return PartialView(model);
        }

        public ActionResult ProductCategory(String searchString, int page = 1, int pagesize = 4,long? ID=null)
        {
            ViewBag.Slides = new SlideDao().ListAll();
            var dao = new ProductDao();
            //var model = new ProductCategoryDao().Details(ID);
            ViewBag.searchString = searchString;
            var model = new ProductDao().ListAllByProductCategoryID(searchString,page,pagesize,ID);
            return View(model);
        }
        public ActionResult Product(long ID)
        {
            var model = new ProductDao().Details(ID);
            ViewBag.ListReatedProducts = new ProductDao().ListReatedProducts(ID);
            return View(model);
        }
    }
}