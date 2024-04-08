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
    public class CATEGORiesController : Controller
    {
        private Group12_iCLOTHINGDBEntities2 db = new Group12_iCLOTHINGDBEntities2();

        // GET: CATEGORies
        public ActionResult Index()
        {
            var cATEGORY = db.CATEGORY.Include(c => c.DEPARTMENT);
            return View(cATEGORY.ToList());
        }

        // GET: CATEGORies/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATEGORY cATEGORY = db.CATEGORY.Find(id);
            if (cATEGORY == null)
            {
                return HttpNotFound();
            }
            return View(cATEGORY);
        }

        // GET: CATEGORies/Create
        public ActionResult Create()
        {
            ViewBag.DEPID = new SelectList(db.DEPARTMENT, "DEPID", "DEPNAME");
            return View();
        }

        // POST: CATEGORies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CATID,CATNAME,DESCRIPTION,DEPID")] CATEGORY cATEGORY)
        {
            if (ModelState.IsValid)
            {
                db.CATEGORY.Add(cATEGORY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DEPID = new SelectList(db.DEPARTMENT, "DEPID", "DEPNAME", cATEGORY.DEPID);
            return View(cATEGORY);
        }

        // GET: CATEGORies/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATEGORY cATEGORY = db.CATEGORY.Find(id);
            if (cATEGORY == null)
            {
                return HttpNotFound();
            }
            ViewBag.DEPID = new SelectList(db.DEPARTMENT, "DEPID", "DEPNAME", cATEGORY.DEPID);
            return View(cATEGORY);
        }

        // POST: CATEGORies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CATID,CATNAME,DESCRIPTION,DEPID")] CATEGORY cATEGORY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cATEGORY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DEPID = new SelectList(db.DEPARTMENT, "DEPID", "DEPNAME", cATEGORY.DEPID);
            return View(cATEGORY);
        }

        // GET: CATEGORies/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATEGORY cATEGORY = db.CATEGORY.Find(id);
            if (cATEGORY == null)
            {
                return HttpNotFound();
            }
            return View(cATEGORY);
        }

        // POST: CATEGORies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CATEGORY cATEGORY = db.CATEGORY.Find(id);
            db.CATEGORY.Remove(cATEGORY);
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
            return View(db.CATEGORY.ToList());

        }
    }
}
