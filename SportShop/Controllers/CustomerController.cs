using SportShop.Models;
using SportShop.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportShop.Controllers
{
    public class CustomerController : Controller
    {
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Customer());
        }
        [HttpPost] 
        public ActionResult Create(Customer customer) 
        { 
            if(ModelState.IsValid) 
            {
                using (SportShopContext db = new SportShopContext())
                {
                    db.Customers.Add(customer);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View(new Customer());
        }

        public ActionResult Index()
        {
            List<Customer> list = new List<Customer>();
            using (SportShopContext db = new SportShopContext())
            {
                var Customers = db.Customers.ToList();
                return View(Customers);
            }
        }
        public ActionResult View(int id)
        {
            Customer customer;
            using (SportShopContext db = new SportShopContext())
            {
                customer = db.Customers.FirstOrDefault(x => x.CustomerID == id); 
            }
            return View(customer);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Customer customer;
            using (SportShopContext db = new SportShopContext())
                customer = db.Customers.FirstOrDefault(x => x.CustomerID == id);
            return View(customer);
        }

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            if (!ModelState.IsValid)
                return View (customer);

            using (SportShopContext db = new SportShopContext())
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete (int? id)
        {
            Customer customer;
            using (SportShopContext db = new SportShopContext())
            {
                customer = db.Customers.FirstOrDefault(x =>x.CustomerID == id); 
            }
            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int? id) 
        {
            Customer customer;
            using (SportShopContext db = new SportShopContext())
            {
                customer = db.Customers.FirstOrDefault(x => x.CustomerID == id);
                db.Customers.Remove(customer);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}