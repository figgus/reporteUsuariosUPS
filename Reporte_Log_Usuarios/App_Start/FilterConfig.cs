using System.Web;
using System.Web.Mvc;

namespace Reporte_Log_Usuarios
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}