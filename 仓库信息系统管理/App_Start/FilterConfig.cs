using System.Web;
using System.Web.Mvc;

namespace 仓库信息系统管理
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}