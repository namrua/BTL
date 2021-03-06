﻿using BTL.Areas.Admin.Models;
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
                        ViewBag.error = "Mật khẩu nhập vào không đúng";
                        return View("Index");
                    }
                    else
                    {
                        if (res == 0)
                        {
                            ViewBag.error = "Tài khoản không tồn tại";
                            return View("Index");
                        }
                        else
                        {
                            ViewBag.error = "Tài khoản bị khóa";
                            return View("Index");
                        }
                    }
                }
            }
            else
            {
                ViewBag.error = "Login thất bại";
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