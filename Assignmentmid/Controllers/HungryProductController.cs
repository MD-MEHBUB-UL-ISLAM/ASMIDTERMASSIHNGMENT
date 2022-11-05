using Assignmentmid.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignmentmid.Controllers
{
    public class HungryProductController : Controller
    {
        // GET: HungryProduct
        public ActionResult Index()
        {
            using (midtermEntities db = new midtermEntities())
            {
                return View(db.Products.ToList());
            }
        }

        // GET: HungryProduct/Details/5
        public ActionResult Details(int id)
        {
            using (midtermEntities db = new midtermEntities())
            {
                return View(db.Products.Where(x => x.ProductID == id).FirstOrDefault());

            }
        }

        // GET: HungryProduct/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HungryProduct/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {

                {
                    using (midtermEntities db = new midtermEntities())
                    {
                        db.Products.Add(product);
                        db.SaveChanges();
                    }

                }
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: HungryProduct/Edit/5
        public ActionResult Edit(int id)
        {
            using (midtermEntities db = new midtermEntities())
            {
                return View(db.Products.Where(x => x.ProductID == id).FirstOrDefault());

            }
        }

        // POST: HungryProduct/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product product)
        {
            try
            {
                // TODO: Add update logic here
                using (midtermEntities db = new midtermEntities())
                {
                    db.Entry(product).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: HungryProduct/Delete/5
        public ActionResult Delete(int id)
        {
            using (midtermEntities db = new midtermEntities())
            {
                return View(db.Products.Where(x => x.ProductID == id).FirstOrDefault());

            }
        }

        // POST: HungryProduct/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Product product)
        {
            try
            {
                // TODO: Add delete logic here

                using (midtermEntities db = new midtermEntities())

                {
                    product = db.Products.Where(x => x.ProductID == id).FirstOrDefault();
                    db.Products.Remove(product);
                    db.SaveChanges();
                }
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
