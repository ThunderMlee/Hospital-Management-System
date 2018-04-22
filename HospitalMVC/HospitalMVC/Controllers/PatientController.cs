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
    public class PatientController : Controller
    {
        private PatientContext dbp = new PatientContext();

        // GET: Patient
        public ActionResult Index()
        {
            if (Session["role"].Equals("Doctor")) return RedirectToAction("Index", "Doctor");

            return View();
        }

		// POST:  GET: Patient/Edit
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpGet]
		public ActionResult EditPatient(int Id)
		{
			Patient patient = dbp.Patients.Find(Id);
			return View(patient);
		}
		[HttpPost]
		public ActionResult EditPatient(Patient patient)
		{
			dbp.Entry(patient).State = System.Data.Entity.EntityState.Modified;
			dbp.SaveChanges();

			return RedirectToAction("Index", new { id = Session["userID"] });
		}
		
	}
}