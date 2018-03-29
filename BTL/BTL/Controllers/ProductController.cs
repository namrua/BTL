using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTL.Controllers
{
    public class ProductController : Controller
    {
        Dbcontext db = new Dbcontext();
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
            ViewBag.ProductCategory = new ProductCategoryDao().Details(ID);
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
        public ActionResult Category(String searchString, int page = 1, int pagesize = 4, long? ID = null)
        {
            var model = new CategoryDao().ListAllByProductCategoryID(searchString, page, pagesize, ID);
            ViewBag.NameCategory = db.Categories.Find(ID);
            return View(model);
        }
    }
}