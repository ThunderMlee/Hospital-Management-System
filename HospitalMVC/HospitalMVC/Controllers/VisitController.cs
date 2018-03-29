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
		VisitContext dbv = new VisitContext();

		public Visit visit { get; private set; }

		// Display visits according to session userId
		
		public ActionResult Index(string searchBy, string search)
        {
			int id = (int)Session["userId"];
			if (id > 999)
			{
				if (searchBy == "Id")
				{
					int identify = Convert.ToInt32(search);
					return View(dbv.Visits.Where(d => (d.patientId == id) &&
					(d.doctorId == identify || search == null)).ToList());
				}
				else
				{
					return View(dbv.Visits.Where(d => (d.patientId == id) &&
					(d.details.Contains(search) || search == null)).ToList());
				}
			}
			else
			{
				if (searchBy == "Id")
				{
					int identify = Convert.ToInt32(search);
					return View(dbv.Visits.Where(d => (d.doctorId == id) &&
					(d.patientId == identify || search == null)).ToList());
				}
				else
				{
					return View(dbv.Visits.Where(d => (d.doctorId == id) &&
					(d.details.Contains(search) || search == null)).ToList());
				}
				
			}
			
		}

		//Editing visits
		[HttpGet]
		public ActionResult Edit(int Id)
		{
			Visit visit  = dbv.Visits.Find(Id);
			return View(visit);
		}
		[HttpPost]
		public ActionResult Edit(Visit visit)
		{
			dbv.Entry(visit).State = System.Data.Entity.EntityState.Modified;
			dbv.SaveChanges();

			return RedirectToAction("Index", new { id = Session["userID"] });
		}

		[HttpGet]
		public ActionResult Delete(int Id)
		{
			Visit visit = dbv.Visits.Find(Id);
			return View(visit);
		}
		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirmed(int Id)
		{
			Visit visit = dbv.Visits.Find(Id);
			dbv.Visits.Remove(visit);
			dbv.SaveChanges();
			return RedirectToAction("Index", new { id = Session["userID"] });
		}

		[HttpGet]
		public ActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public ActionResult Create(Visit visit)
		{
			//insert into table

			//ContextClass db= new ContextClass();
			dbv.Visits.Add(visit);
			dbv.SaveChanges();

			return RedirectToAction("Index", new { id = Session["userID"] });
		}
	}
}