using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_linq_to_sql_SP_Crud.Models;

namespace Mvc_linq_to_sql_SP_Crud.Controllers
{
    public class EmpController : Controller
    {
        AzuredbEntities db = new AzuredbEntities();
        // GET: Emp
        public ActionResult Index()
        {
            var getempcurd = db.crudeemp(null, null, null, null, "select").ToList();
            return View(getempcurd);
        }

        // GET: Emp/Details/5
        public ActionResult Details(int id)
        {
            var empdetails = db.crudeemp(id, null, null, null, "details").Single(x => x.Empid == id);
            return View(empdetails);
        }

        // GET: Emp/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Emp/Create
        [HttpPost]
        public ActionResult Create(Emptable collection)
        {
            try
            {
                // TODO: Add insert logic here
                db.crudeemp(null,collection.Empname,collection.Email, collection.Salary, "insert");
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Emp/Edit/5
        public ActionResult Edit(int id)
        {
            var empdetails = db.crudeemp(id, null, null, null, "details").Single(x => x.Empid == id);
            return View(empdetails);
        
        }

        // POST: Emp/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Emptable collection)
        {
            try
            {
                // TODO: Add update logic here

                db.crudeemp(id, collection.Empname, collection.Email, collection.Salary, "update");
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Emp/Delete/5
        public ActionResult Delete(int id)
        {
            var empdetails = db.crudeemp(id, null, null, null, "details").Single(x => x.Empid == id);
            return View(empdetails);

           
        }

        // POST: Emp/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Emptable collection)
        {
            try
            {
                // TODO: Add delete logic here
                db.crudeemp(id, null, null, null, "delete");
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
