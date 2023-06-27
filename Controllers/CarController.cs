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
    public class CarController : Controller
    {
        private RentYouRideDBEntities db = new RentYouRideDBEntities();

        // GET: Car
        public ActionResult Index()
        {
            return View(db.tbl_Car.ToList());
        }

        // GET: Car/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Car tbl_Car = db.tbl_Car.Find(id);
            if(tbl_Car == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Car);
        }

        // GET: Car/Create
        public async Task<ActionResult> Create(int? id = 1)
        {
       
            if (id.Equals(null)) 
            { 
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); 
            }
            
            tbl_Car car = await db.tbl_Car.FindAsync(id);
            tbl_CarBodyType carbody = await db.tbl_CarBodyType.FindAsync(id);
            if (car == null) 
            { 
                return HttpNotFound();
            }
            //ViewBag.CarNo = new SelectList(db.tbl_Car, "CarNo", "CarNo", car.CarNo);
            //ViewBag.CarMake = new SelectList(db.tbl_Car, "CarMake", "CarMake", car.CarMake);
            //ViewBag.Model = new SelectList(db.tbl_Car, "Model", "Model", car.Model);
            ViewBag.BodyType = new SelectList(db.tbl_CarBodyType, "Description", "Description", carbody.Description);
           
            return View();
            /* This above block of code has been adapted from
             * Author: SurferOnWww
             * Date: Jun 28, 2022
             * URL: https://learn.microsoft.com/en-us/answers/questions/904674/dropdown-list-is-not-showing-selected-value
             * Date Accessed: July 25, 2023
             */
        }

        // POST: Car/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Car,CarNo,CarMake,Model,BodyType,Kilometers_Travelled,Service_Kilometers,Available")] tbl_Car tbl_Car)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Car.Add(tbl_Car);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Car);
        }

        // GET: Car/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Car tbl_Car = db.tbl_Car.Find(id);
            if (tbl_Car == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Car);
        }

        // POST: Car/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Car,CarNo,CarMake,Model,BodyType,Kilometers_Travelled,Service_Kilometers,Available")] tbl_Car tbl_Car)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Car);
        }

        // GET: Car/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Car tbl_Car = db.tbl_Car.Find(id);
            if (tbl_Car == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Car);
        }

        // POST: Car/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Car tbl_Car = db.tbl_Car.Find(id);
            db.tbl_Car.Remove(tbl_Car);
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
