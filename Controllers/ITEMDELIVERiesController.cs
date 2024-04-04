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
    public class ITEMDELIVERiesController : Controller
    {
        private Group12_iCLOTHINGDBEntities2 db = new Group12_iCLOTHINGDBEntities2();

        // GET: ITEMDELIVERies
        public ActionResult Index()
        {
            var iTEMDELIVERY = db.ITEMDELIVERY.Include(i => i.CUSTOMER).Include(i => i.PRODUCT);
            return View(iTEMDELIVERY.ToList());
        }

        // GET: ITEMDELIVERies/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ITEMDELIVERY iTEMDELIVERY = db.ITEMDELIVERY.Find(id);
            if (iTEMDELIVERY == null)
            {
                return HttpNotFound();
            }
            return View(iTEMDELIVERY);
        }

        // GET: ITEMDELIVERies/Create
        public ActionResult Create()
        {
            ViewBag.CUSTID = new SelectList(db.CUSTOMER, "CUSTOMERID", "NAME");
            ViewBag.PROID = new SelectList(db.PRODUCT, "PRODUCTID", "PRODUCTNAME");
            return View();
        }

        // POST: ITEMDELIVERies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "STICKERID,STICKERDATE,CUSTID,PROID")] ITEMDELIVERY iTEMDELIVERY)
        {
            if (ModelState.IsValid)
            {
                db.ITEMDELIVERY.Add(iTEMDELIVERY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CUSTID = new SelectList(db.CUSTOMER, "CUSTOMERID", "NAME", iTEMDELIVERY.CUSTID);
            ViewBag.PROID = new SelectList(db.PRODUCT, "PRODUCTID", "PRODUCTNAME", iTEMDELIVERY.PROID);
            return View(iTEMDELIVERY);
        }

        // GET: ITEMDELIVERies/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ITEMDELIVERY iTEMDELIVERY = db.ITEMDELIVERY.Find(id);
            if (iTEMDELIVERY == null)
            {
                return HttpNotFound();
            }
            ViewBag.CUSTID = new SelectList(db.CUSTOMER, "CUSTOMERID", "NAME", iTEMDELIVERY.CUSTID);
            ViewBag.PROID = new SelectList(db.PRODUCT, "PRODUCTID", "PRODUCTNAME", iTEMDELIVERY.PROID);
            return View(iTEMDELIVERY);
        }

        // POST: ITEMDELIVERies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "STICKERID,STICKERDATE,CUSTID,PROID")] ITEMDELIVERY iTEMDELIVERY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iTEMDELIVERY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CUSTID = new SelectList(db.CUSTOMER, "CUSTOMERID", "NAME", iTEMDELIVERY.CUSTID);
            ViewBag.PROID = new SelectList(db.PRODUCT, "PRODUCTID", "PRODUCTNAME", iTEMDELIVERY.PROID);
            return View(iTEMDELIVERY);
        }

        // GET: ITEMDELIVERies/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ITEMDELIVERY iTEMDELIVERY = db.ITEMDELIVERY.Find(id);
            if (iTEMDELIVERY == null)
            {
                return HttpNotFound();
            }
            return View(iTEMDELIVERY);
        }

        // POST: ITEMDELIVERies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ITEMDELIVERY iTEMDELIVERY = db.ITEMDELIVERY.Find(id);
            db.ITEMDELIVERY.Remove(iTEMDELIVERY);
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
