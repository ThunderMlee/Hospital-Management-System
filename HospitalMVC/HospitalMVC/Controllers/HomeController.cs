using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HospitalMVC.Models;

namespace HospitalMVC.Controllers
{
    public class HomeController : Controller
    {
        DoctorContext db = new DoctorContext();
        PatientContext dbp = new PatientContext();

		//GET general Index
		public ActionResult Index()
        {
            return View();
        }
        //GET admin Index
        public ActionResult AdminIndex()
        {
            return View();
        }
     
        // GET: Doctor
        public ActionResult IndexDoc()
        {
            return View(db.Doctors.ToList());
        }

        [HttpGet]
        public ActionResult AddDoctor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddDoctor(Doctor doctor)
        {
            //insert into table
            db.Doctors.Add(doctor);
            db.SaveChanges();

            return RedirectToAction("IndexDoc");
        }


        //GET Patient
        public ActionResult IndexPat()
        {
            return View(dbp.Patients.ToList());
        }


        // GET: Patient/Create
        public ActionResult CreatePatient()
        {
            return View();
        }

        // POST: Patient/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult CreatePatient(Patient patient)
        {
			patient.discharged = "No";
            dbp.Patients.Add(patient);
            dbp.SaveChanges();

            return RedirectToAction("IndexPat");
        }

		public ActionResult Login(User userModel)
		{
			User userDetails = new User() { Id = -1 };
			if(userModel.Id == 0 && userModel.password == "admin") return RedirectToAction("AdminIndex");
			if (userModel.Id > 999)
			{
				using (PatientContext dbp = new PatientContext())
				{
					userDetails = dbp.Patients.Where(x => x.Id == userModel.Id && x.password == userModel.password).FirstOrDefault();
				
					if (userDetails != null)
					{
						Session["userID"] = userDetails.Id;
						return RedirectToAction("Index", "Patient");
					}
				}
			}
			if (userModel.Id > 0)
			{
				using (DoctorContext db = new DoctorContext())
				{
					userDetails = db.Doctors.Where(x => x.Id == userModel.Id && x.password == userModel.password).FirstOrDefault();
					if (userDetails != null)
					{
						Session["userID"] = userDetails.Id;
						return RedirectToAction("Index", "Doctor");
					}
				}
			}
			return View("Login", userModel);
			
		}

		//edit doctor
		public ActionResult EditDoctor(int Id)
		{
			Doctor doctor = db.Doctors.Find(Id);
			return View(doctor);
		}
		[HttpPost]
		public ActionResult EditDoctor(Doctor doctor)
		{
			db.Entry(doctor).State = System.Data.Entity.EntityState.Modified;
			db.SaveChanges();

			return RedirectToAction("IndexDoc");
		}

		//delete doctor
		[HttpGet]
		public ActionResult DeleteDoctor(int Id)
		{
			Doctor doctor = db.Doctors.Find(Id);
			return View(doctor);
		}
		[HttpPost, ActionName("DeleteDoctor")]
		public ActionResult DeleteConfirmed(int Id)
		{
			Doctor doctor = db.Doctors.Find(Id);
			db.Doctors.Remove(doctor);
			db.SaveChanges();
			return RedirectToAction("IndexDoc");
		}

		//edit patient
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

			return RedirectToAction("IndexPat");
		}

		//delete patient
		[HttpGet]
		public ActionResult DeletePatient(int Id)
		{
			Patient patient = dbp.Patients.Find(Id);
			return View(patient);
		}

		[HttpPost, ActionName("DeletePatient")]
		public ActionResult DeletePConfirmed(int Id)
		{
			Patient patient = dbp.Patients.Find(Id);
			dbp.Patients.Remove(patient);
			dbp.SaveChanges();
			return RedirectToAction("IndexPat");
		}

	}
}