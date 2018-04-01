using BTL.Areas.Common;
using BTL.Models;
using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
namespace BTL.Controllers
{
    public class CartController : Controller
    {
        private string CartSession = CommonConstants.CartSession;
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if(cart!=null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }
        public ActionResult AddItem(long productID, int quantity)
        {
            var product = new ProductDao().Details(productID);
            var cart = Session[CartSession];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if(list.Exists(x=>x.Product.ID==productID))
                {
                    foreach (var item in list)
                    {
                        if(item.Product.ID==productID)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    //tao moi doi tuong cartItem
                    var item = new CartItem();
                    item.Product = product;
                    item.Quantity = quantity;
                    list.Add(item);

                    //gan vao session
                    Session[CartSession] = list;
                }
            }
            else
            {
                //tao moi doi tuong cartItem
                var item = new CartItem();
                item.Product = product;
                item.Quantity = quantity;
                var list = new List<CartItem>();
                list.Add(item);
                //gan vao session
                Session[CartSession] = list;
            }
            return RedirectToAction("Index");
        }
        public JsonResult Update(String cartModel)
        {
            var jsoncart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessioncart = (List<CartItem>)Session[CartSession];
            foreach (var item in sessioncart)
            {
                var jsonItem = jsoncart.SingleOrDefault(x => x.Product.ID == item.Product.ID);
                if(jsonItem!=null)
                {
                    item.Quantity = jsonItem.Quantity;
                }
            }
            Session[CartSession] = sessioncart;
            return Json(new
            {
                status = true
            });
        }
        public JsonResult DeleteAll()
        {
            Session[CartSession] = null;
            return Json(new
            {
                status = true
            });
        }
        public JsonResult Delete(long id)
        {
            var sessioncart = (List<CartItem>)Session[CartSession];
            sessioncart.RemoveAll(x => x.Product.ID == id);
            Session[CartSession] = sessioncart;
            return Json(new
            {
                status = true
            });
        }
        public ActionResult Payment()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }
        [HttpPost]
        public ActionResult Payment(string ShipName,string ShipMobile,string ShipAddress,string ShipEmail)
        {
            var order = new Order();
            order.CreateDate = DateTime.Now;
            order.ShipAddress = ShipAddress;
            order.ShipName = ShipName;
            order.ShipEmail = ShipEmail;
            order.ShipMobile = ShipMobile;
            //add 1 order va lay ra ID de add product vao orderdetail
            long id = new OrderDao().Insert(order);
            var listOrderDetail = (List<CartItem>)Session[CartSession];
            var orderdetaildao = new OrderDetailDao();
            foreach (var item in listOrderDetail)
            {
                var OrderDetail = new OrderDetail();
                OrderDetail.OrderID = id;
                OrderDetail.ProductID = item.Product.ID;
                OrderDetail.Quantity = item.Quantity;
                OrderDetail.Price = item.Product.Price;
                OrderDetail.ProductName = item.Product.Name;
                orderdetaildao.Insert(OrderDetail);
            }
            return Redirect("/hoan-thanh");
        }
        public ActionResult Success()
        {
            return View();
        }
    }
}