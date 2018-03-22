using BTL.Areas.Admin.Models;
using BTL.Areas.Common;
using Model.Dao;
using System.Web.Mvc;

namespace BTL.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
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
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    if (res == -1)
                    {
                        ModelState.AddModelError("", "Mat khau dang nhap khong dung");
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
                            ModelState.AddModelError("", "Tai khoan bi khoa");
                            return View("Index");
                        }
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Dang nhap that bai");
                return View("Index");
            }
        }
    }
}