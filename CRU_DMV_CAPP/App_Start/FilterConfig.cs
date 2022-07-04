using System.Web;
using System.Web.Mvc;

namespace CRU_DMV_CAPP
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
