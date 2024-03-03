using SportShop.Models.DbModels;
using SportShop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Data.Entity.Infrastructure;

namespace SportShop.Controllers
{
    public class OrderController : Controller
    {
        private SportShopContext db = new SportShopContext();

        // GET: Orders
        public ActionResult Index()
        {
            var orders = db.Orders.ToList();
            return View(orders);
        }

        // GET: Order/Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }
        // GET: Order/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = db.Customers
                .Select(c => new SelectListItem
                {
                    Value = c.CustomerID.ToString(),
                    Text = "(" + c.CustomerID + ")" + " - " + c.FirstName + " " + c.LastName
                })
                .ToList();

            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName");

            return View();
        }
        // POST: Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = db.Customers.Select(c => new SelectListItem
            {
                Value = c.CustomerID.ToString(),
                Text = "(" + c.CustomerID + ")" + " - " + c.FirstName + " " + c.LastName
            }).ToList();
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName");
            return View(order);
        }
        // GET: Order/Edit/
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }

            ViewBag.CustomerID = db.Customers.Select(c => new SelectListItem
            {
                Value = c.CustomerID.ToString(),
                Text = "(" + c.CustomerID + ")" + " - " + c.FirstName+ " " + c.LastName
            }).ToList();
            var products = db.Products.ToList();
            ViewBag.ProductID = new SelectList(products, "ProductID", "ProductName", order.ProductID);
            return View(order);
        }

        // POST: Order/Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Order order)
        {
            if (ModelState.IsValid)
            {
                var existingOrder = db.Orders.Find(order.OrderID);
                if (existingOrder != null)
                {
                    db.Entry(existingOrder).CurrentValues.SetValues(order);

                    try
                    {
                        db.SaveChanges();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        db.Entry(existingOrder).Reload();
                        db.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
            }
            ViewBag.CustomerID = db.Customers.Select(c => new SelectListItem
            {
                Value = c.CustomerID.ToString(),
                Text = "(" + c.CustomerID + ")" + " - " + c.FirstName+ " " + c.LastName
            }).ToList();
            var products = db.Products.ToList();
            ViewBag.ID_produktu = new SelectList(products, "ProduktID", "ProductName", order.ProductID);
            return View(order);
        }

        // GET: Order/Delete/
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }

            return View(order);
        }

        // POST: Order/Delete/
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }

            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}