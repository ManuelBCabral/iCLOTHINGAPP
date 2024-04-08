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
    public class PRODUCTsController : Controller
    {
        private Group12_iCLOTHINGDBEntities2 db = new Group12_iCLOTHINGDBEntities2();

        // GET: PRODUCTs
        public ActionResult Index()
        {
            var pRODUCT = db.PRODUCT.Include(p => p.BRAND).Include(p => p.CATEGORY);
            return View(pRODUCT.ToList());
        }

        // GET: PRODUCTs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCT pRODUCT = db.PRODUCT.Find(id);
            if (pRODUCT == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCT);
        }

        // GET: PRODUCTs/Create
        public ActionResult Create()
        {
            ViewBag.BRANDID = new SelectList(db.BRAND, "BRANDID", "BRANDNAME");
            ViewBag.CATID = new SelectList(db.CATEGORY, "CATID", "CATNAME");
            return View();
        }

        // POST: PRODUCTs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PRODUCTID,PRODUCTNAME,DESCIPTION,PRICE,QUANTITY,BRANDID,CATID")] PRODUCT pRODUCT)
        {
            if (ModelState.IsValid)
            {
                db.PRODUCT.Add(pRODUCT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BRANDID = new SelectList(db.BRAND, "BRANDID", "BRANDNAME", pRODUCT.BRANDID);
            ViewBag.CATID = new SelectList(db.CATEGORY, "CATID", "CATNAME", pRODUCT.CATID);
            return View(pRODUCT);
        }

        // GET: PRODUCTs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCT pRODUCT = db.PRODUCT.Find(id);
            if (pRODUCT == null)
            {
                return HttpNotFound();
            }
            ViewBag.BRANDID = new SelectList(db.BRAND, "BRANDID", "BRANDNAME", pRODUCT.BRANDID);
            ViewBag.CATID = new SelectList(db.CATEGORY, "CATID", "CATNAME", pRODUCT.CATID);
            return View(pRODUCT);
        }

        // POST: PRODUCTs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PRODUCTID,PRODUCTNAME,DESCIPTION,PRICE,QUANTITY,BRANDID,CATID")] PRODUCT pRODUCT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRODUCT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BRANDID = new SelectList(db.BRAND, "BRANDID", "BRANDNAME", pRODUCT.BRANDID);
            ViewBag.CATID = new SelectList(db.CATEGORY, "CATID", "CATNAME", pRODUCT.CATID);
            return View(pRODUCT);
        }

        // GET: PRODUCTs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCT pRODUCT = db.PRODUCT.Find(id);
            if (pRODUCT == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCT);
        }

        // POST: PRODUCTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PRODUCT pRODUCT = db.PRODUCT.Find(id);
            db.PRODUCT.Remove(pRODUCT);
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
            return View(db.PRODUCT.ToList());
        }
        public ActionResult RegularView()
        {
            return View(db.PRODUCT.ToList());
        }
    }
}
