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
    public class USERQUERiesController : Controller
    {
        private Group12_iCLOTHINGDBEntities2 db = new Group12_iCLOTHINGDBEntities2();

        // GET: USERQUERies
        public ActionResult Index()
        {
            var uSERQUERY = db.USERQUERY.Include(u => u.CUSTOMER);
            return View(uSERQUERY.ToList());
        }

        // GET: USERQUERies/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USERQUERY uSERQUERY = db.USERQUERY.Find(id);
            if (uSERQUERY == null)
            {
                return HttpNotFound();
            }
            return View(uSERQUERY);
        }

        // GET: USERQUERies/Create
        public ActionResult Create()
        {
            ViewBag.CUSTID = new SelectList(db.CUSTOMER, "CUSTOMERID", "NAME");
            return View();
        }

        // POST: USERQUERies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "QUERYNO,QUERYDATE,QUEDESCRIPTION,CUSTID")] USERQUERY uSERQUERY)
        {
            if (ModelState.IsValid)
            {
                db.USERQUERY.Add(uSERQUERY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CUSTID = new SelectList(db.CUSTOMER, "CUSTOMERID", "NAME", uSERQUERY.CUSTID);
            return View(uSERQUERY);
        }

        // GET: USERQUERies/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USERQUERY uSERQUERY = db.USERQUERY.Find(id);
            if (uSERQUERY == null)
            {
                return HttpNotFound();
            }
            ViewBag.CUSTID = new SelectList(db.CUSTOMER, "CUSTOMERID", "NAME", uSERQUERY.CUSTID);
            return View(uSERQUERY);
        }

        // POST: USERQUERies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "QUERYNO,QUERYDATE,QUEDESCRIPTION,CUSTID")] USERQUERY uSERQUERY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uSERQUERY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CUSTID = new SelectList(db.CUSTOMER, "CUSTOMERID", "NAME", uSERQUERY.CUSTID);
            return View(uSERQUERY);
        }

        // GET: USERQUERies/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USERQUERY uSERQUERY = db.USERQUERY.Find(id);
            if (uSERQUERY == null)
            {
                return HttpNotFound();
            }
            return View(uSERQUERY);
        }

        // POST: USERQUERies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            USERQUERY uSERQUERY = db.USERQUERY.Find(id);
            db.USERQUERY.Remove(uSERQUERY);
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
