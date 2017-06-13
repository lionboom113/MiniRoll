using Microsoft.Practices.Unity;
using System.Web.Mvc;
using Template.Domain.Models;
using Template.Domain.Orm;
using Template.Domain.UseCases;
using Template.Web.Auth;

namespace Template.Web.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        [Dependency]
        public Authentication Authentication { get; set; }

        // GET: Auth/Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        // POST: Auth/Login
        [HttpPost]
        public ActionResult Login(AuthenticateChallengeModel model)
        {
            if (ModelState.IsValid && Authentication.Login(model).IsSuccess)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        // GET: Auth/Logout
        [HttpGet]
        public ActionResult Logout()
        {
            Authentication.Logout();
            return RedirectToAction(Definitions.Auth.LOGIN_ACTION, Definitions.Auth.AUTH_CONTROLLER);
        }
    }
}