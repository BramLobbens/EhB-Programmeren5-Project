using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Examen_P5_Bram;

namespace Examen_P5_Bram.Controllers
{
    public class FlightsController : ApplicationController
    {
        private DB_Examen_P5_BramEntities db = new DB_Examen_P5_BramEntities();

        // GET: Flights
        [AllowAnonymous]
        public ActionResult Index()
        {
            var flights = db.Flights.Include(f => f.Airplane).Include(f => f.Airport).Include(f => f.Airport1);
            return View(flights.ToList());
        }

        // GET: Flights/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight flight = db.Flights.Find(id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            return View(flight);
        }

        // GET: Flights/Create
        public ActionResult Create()
        {
            ViewBag.AirplaneId = new SelectList(db.Airplanes, "Id", "AirlineId");
            ViewBag.From = new SelectList(db.Airports, "Id", "Code");
            ViewBag.To = new SelectList(db.Airports, "Id", "Code");
            return View();
        }

        // POST: Flights/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AirplaneId,From,To")] Flight flight)
        {
            if (ModelState.IsValid)
            {
                db.Flights.Add(flight);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AirplaneId = new SelectList(db.Airplanes, "Id", "AirlineId", flight.AirplaneId);
            ViewBag.From = new SelectList(db.Airports, "Id", "Code", flight.From);
            ViewBag.To = new SelectList(db.Airports, "Id", "Code", flight.To);
            return View(flight);
        }

        // GET: Flights/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight flight = db.Flights.Find(id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            ViewBag.AirplaneId = new SelectList(db.Airplanes, "Id", "AirlineId", flight.AirplaneId);
            ViewBag.From = new SelectList(db.Airports, "Id", "Code", flight.From);
            ViewBag.To = new SelectList(db.Airports, "Id", "Code", flight.To);
            return View(flight);
        }

        // POST: Flights/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AirplaneId,From,To")] Flight flight)
        {
            if (ModelState.IsValid)
            {
                db.Entry(flight).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AirplaneId = new SelectList(db.Airplanes, "Id", "AirlineId", flight.AirplaneId);
            ViewBag.From = new SelectList(db.Airports, "Id", "Code", flight.From);
            ViewBag.To = new SelectList(db.Airports, "Id", "Code", flight.To);
            return View(flight);
        }

        // GET: Flights/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight flight = db.Flights.Find(id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            return View(flight);
        }

        // POST: Flights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Flight flight = db.Flights.Find(id);
            db.Flights.Remove(flight);
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
