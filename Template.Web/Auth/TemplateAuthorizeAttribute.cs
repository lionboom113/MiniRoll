using System.Web.Mvc;
using Template.Domain.Models;
using Template.Web.Services;

namespace Template.Web.Auth
{
    public class TemplateAuthorizeAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            //ControllerまたはActionにAllowAnonymous属性が付与されているか確認
            var isAllowAnonymous = filterContext.Controller.GetType().IsDefined(typeof(AllowAnonymousAttribute), true)
                || filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true);

            if (!isAllowAnonymous && filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                var userName = filterContext.HttpContext.User.Identity.Name;
                var controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
                var action = filterContext.ActionDescriptor.ActionName;

                var authModel = AuthorizeChallengeModel.Create(userName, controller, action);
                var resultModel = DI.Container.Resolve<IAuthService>().Authorize(authModel);
                if (!resultModel.IsSuccess)
                {
                    filterContext.Result = new RedirectResult(Definitions.Auth.UNAUTHORIZE_REDIRECT_PATH);
                }
            }
        }
    }
}