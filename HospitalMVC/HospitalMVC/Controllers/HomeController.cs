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
        private Database1Entities db = new Database1Entities();

        //GET Home
        public ActionResult Home()
        {
            return View();
        }
        //GET Admin Index
        public ActionResult AdminIndex()
        {
            return View();
        }

        // GET: Doctor
        public ActionResult IndexDoc()
        {
            return View(db.doctorTbls.ToList());
        }

        [HttpGet]
        public ActionResult AddDoctor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddDoctor(doctorTbl doctor)
        {
            //insert into table
            db.doctorTbls.Add(doctor);
            db.SaveChanges();

            return RedirectToAction("IndexDoc");
        }


        //GET Patient
        public ActionResult IndexPat()
        {
            return View(db.patientTbls.ToList());
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
        public ActionResult CreatePatient(patientTbl patient)
        {
            patient.discharged = "No";
            db.patientTbls.Add(patient);
            db.SaveChanges();

            return RedirectToAction("IndexPat");
        }

        /*public ActionResult Login(patientTbl patientModel)
        {
            if (Session["userId"] != null) return RedirectToAction("Index");

            patientTbl patientDetails = new patientTbl() { Id = -1 };
            if (patientModel.Id == 0 && patientModel.password == "admin") return RedirectToAction("AdminIndex");

            if (patientModel.Id > 999)
            {
                patientDetails = db.patientTbls.Where(x => x.Id == patientModel.Id && x.password == patientModel.password).FirstOrDefault();

                if (patientDetails != null)
                {
                    Session["userID"] = patientDetails.Id;
                    Session["role"] = "Patient";
                    return RedirectToAction("Index", "Patient");
                }
            }
            return View("Login", patientModel);
        }*/

        public ActionResult Login(doctorTbl doctorModel)
        {
            if (Session["userId"] != null) return RedirectToAction("Index");

            doctorTbl doctorDetails = new doctorTbl() { Id = -1 };
            if (doctorModel.Id == 0 && doctorModel.password == "admin") return RedirectToAction("AdminIndex");

            
            if (doctorModel.Id > 0)
            {
                doctorDetails = db.doctorTbls.Where(x => x.Id == doctorModel.Id && x.password == doctorModel.password).FirstOrDefault();
                if (doctorDetails != null)
                {
                    Session["userID"] = doctorDetails.Id;
                    Session["role"] = "Doctor";
                    return RedirectToAction("Index", "Doctor");
                }
                
            }

            return View("Login", doctorModel);
        }

        public ActionResult Logout()
        {
            Session.Remove("userId");
            Session.Remove("role");

            return RedirectToAction("Home");
        }

        //EDIT Doctor
        public ActionResult EditDoctor(int Id)
        {
            doctorTbl doctor = db.doctorTbls.Find(Id);
            return View(doctor);
        }
        [HttpPost]
        public ActionResult EditDoctor(doctorTbl doctor)
        {
            db.Entry(doctor).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("IndexDoc");
        }

        //DELETE Doctor
        [HttpGet]
        public ActionResult DeleteDoctor(int Id)
        {
            doctorTbl doctor = db.doctorTbls.Find(Id);
            return View(doctor);
        }
        [HttpPost, ActionName("DeleteDoctor")]
        public ActionResult DeleteConfirmed(int Id)
        {
            doctorTbl doctor = db.doctorTbls.Find(Id);
            db.doctorTbls.Remove(doctor);
            db.SaveChanges();
            return RedirectToAction("IndexDoc");
        }

        //EDIT Patient
        public ActionResult EditPatient(int Id)
        {
            patientTbl patient = db.patientTbls.Find(Id);
            return View(patient);
        }
        [HttpPost]
        public ActionResult EditPatient(patientTbl patient)
        {
            db.Entry(patient).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("IndexPat");
        }

        //DELETE Patient
        [HttpGet]
        public ActionResult DeletePatient(int Id)
        {
            patientTbl patient = db.patientTbls.Find(Id);
            return View(patient);
        }

        [HttpPost, ActionName("DeletePatient")]
        public ActionResult DeletePConfirmed(int Id)
        {
            patientTbl patient = db.patientTbls.Find(Id);
            db.patientTbls.Remove(patient);
            db.SaveChanges();
            return RedirectToAction("IndexPat");
        }

    }
}