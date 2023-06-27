using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RentYouRide.Models;

namespace RentYouRide.Controllers
{
    public class CarBodyTypeController : Controller
    {
        private RentYouRideDBEntities db = new RentYouRideDBEntities();

        // GET: CarBodyType
        public ActionResult Index()
        {
            return View(db.tbl_CarBodyType.ToList());
        }

        // GET: CarBodyType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_CarBodyType tbl_CarBodyType = db.tbl_CarBodyType.Find(id);
            if (tbl_CarBodyType == null)
            {
                return HttpNotFound();
            }
            return View(tbl_CarBodyType);
        }

        // GET: CarBodyType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarBodyType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_CarBodyType,Description")] tbl_CarBodyType tbl_CarBodyType)
        {
            if (ModelState.IsValid)
            {
                db.tbl_CarBodyType.Add(tbl_CarBodyType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_CarBodyType);
        }

        // GET: CarBodyType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_CarBodyType tbl_CarBodyType = db.tbl_CarBodyType.Find(id);
            if (tbl_CarBodyType == null)
            {
                return HttpNotFound();
            }
            return View(tbl_CarBodyType);
        }

        // POST: CarBodyType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_CarBodyType,Description")] tbl_CarBodyType tbl_CarBodyType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_CarBodyType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_CarBodyType);
        }

        // GET: CarBodyType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_CarBodyType tbl_CarBodyType = db.tbl_CarBodyType.Find(id);
            if (tbl_CarBodyType == null)
            {
                return HttpNotFound();
            }
            return View(tbl_CarBodyType);
        }

        // POST: CarBodyType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_CarBodyType tbl_CarBodyType = db.tbl_CarBodyType.Find(id);
            db.tbl_CarBodyType.Remove(tbl_CarBodyType);
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
