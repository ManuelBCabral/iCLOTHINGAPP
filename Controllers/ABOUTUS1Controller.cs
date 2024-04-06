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
    public class ABOUTUS1Controller : Controller
    {
        private Group12_iCLOTHINGDBEntities2 db = new Group12_iCLOTHINGDBEntities2();

        // GET: ABOUTUS1
        public ActionResult Index()
        {
            var aBOUTUS = db.ABOUTUS.Include(a => a.ADMINISTRATOR);
            return View(aBOUTUS.ToList());
        }

        // GET: ABOUTUS1/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ABOUTUS aBOUTUS = db.ABOUTUS.Find(id);
            if (aBOUTUS == null)
            {
                return HttpNotFound();
            }
            return View(aBOUTUS);
        }

        // GET: ABOUTUS1/Create
        public ActionResult Create()
        {
            ViewBag.ADMINID = new SelectList(db.ADMINISTRATOR, "ADMINID", "ADMINNAME");
            return View();
        }

        // POST: ABOUTUS1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COMPNAME,SHIPPPOLICY,RETURNPOL,CONTACTINFO,ABDESCRIPTION,ADMINID")] ABOUTUS aBOUTUS)
        {
            if (ModelState.IsValid)
            {
                db.ABOUTUS.Add(aBOUTUS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ADMINID = new SelectList(db.ADMINISTRATOR, "ADMINID", "ADMINNAME", aBOUTUS.ADMINID);
            return View(aBOUTUS);
        }

        // GET: ABOUTUS1/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ABOUTUS aBOUTUS = db.ABOUTUS.Find(id);
            if (aBOUTUS == null)
            {
                return HttpNotFound();
            }
            ViewBag.ADMINID = new SelectList(db.ADMINISTRATOR, "ADMINID", "ADMINNAME", aBOUTUS.ADMINID);
            return View(aBOUTUS);
        }

        // POST: ABOUTUS1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COMPNAME,SHIPPPOLICY,RETURNPOL,CONTACTINFO,ABDESCRIPTION,ADMINID")] ABOUTUS aBOUTUS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aBOUTUS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ADMINID = new SelectList(db.ADMINISTRATOR, "ADMINID", "ADMINNAME", aBOUTUS.ADMINID);
            return View(aBOUTUS);
        }

        // GET: ABOUTUS1/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ABOUTUS aBOUTUS = db.ABOUTUS.Find(id);
            if (aBOUTUS == null)
            {
                return HttpNotFound();
            }
            return View(aBOUTUS);
        }

        // POST: ABOUTUS1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ABOUTUS aBOUTUS = db.ABOUTUS.Find(id);
            db.ABOUTUS.Remove(aBOUTUS);
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
