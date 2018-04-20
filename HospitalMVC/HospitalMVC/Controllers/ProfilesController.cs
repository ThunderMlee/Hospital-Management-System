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
    public class ProfilesController : Controller
    {
        private HospitalDBEntities db = new HospitalDBEntities();

        // GET: Profiles
        public ActionResult PatientIndex()
        {
            return View(db.Profiles.ToList().Where(patient => patient.IsDoctor.Contains("NO") && patient.IsAdmin.Contains("NO")));
        }

        public ActionResult DoctorIndex()
        {
            return View(db.Profiles.ToList().Where(doc => doc.IsDoctor.Contains("YES") && doc.IsAdmin.Contains("NO")));
        }

        // GET: Profiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.Profiles.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        // GET: Profiles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IsAdmin,IsDoctor,FirstName,LastName,Age,Gender,Email,Password,Status")] Profile profile)
        {
            if (ModelState.IsValid)
            {
                db.Profiles.Add(profile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(profile);
        }

        // GET: Profiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.Profiles.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        // POST: Profiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IsAdmin,IsDoctor,FirstName,LastName,Age,Gender,Email,Password,Status")] Profile profile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(profile);
        }

        // GET: Profiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.Profiles.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        // POST: Profiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Profile profile = db.Profiles.Find(id);
            db.Profiles.Remove(profile);
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

        public bool confirmLogin(string[] credentials)
        {
            List<Profile> list = db.Profiles.ToList();

            try
            {
                Profile profile = list.Find(prof => prof.Email.Contains(credentials[0]) && prof.Password.Contains(credentials[1]));

                Session["Id"] = profile.Id;
                Session["Name"] = profile.FirstName + " " + profile.LastName;

                switch (profile.IsAdmin)
                {
                    case "YES":
                        Session["Role"] = "ADMIN";
                        break;
                    case "NO":
                        if (profile.IsDoctor.Contains("YES"))
                        {
                            Session["Role"] = "DOCTOR";
                        }
                        else if (profile.IsDoctor.Contains("NO"))
                        {
                            Session["Role"] = "USER";
                        }
                        break;
                    default:
                        break;
                }

                return true;
            }
            catch (ArgumentNullException e)
            {
                return false;
            }
        }

    }
}
