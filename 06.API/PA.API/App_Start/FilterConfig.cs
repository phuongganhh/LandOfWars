using System.Web;
using System.Web.Mvc;

namespace PA.API
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new Cors());
            filters.Add(new PAAuthorizeAttr());
            filters.Add(new HandleErrorAttribute());
        }
    }
}
