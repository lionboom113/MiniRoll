using Microsoft.Practices.Unity;
using Template.Domain.Models;
using Template.Web.Services;

namespace Template.Domain.UseCases
{
    /// <summary>
    /// <para>ユーザーの認可を表すユースケース.</para>
    /// </summary>
    public class Authentication
    {
        public IAuthService AuthSvc { get; set; }

        public Authentication(IAuthService authSvc)
        {
            AuthSvc = authSvc;
        }

        public AuthenticateResultModel Login(AuthenticateChallengeModel model)
        {
            return AuthSvc.Authenticate(model);
        }

        public void Logout()
        {
            AuthSvc.Logout();
        }
    }
}