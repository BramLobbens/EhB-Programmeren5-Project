using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Examen_P5_Bram
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            General.Initialise();
        }

        protected void Session_Start()
        {
            Session["LastUrl"] = Session["Url"] = Request.Url.AbsoluteUri;
            Session["Language"] = null;

            // Use System language id
            string languageId = Request.UserLanguages[0].Substring(0, 2);
            try 
            { 
                Session["Language"] = Language.LanguageDictionary[languageId]; 
            }
            catch 
            { 
                Session["Language"] = Language.LanguageDictionary["en"]; 
            }

            // Use User language id
            if (User.Identity.IsAuthenticated)
            {
                DB_Examen_P5_BramEntities db = new DB_Examen_P5_BramEntities();
                AspNetUser user = db.AspNetUsers.First(u => u.UserName == User.Identity.Name);
                Session["Language"] = Language.LanguageDictionary[user.LanguageId];
            }

            // Default
            if (Session["Language"] == null)
            {
                Session["Language"] = Language.LanguageDictionary["en"];
            }
        }
    }
}
