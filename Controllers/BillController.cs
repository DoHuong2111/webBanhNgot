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
    public class BillController : Controller
    {
        BanhNgotModelData db = new BanhNgotModelData();
        // GET: Bill
        public ActionResult List(int? page)
        {
            int pageSize = 7;
            int pageNumber = (page ?? 1);
            var lst = db.BILLs.SqlQuery("SELECT * FROM BILL").ToPagedList<BILL>(pageNumber, pageSize);
            return View(lst);
        }

        private IEnumerable<string> GetAllStatus()
        {
            return new List<string>
            {
                "Chưa giao hàng",
                "Đang giao hàng",
                "Hoàn thành",
                "Không giao được",
            };
        }

        public ActionResult Edit (int id)
        {
            List<CUSTOMER> customer = db.CUSTOMERs.ToList();
            SelectList listCustomer = new SelectList(customer, "ID_CUS", "NAME_CUS");
            ViewBag.ID_CUS = listCustomer;

            ViewBag.Status = GetAllStatus();

            var lst = db.BILLs.Find(id);

            return View(lst);
        }
        [HttpPost]
        public ActionResult Edit(BILL dh)
        {
            BILL bill = db.BILLs.Find(dh.ID_BILL);
            if(bill != null)
            {
                bill.STATUS_BILL = dh.STATUS_BILL;
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BILL bILL = db.BILLs.Find(id);
            if (bILL == null)
            {
                return HttpNotFound();
            }
            return View(bILL);
        }


        //public ActionResult Create()
        //{
        //    ViewBag.ID_CUS = new SelectList(db.CUSTOMERs, "ID_CUS", "ID_CUS");
        //    return View();
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ID_BILL,ID_CUS,DATE_ORDER,PAYMENT,NOTE_BILL,STATUS_BILL")] BILL bILL)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.BILLs.Add(bILL);
        //        db.SaveChanges();
        //        return RedirectToAction("List");
        //    }

        //    ViewBag.ID_CUS = new SelectList(db.CUSTOMERs, "ID_CUS", "ID_CUS", bILL.ID_CUS);
        //    return View(bILL);
        //}
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    BILL bILL = db.BILLs.Find(id);
        //    if (bILL == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.ID_CUS = new SelectList(db.CUSTOMERs, "ID_CUS", "ID_CUS", bILL.ID_CUS);
        //    return View(bILL);
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ID_BILL,ID_CUS,DATE_ORDER,PAYMENT,NOTE_BILL,STATUS_BILL")] BILL bILL)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(bILL).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("List");
        //    }
        //    ViewBag.ID_CUS = new SelectList(db.CUSTOMERs, "ID_CUS", "ID_CUS", bILL.ID_CUS);
        //    return View(bILL);
        //}
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    BILL bILL = db.BILLs.Find(id);
        //    if (bILL == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(bILL);
        //}
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    BILL bILL = db.BILLs.Find(id);
        //    db.BILLs.Remove(bILL);
        //    db.SaveChanges();
        //    return RedirectToAction("List");
        //}
        public ActionResult LeftAdmin()
        {
            return PartialView("~/Views/Shared/LeftAdmin.cshtml");
        }
    }
}