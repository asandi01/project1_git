using Project1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project1.Controllers {
    public class ExpenseCategoryController : Controller {
        // GET: RecurenceType
        public ActionResult Index() {
            ExpenseCategoryDBHandle dbhandle = new ExpenseCategoryDBHandle();
            ModelState.Clear();
            return View(dbhandle.Get());
        }

        // GET: RecurenceType/Create
        public ActionResult Create() {
            return View();
        }

        // POST: RecurenceType/Create
        [HttpPost]
        public ActionResult Create(ExpenseCategoryModel smodel) {
            try {
                if (ModelState.IsValid) {
                    ExpenseCategoryDBHandle sdb = new ExpenseCategoryDBHandle();
                    if (sdb.Add(smodel)) {
                        ViewBag.Message = "Details Added Successfully";
                        ModelState.Clear();
                    }
                }
                return View();
            } catch (Exception e) {
                e.GetBaseException();
                return View();
            }
        }

        // GET: RecurenceType/Edit/5
        public ActionResult Edit(int id) {
            ExpenseCategoryDBHandle sdb = new ExpenseCategoryDBHandle();
            return View(sdb.Get().Find(smodel => smodel.id == id));
        }

        // POST: RecurenceType/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ExpenseCategoryModel smodel) {
            try {
                ExpenseCategoryDBHandle sdb = new ExpenseCategoryDBHandle();
                sdb.UpdateDetails(smodel);
                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        // GET: RecurenceType/Delete/5
        public ActionResult Delete(int id) {
            try {
                ExpenseCategoryDBHandle sdb = new ExpenseCategoryDBHandle();
                if (sdb.Delete(id)) {
                    ViewBag.AlertMsg = "Deleted Successfully";
                }
                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }
    }
}
