using System;
using System.Linq;
using System.Web;
using Template.Domain.Entities;
using Microsoft.AspNet.Identity;
using Template.Domain.Models;
using Microsoft.Practices.Unity;
using Template.Domain.Orm;

namespace Template.Web.Services
{
    /// <summary>
    /// 認可、認証用サービスの実装部
    /// </summary>
    public class TemplateAuthService : IAuthService
    {
        [Dependency]
        public TemplateDbContext DbContext { get; set; }

        /// <summary>
        /// ASP.NET Identityのユーザー管理クラス
        /// ※DIしている為、コンテナから取得可能
        /// </summary>
        private UserManager<User, Guid> UserMng { get; set; }

        public TemplateAuthService(UserManager<User, Guid> userMng)
        {
            UserMng = userMng;
        }

        /// <summary>
        /// <para>ユーザーの認可判定.</para>
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public AuthenticateResultModel Authenticate(AuthenticateChallengeModel model)
        {
            bool result = false;
            var user = UserMng.FindAsync(model.UserName, model.Password).Result;
            if (user != null)
            {
                var identity = UserMng.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie).Result;
                HttpContext.Current.GetOwinContext().Authentication.SignIn(identity);
                result = true;
            }
            return AuthenticateResultModel.Create(model, result);
        }

        public void Logout()
        {
            HttpContext.Current.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }

        public AuthorizeResultModel Authorize(AuthorizeChallengeModel model)
        {
            bool result = false;
            var user = DbContext.Users.FirstOrDefault(e => e.UserName == model.UserName);
            if (user != null)
            {
                //Roleに拡張性を持たせる為、IRoleStoreの実装ではなく、独自で行う
                result = user.IsInRole(model.Controller, model.Action);
            }
            return AuthorizeResultModel.Create(model, result);
        }
    }
}