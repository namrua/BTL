using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Xml.Linq;
using Model.Dao;
using Model.EF;

namespace BTL.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        private Dbcontext db = new Dbcontext();

        // GET: Admin/Products
        public ActionResult Index(String searchString, int page = 1, int pagesize = 8)
        {
            var dao = new ProductDao();
            var model = dao.ListAll(searchString, page, pagesize);
            ViewBag.searchString = searchString;
            return View(model);
        }
        // GET: Admin/Products/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Admin/Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Code,MetaTitle,Description,Image,MoreImages,Price,PromotionPrice,IncludeVAT,Quantity,CategoryID,Detail,Warranty,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,MetaKeywords,MetaDescriptions,Status,TopHot,ViewCount")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Admin/Products/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Code,MetaTitle,Description,Image,MoreImages,Price,PromotionPrice,IncludeVAT,Quantity,CategoryID,Detail,Warranty,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,MetaKeywords,MetaDescriptions,Status,TopHot,ViewCount")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Admin/Products/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public JsonResult SaveImages(long id, String images)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            //chuyen ve list images
            var listImages = serializer.Deserialize<List<String>>(images);

            XElement xElement = new XElement("Images");

            //tao 1 mang Xelement
            foreach (var item in listImages)
            {
                var itemx = item.Substring(23);
                xElement.Add(new XElement("Image", itemx));
            }
            ProductDao dao = new ProductDao();
            dao.UpdateImages(id, xElement.ToString());
            try
            {
                return Json(new
                {
                    status = true
                });
            }
            catch(Exception e)
            {
                return Json(new
                {
                    status = false
                });
            }
        }
        public JsonResult LoadImages(long id)
        {
            var product = new ProductDao().Details(id);
            var images = product.MoreImages;
            List<String> ListImageString = new List<string>();
            //convert tu xml sang xlement
            if(images!=null)
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
