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
    public class ORDERSTATUSController : Controller
    {
        private Group12_iCLOTHINGDBEntities2 db = new Group12_iCLOTHINGDBEntities2();

        // GET: ORDERSTATUS
        public ActionResult Index()
        {
            var oRDERSTATUS = db.ORDERSTATUS.Include(o => o.SHOPPINGCART);
            return View(oRDERSTATUS.ToList());
        }

        // GET: ORDERSTATUS/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ORDERSTATUS oRDERSTATUS = db.ORDERSTATUS.Find(id);
            if (oRDERSTATUS == null)
            {
                return HttpNotFound();
            }
            return View(oRDERSTATUS);
        }

        // GET: ORDERSTATUS/Create
        public ActionResult Create()
        {
            ViewBag.CARTID = new SelectList(db.SHOPPINGCART, "CARTID", "CUSTID");
            return View();
        }

        // POST: ORDERSTATUS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "STATUSID,STATUS,STATUSDATE,CARTID")] ORDERSTATUS oRDERSTATUS)
        {
            if (ModelState.IsValid)
            {
                db.ORDERSTATUS.Add(oRDERSTATUS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CARTID = new SelectList(db.SHOPPINGCART, "CARTID", "CUSTID", oRDERSTATUS.CARTID);
            return View(oRDERSTATUS);
        }

        // GET: ORDERSTATUS/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ORDERSTATUS oRDERSTATUS = db.ORDERSTATUS.Find(id);
            if (oRDERSTATUS == null)
            {
                return HttpNotFound();
            }
            ViewBag.CARTID = new SelectList(db.SHOPPINGCART, "CARTID", "CUSTID", oRDERSTATUS.CARTID);
            return View(oRDERSTATUS);
        }

        // POST: ORDERSTATUS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "STATUSID,STATUS,STATUSDATE,CARTID")] ORDERSTATUS oRDERSTATUS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oRDERSTATUS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CARTID = new SelectList(db.SHOPPINGCART, "CARTID", "CUSTID", oRDERSTATUS.CARTID);
            return View(oRDERSTATUS);
        }

        // GET: ORDERSTATUS/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ORDERSTATUS oRDERSTATUS = db.ORDERSTATUS.Find(id);
            if (oRDERSTATUS == null)
            {
                return HttpNotFound();
            }
            return View(oRDERSTATUS);
        }

        // POST: ORDERSTATUS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ORDERSTATUS oRDERSTATUS = db.ORDERSTATUS.Find(id);
            db.ORDERSTATUS.Remove(oRDERSTATUS);
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
    }
}
