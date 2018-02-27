using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project1.Controllers
{
    public class PaymentRecordController : Controller
    {
        // GET: PaymentRecord
        public ActionResult Index()
        {
            return View();
        }

        // GET: PaymentRecord/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PaymentRecord/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PaymentRecord/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PaymentRecord/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PaymentRecord/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PaymentRecord/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PaymentRecord/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
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
