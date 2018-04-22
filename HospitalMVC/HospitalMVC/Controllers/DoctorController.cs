using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HospitalMVC.Models;
using System.Data.Entity;
using System.Net;

namespace HospitalMVC.Controllers
{
    public class DoctorController : Controller
    {
        DoctorContext db = new DoctorContext();
        PatientContext dbp = new PatientContext();

		// GET: Doctor Index
		public ActionResult Index()
        {
            if (Session["role"].Equals("Patient")) return RedirectToAction("Index", "Patient");

            return View();
        }
		//Edit doctor information
        [HttpGet]
        public ActionResult EditDoctorProfile(int Id)
        {
            Doctor doctor = db.Doctors.Find(Id);
            return View(doctor);
        }
        [HttpPost]
        public ActionResult EditDoctorProfile(Doctor doctor)
        {
            db.Entry(doctor).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index", new { id = Session["userID"] });
        }

		//Discharge patient
		[HttpGet]
		public ActionResult Discharge(int? Id)
		{
			Patient patient = dbp.Patients.Find(Id);
			return View(patient);
		}
		[HttpPost]
		public ActionResult Discharge(Patient patient1)
		{
			Patient patient = dbp.Patients.Find(patient1.Id);
			patient.discharged = patient1.discharged;
			dbp.Entry(patient).State = System.Data.Entity.EntityState.Modified;
			dbp.SaveChanges();

			return RedirectToAction("Index", new { id = Session["userID"] });
		}

	}
}