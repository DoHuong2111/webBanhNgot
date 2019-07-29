using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_banh_ngot.Models.Entities;
using System.Net;
using PagedList;

namespace Web_banh_ngot.Controllers
{
    public class HomeController : Controller
    {
        BanhNgotModelData db = new BanhNgotModelData();   
        public ActionResult Index(int? page)
        {
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            var lst = db.Database.SqlQuery<PRODUCT>("select * from product where new = 1").ToPagedList<PRODUCT>(pageNumber, pageSize);
            ViewBag.HotProduct = db.Database.SqlQuery<PRODUCT>("select * from product where hot = 1").ToPagedList<PRODUCT>(pageNumber, pageSize);
            return View(lst);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Type_Product(int id,int? page)
        {
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            var type = new Type_ProductController().Details(id);
            ViewBag.Type = db.Database.SqlQuery<TYPE_PRODUCT>("select * from type_product where id_type = " +id ).ToList();
            var lst = db.Database.SqlQuery<PRODUCT>("select * from product  where id_type = " + id).ToPagedList<PRODUCT>(pageNumber, pageSize);
            return View(lst);
        }
        public ActionResult Cart()
        {
            return View();
        }
        public ActionResult LeftType_Product()
        {
            var lstType_Product = db.TYPE_PRODUCT.ToList();
            return PartialView("~/Views/Shared/LeftType_Product.cshtml", lstType_Product);
        }
        
        
    }
}