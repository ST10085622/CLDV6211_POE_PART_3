using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using RentYouRide.Models;

namespace RentYouRide.Controllers
{
    public class ReturnController : Controller
    {
        private RentYouRideDBEntities db = new RentYouRideDBEntities();

        // GET: Return
        public ActionResult Index()
        {
            return View(db.tbl_Return.ToList());
        }

        // GET: Return/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Return tbl_Return = db.tbl_Return.Find(id);
            if (tbl_Return == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Return);
        }
        public async Task<ActionResult> Create(int id = 1)
        {
            if (id.Equals(null))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Return rturn = await db.tbl_Return.FindAsync(id);
            tbl_Car car = await db.tbl_Car.FindAsync(id);
            tbl_Driver driver = await db.tbl_Driver.FindAsync(id);
            tbl_Inspector inspector = await db.tbl_Inspector.FindAsync(id);

            if (rturn == null)
            {
                return HttpNotFound();
            }
            //these view bags are what contain the list of data which we choose on own terms to display to the user
            ViewBag.CarNo = new SelectList(db.tbl_Car, "CarNo", "CarNo", car.CarNo);
            ViewBag.Driver = new SelectList(db.tbl_Driver, "Name", "Name", driver.Name);
            ViewBag.Inspector = new SelectList(db.tbl_Inspector, "Name", "Name", inspector.Name);

            return View();
            /* This above block of code has been adapted from
             * Author: SurferOnWww
             * Date: Jun 28, 2022
             * URL: https://learn.microsoft.com/en-us/answers/questions/904674/dropdown-list-is-not-showing-selected-value
             * Date Accessed: July 25, 2023
             */

        }

        // POST: Return/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Return,CarNo,Inspector,Driver,Return_Date,Elapsed_Date,Fine")] tbl_Return tbl_Return)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Return.Add(tbl_Return);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Return);
        }

        // GET: Return/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Return tbl_Return = db.tbl_Return.Find(id);
            if (tbl_Return == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Return);
        }

        // POST: Return/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Return,CarNo,Inspector,Driver,Return_Date,Elapsed_Date,Fine")] tbl_Return tbl_Return)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Return).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Return);
        }

        // GET: Return/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Return tbl_Return = db.tbl_Return.Find(id);
            if (tbl_Return == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Return);
        }

        // POST: Return/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Return tbl_Return = db.tbl_Return.Find(id);
            db.tbl_Return.Remove(tbl_Return);
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
