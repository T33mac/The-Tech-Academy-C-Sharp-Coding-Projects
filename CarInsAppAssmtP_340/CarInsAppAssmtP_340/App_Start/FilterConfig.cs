using System.Web;
using System.Web.Mvc;

namespace CarInsAppAssmtP_340
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
