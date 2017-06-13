using Microsoft.AspNet.Identity;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using Template.Domain.Entities;
using Template.Domain.Orm;
using Template.Domain.Definitions;
using Template.Domain.Exceptions;
using Template.Domain.Models;

namespace Template.Domain.UseCases
{
    /// <summary>
    /// <para>ユーザー管理を表すユースケース.</para>
    /// </summary>
    public class UserManagement
    {
        public TemplateDbContext DbContext { get; set; }
        public UserManager<User, Guid> UserMng { get; set; }

        public UserManagement(TemplateDbContext dbContext, UserManager<User, Guid> userMng)
        {
            DbContext = dbContext;
            UserMng = userMng;
        }

        /// <summary>
        /// 全データ取得処理
        /// </summary>
        /// <returns></returns>
        public UserListModel GetUserList()
        {
            return UserListModel.Create(DbContext.Users.ToList());
        }

        /// <summary>
        /// <para>新規ユーザーを登録します.</para>
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public UserCreateResultModel CreateUser(CreateUserModel model)
        {
            CreateResult result = CreateResult.Success;
            ValidationErrors validErrors = ValidationErrors.Create();
            string errorMessage = string.Empty;
            try
            {
                var user = model.CreateUser();
                var identityResult = UserMng.Create(user, model.Password);

                if (!identityResult.Succeeded)
                {
                    result = CreateResult.Failed;
                    errorMessage = CreateErrorMessage(identityResult.Errors);
                }
            }
            catch (TemplateValidationException e)
            {
                result = CreateResult.ValidError;
                validErrors = e.ValidErrors;
            }
            catch
            {
                result = CreateResult.Failed;
            }
            return UserCreateResultModel.Create(model, result, validErrors, errorMessage);
        }

        private string CreateErrorMessage(IEnumerable<string> errors)
        {
            return errors == null || errors.Count() == 0 ? string.Empty : string.Join("\r\n", errors);
        }
    }
}
