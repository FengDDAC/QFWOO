using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FengDDAC1.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FengDDAC1.Controllers
{
    public class VesselsController : Controller
    {
        private FengDDACEntities db = new FengDDACEntities();

        // GET: Vessels
        public ActionResult Index()
        {
            var user = User.Identity;
            ApplicationDbContext context = new ApplicationDbContext();
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            ApplicationUser currentUser = UserManager.FindById(User.Identity.GetUserId());
            if (currentUser != null)
            {
                ViewBag.RoleType = currentUser.role;

            }
            else
            {
                return View();
            }
            var vessels = db.Vessels.Include(v => v.Customer).Include(v => v.Schedule);
            return View(vessels.ToList());
        }

        // GET: Vessels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vessel vessel = db.Vessels.Find(id);
            if (vessel == null)
            {
                return HttpNotFound();
            }
            return View(vessel);
        }

        // GET: Vessels/Create
        public ActionResult Create()
        {
            ViewBag.vesselCustomer = new SelectList(db.Customers, "customerID", "customerName");
            ViewBag.vesselScheduleID = new SelectList(db.Schedules, "scheduleID", "sailingRoute");
            return View();
        }

        // POST: Vessels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "vesselID,vesselScheduleID,vesselType,vesselSize,vesselName,vesselApproval,vesselCustomer,vesselAgent")] Vessel vessel)
        {
            if (ModelState.IsValid)
            {
                db.Vessels.Add(vessel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.vesselCustomer = new SelectList(db.Customers, "customerID", "customerName", vessel.vesselCustomer);
            ViewBag.vesselScheduleID = new SelectList(db.Schedules, "scheduleID", "sailingRoute", vessel.vesselScheduleID);
            return View(vessel);
        }

        // GET: Vessels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vessel vessel = db.Vessels.Find(id);
            if (vessel == null)
            {
                return HttpNotFound();
            }
            ViewBag.vesselCustomer = new SelectList(db.Customers, "customerID", "customerName", vessel.vesselCustomer);
            ViewBag.vesselScheduleID = new SelectList(db.Schedules, "scheduleID", "sailingRoute", vessel.vesselScheduleID);
            return View(vessel);
        }

        // POST: Vessels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "vesselID,vesselScheduleID,vesselType,vesselSize,vesselName,vesselApproval,vesselCustomer,vesselAgent")] Vessel vessel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vessel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.vesselCustomer = new SelectList(db.Customers, "customerID", "customerName", vessel.vesselCustomer);
            ViewBag.vesselScheduleID = new SelectList(db.Schedules, "scheduleID", "sailingRoute", vessel.vesselScheduleID);
            return View(vessel);
        }

        // GET: Vessels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vessel vessel = db.Vessels.Find(id);
            if (vessel == null)
            {
                return HttpNotFound();
            }
            return View(vessel);
        }

        // POST: Vessels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vessel vessel = db.Vessels.Find(id);
            db.Vessels.Remove(vessel);
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
