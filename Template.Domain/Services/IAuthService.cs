using Template.Domain.Models;

namespace Template.Web.Services
{
    /// <summary>
    /// <para>ユーザー認証用interface</para>
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// <para>ユーザーのログイン認証を行う.</para>
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        AuthenticateResultModel Authenticate(AuthenticateChallengeModel model);
        /// <summary>
        /// <para>サインアウト処理</para>
        /// </summary>
        /// <returns></returns>
        void Logout();
        /// <summary>
        /// <para>ユーザーが特定部門の特定Actionへアクセス可能かどうかを取得する.</para>
        /// </summary>
        /// <param name="challengeModel"></param>
        /// <returns></returns>
        AuthorizeResultModel Authorize(AuthorizeChallengeModel model);
    }
}
