using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project1.Models;

namespace Project1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index() {
            AlertDBHandle dbhandle = new AlertDBHandle();
            ModelState.Clear();

            ViewBag.payments = dbhandle.GetPayments();
            ViewBag.incoment = dbhandle.GetIncoments();

            if(dbhandle.getBeterP() > dbhandle.getBeterC()) {
                ViewBag.beterNumber = dbhandle.getBeterP();
                ViewBag.beterText = "The previous Mont was beter / \n El mes anterior fue mejor";
            }else {
                ViewBag.beterNumber = dbhandle.getBeterC();
                ViewBag.beterText = "The current Mont is beter / \n El mes actual es mejor";
            }

            ViewBag.previousMonth = dbhandle.getBeterP();
            ViewBag.currentMonth = dbhandle.getBeterC();


            ViewBag.nextPayment = dbhandle.GetFutureProjectionsPay();
            ViewBag.nextSaving = dbhandle.GetFutureProjectionsIncoment();
            ViewBag.savingIndispensable = dbhandle.GetFutureProjectionsSaving();

            return View(dbhandle.GetAlerts());
        }
    }
}