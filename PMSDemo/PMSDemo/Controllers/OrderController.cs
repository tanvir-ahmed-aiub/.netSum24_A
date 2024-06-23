using PMSDemo.DTOs;
using PMSDemo.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMSDemo.Controllers
{
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
    }
}