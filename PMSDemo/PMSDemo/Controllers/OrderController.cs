using PMSDemo.Auth;
using PMSDemo.DTOs;
using PMSDemo.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMSDemo.Controllers
{
    [Customer]
    public class OrderController : Controller
    {
        // GET: Order
        PMS_Sm24_AEntities db = new PMS_Sm24_AEntities();

        public ActionResult Index()
        {
            
            var products = db.Products.ToList();
            return View(ProductController.Convert(products));
        }
        public ActionResult AddtoCart(int id) {
            var p = db.Products.Find(id);
            var pr = ProductController.Convert(p);
            pr.Qty = 1;
            if (Session["cart"] == null)
            {
                var cart = new List<ProductDTO>();
                cart.Add(pr);
                Session["cart"] = cart;
            }
            else {
                var cart = Session["cart"];
                var data = (List<ProductDTO>)cart;
                data.Add(pr);
                Session["cart"] = data;

            }
            
            TempData["Msg"] = pr.Name + " Added Successfully";
            return RedirectToAction("Index");
        }
        public ActionResult Cart() {
            var cart = Session["cart"];
            if (cart == null) {
                TempData["Msg"] = "Cart Empty";
                return RedirectToAction("Index");
            }
            var data = (List<ProductDTO>)cart;
            return View(data);


        }
        [HttpPost]
        public ActionResult PlaceOrder(decimal Total) {
            var order = new Order();
            order.OrderDate = DateTime.Now;
            order.Status = "Ordered";
            order.TotalAmount = Total;
            order.UserId = ((User)Session["user"]).Id;
            db.Orders.Add(order);
            db.SaveChanges();
            var cart = (List<ProductDTO>)Session["cart"];
            foreach (var p in cart) {
                var op = new OrderProduct();
                op.UnitPrice = p.Price;
                op.Qty =p.Qty;
                op.PId = p.Id;
                op.OId = order.Id;
                db.OrderProducts.Add(op);
            }
            db.SaveChanges();

            Session["cart"] = null;
            TempData["Msg"] = "Order Placed Successfully";
            return RedirectToAction("Index");

        }
        
        public static OrderDTO Convert(Order o) {
            return new OrderDTO() {
                Id = o.Id,
                Status = o.Status,
                TotalAmount = o.TotalAmount,
                UserId = o.UserId,
                OrderDate = o.OrderDate
            };
        }
        public static List<OrderDTO> Convert(List<Order> ords) {
            var list = new List<OrderDTO>();
            foreach (var item in ords)
            {
                list.Add(Convert(item));
            }
            return list;
        }
    }
}