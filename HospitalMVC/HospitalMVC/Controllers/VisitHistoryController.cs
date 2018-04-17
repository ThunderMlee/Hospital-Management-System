using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HospitalMVC.Models;

namespace HospitalMVC.Controllers
{
    public class VisitHistoryController : Controller
    {
        private HospitalDBEntities db = new HospitalDBEntities();

        // GET: VisitHistory
        public ActionResult Index()
        {
            var visitHistories = db.VisitHistories.Include(v => v.Profile);
            return View(visitHistories.ToList());
        }

        // GET: VisitHistory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VisitHistory visitHistory = db.VisitHistories.Find(id);
            if (visitHistory == null)
            {
                return HttpNotFound();
            }
            return View(visitHistory);
        }

        // GET: VisitHistory/Create
        public ActionResult Create()
        {
            ViewBag.PatientId = new SelectList(db.Profiles, "Id", "IsAdmin");
            return View();
        }

        // POST: VisitHistory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PatientId,FirstName,LastName,Reason,Date")] VisitHistory visitHistory)
        {
            if (ModelState.IsValid)
            {
                db.VisitHistories.Add(visitHistory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PatientId = new SelectList(db.Profiles, "Id", "IsAdmin", visitHistory.PatientId);
            return View(visitHistory);
        }

        // GET: VisitHistory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VisitHistory visitHistory = db.VisitHistories.Find(id);
            if (visitHistory == null)
            {
                return HttpNotFound();
            }
            ViewBag.PatientId = new SelectList(db.Profiles, "Id", "IsAdmin", visitHistory.PatientId);
            return View(visitHistory);
        }

        // POST: VisitHistory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PatientId,FirstName,LastName,Reason,Date")] VisitHistory visitHistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(visitHistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PatientId = new SelectList(db.Profiles, "Id", "IsAdmin", visitHistory.PatientId);
            return View(visitHistory);
        }

        // GET: VisitHistory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VisitHistory visitHistory = db.VisitHistories.Find(id);
            if (visitHistory == null)
            {
                return HttpNotFound();
            }
            return View(visitHistory);
        }

        // POST: VisitHistory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VisitHistory visitHistory = db.VisitHistories.Find(id);
            db.VisitHistories.Remove(visitHistory);
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
