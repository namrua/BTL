using BTL.Areas.Admin.Models;
using BTL.Areas.Common;
using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTL.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                var res = dao.Login(model.UserName, Encriptor.MD5Hash(model.Password));
                if (res == 1)
                {
                    var user = dao.GetByID(model.UserName);
                    var UserSession = new UserLogin();
                    UserSession.UserName = user.UserName;
                    UserSession.UserID = user.ID;
                    Session.Add(CommonConstants.User_Session, UserSession);
                    Session["UserID"] = user.ID;
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    if (res == -1)
                    {
                        ViewBag.error = "Mat khau nhap vao khong dung";
                        return View("Index");
                    }
                    else
                    {
                        if (res == 0)
                        {
                            ViewBag.error = "Tai khoan khong ton tai nha";
                            return View("Index");
                        }
                        else
                        {
                            ViewBag.error = "Tai khoan da bi khoa";
                            return View("Index");
                        }
                    }
                }
            }
            else
            {
                ViewBag.error = "Dang nhap that bai";
                return View("Index");
            }
        }
        public ActionResult SignOut()
        {
            Session["UserID"] = null;
            return RedirectToAction("Index");
        }
    }
}