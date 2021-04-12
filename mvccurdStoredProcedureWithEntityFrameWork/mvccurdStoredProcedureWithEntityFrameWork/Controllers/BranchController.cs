using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvccurdStoredProcedureWithEntityFrameWork.Models;

namespace mvccurdStoredProcedureWithEntityFrameWork.Controllers
{
    public class BranchController : Controller
    {
        databaseEntities db = new databaseEntities();
        // GET: Branch
        public ActionResult Index()
        {
          
            return View(db.sp_select_branch().ToList());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Branch o)
        {


           
                db.sp_insert_branch(o.BranchId, o.BranchName);
  
                return View();
          
        }

        public ActionResult Edit(int id)
        {
          var s=  db.sp_find_branch(id).First();
            return View(s);
        }
        [HttpPost]
        public ActionResult Edit(Branch p)
        {
           db.sp_update_branch(p.BranchId, p.BranchName);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id )
        {
            //db.sp_delete_branch(id);
            //return RedirectToAction("Index");

            var res = db.Branches.Where(x => x.BranchId == id).First();
            db.Branches.Remove(res);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}