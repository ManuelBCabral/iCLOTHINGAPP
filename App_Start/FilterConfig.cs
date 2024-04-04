using System.Web;
using System.Web.Mvc;

namespace Group12_iCLOTHINGAPP
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
