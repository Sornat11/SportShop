using SportShop.Models.DbModels;
using SportShop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportShop.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Product());
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                using (SportShopContext db = new SportShopContext())
                {
                    db.Products.Add(product);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View(new Product());
        }

        public ActionResult Index()
        {
            List<Product> list = new List<Product>();
            using (SportShopContext db = new SportShopContext())
            {
                var Products = db.Products.ToList();
                return View(Products);
            }
        }
        public ActionResult View(int id)
        {
            Product product;
            using (SportShopContext db = new SportShopContext())
            {
                product = db.Products.FirstOrDefault(x => x.ProductID == id);
            }
            return View(product);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Product product;
            using (SportShopContext db = new SportShopContext())
                product = db.Products.FirstOrDefault(x => x.ProductID == id);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (!ModelState.IsValid)
                return View(product);

            using (SportShopContext db = new SportShopContext())
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            Product product;
            using (SportShopContext db = new SportShopContext())
            {
                product = db.Products.FirstOrDefault(x => x.ProductID == id);
            }
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int? id)
        {
            Product product;
            using (SportShopContext db = new SportShopContext())
            {
                product = db.Products.FirstOrDefault(x => x.ProductID == id);
                db.Products.Remove(product);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}