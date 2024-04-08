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
    public class USERPASSWORDsController : Controller
    {
        private Group12_iCLOTHINGDBEntities2 db = new Group12_iCLOTHINGDBEntities2();

        // GET: USERPASSWORDs
        public ActionResult Index()
        {
            var uSERPASSWORD = db.USERPASSWORD.Include(u => u.CUSTOMER);
            return View(uSERPASSWORD.ToList());
        }

        // GET: USERPASSWORDs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USERPASSWORD uSERPASSWORD = db.USERPASSWORD.Find(id);
            if (uSERPASSWORD == null)
            {
                return HttpNotFound();
            }
            return View(uSERPASSWORD);
        }

        // GET: USERPASSWORDs/Create
        public ActionResult Create()
        {
            ViewBag.USERID = new SelectList(db.CUSTOMER, "CUSTOMERID", "NAME");
            return View();
        }

        // POST: USERPASSWORDs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "USERID,ACCNAME,ENCRYPTPASS,PASSEXPIRYTIME,ACCEXPITYDATE")] USERPASSWORD uSERPASSWORD)
        {
            if (ModelState.IsValid)
            {
                db.USERPASSWORD.Add(uSERPASSWORD);
                db.SaveChanges();
                return RedirectToAction("Login","Home");
            }

            ViewBag.USERID = new SelectList(db.CUSTOMER, "CUSTOMERID", "NAME", uSERPASSWORD.USERID);
            return View(uSERPASSWORD);
        }

        // GET: USERPASSWORDs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USERPASSWORD uSERPASSWORD = db.USERPASSWORD.Find(id);
            if (uSERPASSWORD == null)
            {
                return HttpNotFound();
            }
            ViewBag.USERID = new SelectList(db.CUSTOMER, "CUSTOMERID", "NAME", uSERPASSWORD.USERID);
            return View(uSERPASSWORD);
        }

        // POST: USERPASSWORDs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "USERID,ACCNAME,ENCRYPTPASS,PASSEXPIRYTIME,ACCEXPITYDATE")] USERPASSWORD uSERPASSWORD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uSERPASSWORD).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.USERID = new SelectList(db.CUSTOMER, "CUSTOMERID", "NAME", uSERPASSWORD.USERID);
            return View(uSERPASSWORD);
        }

        // GET: USERPASSWORDs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USERPASSWORD uSERPASSWORD = db.USERPASSWORD.Find(id);
            if (uSERPASSWORD == null)
            {
                return HttpNotFound();
            }
            return View(uSERPASSWORD);
        }

        // POST: USERPASSWORDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            USERPASSWORD uSERPASSWORD = db.USERPASSWORD.Find(id);
            db.USERPASSWORD.Remove(uSERPASSWORD);
            db.SaveChanges();
            return RedirectToAction("Login","Home");
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
