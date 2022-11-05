using Assignmentmid.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignmentmid.Controllers
{
    public class HungryController : Controller
    {
        // GET: Hungry
        public ActionResult Index()
        { 
            using (midtermEntities db = new midtermEntities())
            {
                return View(db.Employees.ToList());
            }
            
        }

        // GET: Hungry/Details/5
        public ActionResult Details(int id)
        {
            using (midtermEntities db = new midtermEntities())
            {
                return View(db.Employees.Where(x => x.EmployeeID == id).FirstOrDefault());

            }
        }

        // GET: Hungry/Create
        public ActionResult Create()
        {
            return View();
          
        }

        // POST: Hungry/Create
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            
            try
            {

                {
                    using (midtermEntities db = new midtermEntities())
                    {
                        db.Employees.Add(employee);
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

        // GET: Hungry/Edit/5
        public ActionResult Edit(int id)
        {
            using (midtermEntities db = new midtermEntities())
            {
                return View(db.Employees.Where(x => x.EmployeeID == id).FirstOrDefault());

            }
        }

        // POST: Hungry/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Employee employee)
        {
            try
            {
                // TODO: Add update logic here
                using(midtermEntities db = new midtermEntities())
                {
                    db.Entry(employee).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Hungry/Delete/5
        public ActionResult Delete(int id)
        {
            using (midtermEntities db = new midtermEntities())
            {
                return View(db.Employees.Where(x => x.EmployeeID == id).FirstOrDefault());

            }
        }

        // POST: Hungry/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Employee employee)
        {
            try
            {
                using (midtermEntities db = new midtermEntities())

                {
                    employee= db.Employees.Where(x => x.EmployeeID == id).FirstOrDefault();
                    db.Employees.Remove(employee);
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
