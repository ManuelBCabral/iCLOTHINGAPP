﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlTypes;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Group12_iCLOTHINGAPP.Models;

namespace Group12_iCLOTHINGAPP.Controllers
{
    public class DEPARTMENTsController : Controller
    {
        private Group12_iCLOTHINGDBEntities2 db = new Group12_iCLOTHINGDBEntities2();

        // GET: DEPARTMENTs
        public ActionResult Index()
        {
            return View(db.DEPARTMENT.ToList());
        }

        // GET: DEPARTMENTs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEPARTMENT dEPARTMENT = db.DEPARTMENT.Find(id);
            if (dEPARTMENT == null)
            {
                return HttpNotFound();
            }
            return View(dEPARTMENT);
        }

        // GET: DEPARTMENTs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DEPARTMENTs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DEPID,DEPNAME,DESCRIPTION")] DEPARTMENT dEPARTMENT)
        {
            if (ModelState.IsValid)
            {
                db.DEPARTMENT.Add(dEPARTMENT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dEPARTMENT);
        }

        // GET: DEPARTMENTs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEPARTMENT dEPARTMENT = db.DEPARTMENT.Find(id);
            if (dEPARTMENT == null)
            {
                return HttpNotFound();
            }
            return View(dEPARTMENT);
        }

        // POST: DEPARTMENTs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DEPID,DEPNAME,DESCRIPTION")] DEPARTMENT dEPARTMENT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dEPARTMENT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dEPARTMENT);
        }

        // GET: DEPARTMENTs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEPARTMENT dEPARTMENT = db.DEPARTMENT.Find(id);
            if (dEPARTMENT == null)
            {
                return HttpNotFound();
            }
            return View(dEPARTMENT);
        }

        // POST: DEPARTMENTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DEPARTMENT dEPARTMENT = db.DEPARTMENT.Find(id);
            db.DEPARTMENT.Remove(dEPARTMENT);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult CustomerView()
        {
            return View(db.DEPARTMENT.ToList());

        }
        public ActionResult FilteredCustomerView(string DepdepId)
        {
            using (Group12_iCLOTHINGDBEntities2 db = new Group12_iCLOTHINGDBEntities2())
            {
                var categories = db.CATEGORY.Where(c => c.DEPID == DepdepId).ToList();
                return View(categories);
            }


        }
        public ActionResult FilteredCustomerViewPro(string CatId)
        {
            using (Group12_iCLOTHINGDBEntities2 db = new Group12_iCLOTHINGDBEntities2())
            {
                var products = db.PRODUCT.Where(c => c.CATID == CatId).ToList();
                return View(products);
            }


        }
        public ActionResult FilteredRegularViewPro(string CatId)
        {
            using (Group12_iCLOTHINGDBEntities2 db = new Group12_iCLOTHINGDBEntities2())
            {
                var products = db.PRODUCT.Where(c => c.CATID == CatId).ToList();
                return View(products);
            }
        }
        public ActionResult ShoppingCartView(string CustId) {
            using (Group12_iCLOTHINGDBEntities2 db = new Group12_iCLOTHINGDBEntities2())
            {
                //SHOPPINGCART sHOPPINGCART = new SHOPPINGCART(CustId, price, quantity, CustId, proID);
                //db.SHOPPINGCART.Add(sHOPPINGCART);
                var products = db.SHOPPINGCART.Where(c => c.CUSTID == CustId).ToList();
                return View(products);
            }
        }
        public ActionResult RegularView()
        {
            return View(db.DEPARTMENT.ToList());

        }
        public ActionResult AddToCart(string productId)
        {
            Random rn = new Random();

            string customerId = Session["UserID"].ToString();

            if (productId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var product = db.PRODUCT.Find(productId);
            if (product == null)
            {
                return HttpNotFound();
            }

            SHOPPINGCART cartItem = new SHOPPINGCART
            {
                CARTID = rn.Next(1,1000).ToString(),
                CARTPROPRICE = product.PRICE,
                CARTPROQUANTITY = product.QUANTITY,
                CUSTID = customerId,
                PRODID = productId
            };

            db.SHOPPINGCART.Add(cartItem);
            db.SaveChanges();

            return View(cartItem);
        }
    }
}
    
