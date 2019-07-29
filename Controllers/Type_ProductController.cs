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
    public class Type_ProductController : Controller
    {
        BanhNgotModelData db = new BanhNgotModelData();
        // GET: Type_Product
        public ActionResult List(int? page)
        {
            int pageSize = 7;
            int pageNumber = (page ?? 1);
            var lst = db.TYPE_PRODUCT.SqlQuery("SELECT" + "* FROM TYPE_PRODUCT").ToPagedList<TYPE_PRODUCT>(pageNumber, pageSize);
            return View(lst);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TYPE_PRODUCT tYPE_PRODUCT = db.TYPE_PRODUCT.Find(id);
            if (tYPE_PRODUCT == null)
            {
                return HttpNotFound();
            }
            return View(tYPE_PRODUCT);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_TYPE,NAME_TYPE")] TYPE_PRODUCT tYPE_PRODUCT)
        {
            if (ModelState.IsValid)
            {
                db.TYPE_PRODUCT.Add(tYPE_PRODUCT);
                db.SaveChanges();
                return RedirectToAction("List");
            }

            return View(tYPE_PRODUCT);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TYPE_PRODUCT tYPE_PRODUCT = db.TYPE_PRODUCT.Find(id);
            if (tYPE_PRODUCT == null)
            {
                return HttpNotFound();
            }
            return View(tYPE_PRODUCT);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_TYPE,NAME_TYPE")] TYPE_PRODUCT tYPE_PRODUCT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tYPE_PRODUCT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("List");
            }
            return View(tYPE_PRODUCT);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TYPE_PRODUCT tYPE_PRODUCT = db.TYPE_PRODUCT.Find(id);
            if (tYPE_PRODUCT == null)
            {
                return HttpNotFound();
            }
            return View(tYPE_PRODUCT);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TYPE_PRODUCT tYPE_PRODUCT = db.TYPE_PRODUCT.Find(id);
            db.TYPE_PRODUCT.Remove(tYPE_PRODUCT);
            db.SaveChanges();
            return RedirectToAction("List");
        }
        public ActionResult LeftAdmin()
        {
            return PartialView("~/Views/Shared/LeftAdmin.cshtml");
        }
       
    }
}