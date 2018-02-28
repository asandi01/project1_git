using Project1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project1.Controllers {
    public class IncomeRecordController : Controller {
        // GET: IncomeRecord
        public ActionResult Index() {
            IncomeRecordDBHandle dbhandle = new IncomeRecordDBHandle();
            ModelState.Clear();
            return View(dbhandle.Get());
        }
        
        // GET: IncomeRecord/Create
        public ActionResult Create() {
            return View();
        }

        // POST: IncomeRecord/Create
        [HttpPost]
        public ActionResult Create(IncomeRecordModel smodel) {
            try {
                if (ModelState.IsValid) {
                    IncomeRecordDBHandle sdb = new IncomeRecordDBHandle();
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

        // GET: IncomeRecord/Edit/5
        public ActionResult Edit(int id) {
            IncomeRecordDBHandle sdb = new IncomeRecordDBHandle();
            return View(sdb.Get().Find(smodel => smodel.id == id));
        }

        // POST: IncomeRecord/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, IncomeRecordModel smodel) {
            try {
                IncomeRecordDBHandle sdb = new IncomeRecordDBHandle();
                sdb.UpdateDetails(smodel);
                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        // GET: IncomeRecord/Delete/5
        public ActionResult Delete(int id) {
            try {
                IncomeRecordDBHandle sdb = new IncomeRecordDBHandle();
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
