using System.Web;
using System.Web.Mvc;

namespace Examen_P5_Bram
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
