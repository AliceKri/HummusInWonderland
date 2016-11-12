using HummusInWonderland.DAL;
using HummusInWonderland.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HummusInWonderland.Controllers
{
    public class MenuController : Controller
    {
        private HummhusInWonderlandContext db = new HummhusInWonderlandContext();
        // GET: Menu
        public ActionResult Index()
        {
            return View(db.Menu.ToList());
        }

        [HttpPost]
        public ActionResult Index(int ProductID, string ProductDescription, String ProductName, int? Price)
        {
            var menus = from a in db.Menu select a;

            if (!String.IsNullOrEmpty(ProductDescription))
            {
                menus = menus.Where(x => x.ProductDescription == ProductDescription);
            }

            if (!String.IsNullOrEmpty(ProductName))
            {
                menus = menus.Where(x => x.ProductName == ProductName);
            }

            if(Price != null)
            {
                menus = menus.Where(x => x.Price == Price);
            }

            ViewBag.MaxPrice = db.Menu.Select(x => x.Price).Max();
            return View(menus.ToList());
        }

        // GET: Menu/Details/5
        public ActionResult Details(int? productID)
        {
            if (productID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product menu = db.Menu.Find(productID);

            if (menu == null)
            {
                return HttpNotFound();
            }

            return View(menu);
        }

        // GET: Menu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Menu/Create
        [HttpPost]
        public ActionResult Create(Product menu, HttpPostedFileBase file)
        {
            var physicalPath = "";
            var path = "";

            if (file == null)
            {
                physicalPath = "/Images/No-Image.jpg";
                
            }

            if (file != null && file.ContentLength > 0)
            {
                var FileName = string.Format("{0}.{1}", Guid.NewGuid(), "jpg");
                path = Path.Combine(Server.MapPath("~/Images"), FileName);

                Size szDimensions = new Size(340, 300);
                Bitmap resizedImg = new Bitmap(Image.FromStream(file.InputStream), szDimensions.Width, szDimensions.Height);

                physicalPath = "/Images/" + FileName;
                resizedImg.Save(path);
            }

            menu.ProductImage = physicalPath;

            if (ModelState.IsValid)
            {
                db.Menu.Add(menu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(menu);
        }

        // GET: Menu/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product menu = db.Menu.Find(id);
            if (menu == null)
            {
                return HttpNotFound();
            }

            ViewBag.image = menu.ProductImage;

            return View(menu);
        }

        // POST: Menu/Edit/5
        [HttpPost]
        public ActionResult Edit(Product menu, HttpPostedFileBase file)
        {
            var physicalPath = "";

            if (file != null && file.ContentLength > 0)
            {
                var fileName = string.Format("{0}.{1}", Guid.NewGuid(), "jpg");
                var path = Path.Combine(Server.MapPath("~/Images"), fileName);

                Size szDimensions = new Size(340, 300);
                Bitmap resizedImg = new Bitmap(Image.FromStream(file.InputStream), szDimensions.Width, szDimensions.Height);

                physicalPath = "/Images/" + fileName;
                resizedImg.Save(path);

            }
            if (physicalPath != "")
            {
                menu.ProductImage = physicalPath;
            }

            if (ModelState.IsValid)
            {
                db.Entry(menu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(menu);
        }

        // GET: Menu/Delete/5
        public ActionResult Delete(int? productId)
        {
            if (productId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product menu = db.Menu.Find(productId);
            if (menu == null)
            {
                return HttpNotFound();
            }

            return View(menu);
        }

        // POST: Menu/Delete/5
        [HttpPost]
        public ActionResult Delete(int productId)
        {

            Product menu = db.Menu.Find(productId);
            db.Menu.Remove(menu);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetProductName(string productName)
        {
            var artistNames = (from p in db.Menu where p.ProductName.Contains(productName) select p.ProductName).Distinct().Take(10);

            return Json(artistNames, JsonRequestBehavior.AllowGet);
        }
    }
}
