using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Web_banh_ngot.Models.Entities;
using PagedList;
using PagedList.Mvc;

namespace Web_banh_ngot.Controllers
{
    public class UserController : Controller
    {
        BanhNgotModelData db = new BanhNgotModelData();
        // GET: User
        public ActionResult List()
        {
           
            var lst = db.USERS.SqlQuery("SELECT * FROM USERS").ToList<USER>();
            return View(lst);
        }
        public ActionResult Logout()
        {
            Session["username"] = null;
            return RedirectToAction("/Login");
        }
        public ActionResult Login()
        {
            return View();
        }
       
        [HttpPost]
        public ActionResult CheckLogin()
        {
            string us = Request.Form["us"];
            string mk = Request.Form["mk"];
            var result = db.USERS.Where(p => p.USERNAME == us && p.PASSWORD_ == mk);
            if (result.Count() > 0)
            {
                Session["username"] = us;
                return RedirectToAction("List");
            }
            else
            {
                TempData["msg"] = "Sai tài khoản hoặc mật khẩu";
                return RedirectToAction("/Login");
            }
        }
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CheckSignUp(USER user)
        {
            db.USERS.Add(user);
            db.SaveChanges();
            return RedirectToAction("/Login");
        }


        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_US,FULL_NAME,USERNAME,EMAIL,PASSWORD_")] USER uSER)
        {
            if (ModelState.IsValid)
            {
                db.USERS.Add(uSER);
                db.SaveChanges();
                return RedirectToAction("List");
            }

            return View(uSER);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USER uSER = db.USERS.Find(id);
            if (uSER == null)
            {
                return HttpNotFound();
            }
            return View(uSER);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( USER uSER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uSER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("List");
            }
            return View(uSER);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USER uSER = db.USERS.Find(id);
            if (uSER == null)
            {
                return HttpNotFound();
            }
            return View(uSER);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            USER uSER = db.USERS.Find(id);
            db.USERS.Remove(uSER);
            db.SaveChanges();
            return RedirectToAction("List");
        }
        public ActionResult LeftAdmin()
        {
            return PartialView("~/Views/Shared/LeftAdmin.cshtml");
        }
    }
}
