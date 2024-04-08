using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Group12_iCLOTHINGAPP.Models;

namespace Group12_iCLOTHINGAPP.Controllers
{
    public class SHOPPINGCARTsController : Controller
    {
        private Group12_iCLOTHINGDBEntities2 db = new Group12_iCLOTHINGDBEntities2();

        // GET: SHOPPINGCARTs
        public ActionResult Index()
        {
            var sHOPPINGCART = db.SHOPPINGCART.Include(s => s.CUSTOMER).Include(s => s.PRODUCT);
            return View(sHOPPINGCART.ToList());
        }

        // GET: SHOPPINGCARTs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SHOPPINGCART sHOPPINGCART = db.SHOPPINGCART.Find(id);
            if (sHOPPINGCART == null)
            {
                return HttpNotFound();
            }
            return View(sHOPPINGCART);
        }

        // GET: SHOPPINGCARTs/Create
        public ActionResult Create()
        {
            ViewBag.CUSTID = new SelectList(db.CUSTOMER, "CUSTOMERID", "NAME");
            ViewBag.PRODID = new SelectList(db.PRODUCT, "PRODUCTID", "PRODUCTNAME");
            return View();
        }

        // POST: SHOPPINGCARTs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CARTID,CARTPROPRICE,CARTPROQUANTITY,CUSTID,PRODID")] SHOPPINGCART sHOPPINGCART)
        {
            if (ModelState.IsValid)
            {
                db.SHOPPINGCART.Add(sHOPPINGCART);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CUSTID = new SelectList(db.CUSTOMER, "CUSTOMERID", "NAME", sHOPPINGCART.CUSTID);
            ViewBag.PRODID = new SelectList(db.PRODUCT, "PRODUCTID", "PRODUCTNAME", sHOPPINGCART.PRODID);
            return View(sHOPPINGCART);
        }

        // GET: SHOPPINGCARTs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SHOPPINGCART sHOPPINGCART = db.SHOPPINGCART.Find(id);
            if (sHOPPINGCART == null)
            {
                return HttpNotFound();
            }
            ViewBag.CUSTID = new SelectList(db.CUSTOMER, "CUSTOMERID", "NAME", sHOPPINGCART.CUSTID);
            ViewBag.PRODID = new SelectList(db.PRODUCT, "PRODUCTID", "PRODUCTNAME", sHOPPINGCART.PRODID);
            return View(sHOPPINGCART);
        }

        // POST: SHOPPINGCARTs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CARTID,CARTPROPRICE,CARTPROQUANTITY,CUSTID,PRODID")] SHOPPINGCART sHOPPINGCART)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sHOPPINGCART).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CUSTID = new SelectList(db.CUSTOMER, "CUSTOMERID", "NAME", sHOPPINGCART.CUSTID);
            ViewBag.PRODID = new SelectList(db.PRODUCT, "PRODUCTID", "PRODUCTNAME", sHOPPINGCART.PRODID);
            return View(sHOPPINGCART);
        }

        // GET: SHOPPINGCARTs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SHOPPINGCART sHOPPINGCART = db.SHOPPINGCART.Find(id);
            if (sHOPPINGCART == null)
            {
                return HttpNotFound();
            }
            return View(sHOPPINGCART);
        }

        // POST: SHOPPINGCARTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SHOPPINGCART sHOPPINGCART = db.SHOPPINGCART.Find(id);
            db.SHOPPINGCART.Remove(sHOPPINGCART);
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
        public ActionResult CustomerView(string CustID)
        {
            using (Group12_iCLOTHINGDBEntities2 db = new Group12_iCLOTHINGDBEntities2())
            {
                SHOPPINGCART newshopp = new SHOPPINGCART();
                var Shopping = db.SHOPPINGCART.Where(c => c.CUSTID == CustID).ToList();
                return View(Shopping);
            }
            //return View(db.SHOPPINGCART.ToList());

        }
        public ActionResult CreateShopp(string CustID, string proID)
        {
            ViewData["proID"] = proID;
            return View();
            
        }
    }
}
