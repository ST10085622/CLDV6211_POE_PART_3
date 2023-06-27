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
    public class CarMakeController : Controller
    {
        private RentYouRideDBEntities db = new RentYouRideDBEntities();

        // GET: CarMake
        public ActionResult Index()
        {
            return View(db.tbl_CarMake.ToList());
        }

        // GET: CarMake/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_CarMake tbl_CarMake = db.tbl_CarMake.Find(id);
            if (tbl_CarMake == null)
            {
                return HttpNotFound();
            }
            return View(tbl_CarMake);
        }

        // GET: CarMake/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarMake/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_CarMake,Description")] tbl_CarMake tbl_CarMake)
        {
            if (ModelState.IsValid)
            {
                db.tbl_CarMake.Add(tbl_CarMake);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_CarMake);
        }

        // GET: CarMake/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_CarMake tbl_CarMake = db.tbl_CarMake.Find(id);
            if (tbl_CarMake == null)
            {
                return HttpNotFound();
            }
            return View(tbl_CarMake);
        }

        // POST: CarMake/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_CarMake,Description")] tbl_CarMake tbl_CarMake)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_CarMake).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_CarMake);
        }

        // GET: CarMake/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_CarMake tbl_CarMake = db.tbl_CarMake.Find(id);
            if (tbl_CarMake == null)
            {
                return HttpNotFound();
            }
            return View(tbl_CarMake);
        }

        // POST: CarMake/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_CarMake tbl_CarMake = db.tbl_CarMake.Find(id);
            db.tbl_CarMake.Remove(tbl_CarMake);
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
