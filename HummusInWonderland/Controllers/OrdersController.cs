using HummusInWonderland.DAL;
using HummusInWonderland.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HummusInWonderland.Controllers
{
    public class OrdersController : Controller
    {
        private HummhusInWonderlandContext db = new HummhusInWonderlandContext();

        // GET: Orders
        public ActionResult Index()
        {
            //TODO: To check if it works
            var query = (from q in db.Orders
                         group q by q.ProductID into g
                         select new
                         {
                             OrderID = g.Key,
                             Order = g
                         });

            return View(query.ToList());
        }

        [HttpPost]
        public ActionResult Index(string FirstName, string ProductName)
        {
            var orders = from o in db.Orders select o;

            if (!string.IsNullOrEmpty(FirstName))
            {
                orders = orders.Where(x => x.Customer.FirstName == FirstName);
            }

            if (!string.IsNullOrEmpty(ProductName))
            {
                orders = orders.Where(x => x.menu.ProductName == ProductName);
            }

            var query = (from o in orders
                        group o by o.ProductID into g
                        select new
                        {
                            OrderID = g.Key,
                            Order = g
                        });

            return View(query.ToList()); ;
        }

        public ActionResult ShoppingCart()
        {
            List<Product> order = new List<Product>();

            int total = 0;

            foreach (var item in (List<int>)System.Web.HttpContext.Current.Session["shoppingCart"])
            {
                var product = db.Menu.Where(a => a.ProductID == item).FirstOrDefault();
                if (product != null)
                {
                    order.Add(product);
                    total += product.Price;
                }
            }

            ViewBag.Total = total;
            return View(order);
        }

        [HttpPost]
        public JsonResult AddToCart(int productID)
        {
            List<int> shoppingList = (List<int>)System.Web.HttpContext.Current.Session["shoppingCart"];

            if (shoppingList == null)
            {
                shoppingList = new List<int>();
                System.Web.HttpContext.Current.Session["shoppingCart"] = shoppingList;
            }
            if (!shoppingList.Contains(productID))
                shoppingList.Add(productID);
            return Json(true);
        }

        public JsonResult DeleteFromCart(int productID = 0)
        {
            List<int> cart = (List<int>)System.Web.HttpContext.Current.Session["shoppingCart"];
            if (cart != null)
            {
                cart.Remove(productID);
                return Json(cart.Count);
            } else
                return Json(0);
        }

        public JsonResult Pay()
        {
            if (System.Web.HttpContext.Current.Session["user"] == null)
            {
                return Json(false);
            }
            else
            {
                foreach (var item in (List<int>)System.Web.HttpContext.Current.Session["shoppingCart"])
                {
                    Order order = new Order
                    {
                        CustomerId = ((Customer)System.Web.HttpContext.Current.Session["user"]).CustomerID,
                        ProductID = db.Menu.Where(x => x.ProductID == item).FirstOrDefault().ProductID,
                        OrderDate = DateTime.Now,
                        TotalPrice = db.Menu.Where(x => x.ProductID == item).FirstOrDefault().Price
                    };

                    db.Orders.Add(order);
                    db.Customers.Find(order.CustomerId).Orders.Add(order);
                }

                db.SaveChanges();
                ((List<int>)System.Web.HttpContext.Current.Session["shoppingCart"]).Clear();

                return Json(true);
            }
        }

        public ActionResult GetFirstName(string term)
        {
            var firstNames = (from p in db.Orders where p.Customer.FirstName.Contains(term) select p.Customer.FirstName).Distinct().Take(10);

            return Json(firstNames, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAlbumName(string term)
        {
            var albumNames = (from p in db.Orders where p.menu.ProductName.Contains(term) select p.menu.ProductName).Distinct().Take(10);

            return Json(albumNames, JsonRequestBehavior.AllowGet);
        }
    }
}
