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
    public class USERCOMMENTSController : Controller
    {
        private Group12_iCLOTHINGDBEntities2 db = new Group12_iCLOTHINGDBEntities2();

        // GET: USERCOMMENTS
        public ActionResult Index()
        {
            var uSERCOMMENTS = db.USERCOMMENTS.Include(u => u.CUSTOMER);
            return View(uSERCOMMENTS.ToList());
        }

        // GET: USERCOMMENTS/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USERCOMMENTS uSERCOMMENTS = db.USERCOMMENTS.Find(id);
            if (uSERCOMMENTS == null)
            {
                return HttpNotFound();
            }
            return View(uSERCOMMENTS);
        }

        // GET: USERCOMMENTS/Create
        public ActionResult Create()
        {
            ViewBag.CUSTID = new SelectList(db.CUSTOMER, "CUSTOMERID", "NAME");
            return View();
        }

        // POST: USERCOMMENTS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COMMENTNO,COMMENTDATE,COMMDESCRIPTION,CUSTID")] USERCOMMENTS uSERCOMMENTS)
        {
            if (ModelState.IsValid)
            {
                db.USERCOMMENTS.Add(uSERCOMMENTS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CUSTID = new SelectList(db.CUSTOMER, "CUSTOMERID", "NAME", uSERCOMMENTS.CUSTID);
            return View(uSERCOMMENTS);
        }

        // GET: USERCOMMENTS/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USERCOMMENTS uSERCOMMENTS = db.USERCOMMENTS.Find(id);
            if (uSERCOMMENTS == null)
            {
                return HttpNotFound();
            }
            ViewBag.CUSTID = new SelectList(db.CUSTOMER, "CUSTOMERID", "NAME", uSERCOMMENTS.CUSTID);
            return View(uSERCOMMENTS);
        }

        // POST: USERCOMMENTS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COMMENTNO,COMMENTDATE,COMMDESCRIPTION,CUSTID")] USERCOMMENTS uSERCOMMENTS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uSERCOMMENTS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CUSTID = new SelectList(db.CUSTOMER, "CUSTOMERID", "NAME", uSERCOMMENTS.CUSTID);
            return View(uSERCOMMENTS);
        }

        // GET: USERCOMMENTS/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USERCOMMENTS uSERCOMMENTS = db.USERCOMMENTS.Find(id);
            if (uSERCOMMENTS == null)
            {
                return HttpNotFound();
            }
            return View(uSERCOMMENTS);
        }

        // POST: USERCOMMENTS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            USERCOMMENTS uSERCOMMENTS = db.USERCOMMENTS.Find(id);
            db.USERCOMMENTS.Remove(uSERCOMMENTS);
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
