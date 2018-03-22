using BTL.Areas.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTL.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var session = Session[CommonConstants.User_Session];

            if (session == null)
            {
                Response.Redirect("~/Admin/Login/Index");
                //filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { Controller = "Login", action = "Index", Area = "Admin" }));
            }

            base.OnActionExecuted(filterContext);
        }
        protected void SetAlert(String message, String type)
        {
            TempData["AlertMessage"] = message;
            if(type=="success")
            {
                TempData["AlertType"] = " alert-success";
            }
            else if(type=="danger")
            {
                TempData["AlertType"] = "alert-danger";
            }
            else if(type == "warning")
            {
                TempData["AlertType"] = "alert-warning";
            }
        }
        }
}