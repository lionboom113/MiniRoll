using System;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Template.Domain.Exceptions;
using Template.Domain.Services;
using Template.Web.Exceptions;
using Template.Web.Models;

namespace Template.Web
{
    public class MvcApplication : AbstractGlobal
    {
        protected override void MyApplication_Start(object sender, EventArgs e)
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            UnityConfig.RegisterComponents();
        }

        protected override void MyApplication_BeginRequest(object sender, EventArgs e)
        {
        }

        protected override void MyApplication_EndRequest(object sender, EventArgs e)
        {
        }

        protected override void MyApplication_Error(object sender, EventArgs e)
        {
        }
    }

    /// <summary>
    /// Global.asax 基底クラス
    /// </summary>
    public abstract class AbstractGlobal : HttpApplication
    {
        /// <summary>
        /// アプリケーション開始時の処理（サブクラス用）
        /// </summary>
        /// <param name="sender">イベントセンダー</param>
        /// <param name="e">イベント引数</param>
        protected abstract void MyApplication_Start(object sender, EventArgs e);


        /// <summary>
        /// リクエスト開始時の処理（サブクラス用）
        /// </summary>
        /// <param name="sender">イベントセンダー</param>
        /// <param name="e">イベント引数</param>
        protected abstract void MyApplication_BeginRequest(object sender, EventArgs e);


        /// <summary>
        /// リクエスト終了時の処理（サブクラス用）
        /// </summary>
        /// <param name="sender">イベントセンダー</param>
        /// <param name="e">イベント引数</param>
        protected abstract void MyApplication_EndRequest(object sender, EventArgs e);

        /// <summary>
        /// 集約エラーハンドラ（サブクラス用）
        /// </summary>
        /// <param name="sender">イベントセンダー</param>
        /// <param name="e">イベント引数</param>
        protected abstract void MyApplication_Error(object sender, EventArgs e);

        /// <summary>
        /// アプリケーション開始時の処理
        /// </summary>
        /// <param name="sender">イベントセンダー</param>
        /// <param name="e">イベント引数</param>
        protected void Application_Start(object sender, EventArgs e)
        {
            //Logger.TargetApplication = Logger.TargetApplicationType.Web;

            this.MyApplication_Start(sender, e);
        }

        /// <summary>
        /// リクエスト開始時の処理
        /// </summary>
        /// <param name="sender">イベントセンダー</param>
        /// <param name="e">イベント引数</param>
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            //LogContext.StartContext(LogContext.ContextType.Web);

            this.MyApplication_BeginRequest(sender, e);
        }
        /// <summary>
        /// リクエスト終了時の処理
        /// </summary>
        /// <param name="sender">イベントセンダー</param>
        /// <param name="e">イベント引数</param>
        protected void Application_EndRequest(object sender, EventArgs e)
        {
            this.MyApplication_EndRequest(sender, e);
        }

        /// <summary>
        /// 集約エラー
        /// </summary>
        /// <param name="sender">イベントセンダー</param>
        /// <param name="e">イベント引数</param>
        protected void Application_Error(object sender, EventArgs e)
        {
            this.MyApplication_Error(sender, e);

            var ex = Server.GetLastError();
            if (ex == null) return;

            var messageSvc = DI.Container.Resolve<MessageService>();
            ErrorModel model = null;
            //認証エラー
            model = ErrorModel.Create(messageSvc, GetException<TemplateAuthorizeException>(ex));
            if (model == null)
            {
                //検証エラー
                model = ErrorModel.Create(messageSvc, GetException<TemplateValidationException>(ex));
            }
            if (!string.IsNullOrEmpty(model?.Controller))
            {
                Response.RedirectToRoute(model);
            }
            if (model != null)
            {
                Server.ClearError();
            }
        }
        private TException GetException<TException>(Exception e) where TException : Exception
        {
            if (e is TException)
            {
                return (TException)e;
            }
            else if (e.InnerException != null)
            {
                return GetException<TException>(e.InnerException);
            }
            return null;
        }
        private void BuildStackTraceString(Exception exception, StringBuilder builder)
        {
            builder.AppendLine($"{exception.GetType().ToString()}：{exception.Message}");
            builder.AppendLine(exception.StackTrace);

            if (exception.InnerException == null)
            {
                return;
            }
            else
            {
                BuildStackTraceString(exception.InnerException, builder);
            }
        }
    }
}
