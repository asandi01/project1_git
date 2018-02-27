using Project1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project1.Controllers {
    public class ResourceTypeController : Controller {
        // GET: RecurenceType
        public ActionResult Index() {
            ResourceTypeDBHandle dbhandle = new ResourceTypeDBHandle();
            ModelState.Clear();
            return View(dbhandle.Get());
        }
        
        // GET: RecurenceType/Create
        public ActionResult Create() {
            return View();
        }

        // POST: RecurenceType/Create
        [HttpPost]
        public ActionResult Create(ResourceTypeModel smodel) {
            try {
                if (ModelState.IsValid) {
                    ResourceTypeDBHandle sdb = new ResourceTypeDBHandle();
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
            ResourceTypeDBHandle sdb = new ResourceTypeDBHandle();
            return View(sdb.Get().Find(smodel => smodel.id == id));
        }

        // POST: RecurenceType/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ResourceTypeModel smodel) {
            try {
                ResourceTypeDBHandle sdb = new ResourceTypeDBHandle();
                sdb.UpdateDetails(smodel);
                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        // GET: RecurenceType/Delete/5
        public ActionResult Delete(int id) {
            try {
                ResourceTypeDBHandle sdb = new ResourceTypeDBHandle();
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
