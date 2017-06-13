using Microsoft.AspNet.Identity;
using Microsoft.Practices.Unity;
using System;
using System.Linq;
using System.Threading.Tasks;
using Template.Domain.Entities;
using Template.Domain.Orm;

namespace Template.Web.Auth
{
    /// <summary>
    /// <para>ユーザー、パスワード関連の管理を行うASP.NET Identity用のStore.</para>
    /// </summary>
    public class TemplateUserStore : IUserStore<User, Guid>, IUserPasswordStore<User, Guid>
    {
        [Dependency]
        public TemplateDbContext DbContext { get; set; }

        public Task CreateAsync(User user)
        {
            return Task.Run(() =>
            {
                DbContext.Users.Add(user);
                DbContext.SaveChanges();
            });
        }

        public Task DeleteAsync(User user)
        {
            return Task.Run(() =>
            {
                DbContext.Users.Remove(user);
                DbContext.SaveChanges();
            });
        }

        public Task<User> FindByIdAsync(Guid userId)
        {
            return Task.FromResult(DbContext.Users.FirstOrDefault(e => e.Id == userId));
        }

        public Task<User> FindByNameAsync(string userName)
        {
            return Task.FromResult(DbContext.Users.Where(e => e.UserName == userName).FirstOrDefault());
        }

        public Task UpdateAsync(User user)
        {
            return Task.Run(() =>
            {
                DbContext.Users.Remove(user);
                DbContext.Users.Add(user);
                DbContext.SaveChanges();
            });
        }

        public Task SetPasswordHashAsync(User user, string passwordHash)
        {
            return Task.Run(() => user.Password = passwordHash);
        }

        public Task<string> GetPasswordHashAsync(User user)
        {
            return Task.FromResult(user.Password);
        }

        public Task<bool> HasPasswordAsync(User user)
        {
            return Task.FromResult(true);
        }

        public void Dispose()
        {
            if (DbContext != null)
            {
                DbContext = null;
            }
        }
    }
}