using HospitalMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalMVC.Controllers
{
    public class VisitController : Controller
    {
        private Database1Entities db = new Database1Entities();

        //public Visit visit { get; private set; }

        // Display visits according to session userId

        public ActionResult Index(string searchBy, string search)
        {
            int id = (int)Session["userId"];
            if (id > 999)
            {
                if (searchBy == "Id")
                {
                    int identify = Convert.ToInt32(search);
                    return View(db.visitTbls.Where(d => (d.patientId == id) &&
                    (d.doctorId == identify || search == null)).ToList());
                }
                else
                {
                    return View(db.visitTbls.Where(d => (d.patientId == id) &&
                    (d.details.Contains(search) || search == null)).ToList());
                }
            }
            else
            {
                if (searchBy == "Id")
                {
                    int identify = Convert.ToInt32(search);
                    return View(db.visitTbls.Where(d => (d.doctorId == id) &&
                    (d.patientId == identify || search == null)).ToList());
                }
                else
                {
                    return View(db.visitTbls.Where(d => (d.doctorId == id) &&
                    (d.details.Contains(search) || search == null)).ToList());
                }

            }

        }

        //Editing visits
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            visitTbl visit = db.visitTbls.Find(Id);
            return View(visit);
        }
        [HttpPost]
        public ActionResult Edit(visitTbl visit)
        {
            db.Entry(visit).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index", new { id = Session["userID"] });
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            visitTbl visit = db.visitTbls.Find(Id);
            return View(visit);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int Id)
        {
            visitTbl visit = db.visitTbls.Find(Id);
            db.visitTbls.Remove(visit);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = Session["userID"] });
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(visitTbl visit)
        {
            //insert into table

            //ContextClass db= new ContextClass();
            db.visitTbls.Add(visit);
            db.SaveChanges();

            return RedirectToAction("Index", new { id = Session["userID"] });
        }
    }
}