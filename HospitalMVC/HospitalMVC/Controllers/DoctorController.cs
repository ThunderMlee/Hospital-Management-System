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
        private Database1Entities db = new Database1Entities();

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
            doctorTbl doctor = db.doctorTbls.Find(Id);
            return View(doctor);
        }
        [HttpPost]
        public ActionResult EditDoctorProfile(doctorTbl doctor)
        {
            db.Entry(doctor).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index", new { id = Session["userID"] });
        }

        //Discharge patient
        [HttpGet]
        public ActionResult Discharge(int? Id)
        {
            patientTbl patient = db.patientTbls.Find(Id);
            return View(patient);
        }
        [HttpPost]
        public ActionResult Discharge(patientTbl patient1)
        {
            patientTbl patient = db.patientTbls.Find(patient1.Id);
            patient.discharged = patient1.discharged;
            db.Entry(patient).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index", new { id = Session["userID"] });
        }

    }
}