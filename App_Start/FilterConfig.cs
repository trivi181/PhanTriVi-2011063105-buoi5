using System.Web;
using System.Web.Mvc;

namespace PhanTriVi_2011063105_buoi5
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
