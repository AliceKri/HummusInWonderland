using HummhusInWonderland.DAL;
using HummusInWonderland.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        // GET: Orders/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Orders/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Orders/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
