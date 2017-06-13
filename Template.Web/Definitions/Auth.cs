using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Web.Definitions
{
    public static class Auth
    {
        /// <summary>
        /// <para>認可コントローラ名.</para>
        /// </summary>
        public static string AUTH_CONTROLLER = "Auth";
        /// <summary>
        /// <para>ログインアクション名.</para>
        /// </summary>
        public static string LOGIN_ACTION = "Login";
        /// <summary>
        /// <para>ログアウトアクション名.</para>
        /// </summary>
        public static string LOGOUT_ACTION = "Logout";
        /// <summary>
        /// <para>ログインパス.</para>
        /// </summary>
        public static string LOGIN_PATH = $"/{AUTH_CONTROLLER}/{LOGIN_ACTION}";
        /// <summary>
        /// <para>ログアウトパス.</para>
        /// </summary>
        public static string LOGOUT_PATH = $"/{AUTH_CONTROLLER}/{LOGOUT_ACTION}";

        /// <summary>
        /// <para>認証不正時コントローラ名.</para>
        /// </summary>
        public static string UNAUTHORIZE_CONTROLLER = "Home";
        /// <summary>
        /// <para>認証不正時アクション名.</para>
        /// </summary>
        public static string UNAUTHORIZE_ACTION = "Index";
        /// <summary>
        /// <para>認証不正時のリダイレクト先.</para>
        /// </summary>
        public static string UNAUTHORIZE_REDIRECT_PATH = $"/{UNAUTHORIZE_CONTROLLER}/{UNAUTHORIZE_ACTION}";

        /// <summary>
        /// <para>認証用Cookie有効期限.</para>
        /// </summary>
        public static TimeSpan COOKIE_AUTHENTICATE_TIME = TimeSpan.FromHours(1);
    }
}
