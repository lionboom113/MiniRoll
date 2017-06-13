using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Template.Domain.Entities;
using Template.Domain.Definitions;

namespace Template.Domain.Models
{
    public class UserListModel
    {
        public List<UserModel> Users { get; set; }

        public static UserListModel Create(ICollection<User> models)
        {
            return new UserListModel
            {
                Users = models?.Select(e => UserModel.Create(e)).ToList() ?? new List<UserModel>(),
            };
        }
    }

    public class UserModel
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }

        public static UserModel Create(User model)
        {
            return new UserModel
            {
                Id = model.Id,
                UserName = model.UserName,
            };
        }
    }

    public class CreateUserModel
    {
        [Required]
        public string UserName { get; set; }
        public string Password { get; set; }

        public User CreateUser()
        {
            return new User
            {
                UserName = UserName,
                Password = Password,
            };
        }
    }

    public class UserCreateResultModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public CreateResult Result { get; set; }
        public ValidationErrors ValidErrors { get; set; }
        public string ErrorMessage { get; set; }

        public static UserCreateResultModel Create(CreateUserModel model, CreateResult result, ValidationErrors errors = null, string errorMessage = null)
        {
            return new UserCreateResultModel
            {
                UserName = model.UserName,
                Password = model.Password,
                Result = result,
                ValidErrors = errors ?? ValidationErrors.Create(),
                ErrorMessage = errorMessage ?? string.Empty,
            };
        }
    }

    public class UpdateUserModel
    {
    }

    public class UserUpdateResultModel
    {
    }

    public class DeleteUserModel
    {
    }

    public class UserDeleteResultModel
    {
    }
}
