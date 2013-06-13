using System.Web;
using System.Web.Mvc;

namespace WebApi_BasicAuth_Filter
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}