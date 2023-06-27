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
    public class InspectorController : Controller
    {
        private RentYouRideDBEntities db = new RentYouRideDBEntities();

        // GET: Inspector
        public ActionResult Index()
        {
            return View(db.tbl_Inspector.ToList());
        }

        // GET: Inspector/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Inspector tbl_Inspector = db.tbl_Inspector.Find(id);
            if (tbl_Inspector == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Inspector);
        }

        // GET: Inspector/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inspector/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Inspector,InspectorNo,Name,Email,Mobile")] tbl_Inspector tbl_Inspector)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Inspector.Add(tbl_Inspector);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Inspector);
        }

        // GET: Inspector/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Inspector tbl_Inspector = db.tbl_Inspector.Find(id);
            if (tbl_Inspector == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Inspector);
        }

        // POST: Inspector/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Inspector,InspectorNo,Name,Email,Mobile")] tbl_Inspector tbl_Inspector)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Inspector).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Inspector);
        }

        // GET: Inspector/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Inspector tbl_Inspector = db.tbl_Inspector.Find(id);
            if (tbl_Inspector == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Inspector);
        }

        // POST: Inspector/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Inspector tbl_Inspector = db.tbl_Inspector.Find(id);
            db.tbl_Inspector.Remove(tbl_Inspector);
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
