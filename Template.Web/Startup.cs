using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

[assembly: OwinStartupAttribute(typeof(Template.Web.Startup))]
namespace Template.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                ExpireTimeSpan = Definitions.Auth.COOKIE_AUTHENTICATE_TIME,
                LoginPath = new PathString(Definitions.Auth.LOGIN_PATH),
                LogoutPath = new PathString(Definitions.Auth.LOGOUT_PATH),
            });
        }
    }
}