using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examen_P5_Bram
{
    public partial class Language
    {
        static public List<Language> AllLanguages { get; set; }
        static public List<Language> Languages { get; set; }
        static public Dictionary<string, Language> LanguageDictionary { get; set; }
    }
}