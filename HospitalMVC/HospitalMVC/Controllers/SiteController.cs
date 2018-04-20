using HospitalMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalMVC.Controllers
{
    public class SiteController : Controller
    {
        // GET: Site
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Search()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost, ActionName("tryLogin")]
        public ActionResult attemptLogin(string email, string pass)
        {
            ProfilesController proContr = new ProfilesController();

            string[] credentials = new string[2];
            credentials[0] = email;
            credentials[1] = pass;

            if (proContr.confirmLogin(credentials))
            {
                
                return RedirectToAction("Home");
            } else
            {
                return RedirectToAction("Login");
            }
            
        }
    }
}