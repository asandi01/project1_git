using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project1.Models;

namespace Project1.Controllers
{
    public class UserController : Controller {// GET: User
        public ActionResult Index() {
            UsersDBHandle dbhandle = new UsersDBHandle();
            ModelState.Clear();
            return View(dbhandle.GetUser());
        }

        // GET: User/Create
        public ActionResult Create() {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(UserModel smodel) {
            try {
                if (ModelState.IsValid) {
                    UsersDBHandle sdb = new UsersDBHandle();
                    if (sdb.AddUser(smodel)) {
                        ViewBag.Message = "User Details Added Successfully";
                        ModelState.Clear();
                    }
                }
                return View();
            } catch (Exception e) {
                e.GetBaseException();
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id) {
            UsersDBHandle sdb = new UsersDBHandle();
            return View(sdb.GetUser().Find(smodel => smodel.idUsers == id));
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UserModel smodel) {
            try {
                UsersDBHandle sdb = new UsersDBHandle();
                sdb.UpdateDetails(smodel);
                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id) {
            try {
                UsersDBHandle sdb = new UsersDBHandle();
                if (sdb.DeleteUser(id)) {
                    ViewBag.AlertMsg = "Usuario Deleted Successfully";
                }
                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }
    }
}
