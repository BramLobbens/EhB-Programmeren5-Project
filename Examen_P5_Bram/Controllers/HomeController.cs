using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Examen_P5_Bram.Controllers
{
    public class HomeController : ApplicationController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Examen Programmeren 5";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ChangeLanguage(string id)
        {
            Session["Language"] = Language.LanguageDictionary[id];

            // Als de gebruiker aangemeld is:  Wijzig ook de gebruikers-taal!
            if (User.Identity.IsAuthenticated)
            {
                DB_Examen_P5_BramEntities db = new DB_Examen_P5_BramEntities();
                AspNetUser user = db.AspNetUsers.First(u => u.UserName == User.Identity.Name);
                user.LanguageId = id;
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Redirect(Session["LastUrl"].ToString());
        }
    }
}