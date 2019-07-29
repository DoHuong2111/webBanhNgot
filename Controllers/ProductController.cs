using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Web;
using System.IO;
using System.Web.Mvc;
using Web_banh_ngot.Models.Entities;
using PagedList;
using PagedList.Mvc;


namespace Web_banh_ngot.Controllers
{
    public class ProductController : Controller
    {
        BanhNgotModelData db = new BanhNgotModelData();
        // GET: Product
        public ActionResult List(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            List<TYPE_PRODUCT> Type_Pr = db.TYPE_PRODUCT.ToList();
            ViewBag.ID_TYPE = Type_Pr;
          //  ViewBag.ID_TYPE = new SelectList(db.TYPE_PRODUCT, "ID_TYPE", "NAME_TYPE");
            var lst = db.PRODUCTs.SqlQuery("SELECT * FROM PRODUCT ").ToPagedList<PRODUCT>(pageNumber, pageSize);
            return View(lst);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCT pRODUCT = db.PRODUCTs.Find(id);
            if (pRODUCT == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_TYPE = new SelectList(db.TYPE_PRODUCT, "ID_TYPE", "NAME_TYPE", pRODUCT.ID_TYPE);
            return View(pRODUCT);
        }
        public ActionResult Create()
        {
            ViewBag.ID_TYPE = new SelectList(db.TYPE_PRODUCT, "ID_TYPE", "NAME_TYPE");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PRODUCT pRODUCT, HttpPostedFileBase fileUpload)
        {
            if (ModelState.IsValid)
            {
                var fileName = Path.GetFileName(fileUpload.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/ImageProduct"), fileName);
                if (System.IO.File.Exists(path))
                {
                    ViewBag.ThongBao = "Image da ton tai";
                }
                else
                {
                    fileUpload.SaveAs(path);
                }
                pRODUCT.IMAGE = fileUpload.FileName;
                db.PRODUCTs.Add(pRODUCT);
                db.SaveChanges();
                return RedirectToAction("List");
            }
            ViewBag.ID_TYPE = new SelectList(db.TYPE_PRODUCT, "ID_TYPE", "NAME_TYPE", pRODUCT.ID_TYPE);
            return View(pRODUCT);
        }
        public string ProcessUpload(HttpPostedFileBase file)
        {
            file.SaveAs(Server.MapPath("~/Content/ImageProduct/" + file.FileName));
            return "/Content/ImageProduct/" + file.FileName;
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCT pRODUCT = db.PRODUCTs.Find(id);
            if (pRODUCT == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_TYPE = new SelectList(db.TYPE_PRODUCT, "ID_TYPE", "NAME_TYPE", pRODUCT.ID_TYPE);
            return View(pRODUCT);
        }
       
        [HttpPost]
        public ActionResult Edit(PRODUCT pRODUCT, HttpPostedFileBase fileUpload)
        {
            PRODUCT p = db.PRODUCTs.Find(pRODUCT.ID_PR);
            if (p != null)
            {
                if (fileUpload != null && fileUpload.ContentLength > 0)
                {
                    var TenAnh = Path.GetFileName(fileUpload.FileName);
                    var DuongDan = Path.Combine(Server.MapPath("~/Content/ImageProduct/"), TenAnh);
                    p.IMAGE = TenAnh;
                    fileUpload.SaveAs(DuongDan);
                }
                else
                {

                }
                if (ModelState.IsValid)
                {
                    p.NAME_PR = pRODUCT.NAME_PR;
                    p.PRICE = pRODUCT.PRICE;
                    p.PRICE_OLD = pRODUCT.PRICE_OLD;
                    p.NEW = pRODUCT.NEW;
                    p.HOT = pRODUCT.HOT;
                    p.ID_TYPE = pRODUCT.ID_TYPE;
                   
                    db.SaveChanges();
                }
                return RedirectToAction("List");
            }
            else return View(pRODUCT);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCT pRODUCT = db.PRODUCTs.Find(id);
            if (pRODUCT == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCT);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRODUCT pRODUCT = db.PRODUCTs.Find(id);
            db.PRODUCTs.Remove(pRODUCT);
            db.SaveChanges();
            return RedirectToAction("List");
        }
        [HttpPost]
        public ActionResult Search(FormCollection f, int? page)
        {
            string NAME_Pr = f["txtName_Pr"].ToString();
            ViewBag.NAME_Pr = NAME_Pr;
            
            List<TYPE_PRODUCT> ID_TYPE = db.TYPE_PRODUCT.ToList();
            ViewBag.ID_TYPE = ID_TYPE;

            string NAME_TYPE = f["ID_TYPE"].ToString();
            ViewBag.NAME_TYPE = NAME_TYPE;

            string TuGia = f["txtTuGia"].ToString();
            ViewBag.TuGia = TuGia;

            string DenGia = f["txtDenGia"].ToString();
            ViewBag.DenGia = DenGia;

            if (TuGia == "" || TuGia == null)
            {
                TuGia = "0";
            }
            if (DenGia == "" || DenGia == null)
            {
                DenGia = "1000000000000000000000";
            }

            int pageNumber = (page ?? 1);
            int pageSize = 5;

            var list = db.Database.SqlQuery<PRODUCT>("SELECT ID_PR,NAME_PR,TYPE_PRODUCT.ID_TYPE,IMAGE,NEW,HOT,PRICE,PRICE_OLD,DESCRIPTIONS,UNIT,size,TYPE_PRODUCT.NAME_TYPE FROM PRODUCT JOIN TYPE_PRODUCT ON PRODUCT.ID_TYPE = TYPE_PRODUCT.ID_TYPE WHERE  NAME_PR LIKE N'%" + NAME_Pr + "%' and TYPE_PRODUCT.NAME_TYPE LIKE N'%" + NAME_TYPE + "%' and PRICE >" + TuGia + " AND PRICE <" + DenGia).ToPagedList(pageNumber, pageSize);
            return View(list);

        }
        [HttpGet]
        public ActionResult Search(string NAME_Pr,string NAME_TYPE,string TuGia,string DenGia, int? page)
        {
            ViewBag.NAME_Pr = NAME_Pr;

            List<TYPE_PRODUCT> ID_TYPE = db.TYPE_PRODUCT.ToList();
            ViewBag.ID_TYPE = ID_TYPE;


            ViewBag.NAME_TYPE = NAME_TYPE;

 
            ViewBag.TuGia = TuGia;

 
            ViewBag.DenGia = DenGia;

            if (TuGia == ""||TuGia == null)
            {
                TuGia = "0";
            }
            if (DenGia == ""|| DenGia == null)
            {
                DenGia = "1000000000000000000000";
            }

            int pageNumber = (page ?? 1);
            int pageSize = 5;

            var list = db.Database.SqlQuery<PRODUCT>("SELECT ID_PR,NAME_PR,TYPE_PRODUCT.ID_TYPE,IMAGE,NEW,HOT,PRICE,PRICE_OLD,DESCRIPTIONS,UNIT,size,TYPE_PRODUCT.NAME_TYPE FROM PRODUCT JOIN TYPE_PRODUCT ON PRODUCT.ID_TYPE = TYPE_PRODUCT.ID_TYPE WHERE  (NAME_PR LIKE N'%" + NAME_Pr + "%') and (TYPE_PRODUCT.NAME_TYPE LIKE N'%" + NAME_TYPE + "%') and (PRODUCT.PRICE between " + TuGia + " AND " + DenGia + ")").ToPagedList(pageNumber, pageSize);
            return View(list);

        }
        public ActionResult LeftAdmin()
        {
            return PartialView("~/Views/Shared/LeftAdmin.cshtml");
        }
       
    }
 }