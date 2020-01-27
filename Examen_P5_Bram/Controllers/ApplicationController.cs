using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Examen_P5_Bram.Controllers
{
    public class ApplicationController : Controller
    {
        // GET: Application
        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            Language sessionLanguage = (Language)Session["Language"];
            string cultureId = Request.UserLanguages[0];
            cultureId = sessionLanguage.Id + cultureId.Substring(2, cultureId.Length - 2);
            CultureInfo culture = null;
            try { culture = new CultureInfo(cultureId); }
            catch { culture = new CultureInfo(sessionLanguage.Id); }
            Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture = culture;

            Session["LastUrl"] = Session["Url"].ToString();
            String myUrl = Request.Url.AbsoluteUri;
            Session["Url"] = myUrl;

            // Voeg de nodige elementen toe aan de ViewBag

            ViewBag.isAjax = false;

            return base.BeginExecuteCore(callback, state);
        }
    }
}