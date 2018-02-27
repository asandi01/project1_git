using Project1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project1.Controllers {
    public class ProviderController : Controller {
        // GET: Provider
        public ActionResult Index() {
            ProviderDBHandle dbhandle = new ProviderDBHandle();
            ModelState.Clear();
            return View(dbhandle.Get());
        }

        // GET: Provider/Create
        public ActionResult Create() {
            return View();
        }

        // POST: Provider/Create
        [HttpPost]
        public ActionResult Create(ProviderModel smodel) {
            try {
                if (ModelState.IsValid) {
                    ProviderDBHandle sdb = new ProviderDBHandle();
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

        // GET: Provider/Edit/5
        public ActionResult Edit(int id) {
            ProviderDBHandle sdb = new ProviderDBHandle();
            return View(sdb.Get().Find(smodel => smodel.id == id));
        }

        // POST: Provider/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ProviderModel smodel) {
            try {
                ProviderDBHandle sdb = new ProviderDBHandle();
                sdb.UpdateDetails(smodel);
                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }
        
        // GET: Provider/Delete/5
        public ActionResult Delete(int id, FormCollection collection) {
            try {
                ProviderDBHandle sdb = new ProviderDBHandle();
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
