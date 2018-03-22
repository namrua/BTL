using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BTL.Areas.Common;
using Model.Dao;
using Model.EF;

namespace BTL.Areas.Admin.Controllers
{
    public class UsersController : BaseController
    {
        private Dbcontext db = new Dbcontext();

        // GET: Admin/Users
        public ActionResult Index(String searchString, int page = 1, int pagesize = 4)
        {
            var dao = new UserDAO();
            var model = dao.ListAll(searchString, page, pagesize);
            ViewBag.searchString = searchString;
            return View(model);
        }
        [HttpGet]
        // GET: Admin/Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        [HttpGet]
        // GET: Admin/Users/Create
        public ActionResult Create()
        {
            setViewbag();
            return View();
        }

        public void setViewbag(long? selectedID =null)
        {
            var model = new UserDAO();
            //gan viewbag vao thang gia tri address trong User
            ViewBag.Address = new SelectList(model.TestDropdown(), "Content", "Content", selectedID);
            
        }
        // POST: Admin/Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserName,PassWord,Name,Address,Email,Phone,Image,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,Status")] User user)
        {
            Boolean check=false;
            var model = new UserDAO();
            foreach (var item in model.UsLogin())
            {
                if (user.UserName == item.UserName)
                {
                    check = true;
                    break;
                }
            }
            if (ModelState.IsValid)
            {   
                if(check)
                {
                    ModelState.AddModelError("", "UserName da ton tai");
                }
                else
                {
                    SetAlert("Them User thanh cong", "success");
                    user.PassWord = Encriptor.MD5Hash(user.PassWord);
            
                    db.Users.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
               
            }
            return View(user);
        }

        // GET: Admin/Users/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            setViewbag();
            return View(user);
        }

        // POST: Admin/Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserName,PassWord,Name,Address,Email,Phone,Image,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,Status")] User user)
        {
            if (ModelState.IsValid)
            {
                SetAlert("Sua thanh cong", "success");
                user.PassWord = Encriptor.MD5Hash(user.PassWord);
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Admin/Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Admin/Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SetAlert("Xoa thanh cong", "danger");
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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
    }
}
