using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project1.Models;

namespace Project1.Controllers {
    public class PaymentByExpenseCategoryController : Controller {
        // GET: PaymentByExpenseCategory
        public ActionResult Index() {
            AlertDBHandle dbhandle = new AlertDBHandle();
            ModelState.Clear();
            return View(dbhandle.GetPaymentByExpenseCategoryCurrentMonth());
        }
    }
}