using System.Web.Mvc;
using Template.Web.Auth;

namespace Template.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            //認証用属性の追加
            //※デフォルトで追加された状態なので、適用したくないAction、またはControllerにはAllowAnonymous属性を追加する
            filters.Add(new AuthorizeAttribute());
            filters.Add(new TemplateAuthorizeAttribute());
        }
    }
}
