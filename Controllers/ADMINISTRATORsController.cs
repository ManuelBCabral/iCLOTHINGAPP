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
    public class ADMINISTRATORsController : Controller
    {
        private Group12_iCLOTHINGDBEntities2 db = new Group12_iCLOTHINGDBEntities2();

        // GET: ADMINISTRATORs
        public ActionResult Index()
        {
            return View(db.ADMINISTRATOR.ToList());
        }

        // GET: ADMINISTRATORs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ADMINISTRATOR aDMINISTRATOR = db.ADMINISTRATOR.Find(id);
            if (aDMINISTRATOR == null)
            {
                return HttpNotFound();
            }
            return View(aDMINISTRATOR);
        }

        // GET: ADMINISTRATORs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ADMINISTRATORs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ADMINID,ADMINNAME,ADMINEMAIL,DATEHIRED")] ADMINISTRATOR aDMINISTRATOR)
        {
            if (ModelState.IsValid)
            {
                db.ADMINISTRATOR.Add(aDMINISTRATOR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aDMINISTRATOR);
        }

        // GET: ADMINISTRATORs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ADMINISTRATOR aDMINISTRATOR = db.ADMINISTRATOR.Find(id);
            if (aDMINISTRATOR == null)
            {
                return HttpNotFound();
            }
            return View(aDMINISTRATOR);
        }

        // POST: ADMINISTRATORs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ADMINID,ADMINNAME,ADMINEMAIL,DATEHIRED")] ADMINISTRATOR aDMINISTRATOR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aDMINISTRATOR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aDMINISTRATOR);
        }

        // GET: ADMINISTRATORs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ADMINISTRATOR aDMINISTRATOR = db.ADMINISTRATOR.Find(id);
            if (aDMINISTRATOR == null)
            {
                return HttpNotFound();
            }
            return View(aDMINISTRATOR);
        }

        // POST: ADMINISTRATORs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ADMINISTRATOR aDMINISTRATOR = db.ADMINISTRATOR.Find(id);
            db.ADMINISTRATOR.Remove(aDMINISTRATOR);
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
