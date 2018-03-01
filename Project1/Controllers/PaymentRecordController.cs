using Project1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project1.Controllers {
    public class PaymentRecordController : Controller {

        // GET: PaymentRecord
        public ActionResult Index() {
            PaymentRecordDBHandle dbhandle = new PaymentRecordDBHandle();
            ModelState.Clear();
            return View(dbhandle.Get());
        }
        
        // GET: PaymentRecord/Create
        public ActionResult Create() {
            return View();
        }

        // POST: PaymentRecord/Create
        [HttpPost]
        public ActionResult Create(PaymentRecordModel smodel) {
            try {
                if (ModelState.IsValid) {
                    PaymentRecordDBHandle sdb = new PaymentRecordDBHandle();
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

        // GET: PaymentRecord/Edit/5
        public ActionResult Edit(int id) {
            PaymentRecordDBHandle sdb = new PaymentRecordDBHandle();
            return View(sdb.Get().Find(smodel => smodel.id == id));
        }

        // POST: PaymentRecord/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PaymentRecordModel smodel) {
            try {
                PaymentRecordDBHandle sdb = new PaymentRecordDBHandle();
                sdb.UpdateDetails(smodel);
                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        // GET: PaymentRecord/Delete/5
        public ActionResult Delete(int id) {
            try {
                PaymentRecordDBHandle sdb = new PaymentRecordDBHandle();
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
