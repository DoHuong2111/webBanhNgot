using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Web_banh_ngot.Models.Entities;
using PagedList;
using PagedList.Mvc;

namespace Web_banh_ngot.Controllers
{
    public class Bill_DetailController : Controller
    {
        BanhNgotModelData db = new BanhNgotModelData();  
        // GET: Bill_Detail
        public ActionResult List(int? page)
        {
            int pageSize = 7;
            int pageNumber = (page ?? 1);
            var lst = db.BILL_DETAIL.SqlQuery("SELECT" + "* FROM BILL_DETAIL").ToPagedList<BILL_DETAIL>(pageNumber, pageSize);
            return View(lst);
        }
        public ActionResult Create()
        {
            ViewBag.ID_BILL = new SelectList(db.BILLs, "ID_BILL", "ID_BILL");
            ViewBag.ID_PR = new SelectList(db.PRODUCTs, "ID_PR", "ID_PR");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_BILL,ID_PR,QUANTITY,UNIT_PRICE")] BILL_DETAIL bILL_DETAIL)
        {
            if (ModelState.IsValid)
            {
                db.BILL_DETAIL.Add(bILL_DETAIL);
                db.SaveChanges();
                return RedirectToAction("List");
            }

            ViewBag.ID_BILL = new SelectList(db.BILLs, "ID_BILL", "ID_BILL", bILL_DETAIL.ID_BILL);
            ViewBag.ID_PR = new SelectList(db.PRODUCTs, "ID_PR", "ID_PR", bILL_DETAIL.ID_PR);
            return View(bILL_DETAIL);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BILL_DETAIL bILL_DETAIL = db.BILL_DETAIL.Find(id);
            if (bILL_DETAIL == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_BILL = new SelectList(db.BILLs, "ID_BILL", "ID_BILL", bILL_DETAIL.ID_BILL);
            ViewBag.ID_PR = new SelectList(db.PRODUCTs, "ID_PR", "ID_PR", bILL_DETAIL.ID_PR);
            return View(bILL_DETAIL);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_BILL,ID_PR,QUANTITY,UNIT_PRICE")] BILL_DETAIL bILL_DETAIL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bILL_DETAIL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("List");
            }
            ViewBag.ID_BILL = new SelectList(db.BILLs, "ID_BILL", "ID_BILL", bILL_DETAIL.ID_BILL);
            ViewBag.ID_PR = new SelectList(db.PRODUCTs, "ID_PR", "ID_PR", bILL_DETAIL.ID_PR);
            return View(bILL_DETAIL);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BILL_DETAIL bILL_DETAIL = db.BILL_DETAIL.Find(id);
            if (bILL_DETAIL == null)
            {
                return HttpNotFound();
            }
            return View(bILL_DETAIL);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BILL_DETAIL bILL_DETAIL = db.BILL_DETAIL.Find(id);
            db.BILL_DETAIL.Remove(bILL_DETAIL);
            db.SaveChanges();
            return RedirectToAction("List");
        }
        public ActionResult LeftAdmin()
        {
            return PartialView("~/Views/Shared/LeftAdmin.cshtml");
        }
    }
}