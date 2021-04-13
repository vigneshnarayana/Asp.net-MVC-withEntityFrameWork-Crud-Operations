using System.Web;
using System.Web.Mvc;

namespace Mvc_linq_to_sql_SP_Crud
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
