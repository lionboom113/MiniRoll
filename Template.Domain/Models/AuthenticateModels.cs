using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Template.Domain.Models
{
    public class AuthenticateChallengeModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public class AuthenticateResultModel
    {
        public AuthenticateChallengeModel ChallengeModel { get; set; }
        public bool IsSuccess { get; set; }

        public static AuthenticateResultModel Create(AuthenticateChallengeModel model, bool isSuccess)
        {
            return new AuthenticateResultModel
            {
                ChallengeModel = model,
                IsSuccess = isSuccess,
            };
        }
    }
    public class AuthorizeChallengeModel
    {
        public string UserName { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }

        public static AuthorizeChallengeModel Create(string userName, string controller, string action)
        {
            return new AuthorizeChallengeModel
            {
                UserName = userName,
                Controller = controller,
                Action = string.IsNullOrEmpty(action) ? "Index" : action,
            };
        }
    }

    public class AuthorizeResultModel
    {
        public AuthorizeChallengeModel ChallengeModel { get; set; }
        public bool IsSuccess { get; set; }

        public static AuthorizeResultModel Create(AuthorizeChallengeModel model, bool isSuccess)
        {
            return new AuthorizeResultModel
            {
                ChallengeModel = model,
                IsSuccess = isSuccess,
            };
        }
    }
}