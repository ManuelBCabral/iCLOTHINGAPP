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
    public class EMAILsController : Controller
    {
        private Group12_iCLOTHINGDBEntities2 db = new Group12_iCLOTHINGDBEntities2();

        // GET: EMAILs
        public ActionResult Index()
        {
            var eMAIL = db.EMAIL.Include(e => e.ADMINISTRATOR).Include(e => e.CUSTOMER);
            return View(eMAIL.ToList());
        }

        // GET: EMAILs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMAIL eMAIL = db.EMAIL.Find(id);
            if (eMAIL == null)
            {
                return HttpNotFound();
            }
            return View(eMAIL);
        }

        // GET: EMAILs/Create
        public ActionResult Create()
        {
            ViewBag.ADMINID = new SelectList(db.ADMINISTRATOR, "ADMINID", "ADMINNAME");
            ViewBag.USERID = new SelectList(db.CUSTOMER, "CUSTOMERID", "NAME");
            return View();
        }

        // POST: EMAILs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EMAILNO,EMAILDATE,EMAILSUB,EMAILBODY,USERID,ADMINID")] EMAIL eMAIL)
        {
            if (ModelState.IsValid)
            {
                db.EMAIL.Add(eMAIL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ADMINID = new SelectList(db.ADMINISTRATOR, "ADMINID", "ADMINNAME", eMAIL.ADMINID);
            ViewBag.USERID = new SelectList(db.CUSTOMER, "CUSTOMERID", "NAME", eMAIL.USERID);
            return View(eMAIL);
        }

        // GET: EMAILs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMAIL eMAIL = db.EMAIL.Find(id);
            if (eMAIL == null)
            {
                return HttpNotFound();
            }
            ViewBag.ADMINID = new SelectList(db.ADMINISTRATOR, "ADMINID", "ADMINNAME", eMAIL.ADMINID);
            ViewBag.USERID = new SelectList(db.CUSTOMER, "CUSTOMERID", "NAME", eMAIL.USERID);
            return View(eMAIL);
        }

        // POST: EMAILs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EMAILNO,EMAILDATE,EMAILSUB,EMAILBODY,USERID,ADMINID")] EMAIL eMAIL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eMAIL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ADMINID = new SelectList(db.ADMINISTRATOR, "ADMINID", "ADMINNAME", eMAIL.ADMINID);
            ViewBag.USERID = new SelectList(db.CUSTOMER, "CUSTOMERID", "NAME", eMAIL.USERID);
            return View(eMAIL);
        }

        // GET: EMAILs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMAIL eMAIL = db.EMAIL.Find(id);
            if (eMAIL == null)
            {
                return HttpNotFound();
            }
            return View(eMAIL);
        }

        // POST: EMAILs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            EMAIL eMAIL = db.EMAIL.Find(id);
            db.EMAIL.Remove(eMAIL);
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
