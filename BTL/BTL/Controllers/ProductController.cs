using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

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
        //category trong client
        public ActionResult ProductCategory(String searchString, int page = 1, int pagesize = 6,long? ID=null)
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
        //category trong admin
        public ActionResult Category(String searchString, int page = 1, int pagesize = 4, long? ID = null)
        {
            var model = new CategoryDao().ListAllByProductCategoryID(searchString, page, pagesize, ID);
            ViewBag.NameCategory = db.Categories.Find(ID);
            return View(model);
        }

        //load Json do xuong ajax
        public JsonResult LoadImagesPro(long id)
        {
            var product = new ProductDao().Details(id);
            var images = product.MoreImages;
            List<String> ListImageString = new List<string>();
            //convert tu xml sang xlement
            if (images != null)
            {
                XElement xImages = XElement.Parse(images);


                foreach (var item in xImages.Elements())
                {
                    ListImageString.Add(item.Value);
                }
            }
            return Json(new
            {
                data = ListImageString
            }, JsonRequestBehavior.AllowGet);
        }
    }
}