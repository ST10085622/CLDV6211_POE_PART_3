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
    public class RentalController : Controller
    {
        private RentYouRideDBEntities db = new RentYouRideDBEntities();

        // GET: Rental
        public ActionResult Index()
        {
            return View(db.tbl_Rental.ToList());
        }

        // GET: Rental/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Rental tbl_Rental = db.tbl_Rental.Find(id);
            if (tbl_Rental == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Rental);
        }

        // GET: Rental/Create
        //creating this async <actionresult> method so we can call the view bag in the cshtml class, this enables the user to be able to see a list of all the data provided in the database
        public async Task<ActionResult> Create(int id = 1)
        {
            if (id.Equals(null))
                {
                     return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            tbl_Rental rental = await db.tbl_Rental.FindAsync(id);
            tbl_Car car = await db.tbl_Car.FindAsync(id);
            tbl_Driver driver = await db.tbl_Driver.FindAsync(id);
            tbl_Inspector inspector = await db.tbl_Inspector.FindAsync(id);
           
            if (rental == null)
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

        // POST: Rental/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( [Bind(Include = "ID_Rental,CarNo,Inspector,Driver,Rental_Fee,Start_Date,End_Date")] tbl_Rental tbl_Rental)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Rental.Add(tbl_Rental);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Rental);
        }
        
    }
}
