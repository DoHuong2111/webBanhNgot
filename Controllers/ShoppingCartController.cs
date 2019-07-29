using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_banh_ngot.Models.Entities;

namespace Web_banh_ngot.Controllers
{
    public class ShoppingCartController : Controller
    {
        BanhNgotModelData db = new BanhNgotModelData();
        // GET: Cart
        public ActionResult Add(int id)
        {
            ShoppingCart cart = (ShoppingCart)Session["cart"];
            if(cart == null)
            {
                cart = new ShoppingCart();
            }
            PRODUCT pro = db.PRODUCTs.Find(id);
            if(pro != null)
            {
                cart.InsertItem(pro.ID_PR, pro.NAME_PR, (double)pro.PRICE,pro.IMAGE);
            }
            Session["cart"] = cart;
            return Redirect(Request.UrlReferrer.ToString());
        }
        public ActionResult Remove(int id)
        {
            ShoppingCart cart = (ShoppingCart)Session["cart"];
            if (cart == null)
            {
                cart = new ShoppingCart();
            }
            cart.RemoveItem(id);
            Session["cart"] = cart;
            return Redirect(Request.UrlReferrer.ToString());
        }
        public ActionResult RemoveAll()
        {
            ShoppingCart cart = (ShoppingCart)Session["cart"];
            cart = null;
            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult Update(int id,FormCollection f)
        {
            ShoppingCart cart = (ShoppingCart)Session["cart"];
            if (cart == null)
            {
                cart = new ShoppingCart();
            }
            PRODUCT pro = db.PRODUCTs.Find(id);
            if (pro != null)
            {
                cart.UpdateAmount(pro.ID_PR, int.Parse(f["txtSoLuong"].ToString()));
              //  cart.UpdateAmount(pro.ID_PR,);
            }
            Session["cart"] = cart;
            return Redirect(Request.UrlReferrer.ToString());
        }
        public ActionResult Cart()
        {
            return View();
        }
        public ActionResult Payment()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Payment(string name,string sdt,string address, string email,string pay, string note)
        {
            CUSTOMER customer = new CUSTOMER();
            customer.NAME_CUS = name;
            customer.PHONE_CUS = sdt;
            customer.ADDRESS_CUS = address;
            customer.EMAIL_CUS = email;
            db.CUSTOMERs.Add(customer);
            db.SaveChanges();

            
            BILL bill = new BILL();
            bill.ID_CUS = customer.ID_CUS;
            bill.PAYMENT = pay;
            bill.NOTE_BILL = note;
            bill.STATUS_BILL = "Chưa giao hàng";
            bill.DATE_ORDER = DateTime.Now;
            db.BILLs.Add(bill);
            db.SaveChanges();

            var id = bill.ID_BILL;
            ShoppingCart cart = (ShoppingCart)Session["cart"];
            List<Item> lst = new List<Item>();
            if(cart != null)
            {
                lst = cart.lst;
            }
            foreach (var item in lst)
            {
                BILL_DETAIL billDetail = new BILL_DETAIL();
                billDetail.ID_BILL = id;
                billDetail.ID_PR = item.id;
                billDetail.PRICE = (decimal)item.price;
                billDetail.QUANTITY = item.amount;

                db.BILL_DETAIL.Add(billDetail);
                db.SaveChanges();
            }
            lst.Clear();
            return RedirectToAction("Success");
        }
        public ActionResult Success()
        {
            return View();
        }
    }
}