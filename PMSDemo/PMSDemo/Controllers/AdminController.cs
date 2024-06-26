using AutoMapper;
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
    [AdminAccess]
    public class AdminController : Controller
    {
        // GET: Admin

        PMS_Sm24_AEntities db = new PMS_Sm24_AEntities();

        public ActionResult Index()
        {
            return View();
        }
      
        public ActionResult Orders()
        {
            var data = db.Orders.ToList();
            return View(OrderController.Convert(data));
        }
        public ActionResult Od(int id) { 
            var data = (from order in db.OrderProducts
                       where order.OId == id
                       select order).ToList();

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<OrderProduct,OrderProductDTO>();
                cfg.CreateMap<Product, ProductDTO>();

            });
            var mapper = new Mapper(config);
            var pd = mapper.Map<List<OrderProductDTO>>(data);
            return View(pd);
        }
        public ActionResult Decline(int id) {
            var order = db.Orders.Find(id);
            order.Status = "Declined";
            db.SaveChanges();
            TempData["Msg"] = "Order Id " + id + " declined";
            return RedirectToAction("Orders");
        }
        public ActionResult Accept(int id) {
            var order = db.Orders.Find(id);
            var orderProducts = order.OrderProducts;
            foreach (var item in orderProducts)
            {
                item.Product.Qty -= item.Qty;
                //var p = db.Products.Find(item.PId);
                //p.Qty -= item.Qty;
            }
            order.Status = "Processing";
            db.SaveChanges();
            TempData["Msg"] = "Order Id " + id + " processing";
            return RedirectToAction("Orders");

        }
            




    }
}