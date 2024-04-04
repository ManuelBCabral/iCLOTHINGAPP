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
    public class BRANDsController : Controller
    {
        private Group12_iCLOTHINGDBEntities2 db = new Group12_iCLOTHINGDBEntities2();

        // GET: BRANDs
        public ActionResult Index()
        {
            return View(db.BRAND.ToList());
        }

        // GET: BRANDs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BRAND bRAND = db.BRAND.Find(id);
            if (bRAND == null)
            {
                return HttpNotFound();
            }
            return View(bRAND);
        }

        // GET: BRANDs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BRANDs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BRANDID,BRANDNAME,DESCRIPTION")] BRAND bRAND)
        {
            if (ModelState.IsValid)
            {
                db.BRAND.Add(bRAND);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bRAND);
        }

        // GET: BRANDs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BRAND bRAND = db.BRAND.Find(id);
            if (bRAND == null)
            {
                return HttpNotFound();
            }
            return View(bRAND);
        }

        // POST: BRANDs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BRANDID,BRANDNAME,DESCRIPTION")] BRAND bRAND)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bRAND).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bRAND);
        }

        // GET: BRANDs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BRAND bRAND = db.BRAND.Find(id);
            if (bRAND == null)
            {
                return HttpNotFound();
            }
            return View(bRAND);
        }

        // POST: BRANDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            BRAND bRAND = db.BRAND.Find(id);
            db.BRAND.Remove(bRAND);
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
