using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examen_P5_Bram
{
    public class General
    {
        public static void Initialise()
        {
            DB_Examen_P5_BramEntities db = new DB_Examen_P5_BramEntities();

            // Initialise Languages
            Language.AllLanguages = db.Languages.OrderBy(lang => lang.Name).ToList();
            Language.Languages = Language.AllLanguages.Where(lang => lang.SystemLanguage).ToList();
            Language.LanguageDictionary = new Dictionary<string, Language>();
            foreach (Language lan in Language.AllLanguages)
            {
                Language.LanguageDictionary[lan.Id] = lan;
            }
        }
    }
}