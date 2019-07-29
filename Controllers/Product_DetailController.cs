using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_banh_ngot.Models.Entities;
using PagedList;

namespace Web_banh_ngot.Controllers
{
    public class Product_DetailController : Controller
    {
        BanhNgotModelData db = new BanhNgotModelData();
        // GET: Product_Detail
        public ActionResult Detail(int id,int? page)
        {
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            PRODUCT pRODUCT = db.PRODUCTs.SingleOrDefault(n => n.ID_PR == id);
            if (pRODUCT == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.Related_products = db.Database.SqlQuery<PRODUCT>("select * from product where ID_PR !=" + id + "and ID_TYPE =" + pRODUCT.ID_TYPE).ToPagedList<PRODUCT>(pageNumber, pageSize);
            ViewBag.Hot_Product = db.Database.SqlQuery<PRODUCT>("select * from product where hot = 1 ").Take(4).ToList();
            ViewBag.New_Product = db.Database.SqlQuery<PRODUCT>("select * from product where new = 1 ").Take(4).ToList();
            return View(pRODUCT);
           
        }
    }
}